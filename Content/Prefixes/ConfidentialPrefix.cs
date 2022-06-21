// The NiTiS-Dev licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace Renucation.Content.Prefixes;
public class ConfidentialPrefix : ModPrefix
{
	public override PrefixCategory Category => PrefixCategory.Melee;

	public override float RollChance(Item item)
	{
		return 5f;
	}
	public override bool CanRoll(Item item)
	{
		return item.rare == Rarities.LaboratoryRarity.ID;
	}
	public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
	{
		damageMult *= 1.15f;
		knockbackMult *= 1.35f;

	}
	public override void ModifyValue(ref float valueMult)
	{
		valueMult *= 1.18f;
	}
}
