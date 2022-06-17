// The NiTiS-Dev licenses this file to you under the MIT license.

using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Renucation.Content.Items.Armor;

[AutoloadEquip(EquipType.Head)]
public class NickName73Helmet : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("ALWAYS WATCHING TO ME\n" + Language.GetTextValue("CommonItemTooltip.DevItem"));
		SacrificeTotal = 1;

		ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = false;
	}
	public override void SetDefaults()
	{
		Item.width = 25;
		Item.height = 25;
		Item.vanity = false;
		Item.rare = ItemRarityID.Cyan;
	}
}
