// The NiTiS-Dev licenses this file to you under the MIT license.
using Renucation.Common.Players;
using System.IO;
using Terraria;

namespace Renucation;

public partial class RenucationMod
{
	internal enum MessageType : byte
	{
		RenucationPlayerSyncPlayer
	}

	public override void HandlePacket(BinaryReader reader, int whoAmI)
	{
		MessageType msgType = (MessageType)reader.ReadByte();

		switch (msgType)
		{
			case MessageType.RenucationPlayerSyncPlayer:
				ushort playernumber = reader.ReadUInt16();
				ExperimentalHeartPlayer renucationPlayer = Main.player[playernumber].GetModPlayer<ExperimentalHeartPlayer>();
				renucationPlayer.usedExperimentalHeart = reader.ReadInt32();
				break;
			default:
				Logger.WarnFormat("Renucation: Unknown Message type: {0}", msgType);
				break;
		}
	}
}