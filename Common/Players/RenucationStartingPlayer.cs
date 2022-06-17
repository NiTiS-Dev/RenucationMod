// The NiTiS-Dev licenses this file to you under the MIT license.

using Renucation.Content.Items.Accessories;
using Renucation.Content.Items.Armor;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace Renucation.Common.Players;
public class RenucationStartingPlayer : ModPlayer 
{
	public override IEnumerable<Item> AddStartingItems(bool mediumCoreDeath)
	{
		if (Player.name is "NiTiSon" or "NickName73" or "Navillaso")
		{
			return new Item[]
			{
				new Item(ModContent.ItemType<NickName73Wings>(), 1),
			};
		}

		return Array.Empty<Item>();
	}
}
