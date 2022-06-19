// The NiTiS-Dev licenses this file to you under the MIT license.
using Renucation.Common.Systems;
using Terraria;
using Terraria.ModLoader;

namespace Renucation.Content.Biomes;
public class LaboratoryBiome : ModBiome
{
	public override SceneEffectPriority Priority => SceneEffectPriority.BiomeHigh;
	public override void OnInBiome(Player player)
	{
	}
	public override void OnEnter(Player player)
	{
		Main.NewText($"You enter to the {DisplayName}");
	}
	public override void OnLeave(Player player)
	{
		Main.NewText($"You leave the {DisplayName}");
	}
	public override bool IsBiomeActive(Player player)
	{
		return ModContent.GetInstance<LaboratoryBiomeTileCount>().blockCount > 2;
		//TODO: Add checking player on laboratory wall
	}
}
