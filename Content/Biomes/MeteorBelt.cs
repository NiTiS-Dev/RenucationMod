// The NiTiS-Dev licenses this file to you under the MIT license.

using Renucation.Common.Systems;

namespace Renucation.Content.Biomes;
public class MeteorBelt : ModBiome
{
	public override SceneEffectPriority Priority => SceneEffectPriority.BossLow;
	public override void OnEnter(Player player)
	{
		player.GetModPlayer<RenucationPlayer>().ZoneMeteorBelt = true;
	}
	public override void OnLeave(Player player)
	{
		player.GetModPlayer<RenucationPlayer>().ZoneMeteorBelt = false;
	}
	public override bool IsBiomeActive(Player player) 
		=> ModContent.GetInstance<TileCounter>().galactiteStoneBlockCount >= 35;
}
