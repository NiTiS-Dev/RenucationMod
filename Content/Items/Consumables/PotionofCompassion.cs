// The NiTiS-Dev licenses this file to you under the MIT license.
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Renucation.Content.Items.Consumables;
public class PotionofCompassion : ModItem
{
	public override void SetStaticDefaults()
	{
		SacrificeTotal = 20;
	}

	public override void SetDefaults()
	{
		Item.width = 20;
		Item.height = 26;
		Item.useStyle = ItemUseStyleID.DrinkLiquid;
		Item.useAnimation = 15;
		Item.useTime = 15;
		Item.useTurn = true;
		Item.UseSound = SoundID.Item3;
		Item.maxStack = 30;
		Item.consumable = true;
		Item.rare = ItemRarityID.Orange;
		Item.value = Item.buyPrice(gold: 1);
		Item.buffType = ModContent.BuffType<Buffs.CompassionDebuff>();
		Item.buffTime = 300 * 60; // 5 mins
	}
}
