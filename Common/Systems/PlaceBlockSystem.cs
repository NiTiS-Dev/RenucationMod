// The NiTiS-Dev licenses this file to you under the MIT license.

using Renucation.Content.Tiles;

namespace Renucation.Common.Systems;
public class PlaceBlockSystem : GlobalTile
{
	public override bool CanPlace(int i, int j, int type)
	{
		if (WorldGen.InWorld(i, j))
		{
			Tile tile = Main.tile[i, j];
			if (tile.TileType == DioliteOre.ShortID)
			{
				if (ModContent.GetInstance<WorldGenSystem>().CanBreakDiolite())
					return true;


				return false;
			}

			return true;
		}

		return false;
	}
}
