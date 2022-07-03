// The NiTiS-Dev licenses this file to you under the MIT license.
namespace Renucation.Content.NPCs;
public abstract class WormTail : Worm
{
	public sealed override WormSegmentType SegmentType => WormSegmentType.Tail;

	internal override void BodyTailAI()
	{
		WormBody.CommonAI_BodyTail(this);
	}
}