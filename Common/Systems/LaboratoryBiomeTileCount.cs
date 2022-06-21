// The NiTiS-Dev licenses this file to you under the MIT license.

using System;
using Terraria.ModLoader;

namespace Renucation.Common.Systems;
public class LaboratoryBiomeTileCount : ModSystem
{
	public int blockCount;
	public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
	{
		blockCount = tileCounts[ModContent.TileType<Content.Tiles.LaboratoryBlock>()];
	}
}
