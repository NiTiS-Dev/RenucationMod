// The NiTiS-Dev licenses this file to you under the MIT license.
using System;

namespace Renucation.Common.Systems;
public class TileCounter : ModSystem
{
	public int labBlockCount;
	public int galactiteStoneBlockCount;
	public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
	{
		labBlockCount = tileCounts[ModContent.TileType<Content.Tiles.LaboratoryBlock>()];
		galactiteStoneBlockCount = tileCounts[ModContent.TileType<Content.Tiles.GalactiteStone>()] + tileCounts[ModContent.TileType<Content.Tiles.DioliteOre>()];
	}
}
