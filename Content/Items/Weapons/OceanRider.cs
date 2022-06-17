// The NiTiS-Dev licenses this file to you under the MIT license.

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Renucation.Content.Items.Weapons;
public class OceanRider : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Ocean Rider");
		Tooltip.SetDefault("The ocean provides you with bullets");

		CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
	}
	public override void SetDefaults()
	{
		Item.width = 56;
		Item.height = 22;

		Item.autoReuse = true;
		Item.damage = 36;
		Item.DamageType = DamageClass.Ranged;
		Item.knockBack = 4f;
		Item.noMelee = true;
		Item.rare = ItemRarityID.LightPurple;
		Item.useAnimation = 7;
		Item.useTime = 7;
		Item.UseSound = SoundID.Item11;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.value = Item.buyPrice(gold: 55);

		Item.shoot = ProjectileID.PurificationPowder;
		Item.shootSpeed = 21;
		Item.useAmmo = AmmoID.Bullet;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ItemID.Seashell, 15)
			.AddIngredient(ItemID.IllegalGunParts, 1)
			.AddIngredient(ItemID.HallowedBar, 12)
			.AddIngredient<SoulofMech>(10)
			.AddTile(TileID.MythrilAnvil)
			.Register();
	}
	public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
	{
		velocity = velocity.RotatedByRandom(MathHelper.ToRadians(1f));
	}
	public override bool CanConsumeAmmo(Item ammo, Player player)
	{
		return !player.ZoneBeach;
	}
	public override bool NeedsAmmo(Player player)
	{
		return !player.ZoneBeach;
	}
	public override Vector2? HoldoutOffset()
	{
		return new Vector2(-4f, 4f);
	}
}
