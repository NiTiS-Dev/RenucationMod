// The NiTiS-Dev licenses this file to you under the MIT license.

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Renucation.Content.Items.Armor;
public class NickName73Helmet : ModItem
{
	public override void SetStaticDefaults()
	{
		SacrificeTotal = 3;
		ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = false;
	}
	public override void SetDefaults()
	{
		Item.width = 18;
		Item.height = 18;
		Item.value = Item.sellPrice(gold: 1);
		Item.vanity = false;
		Item.rare = ItemRarityID.Cyan;
	}
}
