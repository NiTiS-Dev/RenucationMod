// The NiTiS-Dev licenses this file to you under the MIT license.
using Terraria.Audio;

namespace Renucation.Content.Items.Consumables;
public class PlanterasBulb : ModItem
{
	public override void SetStaticDefaults()
	{
		SacrificeTotal = 3;
		ItemID.Sets.SortingPriorityBossSpawns[Type] = 12;
		NPCID.Sets.MPAllowedEnemies[NPCID.Plantera] = true;
	}

	public override void SetDefaults()
	{
		Item.width = 20;
		Item.height = 20;
		Item.maxStack = 20;
		Item.value = 2500;
		Item.rare = ItemRarityID.Green;
		Item.useAnimation = 30;
		Item.useTime = 30;
		Item.useStyle = ItemUseStyleID.EatFood;
		Item.consumable = true;
	}

	public override bool CanUseItem(Player player)
		=> Main.hardMode
		&& NPC.downedMechBoss1
		&& NPC.downedMechBoss2
		&& NPC.downedMechBoss3
		&& !NPC.AnyNPCs(NPCID.Plantera)
		&& player.ZoneJungle;

	public override bool? UseItem(Player player)
	{
		if (player.whoAmI == Main.myPlayer)
		{
			SoundEngine.PlaySound(SoundID.Roar, player.position);

			int type = NPCID.Plantera;

			if (Main.netMode != NetmodeID.MultiplayerClient)
			{
				NPC.SpawnOnPlayer(player.whoAmI, type);
			}
			else
			{
				NetMessage.SendData(MessageID.SpawnBoss, number: player.whoAmI, number2: type);
			}
		}

		return true;
	}
	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ItemID.SoulofFright, 2)
			.AddIngredient(ItemID.SoulofMight, 2)
			.AddIngredient(ItemID.SoulofSight, 2)
			.AddIngredient(ItemID.JungleSpores, 6)
			.AddIngredient(ItemID.Vine, 3)
			.AddTile(TileID.DemonAltar)
			.Register();
	}
}
