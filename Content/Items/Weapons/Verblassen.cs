// The NiTiS-Dev licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renucation.Content.Items.Weapons;
public class Verblassen : ModItem
{
	public override void SetStaticDefaults()
	{
		SacrificeTotal = 1;
	}

	public override void SetDefaults()
	{
		Item.DefaultToWhip(ModContent.ProjectileType<Projectiles.DioliteWhipProjectile>(), 20, 2, 4);

		Item.shootSpeed = 4;
		Item.rare = Rarities.LaboratoryRarity.ID;

		Item.channel = true;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient<Placeable.DioliteBar>(18)
			.Register();
	}
}
