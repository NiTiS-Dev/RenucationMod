// The NiTiS-Dev licenses this file to you under the MIT license.

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Renucation.Content.Buffs.CompassionDebuff;

namespace Renucation.Content.Buffs;
public class CompassionDebuff : ModBuff
{
	public static int ID => ModContent.BuffType<CompassionDebuff>();
	public override void SetStaticDefaults()
	{
		Main.debuff[Type] = true;
		Main.buffNoSave[Type] = true;
		BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
	}
	public override void Update(Player player, ref int buffIndex)
	{
		player.GetModPlayer<CompassionModPlayer>().underCompassionDebuff = true;
	}
	public override void Update(NPC npc, ref int buffIndex)
	{
		npc.GetGlobalNPC<CompassionGlobalNPC>().underCompassionDebuff = true;
	}
	public static void Modify(ref int damage, ref bool crit)
	{
		damage = System.Math.Max(1, (int)(damage * 0.8f) );
		crit = false;
	}
	public static void Modify(ref int damage, ref float knockback, ref bool crit)
	{
		Modify(ref damage, ref crit);
		knockback *= 0.8f;
	}
}
public class CompassionModPlayer : ModPlayer
{
	public bool underCompassionDebuff;
	public override void ResetEffects()
	{
		underCompassionDebuff = false;
	}
	public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
	{
		if (underCompassionDebuff)
		{
			Modify(ref damage, ref knockback, ref crit);
		}
	}
	public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
	{
		if (underCompassionDebuff)
		{
			Modify(ref damage, ref knockback, ref crit);
		}
	}
}
public class CompassionGlobalNPC : GlobalNPC
{
	public bool underCompassionDebuff;
	public override bool InstancePerEntity => true;
	public override void ResetEffects(NPC npc)
	{
		underCompassionDebuff = false;
	}
	public override void ModifyHitNPC(NPC npc, NPC target, ref int damage, ref float knockback, ref bool crit)
	{
		if (underCompassionDebuff)
		{
			Modify(ref damage, ref knockback, ref crit);
		}
	}
	public override void ModifyHitPlayer(NPC npc, Player target, ref int damage, ref bool crit)
	{
		if (underCompassionDebuff)
		{
			Modify(ref damage, ref crit);
		}
	}
}
