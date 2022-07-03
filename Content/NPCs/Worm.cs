// The NiTiS-Dev licenses this file to you under the MIT license.

using Microsoft.Xna.Framework;

namespace Renucation.Content.NPCs;
public abstract class Worm : ModNPC
{
	/// <summary>
	/// Which type of segment this NPC is considered to be
	/// </summary>
	public abstract WormSegmentType SegmentType { get; }

	/// <summary>
	/// The maximum velocity for the NPC
	/// </summary>
	public float MoveSpeed { get; set; }

	/// <summary>
	/// The rate at which the NPC gains velocity
	/// </summary>
	public float Acceleration { get; set; }

	/// <summary>
	/// The NPC instance of the head segment for this worm.
	/// </summary>
	public NPC HeadSegment => Main.npc[NPC.realLife];

	/// <summary>
	/// The NPC instance of the segment that this segment is following (ai[1]).  For head segments, this property always returns <see langword="null"/>.
	/// </summary>
	public NPC FollowingNPC => SegmentType == WormSegmentType.Head ? null : Main.npc[(int)NPC.ai[1]];
	/// <summary>
	/// The NPC instance of the segment that is following this segment (ai[0]).  For tail segment, this property always returns <see langword="null"/>.
	/// </summary>
	public NPC FollowerNPC => SegmentType == WormSegmentType.Tail ? null : Main.npc[(int)NPC.ai[0]];
	public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
	{
		return SegmentType == WormSegmentType.Head ? null : false;
	}

	private bool startDespawning;

	public sealed override bool PreAI()
	{
		if (NPC.localAI[1] == 0)
		{
			NPC.localAI[1] = 1f;
			Init();
		}

		if (SegmentType == WormSegmentType.Head)
		{
			HeadAI();

			if (!NPC.HasValidTarget)
			{
				NPC.TargetClosest(true);

				// If the NPC is a boss and it has no target, force it to fall to the underworld quickly
				if (!NPC.HasValidTarget && NPC.boss)
				{
					NPC.velocity.Y += 8f;

					MoveSpeed = 1000f;

					if (!startDespawning)
					{
						startDespawning = true;

						// Despawn after 90 ticks (1.5 seconds) if the NPC gets far enough away
						NPC.timeLeft = 90;
					}
				}
			}
		}
		else
			BodyTailAI();

		return true;
	}

	internal virtual void HeadAI() { }

	internal virtual void BodyTailAI() { }

	public abstract void Init();
}
public enum WormSegmentType
{
	/// <summary>
	/// The head segment for the worm.  Only one "head" is considered to be active for any given worm
	/// </summary>
	Head,
	/// <summary>
	/// The body segment.  Follows the segment in front of it
	/// </summary>
	Body,
	/// <summary>
	/// The tail segment.  Has the same AI as the body segments.  Only one "tail" is considered to be active for any given worm
	/// </summary>
	Tail
}
