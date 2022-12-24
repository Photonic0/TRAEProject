
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

        public static string SpeedTooltip(int pow)
        {
            return (pow * 5) + "%";
            //return (pow) + "mph";
        }
        public static string MS = "movement speed";

        /// <summary> percentage value for new default jump speed of 32</summary>
        public static float JSV(float v)
        {
            return (v * 5) * 1.28f;
        }
    }

    //comment out everything below this to turn off my changes
    public class TweakArmorMovespeed : GlobalItem
    {
        public override void UpdateEquip(Item item, Player player)
        {
            switch (item.type)
            {
                case ItemID.BeetleLeggings:
                    player.moveSpeed -= 0.01f;
                    break;
                case ItemID.ShroomiteLeggings:
                    player.moveSpeed += 0.18f;
                    break;
                case ItemID.SpectrePants:
                    player.moveSpeed += 0.02f;
                    break;
                case ItemID.HallowedGreaves:
                case ItemID.AncientHallowedGreaves:
                    player.moveSpeed += 0.02f;
                    break;
                case ItemID.TitaniumLeggings:
                    player.moveSpeed -= 0.01f;
                    break;
                case ItemID.OrichalcumLeggings:
                    player.moveSpeed += 0.09f;
                    break;
                case ItemID.BeetleScaleMail:
                    player.moveSpeed += 0.04f;
                    break;
            }
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            switch (item.type)
            {
                case ItemID.BeetleLeggings:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = "6% increased melee speed\n" + QwertysMovementRemix.SpeedTooltip(1) + " increased " + QwertysMovementRemix.MS;
                        }
                    }
                    break;
                case ItemID.ShroomiteLeggings:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.Text = QwertysMovementRemix.SpeedTooltip(6) + " increased " + QwertysMovementRemix.MS;
                        }
                    }
                    break;
                case ItemID.SpectrePants:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.Text = QwertysMovementRemix.SpeedTooltip(2) + " increased " + QwertysMovementRemix.MS;
                        }
                    }
                    break;
                case ItemID.HallowedGreaves:
                case ItemID.AncientHallowedGreaves:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.Text = QwertysMovementRemix.SpeedTooltip(2) + " increased " + QwertysMovementRemix.MS;
                        }
                    }
                    break;
                case ItemID.TitaniumLeggings:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.Text = QwertysMovementRemix.SpeedTooltip(1) + " increased " + QwertysMovementRemix.MS;
                        }
                    }
                    break;
                case ItemID.OrichalcumLeggings:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = QwertysMovementRemix.SpeedTooltip(4) + " increased " + QwertysMovementRemix.MS;
                        }
                    }
                    break;
                case ItemID.BeetleScaleMail:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.Text = "6% increased melee speed\n" + QwertysMovementRemix.SpeedTooltip(2) + " increased " + QwertysMovementRemix.MS;
                        }
                    }
                    break;
            }
        }
    }
    public class PlayerChanges : ModPlayer
    {
        public bool hasCap = true;
        public bool hasCapVertical = true;
        bool forcedAntiGravity = false;
        public override void ResetEffects()
        {
            hasCap = false;
            hasCapVertical = false;
            forcedAntiGravity = false;
        }
        public override void PostUpdateBuffs()
        {
            if (Player.gravControl && Player.velocity.Y != 0)
            {
                if (Player.gravDir == 1)
                {
                    Player.gravControl = false;
                }
                else
                {
                    forcedAntiGravity = true;
                }
            }
        }
        int dashCount = -1;
        int dashCooldown = 0;
        public override void PreUpdateMovement()
        {
            //Main.NewText(Player.dashDelay + ", " + Player.dashTime + ", " + Player.dash+ ", " + Player.dashType);
            //Player.dashTime = 0;
            if (Player.dashType != 2)
            {
                if (Player.dashDelay == -1 && dashCount == -1)
                {
                    dashCount = 30;
                    dashCooldown = 45;
                }
                if (dashCount > 0)
                {
                    dashCount--;
                    Player.dashDelay = -1;
                    switch (Player.dashType)
                    {
                        case 1: //tabi
                            Player.moveSpeed += 0.5f;
                            break;
                        case 2: //SoC
                            Player.moveSpeed += 0.1f;
                            break;
                        case 3: //Solar Shield
                            Player.moveSpeed += 1.5f;
                            break;
                        case 5: //Crystal
                            Player.moveSpeed += 0.5f;
                            break;
                    }
                    if ((Math.Sign(Player.velocity.X) == 1 && Player.controlLeft) || (Math.Sign(Player.velocity.X) == -1 && Player.controlRight))
                    {
                        dashCount = 0;
                        Player.velocity.X = 0;
                    }

                }
                if (dashCount == 0)
                {
                    dashCount = -1;
                    Player.dashDelay = 0;
                }
            }
            if (dashCooldown > 0)
            {
                Player.dashTime = 0;
                dashCooldown--;
            }
        }
        int ornamentTimer = 0;
        int crippleTimer = 0;

        [Obsolete]
        public override void PostHurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
            if (!Player.noKnockback)
            {
                crippleTimer = 60;
            }
        }
        public override void PostUpdateEquips()
        {
            if (Player.wingsLogic == 23)
            {
                ornamentTimer++;
                if (Player.velocity.Y != 0 && ornamentTimer % 40 == 0)
                {
                    Projectile.NewProjectile(Player.GetSource_ItemUse(Player.HeldItem), Player.Center, Vector2.UnitY * 2, ProjectileID.OrnamentFriendly, 50, 0, Player.whoAmI, -1);
                }
            }
            if (Player.slowFall)
            {
                Player.gravControl = false;
                Player.gravControl2 = false;
            }
            if (Player.slowFall && Player.velocity.Y < 0)
            {
                Player.slowFall = false;
            }
            if (crippleTimer <= 0)
            {
                Player.runAcceleration *= 1.5f;
            }
            else
            {
                crippleTimer--;
            }
            Player.noFallDmg = true;
            if (Player.wingsLogic == 45)
            {
                hasCap = false;
                hasCapVertical = false;
            }

            if (Player.wingsLogic == 30 && Player.TryingToHoverDown)
            {
                Player.runAcceleration /= 3;
                //Player.runSlowdown *= 2;
                Player.moveSpeed += 0.5f;
            }

            if (Player.wingsLogic == 37 && Player.TryingToHoverDown)
            {
                Player.runAcceleration /= 3;
                //Player.runSlowdown *= 2;
                Player.moveSpeed += 0.5f;
            }
            if (Player.wingsLogic == 22 && Player.TryingToHoverDown)
            {
                Player.runAcceleration /= 3;
                //Player.runSlowdown *= 2;
                Player.moveSpeed += 0.5f;
            }
            if (Player.wingsLogic == 45 && Player.TryingToHoverDown)
            {
                Player.runAcceleration /= 3;
                //Player.runSlowdown *= 2;
                Player.moveSpeed += 0.5f;
            }
        }
        public override void PostUpdate()
        {
            if (forcedAntiGravity)
            {
                Player.gravDir = -1;
            }
        }
    }
    public class WingChanges : GlobalItem
    {
        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            switch (item.type)
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
                    player.moveSpeed += 0.0f;
                    break;
                case ItemID.BetsyWings:
                    player.moveSpeed += 0.15f;
                    player.jumpSpeedBoost += QwertysMovementRemix.JSV(0.15f);
                    break;
                case ItemID.TatteredFairyWings:
                    player.wingTime = player.wingTimeMax;
                    player.moveSpeed += 0.15f;
                    player.jumpSpeedBoost += QwertysMovementRemix.JSV(0.15f);
                    break;
                case ItemID.FestiveWings:
                case ItemID.FishronWings:
                case ItemID.MothronWings:
                case ItemID.BoneWings:
                case ItemID.GhostWings:
                case ItemID.BeetleWings:
                case ItemID.SteampunkWings:
                    player.moveSpeed += 0.25f;
                    player.jumpSpeedBoost += QwertysMovementRemix.JSV(0.25f);
                    break;
                case ItemID.RainbowWings:
                    player.moveSpeed += 0.25f;
                    player.jumpSpeedBoost += QwertysMovementRemix.JSV(0.4f);
                    break;
                case ItemID.SpookyWings:
                    player.moveSpeed += 0.40f;
                    player.jumpSpeedBoost += QwertysMovementRemix.JSV(0.25f);
                    break;
                case ItemID.WingsSolar:
                    player.moveSpeed += 0.4f;
                    player.jumpSpeedBoost += QwertysMovementRemix.JSV(0.4f);
                    break;
                case ItemID.WingsStardust:
                    player.moveSpeed += 0.25f;
                    player.jumpSpeedBoost += QwertysMovementRemix.JSV(0.60f);
                    break;
                case ItemID.WingsNebula:
                    player.wingTime = player.wingTimeMax;
                    player.moveSpeed += 0.25f;
                    player.jumpSpeedBoost += QwertysMovementRemix.JSV(0.25f);
                    break;
                case ItemID.WingsVortex:
                    player.moveSpeed += 0.25f;
                    player.jumpSpeedBoost += QwertysMovementRemix.JSV(0.25f);
                    break;
                case ItemID.LongRainbowTrailWings:
                    player.moveSpeed += 1f;
                    player.jumpSpeedBoost += QwertysMovementRemix.JSV(1f);
                    break;
            }
        }
        public static void PostProcessChanges(Player player)
        {
            player.accRunSpeed = 3;
            player.wingTimeMax += 60;
            //player.wingTimeMax *= 2;
            //Main.NewText("WingMax: " + player.wingTimeMax);
            //Main.NewText("WingTime: " + player.wingTime);
        }
        public override bool WingUpdate(int wings, Player player, bool inUse)
        {
            return base.WingUpdate(wings, player, inUse);
        }
        public override void HorizontalWingSpeeds(Item item, Player player, ref float speed, ref float acceleration)
        {
            //Main.NewText(speed);
            //speed = 6.75f;
        }
        public override void VerticalWingSpeeds(Item item, Player player, ref float ascentWhenFalling, ref float ascentWhenRising, ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            //Main.NewText(maxAscentMultiplier);
            //Main.NewText(constantAscend);
            if (!player.TryingToHoverDown)
            {
                player.velocity.Y -= 0.2f * player.gravDir;
            }
            maxAscentMultiplier = 1f;
            /*
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
                case ItemID.SteampunkWings:
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
            */
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            switch (item.type)
            {
                case ItemID.BoneWings:
                case ItemID.GhostWings:
                case ItemID.BeetleWings:
                case ItemID.MothronWings:
                case ItemID.SteampunkWings:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text += "\nIncreases " + QwertysMovementRemix.MS + " and jump speed by " + QwertysMovementRemix.SpeedTooltip(5);
                        }
                    }
                    break;
                case ItemID.WingsNebula:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.Text = "";
                        }
                        if (line.Mod == "Terraria" && line.Name == "Tooltip2")
                        {
                            line.Text = "";
                        }
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text += "\nIncreases " + QwertysMovementRemix.MS + " and jump speed by " + QwertysMovementRemix.SpeedTooltip(5) + "\nInfinite flight time";
                        }
                    }
                    break;
                case ItemID.WingsSolar:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text += "\nIncreases " + QwertysMovementRemix.MS + " and jump speed by " + QwertysMovementRemix.SpeedTooltip(8);
                        }
                    }
                    break;
                case ItemID.WingsStardust:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text += "\nIncreases " + QwertysMovementRemix.MS + " by " + QwertysMovementRemix.SpeedTooltip(5) + " and jump speed by 60%";
                        }
                    }
                    break;
                case ItemID.WingsVortex:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text += "\nIncreases " + QwertysMovementRemix.MS + " and jump speed by " + QwertysMovementRemix.SpeedTooltip(5) + "\nHold down to hover for 50% more movement speed";
                        }
                    }
                    break;
                case ItemID.LongRainbowTrailWings:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text += "\nIncreases " + QwertysMovementRemix.MS + " and jump speed by " + QwertysMovementRemix.SpeedTooltip(20) + "\nHold down to hover for 50% more movement speed";
                        }
                    }
                    break;
                case ItemID.TatteredFairyWings:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text += "\nIncreases " + QwertysMovementRemix.MS + " and jump speed by " + QwertysMovementRemix.SpeedTooltip(3) + "\nInfinite flight time";
                        }
                    }
                    break;
                case ItemID.FishronWings:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text += "\nIncreases " + QwertysMovementRemix.MS + " and jump speed by " + QwertysMovementRemix.SpeedTooltip(5) + "\nHold down to fall faster";
                        }
                    }
                    break;
                case ItemID.Hoverboard:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text += "\nHold down to hover for 50% more movement speed";
                        }
                    }
                    break;
                case ItemID.BetsyWings:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text += "\nIncreases " + QwertysMovementRemix.MS + " by " + QwertysMovementRemix.SpeedTooltip(3) + "\nHold down to hover for 50% more movement speed";
                        }
                    }
                    break;
                case ItemID.RainbowWings:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text += "\nIncreases " + QwertysMovementRemix.MS + " by " + QwertysMovementRemix.SpeedTooltip(5) + " and jump speed by 40%";
                        }
                    }
                    break;
                case ItemID.SpookyWings:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text += "\nIncreases " + QwertysMovementRemix.MS + " by " + QwertysMovementRemix.SpeedTooltip(8) + " and jump speed by 25%";
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
            //WingChanges.PostProcessChanges(Player);

            Player.runSlowdown += 0.3f;
            float mountSpeedBonus = 1f;
            if(Player.GetModPlayer<TRAEProject.Changes.Accesory.MoveSpeed>().TRAEMagi)
            {
                mountSpeedBonus *= 1.15f;
            }
            //Main.NewText("AccRunSpeed: " + Player.accRunSpeed);
            //Main.NewText("Acceleration: " + Player.runAcceleration);
            //Main.NewText("Deceleration: " + Player.runSlowdown);
            //Main.NewText("Movement Speed: " + Player.moveSpeed);
            //Main.NewText("Jump Speed: " + Player.jumpSpeedBoost);
            //Main.NewText("Jump Height: " + Player.jumpHeight);
            
            //nerfed to ~52mph
            if (Player.mount.Type == MountID.SpookyWood || Player.mount.Type == MountID.Unicorn || Player.mount.Type == MountID.WallOfFleshGoat)
            {
                Player.accRunSpeed = 10.6f * mountSpeedBonus;
                if(Math.Abs(Player.velocity.X) > Player.accRunSpeed)
                {
                    Player.velocity.X = Math.Sign(Player.velocity.X) * (Player.accRunSpeed-Player.runAcceleration - 0.2f);
                }
            }
            //nerfed to 40mph
            if (Player.mount.Type == MountID.DarkHorse || Player.mount.Type == MountID.PaintedHorse || Player.mount.Type == MountID.MajesticHorse)
            {

                Player.accRunSpeed = 8f * mountSpeedBonus;
            }
            //Nerfed max horizontal speed to ~35mph
            if (Player.mount.Type == MountID.Basilisk)
            {
                Player.accRunSpeed = 7f * mountSpeedBonus;
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
                Player.accRunSpeed = 6 * mountSpeedBonus;
                Player.runAcceleration = 0.3f;
                Player.jumpHeight = 10;
                Player.jumpSpeed *= 1.4f;
            }

            //max speed reduced to ~35mph
            //acceleration improved significantly
            if(Player.mount.Type == MountID.Pigron)
            {
                Player.accRunSpeed = 7 * mountSpeedBonus;
                Player.runAcceleration = 0.25f;
                //Main.NewText(Player.mount.FlyTime);
                if((Player.controlUp || Player.controlJump) && Player.mount.FlyTime > 0)
                {
			        Player.velocity.Y -= 0.2f * Player.gravDir;
                }
                if(Player.velocity.Y < -7f)
                {
                    Player.velocity.Y = -7f;
                }
            }

            //max speed reduced to ~40mph
            //acceleration improved significantly
            if(Player.mount.Type == MountID.Rudolph)
            {
                Player.accRunSpeed = 8 * mountSpeedBonus;
                Player.runAcceleration = 0.35f;
                if((Player.controlUp || Player.controlJump) && Player.mount.FlyTime > 0)
                {
			        Player.velocity.Y -= 0.2f * Player.gravDir;
                }
            }
            
            //max speed nerfed to ~30mph
            if(Player.mount.Type == MountID.GolfCartSomebodySaveMe)
            {
                float maxSpeed  = 6f * mountSpeedBonus;
                if(Math.Abs(Player.velocity.X) > maxSpeed)
                {
                    Player.velocity.X = Math.Sign(Player.velocity.X) * (maxSpeed-Player.runAcceleration);
                }
            }

            //infinite flight, reduced top speed to ~35mph
            if(Player.mount.Type == MountID.DarkMageBook)
            {
                Player.mount.ResetFlightTime(Player.velocity.X);
                float infinimountMax  = 7 * mountSpeedBonus;
                if(Math.Abs(Player.velocity.X) > infinimountMax)
                {
                    Player.velocity.X = Math.Sign(Player.velocity.X) * (infinimountMax-Player.runAcceleration);
                }
            }

            //infiniflight mounts
            //nerfed speed to ~20mph horizontal and vertical, now has infinite flight
            if (Player.mount.Type == MountID.Bee)
            {
                Player.mount.ResetFlightTime(Player.velocity.X);
                float infinimountMax  = 4 * mountSpeedBonus;
                if(Math.Abs(Player.velocity.X) > infinimountMax)
                {
                    Player.velocity.X = Math.Sign(Player.velocity.X) * (infinimountMax-Player.runAcceleration);
                }
                if(Math.Abs(Player.velocity.Y) > infinimountMax)
                {
                    Player.velocity.Y = Math.Sign(Player.velocity.Y) * (infinimountMax-Player.runAcceleration);
                }
            }

            //nerfed speed to ~25mph horizontal and vertical, improved acceleration
            if (Player.mount.Type == MountID.PirateShip)
            {
                float infinimountMax  = 5 * mountSpeedBonus;
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
            //nerfed to ~30mph horizontal and vertical max speed
            if (Player.mount.Type == MountID.UFO || Player.mount.Type == MountID.WitchBroom || Player.mount.Type == MountID.CuteFishron)
            {
                float infinimountMax  = 6 * mountSpeedBonus;
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



            // removed speed cap for now
            /*
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
            */
            //Main.NewText("After: " + Player.accRunSpeed);
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