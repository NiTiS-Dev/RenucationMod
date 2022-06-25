// The NiTiS-Dev licenses this file to you under the MIT license.
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Renucation.Common.Systems;
public class EnemyKillSystem : ModSystem
{
	private bool laboratoryUnlocked;
	private bool meteorsGenerated;
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
		tag.Set("meteorsGenerated", meteorsGenerated, true);
	}
	public override void LoadWorldData(TagCompound tag)
	{
		laboratoryUnlocked = tag.GetBool("renucationLaboratoryUnlocked");
		meteorsGenerated = tag.GetBool("meteorsGenerated");
	}
	public void GenerateMeteors()
	{
		if (meteorsGenerated)
			return;

		Worlds.RenucationWorld.MeteorGeneration();
		meteorsGenerated = true;
	}
	public void UnlockLaboratory()
	{
		if (laboratoryUnlocked)
			return;

		Main.NewText("The doors of the laboratory collapsed under the roar of a mechanical creature");
		laboratoryUnlocked = true;
	}
}
