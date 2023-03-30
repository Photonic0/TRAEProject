using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.Audio;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria.Graphics.Shaders;
using TRAEProject.NewContent.Items.Accesories.ExtraJumps;
using System;

namespace TRAEProject.Changes.Accesory
{
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


            ArmorIDs.Wing.Sets.Stats[ArmorIDs.Wing.LeafWings].FlyTime = eh;
            ArmorIDs.Wing.Sets.Stats[ArmorIDs.Wing.DemonWings].FlyTime = eh;
            ArmorIDs.Wing.Sets.Stats[ArmorIDs.Wing.AngelWings].FlyTime = eh;
            ArmorIDs.Wing.Sets.Stats[ArmorIDs.Wing.FairyWings].FlyTime = eh2;
            ArmorIDs.Wing.Sets.Stats[ArmorIDs.Wing.FrozenWings].FlyTime = eh2;
            ArmorIDs.Wing.Sets.Stats[ArmorIDs.Wing.ButterflyWings].FlyTime = eh2;
            ArmorIDs.Wing.Sets.Stats[ArmorIDs.Wing.BeeWings].FlyTime = eh2;
            ArmorIDs.Wing.Sets.Stats[ArmorIDs.Wing.HarpyWings].FlyTime = eh2;
            ArmorIDs.Wing.Sets.Stats[ArmorIDs.Wing.FinWings].FlyTime = eh2;

