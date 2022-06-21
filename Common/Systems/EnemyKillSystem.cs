// The NiTiS-Dev licenses this file to you under the MIT license.
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Renucation.Common.Systems;
public class EnemyKillSystem : ModSystem
{
	private byte oneOfEYEDefeated;
	private bool laboratoryUnlocked;
	public override void OnWorldLoad()
	{
		On.Terraria.NPC.DoDeathEvents += (a1, a2, a3) =>
		{
			if (a2.type is NPCID.SkeletronPrime or NPCID.TheDestroyer)
			{
				UnlockLaboratory();	
			}
			else if (a2.type is NPCID.Spazmatism or NPCID.Retinazer)
			{
				if (oneOfEYEDefeated == 1)
				{
					oneOfEYEDefeated = 2;
					UnlockLaboratory();
				}else
				{
					oneOfEYEDefeated = 1;
				}
			}
		};
	}
	public override void SaveWorldData(TagCompound tag)
	{
		tag.Set("renucationLaboratoryUnlocked", laboratoryUnlocked, true);
	}
	public override void LoadWorldData(TagCompound tag)
	{
		laboratoryUnlocked = tag.GetBool("renucationLaboratoryUnlocked");
	}
	public void UnlockLaboratory()
	{
		Main.NewText("The doors of the laboratory collapsed under the roar of a mechanical creature");
		laboratoryUnlocked = true;
	}
}
