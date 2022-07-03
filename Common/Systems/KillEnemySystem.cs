// The NiTiS-Dev licenses this file to you under the MIT license.

using Terraria.DataStructures;

namespace Renucation.Common.Systems;
public class KillEnemySystem : GlobalNPC
{
	public override void OnKill(NPC npc)
	{
		WorldGenSystem sys = ModContent.GetInstance<WorldGenSystem>();
		if (npc.type is NPCID.SkeletronPrime or NPCID.TheDestroyer or NPCID.Spazmatism or NPCID.Retinazer)
			sys.UnlockLaboratory();

		if (npc.type is NPCID.WallofFlesh)
		{
			sys.GenerateMeteorBelt();
		}
	}
}
