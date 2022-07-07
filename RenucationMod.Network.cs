// The NiTiS-Dev licenses this file to you under the MIT license.
using Renucation.Common.Players;
using Renucation.Content.Tiles;
using System.IO;
using Terraria;

namespace Renucation;

public partial class RenucationMod
{
	internal enum MessageType : byte
	{
		RenucationPlayerSyncPlayer = 0,
		RenucationZarnitsaSyncPlayer = 1,
		RenucationBlockSpread = 2,
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
			case MessageType.RenucationZarnitsaSyncPlayer:
				ushort who = reader.ReadUInt16();
				ZarnitsaPlayer zarnitsaPlayer = Main.player[who].GetModPlayer<ZarnitsaPlayer>();

				if (reader.ReadBoolean())
					zarnitsaPlayer.EnableZarnitsa();
				else
					zarnitsaPlayer.DisableZarnitsa();

				break;
			case MessageType.RenucationBlockSpread:
				int i, j;
				i = reader.ReadInt32();
				j = reader.ReadInt32();

				Main.tile[i, j].TileType = DioliteOre.ShortID;

				break;
			default:
				Logger.WarnFormat("Renucation: Unknown Message type: {0}", msgType);
				break;
		}
	}
}