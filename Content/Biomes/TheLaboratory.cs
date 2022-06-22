// The NiTiS-Dev licenses this file to you under the MIT license.
using Renucation.Common.Players;
using Renucation.Common.Systems;
using Terraria;
using Terraria.ModLoader;

namespace Renucation.Content.Biomes;
public class TheLaboratory : ModBiome
{
	public override SceneEffectPriority Priority => SceneEffectPriority.BiomeHigh;
	public override void OnInBiome(Player player)
	{
	}
	public override void OnEnter(Player player)
	{
		player.GetModPlayer<RenucationPlayer>().ZoneTheLaboratory = true;
		Main.NewText($"You enter to the ${DisplayName.Key}");
	}
	public override void OnLeave(Player player)
	{
		player.GetModPlayer<RenucationPlayer>().ZoneTheLaboratory = false;
		Main.NewText($"You leave the ${DisplayName.Key}");
	}
	public override bool IsBiomeActive(Player player)
	{
		return ModContent.GetInstance<LaboratoryBiomeTileCount>().blockCount > 2;
		//TODO: Add checking player on laboratory wall
	}
}
