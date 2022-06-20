// The NiTiS-Dev licenses this file to you under the MIT license.
using Renucation.Content.Rarities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Renucation.Content.Items.Weapons;
public class KrabRave : ModItem
{
	// Item in developing
	public override bool IsLoadingEnabled(Mod mod)
		=> false;

	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Krab Rave");

		SacrificeTotal = 1;
	}
	public override void SetDefaults()
	{
		Item.width = 1;
		Item.height = 1;

		Item.autoReuse = true;
		Item.damage = 46;
		Item.DamageType = DamageClass.Ranged;
		Item.knockBack = 4f;
		Item.noMelee = true;
		Item.rare = LaboratoryRarity.ID;
		Item.useAnimation = 7;
		Item.useTime = 7;
		Item.UseSound = SoundID.Item11;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.value = Item.buyPrice(platinum: 1, gold: 10);

		Item.shoot = ProjectileID.PurificationPowder;
		Item.shootSpeed = 50;
		Item.useAmmo = AmmoID.Bullet;
	}
}
