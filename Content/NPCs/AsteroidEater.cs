// The NiTiS-Dev licenses this file to you under the MIT license.

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;

namespace Renucation.Content.NPCs;
public class AsteroidEaterHead : WormHead
{
	public override int BodyType => ModContent.NPCType<AsteroidEaterBody>();

	public override int TailType => ModContent.NPCType<AsteroidEaterTail>();

	public override void SetStaticDefaults()
	{
		NPCID.Sets.NPCBestiaryDrawModifiers drawModifier = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
		{
			//CustomTexturePath = "Renucation/Content/NPCs/AsteroidEater_Bestiary",
			Position = new Vector2(40f, 24f),
			PortraitPositionXOverride = 0f,
			PortraitPositionYOverride = 12f
		};
		NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, drawModifier);
	}
	public override void ModifyNPCLoot(NPCLoot npcLoot)
	{
		npcLoot.Add(ItemDropRule.Common(Items.Placeable.GalactiteStone.ID, 1, 1, 3));
	}

	public override float SpawnChance(NPCSpawnInfo spawnInfo)
	{
		return (spawnInfo.Player.GetModPlayer<RenucationPlayer>().ZoneMeteorBelt ? 1 : 0) * 0.15f;
	}
	public override void SetDefaults()
	{
		NPC.CloneDefaults(NPCID.DiggerHead);
		NPC.aiStyle = -1;
		CanFly = true;

		SpawnModBiomes = new int[1] { ModContent.GetInstance<Biomes.MeteorBelt>().Type };
		NPC.damage = 50;
		NPC.defense = 25;
		NPC.lifeMax = 1300;
	}

	public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
	{
		// We can use AddRange instead of calling Add multiple times in order to add multiple items at once
		bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {

				// Sets the description of this NPC that is listed in the bestiary.
				new FlavorTextBestiaryInfoElement("Mods.Renucation.BestiaryInfo.AsteroidEater")
			});
	}

	public override void Init()
	{
		// Set the segment variance
		// If you want the segment length to be constant, set these two properties to the same value
		MinSegmentLength = 6;
		MaxSegmentLength = 12;

		CommonWormInit(this);
	}

	internal static void CommonWormInit(Worm worm)
	{
		worm.MoveSpeed = 12.5f;
		worm.Acceleration = 0.145f;
	}

	private int attackCounter;
	public override void SendExtraAI(BinaryWriter writer)
	{
		writer.Write(attackCounter);
	}

	public override void ReceiveExtraAI(BinaryReader reader)
	{
		attackCounter = reader.ReadInt32();
	}

	public override void AI()
	{
		if (Main.netMode != NetmodeID.MultiplayerClient)
		{
			if (attackCounter > 0)
			{
				attackCounter--; // tick down the attack counter.
			}

			Player target = Main.player[NPC.target];
			// If the attack counter is 0, this NPC is less than 12.5 tiles away from its target, and has a path to the target unobstructed by blocks, summon a projectile.
			if (attackCounter <= 0 && Vector2.Distance(NPC.Center, target.Center) < 200 && Collision.CanHit(NPC.Center, 1, 1, target.Center, 1, 1))
			{
				Vector2 direction = (target.Center - NPC.Center).SafeNormalize(Vector2.UnitX);
				direction = direction.RotatedByRandom(MathHelper.ToRadians(10));

				int projectile = Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, direction * 1, ProjectileID.ShadowBeamHostile, 45, 2, Main.myPlayer);
				Main.projectile[projectile].timeLeft = 300;
				attackCounter = 120;
				NPC.netUpdate = true;
			}
		}
	}
}
public class AsteroidEaterBody : WormBody
{
	public override void SetStaticDefaults()
	{
		NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
		{
			Hide = true // Hides this NPC from the Bestiary, useful for multi-part NPCs whom you only want one entry.
		};
		NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);
	}

	public override void SetDefaults()
	{
		NPC.CloneDefaults(NPCID.DiggerBody);
		NPC.aiStyle = -1;
	}

	public override void Init()
	{
		AsteroidEaterHead.CommonWormInit(this);
	}
}

public class AsteroidEaterTail : WormTail
{
	public override void SetStaticDefaults()
	{
		NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
		{
			Hide = true // Hides this NPC from the Bestiary, useful for multi-part NPCs whom you only want one entry.
		};
		NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);
	}

	public override void SetDefaults()
	{
		NPC.CloneDefaults(NPCID.DiggerTail);
		NPC.aiStyle = -1;
	}

	public override void Init()
	{
		AsteroidEaterHead.CommonWormInit(this);
	}
}