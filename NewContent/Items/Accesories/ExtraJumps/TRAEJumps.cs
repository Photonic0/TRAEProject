using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace TRAEProject.NewContent.Items.Accesories.ExtraJumps
{
    public class TRAEJumps : ModPlayer
    {
        public int boosterFlightTimeMax = 0;
        public int boosterFlightTime = 0;
        public const int boosterStartCost = 40;
        public const float boosterSpeedMultiplier = 1.6f;
		bool isBoosting = false;
		bool canStartBoosting = false;

		public override void ResetEffects()
        {
            boosterFlightTimeMax = 0;
        }
        void RestoreJumps()
        {
            boosterFlightTime = boosterFlightTimeMax;
			isBoosting = false;
			canStartBoosting = false;

		}
        void BlockVanillaJumps()
        {
            Player.canJumpAgain_Basilisk = false;
            Player.canJumpAgain_Blizzard = false;
            Player.canJumpAgain_Cloud = false;
            Player.canJumpAgain_Fart = false;
            Player.canJumpAgain_Sail = false;
            Player.canJumpAgain_Sandstorm = false;
            Player.canJumpAgain_Unicorn = false;
            Player.canJumpAgain_WallOfFleshGoat = false;
        }
		void RefreshVanillaJumps()
		{
			if (Player.hasJumpOption_Cloud)
			{
				Player.canJumpAgain_Cloud = true;
			}
			if (Player.hasJumpOption_Sandstorm)
			{
				Player.canJumpAgain_Sandstorm = true;
			}
			if (Player.hasJumpOption_Blizzard)
			{
				Player.canJumpAgain_Blizzard = true;
			}
			if (Player.hasJumpOption_Fart)
			{
				Player.canJumpAgain_Fart = true;
			}
			if (Player.hasJumpOption_Sail)
			{
				Player.canJumpAgain_Sail = true;
			}
			if (Player.hasJumpOption_Unicorn)
			{
				Player.canJumpAgain_Unicorn = true;
			}
			if (Player.hasJumpOption_Santank)
			{
				Player.canJumpAgain_Santank = true;
			}
			if (Player.hasJumpOption_WallOfFleshGoat)
			{
				Player.canJumpAgain_WallOfFleshGoat = true;
			}
			if (Player.hasJumpOption_Basilisk)
			{
				Player.canJumpAgain_Basilisk = true;
			}
		}
		public override void PreUpdateMovement()
        {
			if (Player.jump <= 0)
			{
				if (!Player.controlJump)
                {
					canStartBoosting = true;
                }
				//Main.NewText(boosterFlightTime + "/" + boosterFlightTimeMax);
				if (boosterFlightTime > 0)
				{
					BlockVanillaJumps();
					if (Player.controlJump && (canStartBoosting || boosterFlightTime < boosterFlightTimeMax))
					{
						if (isBoosting)
						{
							boosterFlightTime--;
							if(boosterFlightTime % 6 == 0)
                            {
								Puff();
                            }
						}
						else
						{
							boosterFlightTime -= boosterStartCost;
							isBoosting = true;
							Puff();
						}
						float dir = -(float)Math.PI / 2f; /*
						if (Player.controlRight && Player.controlUp)
						{
							dir = -(float)Math.PI / 4f;
						}
						else if (Player.controlUp && Player.controlLeft)
						{
							dir = -3 * (float)Math.PI / 4f;
						}
						else if (Player.controlDown && Player.controlLeft)
						{
							dir = 3 * (float)Math.PI / 4f;
						}
						else if (Player.controlDown && Player.controlRight)
						{
							dir = (float)Math.PI / 4f;
						}
						else */ if (Player.controlDown)
						{
							dir = (float)Math.PI / 2f;
						}
						else if (Player.controlRight && !Player.controlLeft)
						{
							dir = 0;
						}
						else if (!Player.controlRight && Player.controlLeft)
						{
							dir = (float)Math.PI;
						}
						Player.velocity = TRAEMethods.PolarVector(Terraria.Player.jumpSpeed * boosterSpeedMultiplier, dir);
						Player.velocity.Y += 1E-06f;
					}
					else
					{
						if (boosterFlightTime < boosterStartCost)
						{
							boosterFlightTime = 0;
						}
						else
						{
							isBoosting = false;
						}
					}
				}
				else if (isBoosting && Player.releaseJump)
				{
					RefreshVanillaJumps();
					isBoosting = false;
				}
			}
			else 
            {
				canStartBoosting = false;
            }
			base.PreUpdateMovement();
        }
        public override void PostUpdate()
		{
			if (Player.velocity.Y == 0 || Player.sliding)
			{
				RestoreJumps();
			}
		}
		void Puff()
        {
			for (int i = 0; i < 8; i++)
            {
				Vector2 pos = Player.Center + TRAEMethods.PolarVector(5, ((float)i / 8f) * 2 * (float)Math.PI);
				Dust d = Dust.NewDustPerfect(pos, DustID.Smoke);
				d.frame.Y = 0;
            }
			SoundEngine.PlaySound(SoundID.DoubleJump, Player.Center);
		}
    }
}
