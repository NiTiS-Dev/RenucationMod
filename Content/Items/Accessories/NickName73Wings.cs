// The NiTiS-Dev licenses this file to you under the MIT license.

using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Renucation.Content.Items.Accessories;

[AutoloadEquip(EquipType.Wings)]
public class NickName73Wings : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("NickName73's Wings");
		Tooltip.SetDefault("ALWAYS WATCHING TO ME");

		CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

		// Fly time: 150 ticks = 2.5 seconds
		// Fly speed: 7
		ArmorIDs.Wing.Sets.Stats[Item.wingSlot] = new WingStats(150, 7f);
	}
	public override void SetDefaults()
	{
		Item.width = 22;
		Item.height = 20;
		Item.vanity = false;
		Item.rare = ItemRarityID.Cyan;
		Item.accessory = true;
	}
}
