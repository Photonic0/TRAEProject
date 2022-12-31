
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using Terraria.Audio;
using Terraria.GameContent.Shaders;
using Terraria.GameContent;

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
        public bool blizzardDash = false;
        bool performingBlizzardDash = false;
        public bool ankletAcc = false;
        public override void ResetEffects()
        {
            hasCap = false;
            hasCapVertical = false;
            forcedAntiGravity = false;
            blizzardDash = false;
            ankletAcc = false;
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
        void DoCommonDashHandle(out int dir, out bool dashing, Player.DashStartAction dashStartAction = null)
		{
			dir = 0;
			dashing = false;
			if (Player.dashTime > 0)
			{
				Player.dashTime--;
			}
			if (Player.dashTime < 0)
			{
				Player.dashTime++;
			}
			if (Player.controlRight && Player.releaseRight)
			{
				if (Player.dashTime > 0)
				{
					dir = 1;
					dashing = true;
					Player.dashTime = 0;
					Player.timeSinceLastDashStarted = 0;
					dashStartAction?.Invoke(dir);
				}
				else
				{
					Player.dashTime = 15;
				}
			}
			else if (Player.controlLeft && Player.releaseLeft)
			{
				if (Player.dashTime < 0)
				{
					dir = -1;
					dashing = true;
					Player.dashTime = 0;
					Player.timeSinceLastDashStarted = 0;
					dashStartAction?.Invoke(dir);
				}
				else
				{
					Player.dashTime = -15;
				}
			}
		}
        public override void PostUpdateRunSpeeds()
        {
            
        }
        int dashCount = -1;
        int dashCooldown = 0;
        public override void PreUpdateMovement()
        {
            if(skating)
            {
                Player.coldDash = true;
            }
        }
        int ornamentTimer = 0;
        public int crippleTimer = 0;

        [Obsolete]
        public override void PostHurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
            if (!Player.noKnockback)
            {
                crippleTimer = 60;
            }
        }
        bool skating = false;
        public override void PostUpdateEquips()
        {
            skating = false;
            
            //Main.NewText(Player.dashDelay + ", " + Player.dashTime + ", " + Player.dash+ ", " + Player.dashType);
            //Player.dashTime = 0;
            if (Player.dash == 99)
            {
                DoCommonDashHandle(out var dir, out var dashing);
                //Main.NewText(Player.dash);
                //Main.NewText("Dash Delay: " + Player.dashDelay + ", Dash Time: " + Player.dashTime);
                if (dashing && Player.velocity.Y == 0)
                {
                    Player.velocity.X = 10f * (float)dir;
                    Player.dashDelay = -1;
                    Point point = (Player.Center + new Vector2(dir * Player.width / 2 + 2, Player.gravDir * (float)(-Player.height) / 2f + Player.gravDir * 2f)).ToTileCoordinates();
                    Point point2 = (Player.Center + new Vector2(dir * Player.width / 2 + 2, 0f)).ToTileCoordinates();
                    if (WorldGen.SolidOrSlopedTile(point.X, point.Y) || WorldGen.SolidOrSlopedTile(point2.X, point2.Y))
                    {
                        Player.velocity.X /= 2f;
                    }
                    /*
                    for (int num18 = 0; num18 < 20; num18++)
                    {
                        int num19 = Dust.NewDust(new Vector2(Player.position.X, Player.position.Y), Player.width, Player.height, 31, 0f, 0f, 100, default(Color), 2f);
                        Main.dust[num19].position.X += Main.rand.Next(-5, 6);
                        Main.dust[num19].position.Y += Main.rand.Next(-5, 6);
                        Main.dust[num19].velocity *= 0.2f;
                        Main.dust[num19].scale *= 1f + (float)Main.rand.Next(20) * 0.01f;
                    }
                    int num20 = Gore.NewGore(new Vector2(Player.position.X + (float)(Player.width / 2) - 24f, Player.position.Y + (float)(Player.height / 2) - 34f), default(Vector2), Main.rand.Next(61, 64));
                    Main.gore[num20].velocity.X = (float)Main.rand.Next(-50, 51) * 0.01f;
                    Main.gore[num20].velocity.Y = (float)Main.rand.Next(-50, 51) * 0.01f;
                    Main.gore[num20].velocity *= 0.4f;
                    num20 = Gore.NewGore(new Vector2(Player.position.X + (float)(Player.width / 2) - 24f, Player.position.Y + (float)(Player.height / 2) - 14f), default(Vector2), Main.rand.Next(61, 64));
                    Main.gore[num20].velocity.X = (float)Main.rand.Next(-50, 51) * 0.01f;
                    Main.gore[num20].velocity.Y = (float)Main.rand.Next(-50, 51) * 0.01f;
                    Main.gore[num20].velocity *= 0.4f;
                    */
                }
                else if(dashing && blizzardDash && Player.canJumpAgain_Blizzard)
                {
                    Player.velocity.X = 18f * (float)dir;
                    Player.dashDelay = -1;
                    performingBlizzardDash = true;
                    Player.canJumpAgain_Blizzard = false;
                    Point point = (Player.Center + new Vector2(dir * Player.width / 2 + 2, Player.gravDir * (float)(-Player.height) / 2f + Player.gravDir * 2f)).ToTileCoordinates();
                    Point point2 = (Player.Center + new Vector2(dir * Player.width / 2 + 2, 0f)).ToTileCoordinates();
                    if (WorldGen.SolidOrSlopedTile(point.X, point.Y) || WorldGen.SolidOrSlopedTile(point2.X, point2.Y))
                    {
                        Player.velocity.X /= 2f;
                    }
					SoundEngine.PlaySound(SoundID.DoubleJump, Player.Center);
                }
            }
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
                        case 99: //ice skates
                            if(performingBlizzardDash)
                            {
                                Player.moveSpeed += 0.4f;
                            }
                            Player.moveSpeed += 0.4f;
                            skating = true;
                            Player.armorEffectDrawShadow = false;
                            if(Player.velocity.Y == 0 && ((Math.Sign(Player.velocity.X) == -1 && Player.controlLeft) || (Math.Sign(Player.velocity.X) == 1 && Player.controlRight)))
                            {
                                dashCount = 120;
                            }
                            else if(dashCount > 30 && Player.velocity.Y == 0)
                            {
                                dashCount = 30;
                            }
                            if(Player.velocity.Y == 0)
                            {
                                performingBlizzardDash = false;
                            }
                            
                            break;
                    }
                    if(Player.dash == 99 && Player.velocity.Y != 0 && !performingBlizzardDash && ((Math.Sign(Player.velocity.X) == 1 && !Player.controlRight) || (Math.Sign(Player.velocity.X) == -1 && !Player.controlLeft)))
                    {
                        dashCount = 0;
                    }
                    if ((Math.Sign(Player.velocity.X) == 1 && Player.controlLeft) || (Math.Sign(Player.velocity.X) == -1 && Player.controlRight))
                    {
                        dashCount = 0;
                        Player.velocity.X = 0;
                    }
                    if(dashCooldown <=0)
                    {
                        dashCooldown = 1;
                    }
                    //Main.NewText(dashCount);
                }
                if (dashCount == 0)
                {
                    dashCount = -1;
                    Player.dashDelay = 0;
                    performingBlizzardDash = false;
                }
                if(performingBlizzardDash)
                {
                    int num12 = Player.height - 6;
                    if (Player.gravDir == -1f)
                    {
                        num12 = 6;
                    }
                    for (int k = 0; k < 2; k++)
                    {
                        int num13 = Dust.NewDust(new Vector2(Player.position.X, Player.position.Y + (float)num12), Player.width, 12, 76, Player.velocity.X * 0.3f, Player.velocity.Y * 0.3f);
                        Main.dust[num13].velocity *= 0.1f;
                        if (k == 0)
                        {
                            Main.dust[num13].velocity += Player.velocity * 0.03f;
                        }
                        else
                        {
                            Main.dust[num13].velocity -= Player.velocity * 0.03f;
                        }
                        Main.dust[num13].velocity -= Player.velocity * 0.1f;
                        Main.dust[num13].noGravity = true;
                        Main.dust[num13].noLight = true;
                    }
                    for (int l = 0; l < 3; l++)
                    {
                        int num14 = Dust.NewDust(new Vector2(Player.position.X, Player.position.Y + (float)num12), Player.width, 12, 76, Player.velocity.X * 0.3f, Player.velocity.Y * 0.3f);
                        Main.dust[num14].fadeIn = 1.5f;
                        Main.dust[num14].velocity *= 0.6f;
                        Main.dust[num14].velocity += Player.velocity * 0.8f;
                        Main.dust[num14].noGravity = true;
                        Main.dust[num14].noLight = true;
                    }
                    for (int m = 0; m < 3; m++)
                    {
                        int num15 = Dust.NewDust(new Vector2(Player.position.X, Player.position.Y + (float)num12), Player.width, 12, 76, Player.velocity.X * 0.3f, Player.velocity.Y * 0.3f);
                        Main.dust[num15].fadeIn = 1.5f;
                        Main.dust[num15].velocity *= 0.6f;
                        Main.dust[num15].velocity -= Player.velocity * 0.8f;
                        Main.dust[num15].noGravity = true;
                        Main.dust[num15].noLight = true;
                    }
                }
            }
            if (dashCooldown > 0)
            {
                Player.dashTime = 0;
                dashCooldown--;
            }
            
            if (Player.wingsLogic == 23)
            {
                ornamentTimer++;
                if (Player.velocity.Y != 0 && ornamentTimer % 40 == 0)
                {
                    Projectile.NewProjectile(Player.GetSource_ItemUse(Player.HeldItem), Player.Center, Vector2.UnitY * 2, ProjectileID.OrnamentFriendly, 50, 0, Player.whoAmI, -1);
                }
            }
            if (Player.slowFall || Player.GetModPlayer<TRAEProject.NewContent.Items.Accesories.ExtraJumps.TRAEJumps>().isBoosting)
            {
                Player.gravControl = false;
                Player.gravControl2 = false;
            }
            if (Player.slowFall && Player.velocity.Y < 0)
            {
                Player.slowFall = false;
            }
            if(Player.controlUp && !Player.gravControl && !Player.gravControl2 && Player.GetModPlayer<TRAEProject.NewContent.Items.Accesories.SpaceBalloon.SpaceBalloonPlayer>().SpaceBalloon > 0)
            {
                Player.slowFall = true;
            }
            int num39 = (int)(Player.position.Y / 16f) - Player.fallStart;
            if(Math.Abs(num39) > Player.extraFall + 25 + (Player.statLife / 20))
            {
                Player.extraFall += Math.Abs(num39) - (Player.extraFall + 25 + (Player.statLife / 20));
            }

            if(ankletAcc)
            {
                Player.runAcceleration *= 1.5f;
            }
            //Player.noFallDmg = true;
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
        int skateCounter = 0;
        public override void PostUpdate()
        {
            if(skating)
            {

                Player.armorEffectDrawShadow = false;
                skateCounter++;
                
                Player.runSoundDelay = 2;
                if(Player.velocity.Y == 0)
                {
                    //Main.NewText(Player.legFrameCounter);
                    //Player.legFrameCounter = 2;
                    //Main.NewText(Player.legFrame.Y);
                    int slideTime = 30;
                    int slideTrans = 10;
                    if(skateCounter %  ((slideTime+slideTrans)*2) < slideTime)
                    {
                        Player.legFrame.Y = Player.legFrame.Height * 6;
                    }
                    else if (skateCounter % ((slideTime+slideTrans)*2) < slideTime + slideTrans)
                    {
                        Player.legFrame.Y = Player.legFrame.Height * 7;
                    }
                    else if (skateCounter % ((slideTime+slideTrans)*2) < slideTime * 2 + slideTrans)
                    {
                        Player.legFrame.Y = Player.legFrame.Height * 12;
                    }
                    else
                    {
                        Player.legFrame.Y = Player.legFrame.Height * 13;
                    }

                    float rot = (float)Math.PI / 8f;
                    if(skateCounter % (slideTime+slideTrans) >=  slideTime)
                    {
                        rot = 0;
                    }
                    else if(skateCounter % ((slideTime+slideTrans)*2) > (slideTime+slideTrans))
                    {
                        rot = (float)Math.PI / -8f;
                    }
                    Player.SetCompositeArmBack(true, Player.CompositeArmStretchAmount.Full, -Player.direction * rot);
                    
                    if(Player.itemAnimation == 0)
                    {
                        
                        Player.bodyFrame.Y = 0;
                        Player.direction = Math.Sign(Player.velocity.X);
                        
                        Player.SetCompositeArmFront(true, Player.CompositeArmStretchAmount.Full, Player.direction * rot);
                    }
                    else
                    {
                        //Player.legFrame.Y = Player.legFrame.Height * 6;
                    }
                }
                else
                {
                    if (Player.miscCounter % 4 == 0 && Player.itemAnimation == 0 && !Player.sandStorm)
                    {
                        Player.direction = Player.miscCounter % 8 >= 4 ? 1 : -1;
                        if (Player.inventory[Player.selectedItem].holdStyle == 2)
                        {
                            if (Player.inventory[Player.selectedItem].type == 946 || Player.inventory[Player.selectedItem].type == 4707)
                            {
                                Player.itemLocation.X = Player.position.X + (float)Player.width * 0.5f - (float)(16 * Player.direction);
                            }
                            if (Player.inventory[Player.selectedItem].type == 186)
                            {
                                Player.itemLocation.X = Player.position.X + (float)Player.width * 0.5f + (float)(6 * Player.direction);
                                Player.itemRotation = 0.79f * (float)(-Player.direction);
                            }
                        }
                    }
				    Player.legFrameCounter = 0.0;
                    Player.legFrame.Y = 0;
                }
            }
            if (forcedAntiGravity)
            {
                Player.gravDir = -1;
            }
            Player.oldVelocity = Player.velocity;
        }
    }
    public class WingChanges : GlobalItem
    {
        public override void SetStaticDefaults()
        {
            int ph = 85;
            int eh = 160;
            int eh2 = 200;
            int pp = 230;
            int pp2 = 240;
            
            ArmorIDs.Wing.Sets.Stats[ArmorIDs.Wing.CreativeWings].FlyTime = ph;


            ArmorIDs.Wing.Sets.Stats[ArmorIDs.Wing.LeafWings].FlyTime = ph;
            ArmorIDs.Wing.Sets.Stats[ArmorIDs.Wing.DemonWings].FlyTime = eh;
            ArmorIDs.Wing.Sets.Stats[ArmorIDs.Wing.AngelWings].FlyTime = eh;
            ArmorIDs.Wing.Sets.Stats[ArmorIDs.Wing.FairyWings].FlyTime = eh2;
            ArmorIDs.Wing.Sets.Stats[ArmorIDs.Wing.FrozenWings].FlyTime = eh2;
            ArmorIDs.Wing.Sets.Stats[ArmorIDs.Wing.ButterflyWings].FlyTime = eh2;
            ArmorIDs.Wing.Sets.Stats[ArmorIDs.Wing.BeeWings].FlyTime = eh2;
            ArmorIDs.Wing.Sets.Stats[ArmorIDs.Wing.HarpyWings].FlyTime = eh2;
            ArmorIDs.Wing.Sets.Stats[ArmorIDs.Wing.FinWings].FlyTime = eh2;

            ArmorIDs.Wing.Sets.Stats[ArmorIDs.Wing.Jetpack].FlyTime = 30;

            ArmorIDs.Wing.Sets.Stats[ArmorIDs.Wing.CenxsWings].FlyTime = eh2;
            ArmorIDs.Wing.Sets.Stats[ArmorIDs.Wing.RedsWings].FlyTime = eh2;
            ArmorIDs.Wing.Sets.Stats[ArmorIDs.Wing.JimsWings].FlyTime = eh2;
            ArmorIDs.Wing.Sets.Stats[ArmorIDs.Wing.DTownsWings].FlyTime = eh2;
            ArmorIDs.Wing.Sets.Stats[ArmorIDs.Wing.Yoraiz0rsSpell].FlyTime = eh2;
            ArmorIDs.Wing.Sets.Stats[ArmorIDs.Wing.LazuresBarrierPlatform].FlyTime = eh2;
            ArmorIDs.Wing.Sets.Stats[ArmorIDs.Wing.FoodBarbarianWings].FlyTime = eh2;
            ArmorIDs.Wing.Sets.Stats[ArmorIDs.Wing.SafemanWings].FlyTime = eh2;
            ArmorIDs.Wing.Sets.Stats[ArmorIDs.Wing.LeinforsWings].FlyTime = eh2;
            ArmorIDs.Wing.Sets.Stats[ArmorIDs.Wing.CrownosWings].FlyTime = eh2;
            ArmorIDs.Wing.Sets.Stats[ArmorIDs.Wing.GhostarsWings].FlyTime = eh2;
            ArmorIDs.Wing.Sets.Stats[ArmorIDs.Wing.GroxTheGreatWings].FlyTime = eh2;
            ArmorIDs.Wing.Sets.Stats[ArmorIDs.Wing.LokisWings].FlyTime = eh2;
            ArmorIDs.Wing.Sets.Stats[ArmorIDs.Wing.SkiphssPaws].FlyTime = eh2;

            ArmorIDs.Wing.Sets.Stats[ArmorIDs.Wing.FlameWings].FlyTime = eh2;


            ArmorIDs.Wing.Sets.Stats[ArmorIDs.Wing.SpectreWings].FlyTime = pp;
            ArmorIDs.Wing.Sets.Stats[ArmorIDs.Wing.BoneWings].FlyTime = pp;
            ArmorIDs.Wing.Sets.Stats[ArmorIDs.Wing.Hoverboard].FlyTime = pp;
            ArmorIDs.Wing.Sets.Stats[ArmorIDs.Wing.SteampunkWings].FlyTime = pp;
            ArmorIDs.Wing.Sets.Stats[ArmorIDs.Wing.BeetleWings].FlyTime = pp;
            ArmorIDs.Wing.Sets.Stats[ArmorIDs.Wing.MothronWings].FlyTime = pp;

            ArmorIDs.Wing.Sets.Stats[ArmorIDs.Wing.FishronWings].FlyTime = pp2;
            ArmorIDs.Wing.Sets.Stats[ArmorIDs.Wing.SpookyWings].FlyTime = pp2;
            ArmorIDs.Wing.Sets.Stats[ArmorIDs.Wing.TatteredFairyWings].FlyTime = pp2;
            ArmorIDs.Wing.Sets.Stats[ArmorIDs.Wing.RainbowWings].FlyTime = pp2;
            ArmorIDs.Wing.Sets.Stats[ArmorIDs.Wing.FestiveWings].FlyTime = pp2;
            ArmorIDs.Wing.Sets.Stats[ArmorIDs.Wing.BetsyWings].FlyTime = pp2;

            ArmorIDs.Wing.Sets.Stats[ArmorIDs.Wing.SolarWings].FlyTime = pp2;
            ArmorIDs.Wing.Sets.Stats[ArmorIDs.Wing.StardustWings].FlyTime = pp2;
            ArmorIDs.Wing.Sets.Stats[ArmorIDs.Wing.NebulaMantle].FlyTime = pp2;
            ArmorIDs.Wing.Sets.Stats[ArmorIDs.Wing.VortexBooster].FlyTime = pp2;
        }
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
                    player.moveSpeed += 0.4f;
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
            //player.wingTimeMax += 60;
            //player.wingTimeMax *= 2;
            //Main.NewText("WingMax: " + player.wingTimeMax);
            Main.NewText("WingTime: " + player.wingTime + "/" +  player.wingTimeMax);
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
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if(item.wingSlot >= 0)
            {
                for(int i = 0; i < tooltips.Count; i++)
                {
                    if (tooltips[i].Mod == "Terraria" && tooltips[i].Name == "Tooltip0")
                    {
                        tooltips.Insert(i-1, new TooltipLine(Mod, "WingTime", "Flight Time: " +  ArmorIDs.Wing.Sets.Stats[item.wingSlot].FlyTime));
                        break;
                    }
                }
            }
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

            if (Player.GetModPlayer<PlayerChanges>().crippleTimer <= 0)
            {
            }
            else
            {
                Player.runAcceleration *= 0.5f;
                Player.runSlowdown *= 0.5f;
                Player.GetModPlayer<PlayerChanges>().crippleTimer--;
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