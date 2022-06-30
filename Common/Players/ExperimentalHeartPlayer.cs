// The NiTiS-Dev licenses this file to you under the MIT license.

using Renucation.Content.Items.Consumables;
using Terraria.ModLoader.IO;

namespace Renucation.Common.Players;
public class ExperimentalHeartPlayer : ModPlayer
{
	public int usedExperimentalHeart;
	public override void ResetEffects()
	{
		Player.statLifeMax2 += usedExperimentalHeart * ExperimentalHeart.LifePerOnce;
	}
	public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
	{
		ModPacket packet = Mod.GetPacket();
		packet.Write((byte)RenucationMod.MessageType.RenucationPlayerSyncPlayer);
		packet.Write((ushort)Player.whoAmI);
		packet.Write(usedExperimentalHeart);
		packet.Send(toWho, fromWho);
	}

	public override void SaveData(TagCompound tag)
	{
		tag["usedExperimentalHeart"] = usedExperimentalHeart;
	}

	public override void LoadData(TagCompound tag)
	{
		usedExperimentalHeart = tag.GetInt("usedExperimentalHeart");
	}
}
