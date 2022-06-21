// The NiTiS-Dev licenses this file to you under the MIT license.
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace Renucation.Content.Items;
public class SoulofMech : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Soul of Mechanism");
		Tooltip.SetDefault("'The essence of the elder mechanism'\nCompoud of terror mechinism souls");

		// Registers a vertical animation with 4 frames and each one will last 5 ticks (1/12 second)
		Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 4));
		ItemID.Sets.AnimatesAsSoul[Item.type] = true; 

		ItemID.Sets.ItemIconPulse[Item.type] = true;
		ItemID.Sets.ItemNoGravity[Item.type] = true;

		SacrificeTotal = 25;
	}

	public override void SetDefaults()
	{
		Item.width = 18;
		Item.height = 18;
		Item.maxStack = 999;
		Item.value = 1000;
		Item.rare = ItemRarityID.LightPurple;
	}

	public override void PostUpdate()
		=> Lighting.AddLight(Item.Center, new Color(114, 252, 246).ToVector3() * 0.55f * Main.essScale);
	public override void AddRecipes()
	{
		CreateRecipe(2)
			.AddIngredient(ItemID.SoulofSight, 2)
			.AddIngredient(ItemID.SoulofFright, 2)
			//.AddIngredient(ItemID.SoulofMight, 2)
			.AddTile(TileID.MythrilAnvil)
			.Register();
		CreateRecipe(2)
			.AddIngredient(ItemID.SoulofSight, 2)
			//.AddIngredient(ItemID.SoulofFright, 2)
			.AddIngredient(ItemID.SoulofMight, 2)
			.AddTile(TileID.MythrilAnvil)
			.Register();
		CreateRecipe(2)
			//.AddIngredient(ItemID.SoulofSight, 2)
			.AddIngredient(ItemID.SoulofFright, 2)
			.AddIngredient(ItemID.SoulofMight, 2)
			.AddTile(TileID.MythrilAnvil)
			.Register();
	}
}
