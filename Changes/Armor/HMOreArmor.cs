using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using TRAEProject.Common.ModPlayers;

namespace TRAEProject.Changes.Armor
{
    public class HMOreArmor : GlobalItem
    {
        //public override bool InstancePerEntity => true;
        public override void UpdateEquip(Item item, Player player)
        {
            switch (item.type)
            {
                case ItemID.CobaltHelmet:
                    player.moveSpeed -= 0.1f;
                    player.GetDamage(DamageClass.Melee) -= 0.07f;
                    player.GetCritChance(DamageClass.Melee) += 10;
                    return;
                case ItemID.CobaltMask:
                    player.GetDamage(DamageClass.Ranged) -= 0.02f; 
                    player.GetCritChance(DamageClass.Ranged) -= 1;
                    return;
                case ItemID.CobaltHat:
                    player.GetDamage(DamageClass.Magic) -= 0.01f;
                    player.GetCritChance(DamageClass.Magic) -= 1;
                    return;
                case ItemID.CobaltBreastplate:
                    player.GetCritChance(DamageClass.Generic) -= 3;
                    player.GetArmorPenetration(DamageClass.Generic) += 10;
                    return;
                case ItemID.CobaltLeggings:
                    player.GetDamage(DamageClass.Generic) += 0.03f;
                    return;
                case ItemID.MythrilChainmail:
                    player.GetDamage(DamageClass.Generic) -= 0.07f;
                    player.GetCritChance(DamageClass.Generic) += 10;
                    return;

            }
        }

        public override string IsArmorSet(Item head, Item body, Item legs)
        {
            if ((head.type == ItemID.CobaltHelmet || head.type == ItemID.CobaltMask || head.type == ItemID.CobaltHat) && body.type == ItemID.CobaltBreastplate && legs.type == ItemID.CobaltLeggings)
            {
                return "CobaltSet";
            }
            if ((head.type == ItemID.MythrilHood || head.type == ItemID.MythrilHat || head.type == ItemID.MythrilHelmet) && body.type == ItemID.MythrilChainmail && legs.type == ItemID.MythrilGreaves)
            {
                return "MythrilSet";
            }
            if ((head.type == ItemID.TitaniumHeadgear || head.type == ItemID.TitaniumHelmet || head.type == ItemID.TitaniumMask) && body.type == ItemID.TitaniumBreastplate && legs.type == ItemID.TitaniumLeggings)
                return "TitaniumSet";
            return base.IsArmorSet(head, body, legs);
        }
        public override void UpdateArmorSet(Player player, string set)
        {
            if (set == "CobaltSet")
            {
                switch (player.armor[0].type)
                {
                    case ItemID.CobaltHelmet:
                        player.GetAttackSpeed(DamageClass.Melee) -= 0.15f;
                        break;
                    case ItemID.CobaltMask:
                        player.ammoCost80 = false;
                        break;
                    case ItemID.CobaltHat:
                        player.manaCost += 0.14f;
                        break;
                }
                player.setBonus = "25% increased movement speed and jump speed";
                player.moveSpeed += 0.25f;
                player.jumpSpeedBoost += Mobility.JSV(0.25f);
            }
            if (set == "MythrilSet") // see armor changes
            {
                switch (player.armor[0].type)
                {
                    case ItemID.MythrilHelmet:
                        player.GetAttackSpeed(DamageClass.Melee) -= 0.15f;
                        player.GetCritChance(DamageClass.Melee) -= 10;
                        break;
                    case ItemID.MythrilHat:
                        player.ammoCost80 = false;
                        break;
                    case ItemID.MythrilHood:
                        player.manaCost += 0.17f;
                        break;
                }
                player.setBonus = "Critical Strikes deal 20% more damage";
                player.GetModPlayer<CritDamage>().critDamage += 0.20f;
            }
            if (set == "TitaniumSet") // see armor changes
            {
                player.GetModPlayer<SetBonuses>().TitaniumArmorOn = true;

            }
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            switch (item.type)
            {
                case ItemID.CobaltHelmet:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = "8% increased melee damage and 10% increased melee critical strike chance";
                        }
                        if (line.Mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.Text = "";
                        }
                    }
                    break;
                case ItemID.CobaltMask:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = "8% increased ranged damage and 10% increased ranged critical strike chance";
                        }
                        if (line.Mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.Text = "";
                        }
                    }
                    break;
                case ItemID.CobaltHat:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = "8% increased magic damage and 10% increased magic critical strike chance";
                        }
                        if (line.Mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.Text = "Increases maximum mana by 40";
                        }
                        if (line.Mod == "Terraria" && line.Name == "Tooltip2")
                        {
                            line.Text = "";

                        }
                    }
                    break;
                case ItemID.CobaltBreastplate:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = "Increases armor penetration by 10";
                        }
                    }
                    break;
                case ItemID.CobaltLeggings:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = "10% increased movement speed and 6% increased damage";
                        }
                    }
                    break;
                case ItemID.MythrilChainmail:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = "10% increased critical strike chance";
                        }
                    }
                    break;
            }
        }
    }
}
