// The NiTiS-Dev licenses this file to you under the MIT license.
using System;
using Terraria.ModLoader;

namespace Renucation.Common.Systems;
public class IntegrationSystem : ModSystem
{
	public override void PostSetupContent()
	{
		DoBossChecklistIntegration();
	}

	private void DoBossChecklistIntegration()
	{
		if (!ModLoader.TryGetMod("BossChecklist", out Mod bossChecklistMod))
		{
			return;
		}

		// For some messages, mods might not have them at release, so we need to verify when the last iteration of the method variation was first added to the mod, in this case 1.3.1
		// Usually mods either provide that information themselves in some way, or it's found on the github through commit history/blame
		if (bossChecklistMod.Version < new Version(1, 3, 1))
		{
			return;
		}

		// Add boss here <---------------------------------------------TODO
	}
}
