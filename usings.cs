global using Terraria;
global using Terraria.ID;
global using Terraria.ModLoader;
global using Terraria.Localization;

global using Renucation.Common;
global using Renucation.Content;
global using Renucation.WorldBuilding;
using Microsoft.Xna.Framework;

public static class Extensions
{
	public static Point GetPoint(this Player player)
		=> new((int)player.position.X / 16, (int)player.position.Y / 16);
} 