// The NiTiS-Dev licenses this file to you under the MIT license.
using Terraria.ModLoader.IO;

namespace Renucation.Common.Systems;
public class WorldGenSystem : ModSystem
{
	private bool laboratoryUnlocked = false;
	private bool meteorsGenerated = false;
	public override void SaveWorldData(TagCompound tag)
	{
		tag.Set("renucationLaboratoryUnlocked", laboratoryUnlocked, true);
		tag.Set("meteorsGeneratedV3", meteorsGenerated, true);
	}
	public override void LoadWorldData(TagCompound tag)
	{
		laboratoryUnlocked = tag.GetBool("renucationLaboratoryUnlocked");
		meteorsGenerated = tag.GetBool("meteorsGeneratedV3");
	}
	public void GenerateMeteorBelt()
	{
		if (meteorsGenerated)
			return;

		if (Worlds.RenucationWorld.MeteorGeneration())
		{
			"Mods.Renucation.WorldGen.Steps.MeteorsFinalize".ChatKeyToAllPlayers(r: 128, g: 242, b: 225);
			meteorsGenerated = true;
		}
		else
			"Meteors disapear".ChatToAllPlayers(244, 10, 10);
	}
	public void UnlockLaboratory()
	{
		if (laboratoryUnlocked)
			return;

		"Mods.Renucation.WorldGen.Steps.LaboratoryOpen".ChatKeyToAllPlayers(r:128, g:242, b:225);
		laboratoryUnlocked = true;
	}
}
