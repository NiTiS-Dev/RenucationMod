// The NiTiS-Dev licenses this file to you under the MIT license.
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Renucation.Common.Systems;
public class EnemyKillSystem : ModSystem
{
	private bool laboratoryUnlocked;
	public override void OnWorldLoad()
	{
		On.Terraria.NPC.DoDeathEvents_BeforeLoot += (a1, a2, a3) =>
		{
			if (a2.type is NPCID.SkeletronPrime or NPCID.TheDestroyer or NPCID.Spazmatism or NPCID.Retinazer)
				UnlockLaboratory();
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
		if (laboratoryUnlocked)
			return;

		Main.NewText("The doors of the laboratory collapsed under the roar of a mechanical creature");
		laboratoryUnlocked = true;
	}
}
