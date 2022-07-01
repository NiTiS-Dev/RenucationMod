// The NiTiS-Dev licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renucation.Content.Items;
public class TheTable : ModItem
{
	public override void SetStaticDefaults()
	{
		//DisplayName.SetDefault("ExampleMount Car key");
		//Tooltip.SetDefault("This summons a modded mount.");

		SacrificeTotal = 1;
	}
	public override void SetDefaults()
	{
		Item.width = 20;
		Item.height = 30;
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.value = Item.sellPrice(gold: 7);
		Item.rare = ItemRarityID.Green;
		Item.UseSound = SoundID.Item79;
		Item.noMelee = true;
		Item.mountType = ModContent.MountType<Mounts.TheTable>();
	}
}
