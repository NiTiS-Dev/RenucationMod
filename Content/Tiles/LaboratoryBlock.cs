// The NiTiS-Dev licenses this file to you under the MIT license.
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Renucation.Content.Tiles;
public class LaboratoryBlock : ModTile
{
	public override void SetStaticDefaults()
	{
		Main.tileSolid[Type] = true;
		Main.tileMergeDirt[Type] = true;
		Main.tileBlockLight[Type] = true;

		DustType = DustID.Adamantite;

		ItemDrop = ModContent.ItemType<Items.Placeable.LaboratoryBlock>();

		AddMapEntry(new Color(200, 200, 200));
	}

	public override void NumDust(int i, int j, bool fail, ref int num)
	{
		num = fail ? 1 : 3;
	}
}