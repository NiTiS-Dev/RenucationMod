using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria;

namespace Renucation.Content.Items.Placeble;

public class MagneturnBar : ModItem
{
	public override void SetStaticDefaults()
	{
		CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;
		ItemID.Sets.SortingPriorityMaterials[Item.type] = 62;
	}

	public override void SetDefaults()
	{
		Item.width = 20;
		Item.height = 20;
		Item.maxStack = 999;
		Item.value = 750;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTurn = true;
		Item.useAnimation = 15;
		Item.useTime = 10;
		Item.autoReuse = true;
		Item.consumable = true;
		//Item.createTile = ModContent.TileType<>();
		Item.placeStyle = 0;
	}

	public override void AddRecipes()
	{
		//CreateRecipe()
		//	.AddIngredient<ExampleOre>(4)
		//	.AddTile(TileID.Furnaces)
		//	.Register();
	}
}