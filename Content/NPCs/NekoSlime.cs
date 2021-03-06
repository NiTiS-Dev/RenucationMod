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
	public static int ID => ModContent.NPCType<NekoSlime>();
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Neko Slime");

		Main.npcFrameCount[Type] = 3;

		NPCID.Sets.NPCBestiaryDrawModifiers value = new(0)
		{
			Velocity = 0.2f
		};
		NPCID.Sets.DebuffImmunitySets.Add(Type, new NPCDebuffImmunityData
		{
			SpecificallyImmuneTo = new int[] {
					BuffID.Poisoned,
					BuffID.Burning,
					Buffs.CompassionDebuff.ID
				}
		});
		NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
	}
	public override void OnHitPlayer(Player target, int damage, bool crit)
	{
		if (Main.rand.Next(0, 5) > 2)
			return;

		target.AddBuff(Buffs.CompassionDebuff.ID, 60 * 25);
	}
	public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
	{
		if (Main.rand.Next(0, 5) > 2)
			return;

		target.AddBuff(Buffs.CompassionDebuff.ID, 60 * 25);
	}
	public override void SetDefaults()
	{
		NPC.width = 22;
		NPC.height = 17;
		NPC.damage = 75;
		NPC.defense = 15;
		NPC.lifeMax = 750;
		NPC.HitSound = SoundID.NPCHit1;
		NPC.DeathSound = SoundID.NPCDeath1;
		NPC.value = 450f;
		NPC.knockBackResist = 0.25f;
		NPC.aiStyle = NPCAIStyleID.Slime;
		NPC.Size *= 1.25f; //IDK

		AIType = NPCID.BlueSlime;
		AnimationType = NPCID.ToxicSludge;
		Banner = Item.NPCtoBanner(NPCID.BlueSlime);
		BannerItem = Item.BannerToItem(Banner);
		SpawnModBiomes = new int[1] { ModContent.GetInstance<TheLaboratory>().Type };
	}

	public override void ModifyNPCLoot(NPCLoot npcLoot)
	{
		npcLoot.Add(ItemDropRule.Common(ItemID.Gel, 1, 1, 3));
		npcLoot.Add(ItemDropRule.NormalvsExpert(ItemID.Vitamins, 200, 100));
		npcLoot.Add(ItemDropRule.NormalvsExpert(ItemID.CatEars, 1000, 500)); // Lol
	}

	public override float SpawnChance(NPCSpawnInfo spawnInfo)
	{
		return (spawnInfo.Player.GetModPlayer<RenucationPlayer>().ZoneTheLaboratory ? 1 : 0) * 0.65f;
	}
	public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
	{
		bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				new FlavorTextBestiaryInfoElement("Mods.Renucation.BestiaryInfo.NekoSlime")
		});
	}
}
