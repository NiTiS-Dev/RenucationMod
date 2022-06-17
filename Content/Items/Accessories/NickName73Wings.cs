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

		// These wings use the same values as the solar wings
		// Fly time: 180 ticks = 3 seconds
		// Fly speed: 9
		// Acceleration multiplier: 2.5
		ArmorIDs.Wing.Sets.Stats[Item.wingSlot] = new WingStats(150, 9f, 2.5f);
	}
	public override void SetDefaults()
	{
		Item.width = 22;
		Item.height = 20;
		Item.value = 10000;
		Item.rare = ItemRarityID.Green;
		Item.accessory = true;
	}
}
