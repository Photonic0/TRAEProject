
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace TRAEProject
{
    public static class QwertysMovementRemix
    {
        public static bool active = true;
    }
    //comment out everything below this to turn off my changes
    public class PlayerChanges : ModPlayer
    {
        public bool hasCap = true;
        public bool hasCapVertical = true;
        bool forcedAntiGravity = false;
        public override void ResetEffects()
        {
            hasCap = true;
            hasCapVertical = true;
            forcedAntiGravity = false;
        }
        public override void PostUpdateBuffs()
        {
            if(Player.gravControl && Player.velocity.Y != 0)
            {
                if(Player.gravDir == 1)
                {
                    Player.gravControl = false;
                }
                else
                {
                    forcedAntiGravity = true;
                }
            }
        }
        public override void PostUpdateEquips()
        {
            if(Player.slowFall)
            {
                Player.gravControl = false;
                Player.gravControl2 = false;
            }
            if(Player.slowFall && Player.velocity.Y < 0)
            {
                Player.slowFall = false;
            }
            Player.runAcceleration *= 1.5f;
            Player.noFallDmg = true;
            if(Player.wingsLogic == 45)
            {
                hasCap = false;
                hasCapVertical = false;
            }
            //Main.NewText(Player.dashDelay + ", " + Player.dashTime);
            if(Player.dashDelay == -1)
            {
                hasCap = false;
            }
            if (Player.wingsLogic == 37 && Player.TryingToHoverDown)
            {
                Player.runAcceleration *= 2;
                Player.runSlowdown *= 2;
                Player.moveSpeed += 1.25f;
            }
            if (Player.wingsLogic == 22 && Player.TryingToHoverDown)
            {
                Player.runAcceleration *= 2;
                Player.runSlowdown *= 2;
                Player.moveSpeed += 1.25f;
            }
        }
        public override void PostUpdate()
        {
            if(forcedAntiGravity)
            {
                Player.gravDir = -1;
            }
        }
    }
    public class WingChanges : GlobalItem
    {
        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            switch(item.type)
            {
                case ItemID.FrozenWings:
                case ItemID.HarpyWings:
                case ItemID.FairyWings:
                case ItemID.AngelWings:
                case ItemID.DemonWings:
                player.moveSpeed += 0;
                break;
                case ItemID.FinWings:
                player.moveSpeed += 0;
                player.ignoreWater = true;
                break;
                case ItemID.FlameWings:
                case ItemID.ButterflyWings:
                case ItemID.BeeWings:
                case ItemID.BatWings:
                player.moveSpeed += 0.25f;
                break;
                case ItemID.BoneWings:
                case ItemID.GhostWings:
                case ItemID.BeetleWings:
                case ItemID.BetsyWings:
                player.moveSpeed += 0.5f;
                break;
                case ItemID.TatteredFairyWings:
                player.wingTime = player.wingTimeMax;
                player.moveSpeed += 0.5f;
                break;
                case ItemID.FestiveWings:
                case ItemID.RainbowWings:
                case ItemID.FishronWings:
                case ItemID.MothronWings:
                player.moveSpeed += 0.75f;
                break;
                case ItemID.SpookyWings:
                player.moveSpeed += 1.0f;
                break;
            }
        }
        public static void PostProcessChanges(Player player)
        {
            player.accRunSpeed = 3;
            player.wingTimeMax *= 2;
            //Main.NewText("WingMax: " + Player.wingTimeMax);
            //Main.NewText("WingTime: " + Player.wingTime);
        }
        public override bool WingUpdate(int wings, Player player, bool inUse)
        {
            
            return base.WingUpdate(wings, player, inUse);
        }
        public override void HorizontalWingSpeeds(Item item, Player player, ref float speed, ref float acceleration)
        {
             //Main.NewText(speed);
             speed = 6.75f;
        }
        public override void VerticalWingSpeeds(Item item, Player player, ref float ascentWhenFalling, ref float ascentWhenRising, ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            //Main.NewText(maxAscentMultiplier);
            //Main.NewText(constantAscend);
            
			player.velocity.Y -= 0.2f * player.gravDir;
            switch(item.type)
            {
                case ItemID.FrozenWings:
                case ItemID.HarpyWings:
                case ItemID.FairyWings:
                case ItemID.AngelWings:
                case ItemID.DemonWings:
                case ItemID.FinWings:
                case ItemID.FlameWings:
                case ItemID.ButterflyWings:
                case ItemID.BeeWings:
                case ItemID.BatWings:
                maxAscentMultiplier -= 0.3333f;
                //36mph
                break;
                case ItemID.BoneWings:
                case ItemID.GhostWings:
                case ItemID.BeetleWings:
                case ItemID.MothronWings:
                maxAscentMultiplier -= 0.3333f;
                //41mph
                break;
                case ItemID.TatteredFairyWings:
                maxAscentMultiplier -= 0.3333f * 1.5f;
                //40mph
                break;
                case ItemID.FestiveWings:
                maxAscentMultiplier -= 0.3333f;
                //45mph
                break;
                case ItemID.FishronWings:
                case ItemID.BetsyWings:
                maxAscentMultiplier -= 1f;
                //46mph
                break;
                case ItemID.RainbowWings:
                maxAscentMultiplier -= 1f;
                //54mph
                break;
                case ItemID.SpookyWings:
                maxAscentMultiplier -= 0.3333f;
                //45mph
                break;
            }
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            switch (item.type)
            {           
                
                case ItemID.FlameWings:
                case ItemID.ButterflyWings:
                case ItemID.BeeWings:
                case ItemID.BatWings:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text += "\nIncreases horizontal speed by 5mph";
                        }
                    }
                    break;
                case ItemID.BoneWings:
                case ItemID.GhostWings:
                case ItemID.BeetleWings:
                foreach (TooltipLine line in tooltips)
                {
                    if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                    {
                        line.Text += "\nIncreases horizontal speed by 10mph";
                    }
                }
                break;
                case ItemID.TatteredFairyWings:
                foreach (TooltipLine line in tooltips)
                {
                    if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                    {
                        line.Text += "\nIncreases horizontal speed by 10mph\nInfinite flight time";
                    }
                }
                break;
                case ItemID.FishronWings:
                foreach (TooltipLine line in tooltips)
                {
                    if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                    {
                        line.Text += "\nIncreases horizontal speed by 15mph\nHold down to fall faster";
                    }
                }
                break;
                case ItemID.BetsyWings:
                foreach (TooltipLine line in tooltips)
                {
                    if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                    {
                        line.Text += "\nIncreases horizontal speed by 10mph\nHold down to hover for much faster speed";
                    }
                }
                break;
                case ItemID.RainbowWings:
                case ItemID.MothronWings:
                foreach (TooltipLine line in tooltips)
                {
                    if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                    {
                        line.Text += "\nIncreases horizontal speed by 15mph";
                    }
                }
                break;
                case ItemID.SpookyWings:
                foreach (TooltipLine line in tooltips)
                {
                    if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                    {
                        line.Text += "\nIncreases horizontal speed by 20mph";
                    }
                }
                break;
                case ItemID.FinWings:
                foreach (TooltipLine line in tooltips)
                {
                    if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                    {
                        line.Text += "\nImproves movement in liquids";
                    }
                }
                break;
                case ItemID.BlueHorseshoeBalloon:
                case ItemID.WhiteHorseshoeBalloon:
                case ItemID.YellowHorseshoeBalloon:
                case ItemID.BalloonHorseshoeFart:
                case ItemID.BalloonHorseshoeSharkron:
                foreach (TooltipLine line in tooltips)
                {
                    if (line.Mod == "Terraria" && line.Name == "Tooltip1")
                    {
                        line.Text = "Increases jump height/nAllows fast fall and gravity control";
                    }
                }
                break;

            }
        }
    }
    class MountChanges : ModPlayer
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }
        public override void PostUpdateRunSpeeds()
        {
            WingChanges.PostProcessChanges(Player);

            Player.runSlowdown += 0.3f;
            //Main.NewText("AccRunSpeed: " + Player.accRunSpeed);
            //Main.NewText("Acceleration: " + Player.runAcceleration);
            //Main.NewText("Deceleration: " + Player.runSlowdown);
            //Main.NewText("Movement Speed: " + Player.moveSpeed);
            //Main.NewText("Jump Speed: " + Player.jumpSpeedBoost);
            //Main.NewText("Jump Height: " + Player.jumpHeight);
            
            //nerfed to ~52mph
            if (Player.mount.Type == MountID.SpookyWood || Player.mount.Type == MountID.Unicorn || Player.mount.Type == MountID.WallOfFleshGoat)
            {
                Player.accRunSpeed = 10.2f;
                if(Math.Abs(Player.velocity.X) > Player.accRunSpeed)
                {
                    Player.velocity.X = Math.Sign(Player.velocity.X) * (Player.accRunSpeed-Player.runAcceleration - 0.2f);
                }
            }

            //Nerfed max horizontal speed to ~30mph
            //Improved jumping ability WHY IS A BUNNY SO BAD AT JUMPING
            //Gave it a double jump
            //Improved acceration
            if(Player.mount.Type == MountID.Bunny)
            {
                Player.accRunSpeed = 6;
                Player.runAcceleration = 0.3f;
                Player.jumpHeight = 10;
                Player.jumpSpeed *= 1.4f;
            }

            //max speed reduced to ~40mph
            //acceleration improved significantly
            if(Player.mount.Type == MountID.Pigron)
            {
                Player.accRunSpeed = 8;
                Player.runAcceleration = 0.25f;
            }

            //max speed reduced to ~45mph
            //acceleration improved significantly
            if(Player.mount.Type == MountID.Rudolph)
            {
                Player.accRunSpeed = 9;
                Player.runAcceleration = 0.35f;
            }
            
            //max speed nerfed to ~33mph
            if(Player.mount.Type == MountID.GolfCartSomebodySaveMe)
            {
                float maxSpeed  = 6.5f;
                if(Math.Abs(Player.velocity.X) > maxSpeed)
                {
                    Player.velocity.X = Math.Sign(Player.velocity.X) * (maxSpeed-Player.runAcceleration);
                }
            }

            //infinite flight, reduced top speed to ~35mph
            if(Player.mount.Type == MountID.DarkMageBook)
            {
                Player.mount.ResetFlightTime(Player.velocity.X);
                float infinimountMax  = 7;
                if(Math.Abs(Player.velocity.X) > infinimountMax)
                {
                    Player.velocity.X = Math.Sign(Player.velocity.X) * (infinimountMax-Player.runAcceleration);
                }
            }

            //infiniflight mounts
            //nerfed speed to ~25mph horizontal and vertical, now has infinite flight
            if (Player.mount.Type == MountID.Bee)
            {
                Player.mount.ResetFlightTime(Player.velocity.X);
                float infinimountMax  = 5;
                if(Math.Abs(Player.velocity.X) > infinimountMax)
                {
                    Player.velocity.X = Math.Sign(Player.velocity.X) * (infinimountMax-Player.runAcceleration);
                }
                if(Math.Abs(Player.velocity.Y) > infinimountMax)
                {
                    Player.velocity.Y = Math.Sign(Player.velocity.Y) * (infinimountMax-Player.runAcceleration);
                }
            }

            //nerfed speed to ~30mph horizontal and vertical, improved acceleration
            if (Player.mount.Type == MountID.PirateShip)
            {
                float infinimountMax  = 6;
                Player.runAcceleration = 0.16f;
                if(Math.Abs(Player.velocity.X) > infinimountMax)
                {
                    Player.velocity.X = Math.Sign(Player.velocity.X) * (infinimountMax-Player.runAcceleration);
                }
                if(Math.Abs(Player.velocity.Y) > infinimountMax)
                {
                    Player.velocity.Y = Math.Sign(Player.velocity.Y) * (infinimountMax-Player.runAcceleration);
                }
            }
            //nerfed to ~35mph horizontal and vertical max speed
            if (Player.mount.Type == MountID.UFO || Player.mount.Type == MountID.WitchBroom || Player.mount.Type == MountID.CuteFishron)
            {
                float infinimountMax  = 7;
                if(Player.mount.Type == MountID.CuteFishron)
                {
                    Player.runAcceleration = 0.16f;
                    if(Player.controlUp || Player.controlJump)
                    {
                        Player.velocity.Y -= 0.1f;
                    }
                    else if(Player.controlDown)
                    {
                        Player.velocity.Y += 0.1f;
                    }
                }
                if(Math.Abs(Player.velocity.X) > infinimountMax)
                {
                    Player.velocity.X = Math.Sign(Player.velocity.X) * (infinimountMax-Player.runAcceleration);
                }
                if(Math.Abs(Player.velocity.Y) > infinimountMax)
                {
                    Player.velocity.Y = Math.Sign(Player.velocity.Y) * (infinimountMax-Player.runAcceleration);
                }
            }




            //52mph is the max horizontal velocity the player can obtain
            if(Player.GetModPlayer<PlayerChanges>().hasCap)
            {
                float maxSpeedAllowed = 10.2f;
                if(Math.Abs(Player.velocity.X) > maxSpeedAllowed)
                {
                    Player.velocity.X = Math.Sign(Player.velocity.X) * (maxSpeedAllowed-Player.runAcceleration);
                }
            }

            //56mph is the max vertical velocity the player can obtain
            if(Player.GetModPlayer<PlayerChanges>().hasCapVertical)
            {
                float vMaxSpeedAllowed = 11f;
                if(Math.Abs(Player.velocity.Y) > vMaxSpeedAllowed)
                {
                    Player.velocity.Y = Math.Sign(Player.velocity.Y) * (vMaxSpeedAllowed);
                }
            }
        }
        public override void PostUpdateEquips()
        {
            if(Player.mount.Type == MountID.Bunny)
            {
                Player.hasJumpOption_Cloud = true;
            }
        }
    }
}