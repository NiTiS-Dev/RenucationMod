// The NiTiS-Dev licenses this file to you under the MIT license.

using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Renucation.Content.Items.Tools;
public class Vibraxe : ModItem
{
	public override void SetStaticDefaults()
	{
		SacrificeTotal = 1;
	}
	public override void SetDefaults()
	{
		Item.damage = 21;
		Item.DamageType = DamageClass.Melee;
		Item.width = 40;
		Item.height = 30;
		Item.useTime = 10;
		Item.useAnimation = 10;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.knockBack = 6;
		Item.value = Item.buyPrice(gold: 95);
		Item.rare = Rarities.LaboratoryRarity.ID;
		Item.UseSound = SoundID.Item1;
		Item.autoReuse = true;

		Item.pick = 200;
	}
	public override void MeleeEffects(Player player, Rectangle hitbox)
	{
		if (Main.rand.NextBool(12))
		{
			Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.GlowingMushroom);
		}
	}
	public override void AddRecipes()
	{
		// TODO: Add recipe
	}
}
