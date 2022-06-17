// The NiTiS-Dev licenses this file to you under the MIT license.

using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Renucation.Content.Items.Accessories;

[AutoloadEquip(EquipType.Wings)]
public class NickName73Wings : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("NickName73's Wings");
		Tooltip.SetDefault("ALWAYS WATCHING TO ME\n" + Language.GetTextValue("CommonItemTooltip.DevItem"));

		CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

		ArmorIDs.Wing.Sets.Stats[Item.wingSlot] = new WingStats(150, 7f);
	}
	public override void SetDefaults()
	{
		Item.width = 30;
		Item.height = 30;
		Item.vanity = false;
		Item.rare = ItemRarityID.Cyan;
		Item.accessory = true;
	}
}
