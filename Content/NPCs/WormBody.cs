// The NiTiS-Dev licenses this file to you under the MIT license.

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renucation.Content.NPCs;
public abstract class WormBody : Worm
{
	public sealed override WormSegmentType SegmentType => WormSegmentType.Body;

	internal override void BodyTailAI()
	{
		CommonAI_BodyTail(this);
	}

	internal static void CommonAI_BodyTail(Worm worm)
	{
		if (!worm.NPC.HasValidTarget)
			worm.NPC.TargetClosest(true);

		if (Main.player[worm.NPC.target].dead && worm.NPC.timeLeft > 30000)
			worm.NPC.timeLeft = 10;

		NPC following = worm.NPC.ai[1] >= Main.maxNPCs ? null : worm.FollowingNPC;
		if (Main.netMode != NetmodeID.MultiplayerClient)
		{
			// Some of these conditions are possble if the body/tail segment was spawned individually
			// Kill the segment if the segment NPC it's following is no longer valid
			if (following is null || !following.active || following.friendly || following.townNPC || following.lifeMax <= 5)
			{
				worm.NPC.life = 0;
				worm.NPC.HitEffect(0, 10);
				worm.NPC.active = false;
			}
		}

		if (following is not null)
		{
			// Follow behind the segment "in front" of this NPC
			// Use the current NPC.Center to calculate the direction towards the "parent NPC" of this NPC.
			float dirX = following.Center.X - worm.NPC.Center.X;
			float dirY = following.Center.Y - worm.NPC.Center.Y;
			// We then use Atan2 to get a correct rotation towards that parent NPC.
			// Assumes the sprite for the NPC points upward.  You might have to modify this line to properly account for your NPC's orientation
			worm.NPC.rotation = (float)Math.Atan2(dirY, dirX) + MathHelper.PiOver2;
			// We also get the length of the direction vector.
			float length = (float)Math.Sqrt(dirX * dirX + dirY * dirY);
			// We calculate a new, correct distance.
			float dist = (length - worm.NPC.width) / length;
			float posX = dirX * dist;
			float posY = dirY * dist;

			// Reset the velocity of this NPC, because we don't want it to move on its own
			worm.NPC.velocity = Vector2.Zero;
			// And set this NPCs position accordingly to that of this NPCs parent NPC.
			worm.NPC.position.X += posX;
			worm.NPC.position.Y += posY;
		}
	}
}