            ArmorIDs.Wing.Sets.Stats[ArmorIDs.Wing.Jetpack].FlyTime = eh;

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
        public override void SetDefaults(Item item)
        {
            if(item.type == ItemID.BeetleWings)
            {
                item.defense = 8;
            }
        }
        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            switch (item.type)
            {
                case ItemID.CenxsWings:
                case ItemID.RedsWings:
                case ItemID.JimsWings:
                case ItemID.DTownsWings:
                case ItemID.Yoraiz0rWings:
                case ItemID.FoodBarbarianWings:
                case ItemID.SafemanWings:
                case ItemID.LeinforsWings:
                case ItemID.CrownosWings:
                case ItemID.GhostarsWings:
                case ItemID.GroxTheGreatWings:
                case ItemID.BejeweledValkyrieWing:
                case ItemID.LokisWings:
                case ItemID.SkiphsWings:
                    player.moveSpeed += 0.1f;
                    player.jumpSpeedBoost += Mobility.JSV(0.1f);
                break;
                case ItemID.Jetpack:
                    player.moveSpeed += -0.1f;
                    player.jumpSpeedBoost += Mobility.JSV(0.2f);
                break;
                case ItemID.AngelWings:
                    player.jumpSpeedBoost += Mobility.JSV(0.1f);
                break;
                case ItemID.DemonWings:
                    player.moveSpeed += 0.1f;
                break;
                case ItemID.FlameWings:
                    player.GetDamage(DamageClass.Generic) += 0.08f;
                break;
                case ItemID.FrozenWings:
                case ItemID.HarpyWings:
                case ItemID.FairyWings:
                    player.moveSpeed += 0;
                    break;
                case ItemID.FinWings:
                    player.moveSpeed += 0;
                    player.ignoreWater = true;
                    break;
                case ItemID.ButterflyWings:
                case ItemID.BeeWings:
                case ItemID.BatWings:
                    player.moveSpeed += 0.0f;
                    break;
                case ItemID.BetsyWings:
                    player.moveSpeed += 0.15f;
                    player.jumpSpeedBoost += Mobility.JSV(0.15f);
                    break;
                case ItemID.TatteredFairyWings:
                    player.wingTime = player.wingTimeMax;
                    player.moveSpeed += 0.15f;
                    player.jumpSpeedBoost += Mobility.JSV(0.15f);
                    break;
                case ItemID.SteampunkWings:
                    player.moveSpeed += 0.15f;
                    player.jumpSpeedBoost += Mobility.JSV(0.15f);
                    player.GetModPlayer<TRAEProject.NewContent.Items.Accesories.ExtraJumps.TRAEJumps>().advFlight = true;
                    break;
                case ItemID.MothronWings:
                    player.moveSpeed += 0.15f;
                    player.jumpSpeedBoost += Mobility.JSV(0.15f);
                    player.GetModPlayer<Mobility>().ankletAcc = true;
                    break;
                case ItemID.BeetleWings:
                    player.moveSpeed += 0.15f;
                    player.jumpSpeedBoost += Mobility.JSV(0.15f);
                    break;
                case ItemID.FestiveWings:
                case ItemID.FishronWings:
                case ItemID.BoneWings:
                case ItemID.GhostWings:
                    player.moveSpeed += 0.25f;
                    player.jumpSpeedBoost += Mobility.JSV(0.25f);
                    break;
                case ItemID.RainbowWings:
                    player.moveSpeed += 0.25f;
                    player.jumpSpeedBoost += Mobility.JSV(0.4f);
                    break;
                case ItemID.SpookyWings:
                    player.moveSpeed += 0.4f;
                    player.jumpSpeedBoost += Mobility.JSV(0.25f);
                    break;
                case ItemID.WingsSolar:
                    player.moveSpeed += 0.4f;
                    player.jumpSpeedBoost += Mobility.JSV(0.4f);
                    break;
                case ItemID.WingsStardust:
                    player.moveSpeed += 0.25f;
                    player.jumpSpeedBoost += Mobility.JSV(0.60f);
                    break;
                case ItemID.WingsNebula:
                    player.wingTime = player.wingTimeMax;
                    player.moveSpeed += 0.25f;
                    player.jumpSpeedBoost += Mobility.JSV(0.25f);
                    break;
                case ItemID.WingsVortex:
                    player.moveSpeed += 0.25f;
                    player.jumpSpeedBoost += Mobility.JSV(0.25f);
                    break;
                case ItemID.LongRainbowTrailWings:
                    player.moveSpeed += 0.6f;
                    player.jumpSpeedBoost += Mobility.JSV(0.6f);
                    break;
            }
        }
        public static void PostProcessChanges(Player player)
        {
            player.accRunSpeed = 3;

            if(player.wingsLogic == 4)
            {
                if(player.gravDir == 1)
                {
                    if(player.velocity.Y < -Player.jumpSpeed)
                    {
                        player.velocity.Y = -Player.jumpSpeed;
                    }
                }
                else
                {
                    if(player.velocity.Y > Player.jumpSpeed)
                    {
                        player.velocity.Y = Player.jumpSpeed;
                    }
                }
            }
            //player.wingTimeMax += 60;
            //player.wingTimeMax *= 2;
            //Main.NewText("WingMax: " + player.wingTimeMax);
            //Main.NewText("WingTime: " + player.wingTime + "/" +  player.wingTimeMax);
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
                    float flightTime = MathF.Round((float)ArmorIDs.Wing.Sets.Stats[item.wingSlot].FlyTime / 60, 2);
                    if (tooltips[i].Mod == "Terraria" && tooltips[i].Name == "Tooltip0")
                    {
                        string text = "Flight Time: " + flightTime + " seconds";
                        if(item.wingSlot == ArmorIDs.Wing.TatteredFairyWings || item.wingSlot == ArmorIDs.Wing.NebulaMantle)
                        {
                            text = "Flight Time: infinite";
                        }
                        tooltips.Insert(i-1, new TooltipLine(Mod, "WingTime", text));
                        break;
                    }
                }
            }
            switch (item.type)
            {
                case ItemID.CenxsWings:
                case ItemID.RedsWings:
                case ItemID.JimsWings:
                case ItemID.DTownsWings:
                case ItemID.Yoraiz0rWings:
                case ItemID.FoodBarbarianWings:
                case ItemID.SafemanWings:
                case ItemID.LeinforsWings:
                case ItemID.CrownosWings:
                case ItemID.GhostarsWings:
                case ItemID.GroxTheGreatWings:
                case ItemID.BejeweledValkyrieWing:
                case ItemID.LokisWings:
                case ItemID.SkiphsWings:
                    tooltips.Add(new TooltipLine(Mod, "dev wing speed", "Increases movement and jumps speed by 10%"));
                break;
                case ItemID.Jetpack:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text += "\n20% increased jump speed, but reduces movement speed by 10%";
                        }
                    }
                    break;
                case ItemID.AngelWings:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text += "\n10% increased jump speed";
                        }
                    }
                    break;
                case ItemID.DemonWings:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text += "\n10% increased movement speed";
                        }
                    }
                    break;
                case ItemID.FlameWings:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text += "\nIncreases damage by 8%";
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
                            line.Text += "\n25% increased movement and jump speed";
                        }
                    }
                    break;
                case ItemID.MothronWings:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text += "\n15% increased movement and jump speed" + "\nGrants horizontal acceleration";
                        }
                    }
                    break;
                case ItemID.SteampunkWings:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text += "\n15% increased movement and jump speed" + "\nGrants advanced flight";
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
                            line.Text += "\n25% increased movement and jump speed";
                        }
                    }
                    break;
                case ItemID.WingsSolar:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text += "\n40% increased movement and jump speed";
                        }
                    }
                    break;
                case ItemID.WingsStardust:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text += "25% increaded movement speed and 60% increased movement speed";
                        }
                    }
                    break;
                case ItemID.WingsVortex:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text += "\n25% increased movement and jump speed" + "\nHold down to hover for 50% more movement speed";
                        }
                    }
                    break;
                case ItemID.LongRainbowTrailWings:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text += "\n100% increased movement and jump speed" + "\nHold down to hover for 50% more movement speed";
                        }
                    }
                    break;
                case ItemID.TatteredFairyWings:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text += "\n15% increased movement and jump speed";
                        }
                    }
                    break;
                case ItemID.FishronWings:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text += "\n25% increased movement and jump speed" +"\nHold down to fall faster";
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
                            line.Text += "\n15% increased movement and jump speed" + "\nHold down to hover for 50% more movement speed";
                        }
                    }
                    break;
                case ItemID.RainbowWings:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text += "\n25% increased movement and 40% increased jump speed";
                        }
                    }
                    break;
                case ItemID.SpookyWings:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text += "\n45% increased movement and 25% increased jump speed";
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

            }
        }
    }
}