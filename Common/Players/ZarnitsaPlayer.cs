// The NiTiS-Dev licenses this file to you under the MIT license.
using Terraria.ModLoader.IO;

namespace Renucation.Common.Players;
public class ZarnitsaPlayer : ModPlayer
{
	private bool usedZarnitsa;
	public void EnableZarnitsa()
		=> usedZarnitsa = true;
	public void DisableZarnitsa()
		=> usedZarnitsa = false;
	public bool IsZarnitsaUsed
		=> usedZarnitsa;

	private bool killed;

	public override void UpdateDead()
	{
		killed = true;
	}
	public override void PostUpdate()
	{
		if (killed && IsZarnitsaUsed) //Restore full HP after death if Zarnitsa used
		{
			Player.statLife = Player.statLifeMax2;
			killed = false;
		}
	}
	public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
	{
		ModPacket packet = Mod.GetPacket();
		packet.Write((byte)RenucationMod.MessageType.RenucationZarnitsaSyncPlayer);
		packet.Write((ushort)Player.whoAmI);
		packet.Write(usedZarnitsa);
		packet.Send(toWho, fromWho);
	}
	public override void LoadData(TagCompound tag)
	{
		usedZarnitsa = tag.GetBool("usedZarnitsa");
	}
	public override void SaveData(TagCompound tag)
	{
		tag["usedZarnitsa"] = usedZarnitsa;
	}
}
