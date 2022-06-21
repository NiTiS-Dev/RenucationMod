// The NiTiS-Dev licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;

namespace Renucation.Content.Items.Placeable;
public class DioliteBar : ModItem
{
	public override void SetStaticDefaults()
	{
		SacrificeTotal = 25;
		ItemID.Sets.SortingPriorityMaterials[Item.type] = 65;
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
		//Item.createTile = ModContent.TileType<Tiles.DioliteBar>();
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
