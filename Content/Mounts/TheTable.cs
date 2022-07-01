﻿// The NiTiS-Dev licenses this file to you under the MIT license.

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.DataStructures;

namespace Renucation.Content.Mounts;
public class TheTable : ModMount
{
	public override void SetStaticDefaults()
	{
		// Movement
		MountData.jumpHeight = 12; // How high the mount can jump.
		MountData.acceleration = 0.19f; // The rate at which the mount speeds up.
		MountData.jumpSpeed = 4f; // The rate at which the player and mount ascend towards (negative y velocity) the jump height when the jump button is presssed.
		MountData.blockExtraJumps = false; // Determines whether or not you can use a double jump (like cloud in a bottle) while in the mount.
		MountData.constantJump = true; // Allows you to hold the jump button down.
		MountData.heightBoost = 20; // Height between the mount and the ground
		MountData.fallDamage = 0.5f; // Fall damage multiplier.
		MountData.runSpeed = 11f; // The speed of the mount
		MountData.dashSpeed = 8f; // The speed the mount moves when in the state of dashing.
		MountData.flightTimeMax = 60 * 3; // The amount of time in frames a mount can be in the state of flying.

		// Misc
		MountData.fatigueMax = 0;
		MountData.buff = ModContent.BuffType<Buffs.TheTableBuff>(); // The ID number of the buff assigned to the mount.

		// Effects
		MountData.spawnDust = DustID.TreasureSparkle; // The ID of the dust spawned when mounted or dismounted.

		// Frame data and player offsets
		MountData.totalFrames = 3; // Amount of animation frames for the mount
		MountData.playerYOffsets = Enumerable.Repeat(20, MountData.totalFrames).ToArray(); // Fills an array with values for less repeating code
		MountData.xOffset = 13;
		MountData.yOffset = 12;
		MountData.playerHeadOffset = -10;
		MountData.bodyFrame = 3;
		// Standing
		MountData.standingFrameCount = 1;
		MountData.standingFrameDelay = 0;
		MountData.standingFrameStart = 0;
		// Running
		MountData.runningFrameCount = 2;
		MountData.runningFrameDelay = 22;
		MountData.runningFrameStart = 0;
		// Flying
		MountData.flyingFrameCount = 2;
		MountData.flyingFrameDelay = 22;
		MountData.flyingFrameStart = 0;
		// In-air
		MountData.inAirFrameCount = 2;
		MountData.inAirFrameDelay = 22;
		MountData.inAirFrameStart = 0;
		// Idle
		MountData.idleFrameCount = 1;
		MountData.idleFrameDelay = 0;
		MountData.idleFrameStart = 0;
		MountData.idleFrameLoop = true;
		// Swim
		MountData.swimFrameCount = MountData.inAirFrameCount;
		MountData.swimFrameDelay = MountData.inAirFrameDelay;
		MountData.swimFrameStart = MountData.inAirFrameStart;

		if (!Main.dedServ)
		{
			MountData.textureWidth = MountData.backTexture.Width() + 20;
			MountData.textureHeight = MountData.backTexture.Height();
		}
	}
	public override void SetMount(Player player, ref bool skipDust)
	{
		// This code bypasses the normal mount spawning dust and replaces it with our own visual.
		if (!Main.dedServ)
		{
			for (int i = 0; i < 16; i++)
			{
				Dust.NewDustPerfect(player.Center + new Vector2(80, 0).RotatedBy(i * Math.PI * 2 / 16f), MountData.spawnDust);
			}

			skipDust = true;
		}
	}
}
