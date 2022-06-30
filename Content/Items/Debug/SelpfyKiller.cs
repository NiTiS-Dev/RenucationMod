// The NiTiS-Dev licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.DataStructures;

namespace Renucation.Content.Items.Debug;
public class SelpfyKiller : DebugItem
{
	public override string ItemName => "Selphy Killer";

	public override void SetDefaults()
	{
		Item.useTime = 5;
		Item.useAnimation = 5;
		Item.useStyle = ItemUseStyleID.HoldUp;
		Item.consumable = false;
		Item.autoReuse = false;
	}
	public override bool? UseItem(Player player)
	{
		player.KillMe(PlayerDeathReason.LegacyEmpty(), Double.MaxValue, 0);
		CombatText.NewText(new((int)player.position.X, (int)player.position.Y, player.width, player.height), new(45, 45, 120), "Say Chesse~ ^_^");
		player.respawnTimer = 1;
		return true;
	}
}
