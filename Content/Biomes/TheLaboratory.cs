// The NiTiS-Dev licenses this file to you under the MIT license.
using Renucation.Common.Systems;

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
	}
	public override void OnLeave(Player player)
	{
		player.GetModPlayer<RenucationPlayer>().ZoneTheLaboratory = false;
	}
	public override bool IsBiomeActive(Player player)
	{
		return ModContent.GetInstance<TileCounter>().labBlockCount >= 40;
		//TODO: Add checking player on laboratory wall
	}
}
