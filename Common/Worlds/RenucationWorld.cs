﻿// The NiTiS-Dev licenses this file to you under the MIT license.

using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Generation;
using System.Collections.Generic;
using Terraria.WorldBuilding;
using Terraria.Localization;
using Terraria.IO;
using Microsoft.Xna.Framework;

namespace Renucation.Common.Worlds;
public class RenucationWorld : ModSystem
{
	public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
	{
		//int IslandIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Floating Islands"));
		int IslandIndex = tasks.Count - 1;
		if (IslandIndex != -1)
		{
			tasks.Insert(IslandIndex + 1, new PassLegacy("Renucation Laboratory", LaboratoryGeneration));
		} else
		{
			throw new System.Exception("Where my step?");
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
		//WorldUtils.Gen(point, new Shapes.Slime(10), new Actions.PlaceTile( (ushort)ModContent.TileType<Content.Tiles.LaboratoryBlock>() ));
	}
}
