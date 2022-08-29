using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.Audio;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria.Graphics.Shaders;

namespace TRAEProject.Changes.Accesory
{
    public class MoveSpeed : ModPlayer
    {
        public bool TRAEwaterwalk = false;
        public override void ResetEffects()
        {

            TRAEwaterwalk = false;
        }
        public override void PreUpdate()
        {
            Player.rocketTimeMax = 7; // without this Obsidian Hover Shoes permanently set it to 14          
   
        }
        void SpawnFastRunParticles()
        {
            int num = 0;
            if (Player.gravDir == -1f)
            {
                num -= Player.height;
            }
            if (Player.runSoundDelay == 0 && Player.velocity.Y == 0f)
            {
                SoundEngine.PlaySound(Player.hermesStepSound.Style, Player.position);
                Player.runSoundDelay = Player.hermesStepSound.IntendedCooldown;
            }
            if (Player.wings == 3)
            {
                int num2 = Dust.NewDust(new Vector2(Player.position.X - 4f, Player.position.Y + Player.height + num), Player.width + 8, 4, 186, (0f - Player.velocity.X) * 0.5f, Player.velocity.Y * 0.5f, 50, default(Color), 1.5f);
                Main.dust[num2].velocity *= 0.025f;
                Main.dust[num2].shader = GameShaders.Armor.GetSecondaryShader(Player.cWings, Player);
                num2 = Dust.NewDust(new Vector2(Player.position.X - 4f, Player.position.Y + Player.height + num), Player.width + 8, 4, 186, (0f - Player.velocity.X) * 0.5f, Player.velocity.Y * 0.5f, 50, default(Color), 1.5f);
                Main.dust[num2].velocity *= 0.2f;
                Main.dust[num2].shader = GameShaders.Armor.GetSecondaryShader(Player.cWings, Player);
            }
            else if (Player.sailDash)
            {
                for (int i = 0; i < 4; i++)
                {
                    int num3 = Dust.NewDust(new Vector2(Player.position.X - 4f, Player.position.Y), Player.width + 8, Player.height, 253, (0f - Player.velocity.X) * 0.5f, Player.velocity.Y * 0.5f, 100, default(Color), 1.5f);
                    Main.dust[num3].noGravity = true;
                    Main.dust[num3].velocity.X = Main.dust[num3].velocity.X * 0.2f;
                    Main.dust[num3].velocity.Y = Main.dust[num3].velocity.Y * 0.2f;
                    Main.dust[num3].shader = GameShaders.Armor.GetSecondaryShader(Player.cShoe, Player);
                    Main.dust[num3].scale += (float)Main.rand.Next(-5, 3) * 0.1f;
                    Vector2 vector = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
                    vector.Normalize();
                    vector *= (float)Main.rand.Next(81) * 0.1f;
                }
            }
            else if (Player.desertDash)
            {
                Dust dust = Dust.NewDustDirect(new Vector2(Player.position.X - 4f, Player.position.Y + Player.height + num), Player.width + 8, 4, 32, (0f - Player.velocity.X) * 0.5f, Player.velocity.Y * 0.5f);
                dust.velocity *= 0.2f;
                dust.velocity.Y -= Player.gravDir * 2f;
                dust.shader = GameShaders.Armor.GetSecondaryShader(Player.cShoe, Player);
            }
            else if (Player.coldDash)
            {
                for (int j = 0; j < 2; j++)
                {
                    int num4 = ((j != 0) ? Dust.NewDust(new Vector2(Player.position.X + (Player.width / 2), Player.position.Y + Player.height + Player.gfxOffY), Player.width / 2, 6, 76, 0f, 0f, 0, default(Color), 1.35f) : Dust.NewDust(new Vector2(Player.position.X, Player.position.Y + (float)Player.height + Player.gfxOffY), Player.width / 2, 6, 76, 0f, 0f, 0, default(Color), 1.35f));
                    Main.dust[num4].scale *= 1f + (float)Main.rand.Next(20, 40) * 0.01f;
                    Main.dust[num4].noGravity = true;
                    Main.dust[num4].noLight = true;
                    Main.dust[num4].velocity *= 0.001f;
                    Main.dust[num4].velocity.Y -= 0.003f;
                    Main.dust[num4].shader = GameShaders.Armor.GetSecondaryShader(Player.cShoe, Player);
                }
            }
            else if (Player.fairyBoots)
            {
                int type = Main.rand.NextFromList(new short[6] { 61, 61, 61, 242, 64, 63 });
                int alpha = 0;
                for (int k = 1; k < 3; k++)
                {
                    float scale = 1.5f;
                    if (k == 2)
                    {
                        scale = 1f;
                    }
                    int num5 = Dust.NewDust(new Vector2(Player.position.X - 4f, Player.position.Y + (float)Player.height + (float)num), Player.width + 8, 4, type, (0f - Player.velocity.X) * 0.5f, Player.velocity.Y * 0.5f, alpha, default(Color), scale);
                    Main.dust[num5].velocity *= 1.5f;
                    if (k == 2)
                    {
                        Main.dust[num5].position += Main.dust[num5].velocity;
                    }
                    Main.dust[num5].noGravity = true;
                    Main.dust[num5].noLightEmittence = true;
                    Main.dust[num5].shader = GameShaders.Armor.GetSecondaryShader(Player.cShoe, Player);
                }
            }
            else
            {
                int num7 = Dust.NewDust(new Vector2(Player.position.X - 4f, Player.position.Y + (float)Player.height + (float)num), Player.width + 8, 4, 16, (0f - Player.velocity.X) * 0.5f, Player.velocity.Y * 0.5f, 50, default(Color), 1.5f);
                Main.dust[num7].velocity.X = Main.dust[num7].velocity.X * 0.2f;
                Main.dust[num7].velocity.Y = Main.dust[num7].velocity.Y * 0.2f;
                Main.dust[num7].shader = GameShaders.Armor.GetSecondaryShader(Player.cShoe, Player);
            }
        }
        public override void PostUpdateEquips()
        {    
            if (TRAEwaterwalk)
            {
                Player.waterWalk = true;
                Player.waterWalk2 = true;
            }
            Player.jumpSpeedBoost += 1f;
            Player.moveSpeed *= 1.33f;
            if (Player.isPerformingJump_Sandstorm)
            {
                Player.moveSpeed *= 0.75f;
            }
            if (Player.accRunSpeed >= 4.8f)
            {
                if (Player.controlLeft && Player.velocity.X <= 0f - Player.accRunSpeed && Player.dashDelay >= 0)
                {
                    if (Player.velocity.X < 0 - Player.accRunSpeed && Player.velocity.Y == 0f && !Player.mount.Active)
                    {
                        SpawnFastRunParticles();
                    }
                }
                else if (Player.controlRight && Player.velocity.X >= Player.accRunSpeed && Player.dashDelay >= 0)
                {
                    if (Player.mount.Active && Player.mount.Cart)
                    {
                        if (Player.velocity.X > 0f)
                        {
                            Player.direction = -1;
                        }
                    }
                    if (Player.velocity.X > Player.accRunSpeed && Player.velocity.Y == 0f && !Player.mount.Active)
                    {
                        SpawnFastRunParticles();
                    }
                }
            }
        }
    }
    public class MobilityAccessories : GlobalItem
    {
        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            switch (item.type)
            {
                case ItemID.HermesBoots:
                case ItemID.FlurryBoots:
                case ItemID.SailfishBoots:
                    if (player.velocity.Y == 0)
                    {
                        player.moveSpeed += 0.25f;
                    }
					player.accRunSpeed = 4.8f;
                    return;
                case ItemID.SandBoots:
                    if (player.velocity.Y == 0)
                    {
                        player.moveSpeed += 0.25f;
                    }
                    player.desertBoots = false;
                    player.GetModPlayer<AccesoryEffects>().sandRunning = true;
                    return;
                case ItemID.FrogLeg:
                case ItemID.FrogWebbing:
                case ItemID.FrogFlipper:
                    player.frogLegJumpBoost = false;
                    player.extraFall += 15;
                    player.jumpSpeedBoost += 1.4f;
                    return;
                case ItemID.FrogGear:
                    player.frogLegJumpBoost = false;
                    player.accFlipper = true;
                    player.dashType = 1;
                    player.spikedBoots = 0;
                    player.extraFall += 15;
                    player.jumpSpeedBoost += 1.4f;
                    return;
                case ItemID.AmphibianBoots:
                    player.frogLegJumpBoost = false;
                    player.extraFall += 15;
                    
                    player.jumpSpeedBoost += 1.4f;
                    if (player.velocity.Y == 0)
                    {
                        player.moveSpeed += 0.25f;
                    }
                    player.accRunSpeed = 4.8f;
                    return;     
                case ItemID.Aglet:
                    player.moveSpeed += 0.05f;
                    return;
                case ItemID.AnkletoftheWind:
                    player.moveSpeed += 0.15f;
                    
                    return;
                case ItemID.IceSkates:
           	        player.runAcceleration *= 1.5f;
                    return;
                case ItemID.FrostsparkBoots:
                    player.rocketTimeMax -= 7;
                    player.accRunSpeed = 4.8f;
                    player.moveSpeed -= 0.08f; // get rid of the 8% move speed buff separately to not mess up future calcs 

                    player.GetModPlayer<AccesoryEffects>().icceleration = true;
                    if (player.velocity.Y == 0)
                    {
                        player.moveSpeed += 0.25f;
                    }
                    player.runAcceleration *= 1.5f;
                    return;
                case ItemID.TerrasparkBoots:
                    player.iceSkate = false;
                    player.lavaMax -= 42;
                    player.lavaRose = false;

                    player.fireWalk = false;
                    player.waterWalk = false;
                    player.accRunSpeed = 6f; 
                    player.moveSpeed -= 0.08f; // get rid of the 8% move speed buff separately to not mess up future calcs 
                    player.moveSpeed += 0.25f;
                    if (player.velocity.Y == 0)
                    {
                        player.moveSpeed += 0.25f;
                    }
                    player.dashType = 1;
                    return;
                case ItemID.LightningBoots:
                    player.moveSpeed -= 0.08f; // get rid of the 8% move speed buff separately to not mess up future calcs 
                    player.rocketTimeMax = 7;
                    player.accRunSpeed = 6f; 
                    player.moveSpeed += 0.25f;
                    if (player.velocity.Y == 0)
                    {
                        player.moveSpeed += 0.25f;
                    }
                    return;
                case ItemID.RocketBoots:
                    player.rocketTimeMax = 7;
                    return;
                case ItemID.FairyBoots:
                case ItemID.SpectreBoots:
                    player.rocketTimeMax = 7; 
                    player.accRunSpeed = 4.8f;
                    if (player.velocity.Y == 0)
                    {
                        player.moveSpeed += 0.25f;
                    }
                    return;
                case ItemID.ObsidianHorseshoe:
                    player.fireWalk = false;
                    player.GetModPlayer<AccesoryEffects>().FastFall = true;
                    return;
                case ItemID.ObsidianWaterWalkingBoots:
                    player.waterWalk2 = false;
                    player.rocketBoots = 1;
                    player.rocketTimeMax = 14;
                    player.GetModPlayer<AccesoryEffects>().FastFall = true;
                    player.noFallDmg = true;
                    player.fireWalk = false;
                    player.buffImmune[BuffID.Burning] = false;
                    return;
                case ItemID.BalloonHorseshoeHoney:
                case ItemID.HoneyBalloon:
                    player.lifeRegen += 2;
                    return;
                case ItemID.BundleofBalloons:
                    player.noFallDmg = true;
                    return;
                case ItemID.WaterWalkingBoots:
                    player.GetModPlayer<AccesoryEffects>().waterRunning = true;
                    player.GetModPlayer<MoveSpeed>().TRAEwaterwalk = true;
                    player.waterWalk = true;
                    return;
                case ItemID.LavaCharm:
                    player.GetModPlayer<AccesoryEffects>().LavaShield = true;
                    return;
                case ItemID.LavaWaders:
                    player.GetModPlayer<AccesoryEffects>().waterRunning = true;
                    player.GetModPlayer<AccesoryEffects>().LavaShield = true;
                    player.GetModPlayer<MoveSpeed>().TRAEwaterwalk = true;

                    player.lavaImmune = true;
                    player.lavaRose = false;
                    return;

                case ItemID.EmpressFlightBooster:
                    player.jumpSpeedBoost -= 2.4f;
                    return;
                case ItemID.Magiluminescence:
                    player.hasMagiluminescence = false;
                    if (player.velocity.Y == 0)
                    {
                        player.runAcceleration *= 1.33f;
                        player.maxRunSpeed *= 1.2f;
                        player.accRunSpeed *= 1.2f;
                        player.runSlowdown *= 2f;
                    }
                    return;
                case ItemID.ShinyStone:
                    if (player.velocity.Y == 0)
                    {
                        player.lifeRegen += 4;
                    }
                    return;
            }
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            switch (item.type)
            {           case ItemID.EmpressFlightBooster:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.Text = "Doubles acceleration";
                        }
                    }
                    return;
                case ItemID.HermesBoots:
                case ItemID.SailfishBoots:
                case ItemID.FlurryBoots:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = "25% increased running speed";
                        }
                    }
                    return;
                case ItemID.SandBoots:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = "25% increased running speed\nRunning and jumping speed increased by 25% on sand, and for 4 seconds after leaving it";
                        }
                    }
                    return;
                case ItemID.Aglet:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = "10% increased movement speed";
                        }
                    }
                    return;
                case ItemID.AnkletoftheWind:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = "25% increased movement speed";
                        }
                    }
                    return;
                case ItemID.FairyBoots:
                case ItemID.SpectreBoots:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.Text = "25% increased running speed";
                        }
                    }
                    return;
                case ItemID.FrostsparkBoots:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = "25% increased running speed";
                        }
                        if (line.Mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.Text = "Increases acceleration by 50%, and mobility on ice";
                        }
                    }
                    return;
                case ItemID.AmphibianBoots:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = "25% increased running speed";
                        }
                    }
                    return;
                case ItemID.LightningBoots:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = "Allows flight";
                        }
                        if (line.Mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.Text = "50% increased running speed, 25% movement speed while in the air";
                        }
                    }
                    return;
                case ItemID.TerrasparkBoots:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = "50% increased running speed, 25% movement speed while in the air";
                        }
                        if (line.Mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.Text = "Allows flight and the ability to dash";
                        }
                        if (line.Mod == "Terraria" && line.Name == "Tooltip2")
                        {
                            line.Text = "";
                        }
                        if (line.Mod == "Terraria" && line.Name == "Tooltip3")
                        {
                            line.Text = "";
                        }
                        if (line.Mod == "Terraria" && line.Name == "Tooltip4")
                        {
                            line.Text = "";
                        }
                    }
                    return;
                case ItemID.WaterWalkingBoots:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = "The wearer can walk on water\nIncreases running speed by 33% when walking on a liquid";
                        }
                    }
                    return;
                case ItemID.ObsidianHorseshoe:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = "Negates fall damage";
                        }
                        if (line.Mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.Text = "Hold DOWN to increase falling speed";
                        }
                    }
                    return;
                case ItemID.ObsidianWaterWalkingBoots:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = "Allows extended flight";
                        }
                        if (line.Mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.Text = "Hold DOWN to increase falling speed";
                        }
                        if (line.Mod == "Terraria" && line.Name == "Tooltip2")
                        {
                            line.Text = "Grants immunity to fall damage";
                        }
                    }
                    return;
                case ItemID.LavaCharm:
                    foreach (TooltipLine line in tooltips)
                    {
                        {
                            if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                            {
                                line.Text += "\nShields the wearer when entering lava";
                            }
                        }
                    }
                    return;
                case ItemID.LavaWaders:
                    foreach (TooltipLine line in tooltips)
                    {
                        {
                            if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                            {
                                line.Text = "Increases movement speed and shields the wearer when entering liquids";
                            }
                            if (line.Mod == "Terraria" && line.Name == "Tooltip1")
                            {
                                line.Text = "Allows walking on water and grants immunity to lava";
                            }
                        }
                    }
                    return;
                case ItemID.HiveBackpack:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = "Stores up to 16 bees while grounded, releases them while in mid-air\nIncreases jump height by 4.5% for every bee stored\nDoubles strength, recharge delay, and release rate of the bees when honeyed";
                        }
                    }
                    return;
                case ItemID.FrogGear:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.Text = "Allows the wearer to perform a short dash";
                        }
                    }
                    return;
                case ItemID.HoneyBalloon:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = "Releases bees and douses you in honey when damaged";
                        }
                        if (line.Mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.Text = "Increases jump height and life regeneration";
                        }
                    }
                    return;
                case ItemID.BalloonHorseshoeHoney:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = "Releases bees and douses you in honey when damaged and negates fall damage";
                        }
                        if (line.Mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.Text = "Increases jump height and life regeneration";
                        }
                    }
                    return;
                case ItemID.IceSkates:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = "Increases acceleration by 50%\nIncreases mobility on ice";
                        }
                    }
                    return;
         
            }
        }
   
    }
}






