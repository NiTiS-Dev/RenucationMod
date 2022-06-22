// The NiTiS-Dev licenses this file to you under the MIT license.

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

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
	public override void Update(NPC npc, ref int buffIndex)
	{
		npc.GetGlobalNPC<CompassionGlobalNPC>().underCompassionDebuff = true;
	}
}
public class CompassionGlobalNPC : GlobalNPC
{
	public bool underCompassionDebuff;
	public override bool InstancePerEntity => true;
	public override void ModifyHitNPC(NPC npc, NPC target, ref int damage, ref float knockback, ref bool crit)
	{
		if (underCompassionDebuff)
		{
			//damage = System.Math.Max(1, (int)(damage * 0.8f) );
			//knockback *= 0.8f;
			//crit = false;
			damage = 13;
			crit = false;
		}
	}
}
