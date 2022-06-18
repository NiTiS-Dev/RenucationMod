// The NiTiS-Dev licenses this file to you under the MIT license.
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace Renucation.Content.Rarities;

/// <summary>
/// Rarity of all laboratory items (exclude some drops and tiles)
/// </summary>
public class LaboratoryRarity : ModRarity
{
	public static int ID => ModContent.RarityType<LaboratoryRarity>();

	public override Color RarityColor => new(139, 65, 242);

	public override int GetPrefixedRarity(int offset, float valueMult)
	{
		if (offset > 1)
		{
			return ItemRarityID.Lime;
		}
		else if (offset < -1)
		{
			return ItemRarityID.LightPurple;
		}
		else return Type;
	}
}
