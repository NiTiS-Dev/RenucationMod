using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace Renucation.Common.Configs;

public class RenucationConfig : ModConfig
{
	public override ConfigScope Mode => ConfigScope.ServerSide;

	public static RenucationConfig Instance => ModContent.GetInstance<RenucationConfig>();

	[Header("$Mods.Renucation.Config.CraftsHeader")]
	[Label("$Mods.Renucation.Config.WaterBootsCraft.Label")]
	[Tooltip("$Mods.Renucation.Config.WaterBootsCraft.Tooltip")]
	[DefaultValue(true)]
	[ReloadRequired]
	public bool EnableWaterBotsCraft;

	[Header("$Mods.Renucation.Config.WorldGenHeader")]
	[Label("$Mods.Renucation.Config.INDEVGEN.Label")]
	[Tooltip("$Mods.Renucation.Config.INDEVGEN.Tooltip")]
	[DefaultValue(false)]
	public bool EnableINDEVGeneration;
}