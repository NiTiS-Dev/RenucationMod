// The NiTiS-Dev licenses this file to you under the MIT license.
using System;

namespace Renucation.Content.Items.Debug;
public abstract class DebugItem : ModItem
{
	public abstract string ItemName { get; }
	public override string Texture => "Renucation/Content/Items/Debug/DebugItem";
	public override void SetStaticDefaults()
	{
		SacrificeTotal = Int32.MaxValue;
	}
	public override string Name => $"[Debug] {ItemName}";
}
