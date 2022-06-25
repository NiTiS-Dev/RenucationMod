// The NiTiS-Dev licenses this file to you under the MIT license.
using Microsoft.Xna.Framework;
using System.Diagnostics;
using Terraria.WorldBuilding;

namespace Renucation.WorldBuilding;
public static class RenuShapes
{
	public class Meteor : GenShape
	{
		private uint sizeX, sizeY;
		private float activity;
		public Meteor(uint sizeX, uint sizeY) : this(sizeX, sizeY, 0.5f) { }
		public Meteor(uint sizeX, uint sizeY, float activity)
		{
			this.sizeX = sizeX;
			this.sizeY = sizeY;
			this.activity = activity;
		}

		[DebuggerStepThrough] // AAAAAA (special for debug)
		private float Next() =>
			_random.NextFloat();
		[DebuggerStepThrough]
		private uint Next(uint max) =>
			(uint)_random.Next(0, (int)max);

		public override bool Perform(Point origin, GenAction action)
		{
			bool[,] pool = new bool[this.sizeX, this.sizeY];

			float backActivity = 1 - this.activity;

			uint halfY = this.sizeY / 2;

			uint hY = halfY,
				 lY = halfY - 1;

			pool[0, halfY] = true;

			float progressLimitH = (Next() / 5) + activity;
			float progressLimitL = (Next() / 5) + backActivity;

			for (int stepX = 1; stepX < this.sizeX; stepX++)
			{
				float progressX = stepX / (float)this.sizeX;

				if (progressX < progressLimitH) //Grow
				{
					if (Next() > backActivity) hY += 0;
					else hY += 1;
				}
				else
				{
					if (Next() > backActivity) hY -= 0;
					else hY -= 1;
				}
				if (progressX < progressLimitL)
				{
					if (Next() > backActivity) lY -= 0;
					else lY -= 1;
				}
				else
				{
					if (Next() > backActivity) lY += 0;
					else lY += 1;
				}

				//Normalize
				if (hY > this.sizeY)
					hY = this.sizeY;
				if (lY > this.sizeY)
					lY = 0;

				for (uint pseudoY = 0; pseudoY < this.sizeY; pseudoY++)
				{
					if (lY == hY)
					{
						pool[stepX, lY] = true;
						break;
					}

					if (pseudoY >= lY && pseudoY <= hY)
					{
						pool[stepX, pseudoY] = true;
					}
				}
				Main.NewText($"[{stepX}]: {progressX}  H:{hY} L:{lY} ProgLimitH:{progressLimitH} ProgLimitL:{progressLimitL}");
			}



			for (int x = 0; x < this.sizeX; x++)
			{
				for (int y = 0; y < this.sizeY; y++)
				{
					if (pool[x, y])
						if (!UnitApply(action, origin, x + origin.X, y + origin.Y))
						{
							return false;
						}
				}
			}
			return true;
		}
	}
}
