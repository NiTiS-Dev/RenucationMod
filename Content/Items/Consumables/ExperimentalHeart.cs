// The NiTiS-Dev licenses this file to you under the MIT license.
using Microsoft.Xna.Framework;

namespace Renucation.Content.Items.Consumables;
public class ExperimentalHeart : ModItem
{
	public const int Maximum = 5;
	public const int LifePerOnce = 10;

	public override void SetStaticDefaults()
	{

		SacrificeTotal = 5;
	}

	public override void SetDefaults()
	{
		Item.CloneDefaults(ItemID.LifeFruit);
		Item.rare = Rarities.LaboratoryRarity.ID;
	}
	public override bool CanUseItem(Player player)
	{
		return player.statLifeMax >= 500 && player.GetModPlayer<ExperimentalHeartPlayer>().usedExperimentalHeart < Maximum;
	}
	public override bool? UseItem(Player player)
	{
		player.statLifeMax2 += LifePerOnce;
		player.statLife += LifePerOnce;
		if (Main.myPlayer == player.whoAmI)
		{
			player.HealEffect(LifePerOnce);
		}

		player.GetModPlayer<ExperimentalHeartPlayer>().usedExperimentalHeart++;
		return true;
	}
}
