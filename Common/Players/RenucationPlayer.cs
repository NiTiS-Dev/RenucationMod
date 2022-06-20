// The NiTiS-Dev licenses this file to you under the MIT license.

using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Renucation.Common.Players;
public class RenucationPlayer : ModPlayer
{
	public int usedExperementalHeart;
	public bool ZoneTheLaboratory { get; set; }

	public override void ResetEffects()
	{
		Player.statLifeMax2 += usedExperementalHeart * 0;
	}

	public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
	{
		ModPacket packet = Mod.GetPacket();
		packet.Write((byte)RenucationMod.MessageType.RenucationPlayerSyncPlayer);
		packet.Write((byte)Player.whoAmI);
		packet.Write(usedExperementalHeart);
		packet.Send(toWho, fromWho);
	}

	public override void SaveData(TagCompound tag)
	{
		tag["usedExperementalHeart"] = usedExperementalHeart;
	}

	public override void LoadData(TagCompound tag)
	{
		usedExperementalHeart = (int)tag["usedExperementalHeart"];
	}
}
