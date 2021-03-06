// The NiTiS-Dev licenses this file to you under the MIT license.
using Microsoft.Xna.Framework;
using Renucation.Common.Systems;
using Renucation.Common.Worlds;
using System;
using static Renucation.RenucationMod;

namespace Renucation.Content.Tiles;
public class DioliteOre : ModTile
{
	public static int ID => ModContent.TileType<DioliteOre>();
	public static ushort ShortID => (ushort)ModContent.TileType<DioliteOre>();
	public override void SetStaticDefaults()
	{
		TileID.Sets.Ore[Type] = true;

		TileID.Sets.BlockMergesWithMergeAllBlock[Type] = true;
		Main.tileMerge[Type][GalactiteStone.ID] = true;
		Main.tileMerge[GalactiteStone.ID][Type] = true;

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
	public override void RandomUpdate(int i, int j)
	{
		if (Main.rand.NextBool(1024))
		{
			i += Main.rand.Next(-1, 1);
			j += Main.rand.Next(-1, 1);

			if (WorldGen.InWorld(i, j))
			{
				Tile newTile = Main.tile[i, j];

				if (newTile.TileType == GalactiteStone.ShortID)
				{
					newTile.TileType = DioliteOre.ShortID;
					if (Main.netMode == NetmodeID.Server)
					{
						ModPacket packet = Mod.GetPacket();
						packet.Write((byte)MessageType.RenucationBlockSpread);
						packet.Write(i);
						packet.Write(j);
						packet.Send();
					}
				}
			}
		}
	}
	public override bool CanKillTile(int i, int j, ref bool blockDamaged)
	{
		bool breakable = ModContent.GetInstance<WorldGenSystem>().CanBreakDiolite();

		blockDamaged = breakable && blockDamaged;

		return breakable;
	}
	public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
	{
		float re = (float)Main.maxTilesY / j;
		re = Math.Min(re + 0.2f, 1f);
		r = 0.16f * re;
		g = 0.92f * re;
		b = 0.90f * re;
	}
	public override bool CanExplode(int i, int j)
		=> false;
}
