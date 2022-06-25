// The NiTiS-Dev licenses this file to you under the MIT license.
using Microsoft.Xna.Framework;

namespace Renucation.Content.Tiles;
public class GalactiteStone : ModTile
{
	public static int ID => ModContent.TileType<GalactiteStone>();
	public static ushort ShortID => (ushort)ModContent.TileType<GalactiteStone>();
	public override void SetStaticDefaults()
	{
		Main.tileSolid[Type] = true;
		Main.tileMerge[LaboratoryBlock.ID][Type] = true;
		Main.tileMerge[Type][LaboratoryBlock.ID] = true;

		Main.tileBlockLight[Type] = true;
		MinPick = 165;
		MineResist = 8.5f;

		DustType = DustID.Asphalt;

		ItemDrop = Items.Placeable.GalactiteStone.ID;

		AddMapEntry(new Color(77, 76, 73));
	}
	public override bool CanExplode(int i, int j)
		=> false;
}
