// The NiTiS-Dev licenses this file to you under the MIT license.
namespace Renucation.Content.Items.Weapons;

public class Verblassen : ModItem
{
	public override void SetStaticDefaults()
	{
		SacrificeTotal = 1;
	}

	public override void SetDefaults()
	{
		Item.DamageType = DamageClass.SummonMeleeSpeed;
		Item.damage = 51;
		Item.knockBack = 3.5f;

		Item.shoot = ModContent.ProjectileType<Projectiles.DioliteWhip>();
		Item.shootSpeed = 4;
		Item.rare = Rarities.LaboratoryRarity.ID;

		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 25;
		Item.useAnimation = 25;
		Item.UseSound = SoundID.Item152;
		Item.channel = false;
		Item.noMelee = true;
		Item.noUseGraphic = true;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient<Placeable.DioliteBar>(12)
			.AddTile(TileID.MythrilAnvil)
			.Register();
	}
}
