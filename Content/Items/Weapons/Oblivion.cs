// The NiTiS-Dev licenses this file to you under the MIT license.

using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace Renucation.Content.Items.Weapons;
public class Oblivion : ModItem
{
	public override void SetStaticDefaults()
	{
		SacrificeTotal = 1;
	}
	public override void SetDefaults()
	{
		Item.damage = 44;
		Item.DamageType = DamageClass.Magic;
		Item.width = 40;
		Item.height = 20;
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.noMelee = true;
		Item.knockBack = 6;
		Item.value = Item.sellPrice(gold: 25);
		Item.rare = ItemRarityID.LightRed;
		Item.UseSound = SoundID.Item72;
		Item.autoReuse = true;
		Item.shoot = ProjectileID.BlackBolt; // Shoot a black bolt, also known as the projectile shot from the onyx blaster.
		Item.shootSpeed = 38; // How fast the item shoots the projectile.
		Item.crit = 32; // The percent chance at hitting an enemy with a crit, plus the default amount of 4.
		Item.mana = 12;
	}
	public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
	{

	}
	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		return base.Shoot(player, source, position, velocity, type, damage, knockback);
	}
	public override Vector2? HoldoutOrigin() => new(-10f, 10);
	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient<Placeable.DioliteBar>(12)
			.AddTile(TileID.MythrilAnvil)
			.Register();
	}
}
