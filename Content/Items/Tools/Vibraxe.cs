// The NiTiS-Dev licenses this file to you under the MIT license.

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.ObjectModel;
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
		Item.damage = 48;
		Item.DamageType = DamageClass.Melee;
		Item.width = 40;
		Item.height = 30;
		Item.useTime = 10;
		Item.useAnimation = 15;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.knockBack = 6;
		Item.value = Item.buyPrice(gold: 95);
		Item.rare = Rarities.LaboratoryRarity.ID;
		Item.UseSound = SoundID.Item1;
		Item.autoReuse = true;

		Item.pick = 190;
	}
	public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
	{
		Texture2D texture = Mod.Assets.Request<Texture2D>("Content/Items/Tools/Vibraxe_Glow").Value;
		spriteBatch.Draw
		(
			texture,
			new Vector2
			(
				Item.position.X - Main.screenPosition.X + Item.width * 0.5f,
				Item.position.Y - Main.screenPosition.Y + Item.height - texture.Height * 0.5f + 2f
			),
			new Rectangle(0, 0, texture.Width, texture.Height),
			Color.White,
			rotation,
			texture.Size() * 0.5f,
			scale,
			SpriteEffects.None,
			0f
		);
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
		CreateRecipe()
			.AddIngredient<Placeable.DioliteBar>(14)
			.AddTile(TileID.MythrilAnvil)
			.Register();
	}
}
