// The NiTiS-Dev licenses this file to you under the MIT license.

using Renucation.Common.Players;
using Renucation.Content.Biomes;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Renucation.Content.NPCs;
public class NekoSlime : ModNPC
{
	// TODO: Resprite and change texture style to other slime!!!
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Neko Slime");

		Main.npcFrameCount[Type] = 2;

		NPCID.Sets.NPCBestiaryDrawModifiers value = new(0)
		{
			Velocity = 1f
		};
		NPCID.Sets.DebuffImmunitySets.Add(Type, new NPCDebuffImmunityData
		{
			SpecificallyImmuneTo = new int[] {
					BuffID.Poisoned,
					BuffID.Burning
				}
		});
		NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
	}

	public override void SetDefaults()
	{
		NPC.width = 25;
		NPC.height = 20;
		NPC.damage = 160;
		NPC.defense = 20;
		NPC.lifeMax = 1500;
		NPC.HitSound = SoundID.NPCHit1;
		NPC.DeathSound = SoundID.NPCDeath2;
		NPC.value = 280f;
		NPC.knockBackResist = 0.7f;
		NPC.aiStyle = NPCAIStyleID.Slime;

		AIType = NPCID.BlueSlime;
		AnimationType = NPCID.BlueSlime;
		Banner = Item.NPCtoBanner(NPCID.BlueSlime);
		BannerItem = Item.BannerToItem(Banner);
		SpawnModBiomes = new int[1] { ModContent.GetInstance<LaboratoryBiome>().Type };
	}

	public override void ModifyNPCLoot(NPCLoot npcLoot)
	{
		npcLoot.Add(ItemDropRule.Common(ItemID.Gel, 1, 1, 3));
		npcLoot.Add(ItemDropRule.Common(ItemID.CatEars, 512));
	}

	public override float SpawnChance(NPCSpawnInfo spawnInfo)
	{
		return (spawnInfo.Player.GetModPlayer<RenucationPlayer>().ZoneTheLaboratory ? 1 : 0);
	}
	public static SpawnConditionBestiaryInfoElement TheLaboratory = new("Mods.Renucation.BestiaryCondition.TheLaboratory", 1, "Images/MapBG36");
	public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
	{
		bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				TheLaboratory,
				new FlavorTextBestiaryInfoElement("Mods.Renucation.BestiaryInfo.NekoSlime")
			});
	}
}
