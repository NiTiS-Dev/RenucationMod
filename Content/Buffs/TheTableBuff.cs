// The NiTiS-Dev licenses this file to you under the MIT license.
namespace Renucation.Content.Buffs;
public class TheTableBuff : ModBuff
{
	public override void SetStaticDefaults()
	{
		Main.buffNoTimeDisplay[Type] = true;
		Main.buffNoSave[Type] = true; 
	}

	public override void Update(Player player, ref int buffIndex)
	{
		player.mount.SetMount(ModContent.MountType<Mounts.TheTable>(), player);
		player.buffTime[buffIndex] = 10;
	}
}
