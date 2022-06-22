// The NiTiS-Dev licenses this file to you under the MIT license.
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Renucation.Content.Tiles;
public class LaboratoryBlock : ModTile
{
	public static int ID => ModContent.TileType<LaboratoryBlock>();
	public override void SetStaticDefaults()
	{
		Main.tileSolid[Type] = true;
		Main.tileMerge[TileID.Stone][Type] = true;
		Main.tileMerge[TileID.Dirt][Type] = true;
		Main.tileBlockLight[Type] = true;
		MinPick = 195;
		MineResist = 16.5f;

		DustType = DustID.Adamantite;

		ItemDrop = ModContent.ItemType<Items.Placeable.LaboratoryBlock>();

		AddMapEntry(new Color(200, 200, 200));
	}
	public override bool CanExplode(int i, int j)
		=> false;
	public override void NumDust(int i, int j, bool fail, ref int num)
	{
		num = fail ? 1 : 3;
	}
}