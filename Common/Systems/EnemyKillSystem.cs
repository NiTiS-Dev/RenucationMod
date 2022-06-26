// The NiTiS-Dev licenses this file to you under the MIT license.
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Renucation.Common.Systems;
public class EnemyKillSystem : ModSystem
{
	private bool laboratoryUnlocked = false;
	private bool meteorsGenerated = false;
	public override void OnWorldLoad()
	{
		On.Terraria.NPC.DoDeathEvents_BeforeLoot += (a1, a2, a3) =>
		{
			if (a2.type is NPCID.SkeletronPrime or NPCID.TheDestroyer or NPCID.Spazmatism or NPCID.Retinazer)
				UnlockLaboratory();

			if (a2.type is NPCID.WallofFlesh)
			{
				GenerateMeteors();
			}
		};
	}
	public override void SaveWorldData(TagCompound tag)
	{
		tag.Set("renucationLaboratoryUnlocked", laboratoryUnlocked, true);
		tag.Set("meteorsGeneratedV2", meteorsGenerated, true);
	}
	public override void LoadWorldData(TagCompound tag)
	{
		laboratoryUnlocked = tag.GetBool("renucationLaboratoryUnlocked");
		meteorsGenerated = tag.GetBool("meteorsGeneratedV2");
	}
	public void GenerateMeteors()
	{
		if (meteorsGenerated)
			return;

		if (Worlds.RenucationWorld.MeteorGeneration())
			meteorsGenerated = true;
		else
			Main.NewText("Meteors disapear", 244, 10, 10);
	}
	public void UnlockLaboratory()
	{
		if (laboratoryUnlocked)
			return;

		

		Main.NewText(Language.GetTextValue("Mods.Renucation.WorldGen.Steps.LaboratoryOpen"), 128, 242, 225);
		laboratoryUnlocked = true;
	}
}
