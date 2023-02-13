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
                            line.Text = "6% increased melee speed\n5% increased movement speed";
                        }
                    }
                    break;
                case ItemID.ShroomiteLeggings:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.Text = "30% increased movement speed";
                        }
                    }
                    break;
                case ItemID.SpectrePants:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.Text = "10% increased movement speed";
                        }
                    }
                    break;
                case ItemID.HallowedGreaves:
                case ItemID.AncientHallowedGreaves:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.Text = "10% increased movement speed";
                        }
                    }
                    break;
                case ItemID.TitaniumLeggings:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.Text = "5% increased movement speed";
                        }
                    }
                    break;
                case ItemID.OrichalcumLeggings:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = "20% increased movement speed";
                        }
                    }
                    break;
                case ItemID.BeetleScaleMail:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.Text = "6% increased melee speed\n10% increased movement speed";
                        }
                    }
                    break;
            }
        }
    }
    
    
    
}