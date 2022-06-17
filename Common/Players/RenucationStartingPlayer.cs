// The NiTiS-Dev licenses this file to you under the MIT license.

using Renucation.Content.Items;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace Renucation.Common.Players;
public class RenucationStartingPlayer : ModPlayer 
{
	public override IEnumerable<Item> AddStartingItems(bool mediumCoreDeath)
	{
		if (Player.name is "NiTiSon" or "NickName73" or "Navillaso")
		yield return new Item(ModContent.ItemType<SoulofMech>(), 1);
	}
}
