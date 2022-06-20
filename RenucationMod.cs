using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Renucation.Common.Configs;

namespace Renucation;

public partial class RenucationMod : Mod
{
	public const string AssetPath = $"Renucation/Assets/";
	public override void Unload()
	{
	}
	public override void AddRecipes()
	{
		RenucationConfig renucationConfig = ModContent.GetInstance<RenucationConfig>();
		if (renucationConfig.EnableWaterBotsCraft)
		{
			CreateRecipe(ItemID.WaterWalkingBoots, 1)
			.AddIngredient(ItemID.WaterWalkingPotion, 4)
			.AddIngredient(ItemID.HermesBoots)
			.AddTile(TileID.TinkerersWorkbench)
			//.AddCondition(NetworkText.FromKey("RecipeConditions.AroundWaterCandle"), (Recipe _) => Main.LocalPlayer.ZoneWaterCandle)
			.Register();
		}
	}
}