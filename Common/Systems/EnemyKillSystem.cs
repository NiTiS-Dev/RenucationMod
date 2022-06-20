// The NiTiS-Dev licenses this file to you under the MIT license.
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Renucation.Common.Systems;
public class EnemyKillSystem : ModSystem
{
	public override void OnWorldLoad()
	{
		On.Terraria.NPC.DoDeathEvents += (a1, a2, a3) =>
		{
			Main.NewText("Enemy was killed " + a2.GivenOrTypeName);
			if (a2.type is NPCID.SkeletronPrime or NPCID.TheDestroyer or NPCID.Spazmatism or NPCID.Retinazer)
			{
				Main.NewText("The doors of the laboratory collapsed under the roar of a mechanical creature");
			}
		};
	}
	private void EnemyKill(object self, NPC sawBody, Player killer)
	{
		Main.NewText("Enemy was killed " + sawBody.GivenOrTypeName);
		if (sawBody.type is NPCID.SkeletronPrime or NPCID.TheDestroyer or NPCID.Spazmatism or NPCID.Retinazer)
		{
			Main.NewText("The doors of the laboratory collapsed under the roar of a mechanical creature");
		}
	}
	public override void OnWorldUnload()
	{
	}
}
