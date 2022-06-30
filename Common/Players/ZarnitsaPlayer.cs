// The NiTiS-Dev licenses this file to you under the MIT license.
using Terraria.ModLoader.IO;

namespace Renucation.Common.Players;
public class ZarnitsaPlayer : ModPlayer
{
	public bool usedZarnitsa;
	private bool killed;

	public override void UpdateDead()
	{
		killed = true;
	}
	public override void PostUpdate()
	{
		if (killed && usedZarnitsa) //Restore full HP after death if Zarnitsa used
		{
			Player.statLife = Player.statLifeMax2;
			killed = false;
		}
	}
	public override void LoadData(TagCompound tag)
	{
		tag["usedZarnitsa"] = usedZarnitsa;
	}
	public override void SaveData(TagCompound tag)
	{
		usedZarnitsa = tag.GetBool("usedZarnitsa");
	}
}
