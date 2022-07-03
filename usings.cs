global using Terraria;
global using Terraria.ID;
global using Terraria.ModLoader;
global using Terraria.Localization;

global using System.Linq;

global using Renucation.Common.Players;
global using Renucation.WorldBuilding;
global using static RenuExtensions;

using Microsoft.Xna.Framework;
using Terraria.Chat;

internal static class RenuExtensions
{
	public static RenucationPlayer Renu(this Player player)
		=> player.GetModPlayer<RenucationPlayer>();
	public static Point GetPoint(this Player player)
		=> new((int)player.position.X / 16, (int)player.position.Y / 16);
	public static void DebugLog(this object obj, byte r = 255, byte g = 255, byte b = 255, bool sendOnServer = true)
		=> obj.ToString().DebugLog(r, g, b, sendOnServer);
	public static void DebugLog(this string str, byte r = 255, byte g = 255, byte b = 255, bool sendOnServer = true)
	{
		if (!Main.dedServ)
			Main.NewText(str, r, g, b); //MSG for player
		else if (sendOnServer)
			System.Console.WriteLine(str); // MSG for server
	}
	public static void ChatToPlayer(NetworkText text, Player player, byte r = 255, byte g = 255, byte b = 255)
		=> ChatToPlayer(text, player.whoAmI, r, g, b);
	public static void ChatToPlayer(NetworkText text, int playerID, byte r = 255, byte g = 255, byte b = 255)
		=> ChatHelper.SendChatMessageToClient(text, new(r, g, b), playerID);
	public static void ChatToPlayer(this string str, Player player, byte r = 255, byte g = 255, byte b = 255)
		=> ChatToPlayer(str, player.whoAmI, r, g, b);
	public static void ChatToPlayer(this string str, int playerID, byte r = 255, byte g = 255, byte b = 255)
		=> ChatHelper.SendChatMessageToClient(NetworkText.FromLiteral(str), new(r, g, b), playerID);

	public static void ChatToAllPlayers(this string str, byte r = 255, byte g = 255, byte b = 255)
		=> ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(str), new(r, g, b));
	public static void ChatKeyToAllPlayers(this string str, byte r = 255, byte g = 255, byte b = 255, params object[] args)
		=> ChatHelper.BroadcastChatMessage(NetworkText.FromKey(str, args), new(r, g, b));
} 