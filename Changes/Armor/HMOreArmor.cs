using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TRAEProject.Changes.Armor
{
    public class CobaltArmorEffect : ModPlayer
    {
        public bool CobaltCritical = false; 
        public bool MythrilCritical = false;
        public int CobaltSpeed = 0;
        public override void ResetEffects()
        {
            CobaltCritical = false;
            MythrilCritical = false;
        }
        public override void PostUpdateEquips()
        {
            if (CobaltSpeed > 0)
            {
                // TO DO: VISUAL FOR THE SPEED INCREASE. LOOK AT AMPHIBIAN BOOTS. 
                float speedIncrease = 1 + (float)(CobaltSpeed / 2000);

                if (CobaltSpeed > 600)
                    CobaltSpeed = 600;
                CobaltSpeed--;
                Player.moveSpeed *= speedIncrease;
                Player.runAcceleration *= speedIncrease;
            }    
        }
        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            if (CobaltCritical && crit)
            {
                CobaltSpeed += damage;
            }
        }
        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if (CobaltCritical && crit)
            {
                CobaltSpeed += damage;
            }
        }
        public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
        {
            if(crit && MythrilCritical)
            {
                damage = (int)(damage * 1.25f);
            }
        }
        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (crit && MythrilCritical)
            {
                damage = (int)(damage * 1.25f);
            }
        }
    }
    public class HMOreArmor : GlobalItem
    {
        //public override bool InstancePerEntity => true;
        public override void UpdateEquip(Item item, Player player)
        {
            switch (item.type)
            {
                case ItemID.CobaltHelmet:
                    player.moveSpeed -= 0.1f;
                    player.GetDamage(DamageClass.Melee) -= 0.01f;
                    player.GetCritChance(DamageClass.Melee) += 10;
                    return;
                case ItemID.CobaltMask:
                    player.GetDamage(DamageClass.Ranged) -= 0.04f; 
                    player.GetCritChance(DamageClass.Ranged) -= 1;
                    return;
                case ItemID.CobaltHat:
                    player.GetDamage(DamageClass.Magic) -= 0.03f;
                    player.GetCritChance(DamageClass.Magic) -= 1;
                    return;
                case ItemID.CobaltBreastplate:
                    player.GetCritChance(DamageClass.Generic) += 3;
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
            return base.IsArmorSet(head, body, legs);
        }
        public override void UpdateArmorSet(Player player, string set)
        {
            if(set == "CobaltSet")
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
                player.setBonus = "Critical Strikes deal 25% more damage";
                player.GetModPlayer<CobaltArmorEffect>().CobaltCritical = true;
            }
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
                player.setBonus = "Critical Strikes significantly increase movement speed for a short time";
                player.GetModPlayer<CobaltArmorEffect>().CobaltCritical = true;
            }
            if (set == "MythrilSet") // see armor changes
            {
                switch (player.armor[0].type)
                {
                    case ItemID.MythrilHelmet:
                        player.GetAttackSpeed(DamageClass.Melee) -= 0.15f;
                        break;
                    case ItemID.MythrilHat:
                        player.ammoCost80 = false;
                        break;
                    case ItemID.MythrilHood:
                        player.manaCost += 0.17f;
                        break;
                }
                player.setBonus = "Critical Strikes deal 25% more damage";
                player.GetModPlayer<CobaltArmorEffect>().MythrilCritical = true;
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
                            line.Text = "5% increased melee damage and 10% increased melee critical strike chance";
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
                            line.Text = "5% increased ranged damage and 10% increased ranged critical strike chance";
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
                            line.Text = "5% increased magic damage and 10% increased magic critical strike chance";
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
                            line.Text = "8% increased critical strike chance";
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
