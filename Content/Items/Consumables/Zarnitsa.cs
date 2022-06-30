// The NiTiS-Dev licenses this file to you under the MIT license.
namespace Renucation.Content.Items.Consumables;
public class Zarnitsa : ModItem
{
	public override string Texture => "Renucation/Content/Items/Debug/DebugItem";
	public override void SetStaticDefaults()
	{
		SacrificeTotal = 3;
	}
	public override void SetDefaults()
	{
		Item.width = 20;
		Item.height = 20;
		Item.maxStack = 1;
		Item.value = 2500;
		Item.rare = ItemRarityID.Cyan;
		Item.useAnimation = 30;
		Item.useTime = 30;
		Item.useStyle = ItemUseStyleID.HoldUp;
		Item.consumable = true;
	}
	public override bool? UseItem(Player player)
	{
		ZarnitsaPlayer playerz = player.GetModPlayer<ZarnitsaPlayer>();

		if (!playerz.usedZarnitsa)
		{
			playerz.usedZarnitsa = true;
			return true;
		}
		return false;
	}
}
