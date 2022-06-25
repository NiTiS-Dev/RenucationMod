﻿// The NiTiS-Dev licenses this file to you under the MIT license.
namespace Renucation.Content.Items.Placeable;
public class LaboratoryBlock : ModItem
{
	public override void SetStaticDefaults()
	{
		SacrificeTotal = 100;
	}

	public override void SetDefaults()
	{
		Item.width = 8;
		Item.height = 8;
		Item.maxStack = 999;
		Item.useTurn = true;
		Item.autoReuse = true;
		Item.useAnimation = 15;
		Item.useTime = 10;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.consumable = true;
		Item.createTile = ModContent.TileType<Tiles.LaboratoryBlock>();
	}
}
