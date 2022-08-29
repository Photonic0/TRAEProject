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

namespace TRAEProject.Changes.Armor
{
    public class CobaltArmorEffect : ModPlayer
    {
        public bool CobaltCritical = false; 
        public bool MythrilCritical = false;
        public float CobaltSpeed = 0;
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
                float speedIncrease = CobaltSpeed / 450;

                if (CobaltSpeed > 300)
                    CobaltSpeed = 300;
                CobaltSpeed -= 1 + CobaltSpeed / 100;
                Player.moveSpeed += speedIncrease;
                Player.runAcceleration *= 1 + speedIncrease * 2;
                Player.armorEffectDrawShadow = true;
                if (Player.velocity.X != 0)
                {
                    if (Main.rand.NextBool(7 - (int)(CobaltSpeed / 100))) // the more boost the more dusts
                    { 
                            int num3 = Dust.NewDust(new Vector2(Player.position.X - 4f, Player.position.Y), Player.width + 8, Player.height, DustID.BlueFairy, (0f - Player.velocity.X) * 0.5f, Player.velocity.Y * 0.5f, 100, default(Color), 1.5f);
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
                    player.GetCritChance(DamageClass.Generic) += 3;
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
                player.setBonus = "Critical Strikes significantly increase movement speed for a short time";
                player.GetModPlayer<CobaltArmorEffect>().CobaltCritical = true;
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
                            line.Text = "8% increased critical strike chance";
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
