// The NiTiS-Dev licenses this file to you under the MIT license.
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Renucation.Content.Tiles;
public class GalactiteStone : ModTile
{
	public override void SetStaticDefaults()
	{
		Main.tileSolid[Type] = true;
		Main.tileMerge[LaboratoryBlock.ID][Type] = true;
		//Main.tileMerge[][Type] = true; TODO: Add blending for Diolite ore
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
