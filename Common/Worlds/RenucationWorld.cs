// The NiTiS-Dev licenses this file to you under the MIT license.

using Microsoft.Xna.Framework;
using Renucation.Common.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria.GameContent.Generation;
using Terraria.IO;
using Terraria.WorldBuilding;

namespace Renucation.Common.Worlds;
public class RenucationWorld : ModSystem
{
	#region WorldGen constants
	public const int SafeZoneY = 45;
	public const int ValidatorStepX = 5;
	private const int OreRarity = 120;
	public static readonly int[] MeteorRangeX = new int[] { 370, 1100, 2200 };
	public static readonly int[] MeteorRangeY = new int[] { 110, 250, 450 };
	public static readonly int[] MeteorRare = new int[] { 450, 560, 670 };
	#endregion
	public static bool IsEnabledINDEVGEN => ModContent.GetInstance<RenucationConfig>().EnableINDEVGeneration;
	public static bool MeteorGeneration()
	{
		if (!IsEnabledINDEVGEN)
			return false;
		#region Found x..x range for gen meteors
		// See here https://terraria.fandom.com/wiki/World_size for look world sizes
		int meteorRangeSizeX = Main.maxTilesX switch
		{
			>= 8000 => MeteorRangeX[2],
			>= 6000 => MeteorRangeX[1],
			>= 3000 => MeteorRangeX[0],
			_ => -1
		};
		int meteorRangeSizeY = Main.maxTilesY switch
		{
			>= 2000 => MeteorRangeY[2],
			>= 1500 => MeteorRangeY[1],
			>= 1000 => MeteorRangeY[0],
			_ => -1
		};
		int meteorRarity = Main.maxTilesX switch
		{
			>= 8000 => MeteorRare[2],
			>= 6000 => MeteorRare[1],
			>= 3000 => MeteorRare[0],
			_ => -1
		};

		if (meteorRangeSizeX == -1 || meteorRangeSizeY == -1 || meteorRarity == -1) // Very small world
			return false;

		bool[] validPlacesX = new bool[Main.maxTilesX];

		for (int x = 0; x < Main.maxTilesX; x++)
		{
			validPlacesX[x] = true;
			for (int y = SafeZoneY; y < meteorRangeSizeY + SafeZoneY; y++) // Plus 20 blocks for safe
			{
				Tile tile = Main.tile[x, y];

				if (tile.HasTile)
				{
					validPlacesX[x] = false;
				}
			}
		}

		int beginX = -1, endX = -1;
		int debug_maxSize = 0;

		bool __skip = false;
		for (int x = 0; x < Main.maxTilesX; x += ValidatorStepX)
		{
			if (__skip)
				break;

			if (x + meteorRangeSizeX > Main.maxTilesX)
				break;
			int debug_currentSize = 0;
			for (int alsoX = x; alsoX < x + meteorRangeSizeX; alsoX++)
			{
				if (!validPlacesX[alsoX])
				{
					break;
				}
				else
				{
					debug_currentSize++;
					if (alsoX + 1 == x + meteorRangeSizeX)
					{
						beginX = x;
						endX = alsoX + 1;
						if (WorldGen.genRand.NextBool(3)) // Randomize meteors location
							__skip = true;
					}
				}
			}
			debug_maxSize = Math.Max(debug_maxSize, debug_currentSize);
		}
		Main.NewText($"DEBUG Maximum size found: {debug_maxSize} Valid places: {validPlacesX.Count(x => x)}");

		if (beginX == endX)
		{
			return false; // Found no space
		}

		#endregion
		#region Gen meteors

		int beginY = SafeZoneY;
		int endY = SafeZoneY + meteorRangeSizeY;

		int spawnedMeteors = 0;
		List<Rectangle> regions = new(Main.maxTilesX > 4000 ? 256 : 128);
		for (int y = beginY; y < endY; y++) // Meteor generation
		{
			for (int x = beginX; x < endX; x++)
			{

				int sizeX = WorldGen.genRand.Next(12, 34);
				int sizeY = WorldGen.genRand.Next(7, 24);

				if (x + sizeX > endX || y + sizeY > endY)
					continue;

				if (WorldGen.genRand.NextBool(meteorRarity))
				{
					if (sizeX + x > endX) //Out of bounds
						continue;

					if (regions.All(zi => !zi.Contains(x, y) && !zi.Contains(x + sizeX, y + sizeY)))
					{
						PlaceMeteor(new(x, y), (uint)sizeX, (uint)sizeY);
						regions.Add(new(x, y, sizeX, sizeY));
						spawnedMeteors++;
					}
				}
			}
		}

		Main.NewText($"DEBUG BeginX {beginX} EndX {endX}", 128, 242, 225);

		int debug_oreCount = 0;
		for (int x = beginX; x < endX; x++) // Ore generation
		{
			for (int y = beginY; y < endY; y++)
			{
				if (WorldGen.genRand.NextBool(OreRarity))
				{
					debug_oreCount++;
					WorldGen.OreRunner(
						x, y,
						6,
						7,
						Content.Tiles.DioliteOre.ShortID
						);
				}
			}
		}

		Main.NewText($"DEBUG Spawned meteors: {spawnedMeteors} Spawned ores: {debug_oreCount}", 128, 242, 225);

		if (spawnedMeteors == 0)
			return false;

		#endregion
		Main.NewText(Language.GetTextValue("Mods.Renucation.WorldGen.Steps.MeteorsFinalize"), 128, 242, 225);
		return true;
	}
	public static void PlaceMeteor(Point position, uint sizeX, uint sizeY)
	{
		WorldUtils.Gen(position, new RenuShapes.Meteor(sizeX, sizeY), Actions.Chain(
			new Actions.SetTile(Content.Tiles.GalactiteStone.ShortID, true)
		));
	}
	public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
	{
		if (!IsEnabledINDEVGEN)
			return;

		int IslandIndex = tasks.Count - 1;
		if (IslandIndex != -1)
		{
			tasks.Insert(IslandIndex + 1, new PassLegacy("Renucation Laboratory", LaboratoryGeneration));
		}
		else
		{
			throw new Exception("Where my step?");
		}
	}
	private void LaboratoryGeneration(GenerationProgress progress, GameConfiguration config)
	{
		progress.Message = Language.GetTextValue("Mods.Renucation.WorldGen.Steps.IslandGeneration");

		// Place laboratory otherside skeletron dungeon
		int x = (Main.dungeonX > Main.maxTilesX / 2) ? 170 : Main.maxTilesX - 170;


		int surfaceY = (int)WorldGen.worldSurface;

		const int width = 82;

		int mediumY = (surfaceY / 2) + 10;

		Point point = new Point(x, mediumY);


		WorldGen.structures.AddProtectedStructure(new(x - width / 2, mediumY - width / 2, width, width), 1);

		ShapeData shapeData = new ShapeData();
		WorldUtils.Gen(point, new Shapes.Circle(81, 81), new Actions.Blank().Output(shapeData));
		WorldUtils.Gen(point, new ModShapes.InnerOutline(shapeData, true), new Actions.SetTile(TileID.Grass, true));
		WorldUtils.Gen(point, new Shapes.Circle(80, 80), Actions.Chain(
			new Actions.SetTile(TileID.Dirt, true),
			new Actions.PlaceWall(WallID.DirtUnsafe, true)
		));
		WorldUtils.Gen(point, new Shapes.Circle(70, 70), Actions.Chain(
			new Actions.SetTile(TileID.Stone, true),
			new Actions.PlaceWall(WallID.DirtUnsafe, true)
		));
	}
}