// The NiTiS-Dev licenses this file to you under the MIT license.
namespace Renucation.Content.Items.Placeable;
public class DioliteOre : ModItem
{
	public static int ID => ModContent.ItemType<DioliteOre>();
	public override void SetStaticDefaults()
	{
		SacrificeTotal = 100;
		ItemID.Sets.SortingPriorityMaterials[Item.type] = 58;
	}

	public override void SetDefaults()
	{
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTurn = true;
		Item.useAnimation = 15;
		Item.useTime = 10;
		Item.autoReuse = true;
		Item.maxStack = 999;
		Item.consumable = true;
		Item.createTile = ModContent.TileType<Tiles.DioliteOre>();
		Item.width = 12;
		Item.height = 12;
		Item.value = 30000;
	}
}
