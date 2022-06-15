using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Renucation
{
	public class Renucation : Mod
	{
		public const string AssetPath = $"{nameof(Renucation)}/Assets/";
		public override void Unload()
		{

		}
		public override void AddRecipes()
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