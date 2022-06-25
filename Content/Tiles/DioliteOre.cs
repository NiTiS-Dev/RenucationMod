// The NiTiS-Dev licenses this file to you under the MIT license.
using Microsoft.Xna.Framework;

namespace Renucation.Content.Tiles;
public class DioliteOre : ModTile
{
	public static int ID => ModContent.TileType<GalactiteStone>();
	public static ushort ShortID => (ushort)ModContent.TileType<GalactiteStone>();
	public override void SetStaticDefaults()
	{
		TileID.Sets.Ore[Type] = true;
		TileID.Sets.BlockMergesWithMergeAllBlock[Type] = true;
		Main.tileSolid[Type] = true;
		Main.tileBlockLight[Type] = true;
		Main.tileLighted[Type] = true;

		Main.tileSpelunker[Type] = true;
		Main.tileOreFinderPriority[Type] = 710;
		Main.tileShine2[Type] = true;
		Main.tileShine[Type] = 975;

		MinPick = 170;
		MineResist = 12.5f;

		DustType = DustID.Chlorophyte;
		HitSound = SoundID.Tink;

		ItemDrop = Items.Placeable.DioliteOre.ID;


		ModTranslation name = CreateMapEntryName();
		AddMapEntry(new Color(40, 237, 234), name);
	}
	public override bool CanExplode(int i, int j)
		=> false;
}
