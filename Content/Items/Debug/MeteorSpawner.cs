// The NiTiS-Dev licenses this file to you under the MIT license.
using Microsoft.Xna.Framework;
using Renucation.Common.Worlds;
using System;

namespace Renucation.Content.Items.Debug;

public class MeteorSpawner : DebugItem
{
	public override string ItemName => "Meteor Spawner";

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
		RenucationWorld.PlaceMeteor(player.GetPoint() - new Point(0, 10), 25, 16);
		return true;
	}
}
