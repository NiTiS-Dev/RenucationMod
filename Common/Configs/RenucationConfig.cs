using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace Renucation.Common.Configs;

public class RenucationConfig : ModConfig
{
	public override ConfigScope Mode => ConfigScope.ServerSide;

	[Header("$Mods.Renucation.Config.CraftsHeader")]
	[Label("$Mods.Renucation.Config.WaterBootsCraft.Label")]
	[Tooltip("$Mods.Renucation.Config.WaterBootsCraft.Tooltip")]
	[DefaultValue(true)]
	[ReloadRequired]
	public bool EnableWaterBotsCraft;
}