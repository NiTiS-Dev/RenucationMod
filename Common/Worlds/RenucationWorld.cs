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
	public const int SafeZoneX = 10;
	public const int ValidatorStepX = 10;
	private const int OreRarity = 225;
	public static readonly int[] MeteorRangeX = new int[] { 370, 700, 1200 };
	public static readonly int[] MeteorRangeY = new int[] { 90, 175, 250 };
	public static readonly int[] MeteorRare = new int[] { 450, 560, 700 };
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

		for (int x = 0; x < Main.maxTilesX; x++) // X Safe zone
		{
			validPlacesX[x] = true;

			if (x <= SafeZoneX || x >= Main.maxTilesX - SafeZoneX)
			{
				validPlacesX[x] = false;
				continue;
			}

			for (int y = SafeZoneY; y < meteorRangeSizeY + SafeZoneY; y++) // Y safe zone
			{
				Tile tile = Main.tile[x, y];

				if (tile.HasTile)
				{
					validPlacesX[x] = false;
				}
			}
		}

		List<ValidZone> validZones = new();

		for (int x = 0; x < Main.maxTilesX; x += ValidatorStepX)
		{
			if (x + meteorRangeSizeX > Main.maxTilesX)
				break;

			bool mark = true;
			int _endX = x;
			for (int pointX = x; pointX < x + meteorRangeSizeX; pointX++) // Try to find rectangle with empty tiles
			{
				if (!validPlacesX[pointX]) //This X-line already taken
				{
					mark = false;
					break;
				}
				_endX = pointX + 1;
			}
			if (mark) // Place is found
			{
				ValidZone newZone = new(x, _endX);
				if (validZones.All(vz => vz | newZone)) // Check to not collide
					validZones.Add(newZone);
			}
		}

		$"DEBUG Founded Valid Zones {validZones.Count}".DebugLog(128, 242, 225);

		if (validZones.Count <= 0)
			return false;

		#endregion
		#region Gen meteors

		int beginY = SafeZoneY;
		int endY = SafeZoneY + meteorRangeSizeY;

		int _selected = WorldGen.genRand.Next(validZones.Count);

		(ref int beginX, ref int endX) = validZones[_selected].Unpack();

		$"DEBUG Placed belt at X{beginX}:{endX} Y{beginY}:{endY} on {_selected} zone".DebugLog();

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

		$"DEBUG BeginX {beginX} EndX {endX}".DebugLog();

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

		$"DEBUG Spawned meteors: {spawnedMeteors} Spawned ores: {debug_oreCount}".DebugLog();

		if (spawnedMeteors == 0)
			return false;

		#endregion
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

		int IslandIndex = tasks.Count;
		if (IslandIndex != -1)
		{
			tasks.Insert(IslandIndex - 4, new PassLegacy("Renucation Laboratory", LaboratoryGeneration));
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
	private readonly struct ValidZone
	{
		private readonly int startX;
		private readonly int endX;

		public ValidZone(int startX, int endX)
		{
			this.startX = startX;
			this.endX = endX;
		}
		public readonly bool Colide(ValidZone other)
		{
			if (other.startX >= this.startX && other.startX <= this.endX)
				return true;
			else
			if (other.endX >= this.startX && other.endX <= this.endX)
				return true;

			return false;
		}
		public readonly (int, int) Unpack()
			=> (startX, endX);
		public static bool operator |(ValidZone left, ValidZone right)
			=> !left.Colide(right);
		public override string ToString()
			=> $"{{{startX}:{endX}}}";
	}
}