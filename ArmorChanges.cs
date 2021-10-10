using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TRAEProject;
using System.Collections.Generic;
namespace ChangesArmor
{
    public class ChangesArmor : GlobalItem
    {
        public override bool InstancePerEntity => true;
        public override GlobalItem Clone(Item item, Item itemClone)
        {
            return base.Clone(item, itemClone);
        }
        public override void UpdateEquip(Item item, Player player)
    {
            switch (item.type)
            {
                case ItemID.AncientArmorHat:
                    player.GetDamage<MagicDamageClass>()  += 0.17f;
                    player.GetDamage<MeleeDamageClass>()  += 0.17f;
                    player.manaCost -= 0.10f;
                    player.meleeSpeed += 0.10f;
                    return;
                case ItemID.AncientArmorShirt:
                    player.canJumpAgain_Sandstorm = true;
                    player.GetCritChance<MagicDamageClass>() += 3;
                    player.GetCritChance<MeleeDamageClass>()  += 3;
                    return;
                case ItemID.AncientArmorPants:
                    player.moveSpeed += 0.20f;
                    player.GetDamage<MagicDamageClass>() += 0.03f;
                    player.GetDamage<MeleeDamageClass>() += 0.03f;
                    return;
                case ItemID.PharaohsMask:
                    player.moveSpeed += 0.10f;
                    return;
                case ItemID.PharaohsRobe:
                    player.moveSpeed += 0.15f;
                    return;
                case ItemID.ShadowHelmet:
                case ItemID.ShadowScalemail:
                case ItemID.ShadowGreaves:
                case ItemID.AncientShadowHelmet:
                case ItemID.AncientShadowScalemail:
                case ItemID.AncientShadowGreaves:
                    player.meleeSpeed -= 0.07f;
                    player.GetCritChance<GenericDamageClass>() += 2;
                    return;
                case ItemID.RuneRobe:
                    player.statManaMax2 += 100;
                    player.manaCost -= 0.21f;
                    return;
                case ItemID.RuneHat:
                    player.GetDamage<MagicDamageClass>() += 0.15f;
                    player.GetCritChance<MagicDamageClass>()  += 15;
                    return;
                case ItemID.CobaltLeggings:
                    player.GetCritChance<GenericDamageClass>()  += 3;
                    return;
                case ItemID.CobaltBreastplate:
                    player.GetDamage<GenericDamageClass>() += 0.05f;
                    player.GetCritChance<GenericDamageClass>() -= 3;    
                    return;
                case ItemID.OrichalcumMask:
                    player.GetDamage<MeleeDamageClass>()  -= 0.11f;
                    player.GetCritChance<MeleeDamageClass>()  += 13;
                    return;
                case ItemID.DjinnsCurse:
                    player.jumpSpeedBoost += 1f;
                    return;
                case ItemID.TikiMask:
                    player.whipRangeMultiplier += 0.3f;
                    return;
                case ItemID.SpectreMask:
                    player.manaCost += 0.13f;
                    return;
                case ItemID.SpectreHood:
                    player.GetDamage<MagicDamageClass>() += 0.4f; // +0.4 to negate the reduction
                    player.statManaMax2 += 100;
                    player.manaCost -= 0.20f;
                    return;
                case ItemID.SquireGreatHelm:
                    player.lifeRegen -= 2;
                    return;
                case ItemID.SquirePlating:
                    player.lifeRegen += 2;
                    return;
                case ItemID.SquireAltHead:
                    player.lifeRegen += 4;
                    ++player.maxMinions;
                    return;
                case ItemID.SquireAltShirt:
                    player.lifeRegen -= 4;
                    return;
                case ItemID.MonkShirt:
                    player.GetDamage<MeleeDamageClass>()  -= 0.2f;
                    player.meleeSpeed += 0.2f;
                    return;
                case ItemID.MonkBrows:
                    player.GetDamage<MeleeDamageClass>()  += 0.2f;
                    player.meleeSpeed -= 0.2f;
                    return;
                case ItemID.MonkAltShirt:
                    player.meleeSpeed -= 0.2f;
                    player.GetDamage<MeleeDamageClass>()  += 0.2f;
                    return;
                case ItemID.MonkAltHead:
                    player.meleeSpeed += 0.3f;
                    player.GetDamage<SummonDamageClass>()  += 0.1f;
                    player.GetDamage<MeleeDamageClass>()  -= 0.2f;
                    return;
				case ItemID.ObsidianShirt:
                    player.GetDamage<SummonDamageClass>() += 0.08f;
                    return;
                case ItemID.PirateHat:
                    player.whipRangeMultiplier += 0.3f;
                    player.GetDamage<SummonDamageClass>() += 0.1f;
                    return;
                case ItemID.PirateShirt:
                    player.whipUseTimeMultiplier *= (1 / 1.12f);
                    player.GetDamage<SummonDamageClass>() += 0.1f;
                    return;
                case ItemID.PiratePants:
				player.moveSpeed += 0.1f;
                    player.whipUseTimeMultiplier *= (1 / 1.08f);
                    player.GetDamage<SummonDamageClass>() += 0.1f;
                    return;
            }
        }
        public override string IsArmorSet(Item head, Item body, Item legs)
        {
            if (head.type == ItemID.CopperHelmet && body.type == ItemID.CopperChainmail && legs.type == ItemID.CopperGreaves)
                return "CopperSet";
            if (head.type == ItemID.TinHelmet && body.type == ItemID.TinChainmail && legs.type == ItemID.TinGreaves)
                return "TinSet";
            if ((head.type == ItemID.IronHelmet || head.type == ItemID.AncientIronHelmet) && body.type == ItemID.IronChainmail && legs.type == ItemID.IronGreaves)
                return "IronSet";
            if (head.type == ItemID.LeadHelmet && body.type == ItemID.LeadChainmail && legs.type == ItemID.LeadGreaves)
                return "LeadSet";
            if (head.type == ItemID.SilverHelmet && body.type == ItemID.SilverChainmail && legs.type == ItemID.SilverGreaves)
                return "SilverSet";
            if (head.type == ItemID.TungstenHelmet && body.type == ItemID.TungstenChainmail && legs.type == ItemID.TungstenGreaves)
                return "TungstenSet";
            if ((head.type == ItemID.GoldHelmet || head.type == ItemID.AncientGoldHelmet) && body.type == ItemID.GoldChainmail && legs.type == ItemID.GoldGreaves)
                return "GoldSet";
            if (head.type == ItemID.PlatinumHelmet && body.type == ItemID.PlatinumChainmail && legs.type == ItemID.PlatinumGreaves)
                return "PlatinumSet";
            if (head.type == ItemID.PharaohsMask && body.type == ItemID.PharaohsRobe)
                return "PharaohSet";
            if (head.type == ItemID.RuneHat && body.type == ItemID.RuneRobe)
                return "WizardSetHM";
            if ((head.type == ItemID.ShadowHelmet || head.type == ItemID.AncientShadowHelmet) && (body.type == ItemID.ShadowScalemail || body.type == ItemID.AncientShadowScalemail) && (legs.type == ItemID.ShadowGreaves || legs.type == ItemID.AncientShadowGreaves))
                return "ShadowSet";
            if (head.type == ItemID.AncientArmorHat && body.type == ItemID.AncientArmorShirt && legs.type == ItemID.AncientArmorPants)
                return "AncientSet";
            if (head.type == ItemID.TurtleHelmet && body.type == ItemID.TurtleScaleMail && legs.type == ItemID.TurtleLeggings)
                return "TurtleSet";
            if (head.type == ItemID.MythrilHood && body.type == ItemID.MythrilChainmail && legs.type == ItemID.MythrilGreaves)
                return "MythrilHood";
            if (head.type == ItemID.MythrilHat && body.type == ItemID.MythrilChainmail && legs.type == ItemID.MythrilGreaves)
                return "MythrilHat";
            if (head.type == ItemID.MythrilHelmet && body.type == ItemID.MythrilChainmail && legs.type == ItemID.MythrilGreaves)
                return "MythrilHelmet";
            if (head.type == ItemID.AdamantiteMask && body.type == ItemID.AdamantiteBreastplate && legs.type == ItemID.AdamantiteLeggings)
                return "AdamantiteSet";
            if ((head.type == ItemID.TitaniumHeadgear || head.type == ItemID.TitaniumHelmet || head.type == ItemID.TitaniumMask) && body.type == ItemID.TitaniumBreastplate && legs.type == ItemID.TitaniumLeggings)
                return "TitaniumSet";
            if (head.type == ItemID.CobaltMask && body.type == ItemID.CobaltBreastplate && legs.type == ItemID.CobaltLeggings)
                return "CobaltSet";
            if ((head.type == ItemID.HallowedHeadgear || head.type == ItemID.HallowedHelmet || head.type == ItemID.HallowedMask || head.type == ItemID.HallowedHood) && body.type == ItemID.HallowedPlateMail && legs.type == ItemID.HallowedGreaves)
                return "HallowedSet";
            if (head.type == ItemID.TikiMask && body.type == ItemID.TikiShirt && legs.type == ItemID.TikiPants)
                return "TikiSet";
            if ((head.type == ItemID.ShroomiteHeadgear || head.type == ItemID.ShroomiteHelmet || head.type == ItemID.ShroomiteMask) && body.type == ItemID.ShroomiteBreastplate && legs.type == ItemID.ShroomiteLeggings)
                return "ShroomiteSet";
            if (head.type == ItemID.ObsidianHelm && body.type == ItemID.ObsidianShirt && legs.type == ItemID.ObsidianPants)
                return "ObsidianSet";
            if (head.type == ItemID.PirateHat && body.type == ItemID.PirateShirt && legs.type == ItemID.PiratePants)
                return "PirateSet";
            return base.IsArmorSet(head, body, legs);
        }
        public override void UpdateArmorSet(Player player, string armorSet)
        {
            if (armorSet == "CopperSet") // Revisit
            {
                player.setBonus = "Reduce damage taken by 8%";
                player.endurance += 0.08f;
                player.statDefense -= 2;
            }
            if (armorSet == "TinSet")
            {
                player.setBonus = "Reduce damage taken by 9%";
                player.endurance += 0.09f;
                player.statDefense -= 2;
            }
            if (armorSet == "IronSet") // Revisit
            {
                player.setBonus = "Reduce damage taken by 10%";
                player.endurance += 0.1f;
                player.statDefense -= 2;
            }
            if (armorSet == "LeadSet")
            {
                player.setBonus = "Reduce damage taken by 11%";
                player.endurance += 0.11f;
                player.statDefense -= 3;
            }
            if (armorSet == "SilverSet") // Revisit
            {
                player.setBonus = "Reduce damage taken by 12%";
                player.endurance += 0.12f;
                player.statDefense -= 3;
            }
            if (armorSet == "TungstenSet")
            {
                player.setBonus = "Reduce damage taken by 13%";
                player.endurance += 0.13f;
                player.statDefense -= 3;
            }
            if (armorSet == "GoldSet") // Revisit
            { 
                player.setBonus = "Reduce damage taken by 14%";
            player.endurance += 0.08f;
            player.statDefense -= 3;
        }
            if (armorSet == "PlatinumSet")
            {
                player.setBonus = "Reduce damage taken by 15%";
                player.endurance += 0.15f;
                player.statDefense -= 4;
            }
            if (armorSet == "PharaohSet")
            {
                player.setBonus = "Grants an improved double jump and the ability to float for a few seconds";
                player.canJumpAgain_Sandstorm = true;
                player.carpet = true;
            }
            if (armorSet == "WizardSetHM")
            {
                player.setBonus = "Return dectuple damage taken to near enemies";
                player.GetModPlayer<TRAEPlayer>().runethorns += 10f;
            }
            if (armorSet == "ShadowSet")
            {
                player.moveSpeed -= 0.15f;
                player.setBonus = "Gives a chance to dodge attacks";
                player.GetModPlayer<TRAEPlayer>().shadowArmorDodgeChance = 9;
            }
            if (armorSet == "AncientSet")
            {
                player.setBonus = "Increases melee speed by 30%\nIncreases maximum mana by 60\nIncreases length of invincibility after taking damage";
                player.GetModPlayer<TRAEPlayer>().AncientSet = true;
                player.meleeSpeed += 0.3f;
                player.statManaMax2 += 60;
            }
            if (armorSet == "TurtleSet")
            {
                player.setBonus = "Damage taken is reflected to nearby enemies with thrice the strength\nReduces damage taken by 15%";
                player.GetModPlayer<TRAEPlayer>().newthorns += 3f;
                player.thorns -= 2f;
                player.turtleThorns = false;
            }
            if (armorSet == "MythrilHood")
            {
                player.setBonus = "15% increased magic critical strike chance";
                player.GetCritChance<MagicDamageClass>()  += 15;
                player.manaCost += 0.17f;
            }
            if (armorSet == "MythrilHat")
            {
                player.setBonus = "12% increased ranged critical strike chance";
                player.GetCritChance<RangedDamageClass>() += 12;
                player.ammoCost80 = false; 
            }           
            if (armorSet == "HallowedSet")
            {
                player.setBonus = "You gain immunity to the next attack after taking a hit";
                player.GetModPlayer<TRAEPlayer>().titatimer = 900;
                player.GetModPlayer<TRAEPlayer>().HolyProtection = true;
                player.onHitDodge = false;
            }
            if (armorSet == "ShroomiteSet")
            {
                player.setBonus = "Enter a stealth mode while on the ground, significantly increasing ranged abilities";
            }
			if (armorSet == "ObsidianSet")
            {
                player.setBonus = "30% increased whip range and 15% increased whip speed";
				player.whipRangeMultiplier -= 0.2f;
				player.whipUseTimeMultiplier /= 0.869f;
				player.GetDamage<SummonDamageClass>() -= 0.15f;
            }
            if (armorSet == "PirateSet")
            {
                player.setBonus = "All whips gain an additional +5 tag damage and +5% summon tag critical strike chance";
				player.GetModPlayer<TRAEPlayer>().PirateSet = true;
            }
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            switch (item.type)
            {
                case ItemID.SpectreHood:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Defense")
                        {
                            line.text += "\nIncreases maximum mana by 100 and reduces mana costs by 20%";
                        }
                    }
                    return;
                case ItemID.SpectreMask:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "Increases maximum mana by 60";
                        }
                    }
                    return;
                case ItemID.ObsidianShirt:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text += "\nIncreases summon damage by 8%";
                        }
                    }
                    return;
                case ItemID.PharaohsRobe:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Defense")
                        {
                            line.text += "\nIncreases movement speed by 15%";
                        }
                    }
                    return;
                case ItemID.PharaohsMask:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Defense")
                        {
                            line.text += "\nIncreases movement speed by 10%";
                        }
                    }
                    return;
                case ItemID.PirateHat:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Defense")
                        {
                            line.text += "\n10% increased summon damage\n30% increased whip range";
                        }
                    }
                    return;
                case ItemID.PirateShirt:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Defense")
                        {
                            line.text += "\n10% increased summon damage\n12% increased whip speed";
                        }
                    }
                    return;
                case ItemID.PiratePants:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Defense")
                        {
                            line.text += "\n10% increased summon damage and movement speed\n8% increased whip speed";
                        }
                    }
                    return;
                case ItemID.AncientArmorHat:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Defense")
                        {
                            line.text += "\n17% increased magic and melee damage\n10% increased melee speed and decreased mana costs";
                        }
                    }
                    return;
                case ItemID.AncientArmorShirt:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Defense")
                        {
                            line.text += "\nAllows the player to perform an improved double jump\n3% increased magic and melee critical strike chance";
                        }
                    }
                    return;
                case ItemID.AncientArmorPants:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Defense")
                        {
                            line.text += "\nIncreases movement speed by 20%\n3% increased magic and melee damage";
                        }
                    }
                    return;
                case ItemID.ShadowHelmet:
                case ItemID.ShadowScalemail:
                case ItemID.ShadowGreaves:
                case ItemID.AncientShadowHelmet:
                case ItemID.AncientShadowScalemail:
                case ItemID.AncientShadowGreaves:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "2% increased critical strike chance";
                        }
                    }
                    return;              
                case ItemID.RuneHat:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Defense")
                        {
                            line.text += "\n15% increased magic damage and critical strike chance";
                        }
                    }
                    return;
                case ItemID.RuneRobe:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Defense")
                        {
                            line.text += "\nIncreases maximum mana by 100\nReduces mana costs by 21%";
                        }
                    }
                    return;              
                case ItemID.OrichalcumMask:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "13% increased melee critical strike chance";
                        }
                        if (line.mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.text = "7% increased melee and movement speed";
                        }
                    }
                    return;
                case ItemID.DjinnsCurse:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text += "\nIncreases jump height and speed";
                        }
                    }
                    return;
                   
                case ItemID.TikiMask:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.text += "\nIncreases whip range by 30%";
                        }
                    }
                    return;              
                case ItemID.MonkBrows:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "Increases your max number of sentries and increases melee damage by 20%";
                        }
                    }
                    return;
                case ItemID.MonkShirt:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "20% increased minion damage and melee speed";
                        }
                    }
                    return;
                case ItemID.MonkAltHead:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "Increases your maximum number of sentries by 2 and melee speed and minion damage by 30%";
                        }
                    }
                    return;
                case ItemID.MonkAltShirt:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "20% increased melee and minion damage";
                        }
                    }
                    return;     
                case ItemID.SquirePlating:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text += "\nIncreases life regeneration";
                        }
                    }
                    return;      
                case ItemID.SquireAltHead:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text += "\nGreatly increased life regeneration";
                        }
                    }
                    return;
                case ItemID.SquireAltShirt:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "30% increased minion damage and greatly increased life regeneration";
                        }
                    }
                    return;     
            }
        }
    }
}



