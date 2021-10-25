using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TRAEProject;
using System.Collections.Generic;
using Terraria.Utilities;
using TRAEProject.Buffs;
using TRAEProject.Changes;
using TRAEProject.Items.Accesories.EvilEye;
using TRAEProject.Items.Accesories.ShadowflameCharm;
using TRAEProject.Changes.Items;
using static Terraria.ModLoader.ModContent;


namespace TRAEProject.Changes.Accesory
{
    public class ChangesAccessories : GlobalItem
    {
        public static readonly int[] AnkhDebuffList = new int[] { BuffID.Bleeding, BuffID.Poisoned, BuffID.OnFire, BuffID.Venom,
        BuffID.Darkness, BuffID.Blackout, BuffID.Silenced, BuffID.Cursed,
        BuffID.Confused, BuffID.Slow, BuffID.OgreSpit, BuffID.Weak, BuffID.BrokenArmor,
        BuffID.CursedInferno,   BuffID.Frostburn,  BuffID.Chilled,  BuffID.Frozen,
        BuffID.Ichor,   BuffID.Stoned,  BuffID.VortexDebuff,  BuffID.Obstructed,
        BuffID.Electrified, BuffID.ShadowFlame, BuffID.WitheredWeapon, BuffID.WitheredArmor, BuffID.Dazed }; // 

        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            switch (item.type)
            {
                case ItemID.FastClock:
                    Main.time += 4;
                    player.buffImmune[BuffID.Slow] = false;
                    return;
                case ItemID.Bezoar:
                    player.GetModPlayer<Bezoar>().bezoar = true;
                    player.buffImmune[BuffID.Poisoned] = false;
                    return;
                case ItemID.AdhesiveBandage:
                    player.GetModPlayer<BandAid>().Bandaid = true;
                    player.buffImmune[BuffID.Bleeding] = false;
                    return;
                case ItemID.MedicatedBandage:
                    player.GetModPlayer<Bezoar>().bezoar = true;
                    player.GetModPlayer<BandAid>().Bandaid = true;
                    player.buffImmune[BuffID.Poisoned] = false;
                    player.buffImmune[BuffID.Bleeding] = false;
                    return;
                case ItemID.Blindfold:
                    player.AddBuff(BuffID.Obstructed, 1);
                    player.buffImmune[BuffID.Darkness] = false;
                    return;
                case ItemID.Nazar:
                    player.GetModPlayer<NazarDebuffs>().Nazar += 1;
                    player.buffImmune[BuffID.Cursed] = false;
                    return;
                case ItemID.CountercurseMantra:
                    player.GetModPlayer<NazarDebuffs>().Nazar += 1;
                    foreach (int i in AnkhDebuffList)
                    {
                        player.buffImmune[i] = true;
                    }
                    return;
                case ItemID.AnkhShield:
                case ItemID.AnkhCharm:
                    foreach (int i in AnkhDebuffList)
                    {
                        player.buffImmune[i] = true;
                    }
                    return;
                case ItemID.RoyalGel:
                    player.GetModPlayer<OnHitItems>().RoyalGel = true;
                    return;

                case ItemID.MoltenCharm:
                    player.lavaImmune = true;
                    player.GetModPlayer<ShadowflameCharmPlayer>().MoltenCharm += 1;
                    player.fireWalk = false;
                    return;
                case ItemID.BeeCloak:
                    player.honeyCombItem = null;
                    player.starCloakItem = null;
                    player.GetModPlayer<OnHitItems>().NewbeesOnHit = true;
                    return;
                case ItemID.CrossNecklace:
                case ItemID.StarVeil:
                    player.starCloakItem = null;
                    player.GetModPlayer<OnHitItems>().NewstarsOnHit = true;
                    return;
                case ItemID.MechanicalGlove:
                    player.kbGlove = false;
                    player.meleeScaleGlove = false;
                    return;
                case ItemID.MoonShell:
                    if (player.statLife > player.statLifeMax2 * 0.67)
                    {
                        player.buffImmune[BuffID.Werewolf] = true;
                    }
                    player.GetModPlayer<TRAEPlayer>().wErewolf = true;
                    if (player.statLife < player.statLifeMax2 * 0.5)
                        player.AddBuff(BuffID.IceBarrier, 1, false);
                    player.accMerman = false;
                    player.wolfAcc = false;
                    return;
                case ItemID.MoonCharm:
                    player.GetModPlayer<TRAEPlayer>().wErewolf = true;
                    player.wolfAcc = false;
                    return;
                // CELESTIAL STONE CHANGES
                case ItemID.CelestialStone:
                    player.skyStoneEffects = false;
                    player.GetDamage<GenericDamageClass>() += 0.08f;
                    player.GetCritChance<GenericDamageClass>() += 2;
                    player.statDefense += 4;
                    player.lifeRegen++;
                    player.statManaMax2 += 20;
                    player.meleeSpeed += 0.05f;
                    player.moveSpeed += 0.1f;
                    player.GetModPlayer<TRAEPlayer>().chanceNotToConsumeAmmo += 10;// new bonus
                                                                                   // total stats: +8% damage, +2% crit, +0.5 hp/s, +4 defense. +5% melee speed, +20 max mana, +10% movement speed
                    return;
                case ItemID.MoonStone:
                    if (!Main.dayTime)
                    {
                        player.skyStoneEffects = false;
                        player.GetDamage<GenericDamageClass>() += 0.08f;
                        player.GetCritChance<GenericDamageClass>() += 2;
                        player.statDefense += 4;
                        player.lifeRegen++;
                        player.statManaMax2 += 20;
                        player.meleeSpeed += 0.05f;
                        player.moveSpeed += 0.1f;
                        player.GetModPlayer<TRAEPlayer>().chanceNotToConsumeAmmo += 10;
                    }
                    return;
                case ItemID.SunStone:
                    if (Main.dayTime)
                    {
                        player.skyStoneEffects = false;
                        player.GetDamage<GenericDamageClass>() += 0.08f;
                        player.GetCritChance<GenericDamageClass>() += 2;
                        player.statDefense += 4;
                        player.lifeRegen++;
                        player.statManaMax2 += 20;
                        player.meleeSpeed += 0.05f;
                        player.moveSpeed += 0.1f;
                        player.GetModPlayer<TRAEPlayer>().chanceNotToConsumeAmmo += 10;
                    }
                    return;
                case ItemID.CelestialShell:
                    player.skyStoneEffects = false;
                    player.GetDamage<GenericDamageClass>() += 0.08f;
                    player.GetCritChance<GenericDamageClass>() += 2;
                    player.statDefense += 4;
                    player.lifeRegen++;
                    player.statManaMax2 += 20;
                    player.meleeSpeed += 0.05f;
                    player.moveSpeed += 0.1f;
                    player.GetModPlayer<TRAEPlayer>().chanceNotToConsumeAmmo += 10;
                    player.wolfAcc = false;
                    return;
                case ItemID.BandofStarpower:
                    player.GetModPlayer<TRAEPlayer>().manaRegenBoost += 0.1f;
                    player.statManaMax2 -= 20;
                    return;
                case ItemID.ManaRegenerationBand:
                    player.statManaMax2 -= 20;
                    player.GetModPlayer<TRAEPlayer>().manaRegenBoost += 0.1f;
                    player.lifeRegen += 2;
                    return;
                case ItemID.MagicCuffs:
                    player.GetModPlayer<OnHitItems>().magicCuffsCount += 1; // the duration of the buff is the Hit's damage multiplied by this number, then multiplied by 3. This also decides how much mana is recovered.
                    player.statManaMax2 -= 20;
                    player.magicCuffs = false;
                    return;
                case ItemID.CelestialCuffs:
                    player.statManaMax2 -= 20;
                    player.GetModPlayer<OnHitItems>().magicCuffsCount += 1;
                    player.magicCuffs = false;
                    player.GetModPlayer<Mana>().celestialCuffsOverload = true;
                    return;
                case ItemID.StarCloak:
                    player.starCloakItem = null;
                    player.GetModPlayer<OnHitItems>().NewstarsOnHit = true;
                    return;
                case ItemID.MagicDagger:
                    player.GetModPlayer<TRAEPlayer>().MagicDagger = true;
                    return;
                case ItemID.ManaCloak:
                    player.starCloakItem_manaCloakOverrideItem = item;
                    player.GetModPlayer<TRAEPlayer>().manaCloak = true;
                    player.manaCost += 0.08f;
                    return;
                case ItemID.ManaFlower:
                case ItemID.MagnetFlower:
                    player.GetModPlayer<TRAEPlayer>().newManaFlower = true;
                    player.manaCost += 0.08f;
                    return;
                case ItemID.ArcaneFlower:
                    player.manaCost += 0.08f;
                    player.GetModPlayer<TRAEPlayer>().newManaFlower = true;
                    player.GetDamage<MagicDamageClass>() += 0.05f;
                    player.GetCritChance<MagicDamageClass>() += 5;
                    return;
                case ItemID.CelestialEmblem:
                    player.GetDamage<MagicDamageClass>() -= 0.03f;
                    return;
                case ItemID.DestroyerEmblem:
                    player.GetDamage<GenericDamageClass>() -= 0.1f;
                    player.GetCritChance<GenericDamageClass>() += 14;
                    return;
                case ItemID.HerculesBeetle:
                    ++player.maxTurrets;
                    player.GetDamage<SummonDamageClass>() -= 0.15f;
                    return;
                case ItemID.NecromanticScroll:
                    player.GetModPlayer<TRAEPlayer>().minionCritChance += 5;
                    player.GetDamage<SummonDamageClass>() -= 0.1f;
                    return;
                case ItemID.PapyrusScarab:
                    ++player.maxTurrets;
                    player.GetModPlayer<TRAEPlayer>().minionCritChance += 5;
                    player.GetDamage<SummonDamageClass>() -= 0.15f;
                    return;
                case ItemID.HeroShield:
                    player.hasPaladinShield = false;
                    return;
                case ItemID.BerserkerGlove:
                    player.kbGlove = false;
                    player.meleeScaleGlove = false;
                    return;
                case ItemID.SquireShield:
                    player.dd2Accessory = false;
                    player.GetDamage<MeleeDamageClass>() += 0.1f;
                    ++player.maxTurrets;
                    return;
                case ItemID.ApprenticeScarf:
                    ++player.maxTurrets;
                    player.GetDamage<SummonDamageClass>() -= 0.1f;
                    player.GetDamage<MagicDamageClass>() += 0.1f;
                    player.dd2Accessory = false;
                    return;
                case ItemID.MonkBelt:
                    ++player.maxTurrets;
                    player.GetDamage<SummonDamageClass>() += 0.1f;
                    player.dd2Accessory = false;
                    return;
                case ItemID.HuntressBuckler:
                    ++player.maxTurrets;
                    player.GetDamage<RangedDamageClass>() += 0.1f;
                    player.dd2Accessory = false;
                    return;
            }
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            switch (item.type)
            {
                case ItemID.SquireShield:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.text = "10% increased melee damage";
                        }
                    }
                    break;
                case ItemID.ApprenticeScarf:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.text = "10% increased magic damage";
                        }
                    }
                    break;
                case ItemID.HuntressBuckler:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.text = "10% increased ranged damage";
                        }
                    }
                    break;
                case ItemID.AdhesiveBandage:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "Significantly increases potency of friendly Poison\nIncreases potency of friendly debuffs by 50%";
                        }
                    }
                    break;
                case ItemID.MedicatedBandage:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "Significantly increases potency of friendly Poison\nIncreases potency of friendly debuffs by 50%";
                        }
                    }
                    break;
                case ItemID.Blindfold:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "";
                        }
                    }
                    break;
                case ItemID.FastClock:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "Time goes by faster when equipped";
                        }
                    }
                    return;
                case ItemID.Nazar:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "Unleashes curses to the wielder and nearby enemies when damaged" +
                                "\nCurses either deal damage over time, reduce contact damage by 20% or defense by 25";
                        }
                    }
                    break;
                case ItemID.CountercurseMantra:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "Provides immunity to a large number of debuffs\nUnleashes curses to nearby enemies when damaged";
                        }
                    }
                    break;
                case ItemID.HoneyComb:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {

                            line.text = "Releases bees and increases life regeneration when damaged";
                        }
                    }
                    return;

                case ItemID.BeeCloak:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "Causes buzzy stars to fall when damaged";
                        }
                    }
                    return;
                case ItemID.Shackle:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Defense")
                        {
                            line.text += "\nTemporarily increases defense when damaged";
                        }
                    }
                    return;
                case ItemID.BandofStarpower:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "Increases mana regeneration rate by 10%";
                        }
                        if (line.mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.text = "";
                        }
                    }
                    return;
                case ItemID.ManaRegenerationBand:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "Increases mana and health regeneration rate";
                        }
                        if (line.mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.text = "";
                        }
                    }
                    return;
                case ItemID.MagicCuffs:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "Restores mana and briefly increases magic damage when damaged";
                        }
                        if (line.mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.text = "";
                        }
                    }
                    return;
                case ItemID.CelestialCuffs:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "Restores mana and briefly increases magic damage when damaged";
                        }
                        if (line.mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.text = "Increases pickup range for mana stars";
                        }
                        if (line.mod == "Terraria" && line.Name == "Tooltip2")
                        {
                            line.text = "";
                        }
                    }
                    return;
                case ItemID.MechanicalGlove:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "12% increased melee damage and speed";
                        }
                        if (line.mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.text = "";
                        }
                    }
                    return;
                case ItemID.MoltenSkullRose:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.text = "Magic attacks lower enemy contact damage by 15%";
                        }
                        if (line.mod == "Terraria" && line.Name == "Tooltip2")
                        {
                            line.text = "Enemies near the player take 10% more damage";
                        }
                    }
                    return;
                case ItemID.ObsidianSkullRose:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "Magic attacks lower enemy contact damage by 15%";
                        }
                        if (line.mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.text = "Enemies near the player take 10% more damage";
                        }
                    }
                    return;
                case 3999: // Magma Skull
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.text = "Enemies near the player take 10% more damage";
                        }
                    }
                    return;
                case ItemID.ObsidianSkull:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "Enemies near the player take 10% more damage";
                        }
                    }
                    return;
                case ItemID.ObsidianShield:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.text = "Enemies near the player take 10% more damage";
                        }
                    }
                    return;
                case ItemID.ObsidianRose:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "Magic attacks lower enemy contact damage by 15%";
                        }
                    }
                    return;
                case ItemID.CrossNecklace:
                case ItemID.StarVeil:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text += "\nMore effective on strong hits";
                        }
                    }
                    return;
                case ItemID.MagnetFlower:
                case ItemID.ManaFlower:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "Magic critical hits have a chance to spawn a mana star";
                        }
                    }
                    return;
                case ItemID.ArcaneFlower:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "Magic critical hits have a chance to spawn a mana star\n5% increased magic damage and critical strike chance";
                        }
                    }
                    return;
                case ItemID.ManaCloak:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "Magic critical hits have a chance to cause a damaging star to fall";
                        }
                        if (line.mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.text = "Stars restore mana when collected";
                        }
                        if (line.mod == "Terraria" && line.Name == "Tooltip2")
                        {
                            line.text = "Automatically uses mana potions when needed";
                        }
                        if (line.mod == "Terraria" && line.Name == "Tooltip3")
                        {
                            line.text = "";
                        }
                    }
                    return;
                case ItemID.DestroyerEmblem:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "22% increased critical strike chance";
                        }
                        if (line.mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.text = "";
                        }
                    }
                    return;
                case ItemID.CelestialEmblem:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.text = "12% increased magic damage";
                        }
                    }
                    return;
                case ItemID.HeroShield:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "Grants immunity to knockback";
                        }
                        if (line.mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.text = "Enemies are more likely to target you";
                        }
                        if (line.mod == "Terraria" && line.Name == "Tooltip2")
                        {
                            line.text = "";
                        }
                        if (line.mod == "Terraria" && line.Name == "Tooltip3")
                        {
                            line.text = "";
                        }
                        if (line.mod == "Terraria" && line.Name == "Tooltip4")
                        {
                            line.text = "";
                        }
                    }
                    return;
                case ItemID.BerserkerGlove:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "12% increased melee speed";
                        }
                        if (line.mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.text = "Enables auto swing for melee weapons\nEnemies are more likely to target you";
                        }
                        if (line.mod == "Terraria" && line.Name == "Tooltip2")
                        {
                            line.text = "";
                        }
                        if (line.mod == "Terraria" && line.Name == "Tooltip3")
                        {
                            line.text = "";
                        }
                        if (line.mod == "Terraria" && line.Name == "Tooltip4")
                        {
                            line.text = "";
                        }
                    }
                    return;
                case ItemID.MagicQuiver:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "Allows arrows to bounce towards nearby enemies";
                        }
                    }
                    return;




                case ItemID.MoltenCharm:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "Minion damage is stored as Fire energy, up to 2250\nWhip strikes summon a friendly Molten Apparition for every 750 damage stored";
                        }
                        if (line.mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.text = "The wearer is immune to lava";
                        }
                    }
                    return;
                case ItemID.RoyalGel:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text += "\nStores damage dealt, dealing it slowly over time";
                        }
                    }
                    return;
                case ItemID.MoonCharm:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "Turns the holder into a werewolf when missing health";
                        }
                    }
                    return;
                case ItemID.MoonShell:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "Turns the holder into a werewolf when missing health and into a merfolk when entering water\nPuts a shell around the owner when below 50% life";
                        }
                    }
                    return;
                case ItemID.MoonStone:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "Minor increases to all stats during the night";
                        }
                    }
                    return;
                case ItemID.SunStone:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "Minor increases to all stats during the day";
                        }
                    }
                    return;
                case ItemID.CelestialStone:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "Minor increases to all stats";
                        }
                        if (line.mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.text = "";
                        }
                    }
                    return;
                case ItemID.CelestialShell:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "Turns into holder into a merfolk when entering water";
                        }
                    }
                    return;
                case ItemID.NecromanticScroll:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.text = "Gives minions a 5% chance to crit";
                        }
                    }
                    return;
                case ItemID.HerculesBeetle:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "Increases your maximum number of sentries by 1";
                        }
                    }
                    return;
                case ItemID.PapyrusScarab:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "Increases your max number of minions and sentries by 1";
                        }
                        if (line.mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.text = "Gives minions a 5% chance to crit";
                        }
                    }
                    return;
            }
        }
        public override int ChoosePrefix(Item item, UnifiedRandom rand)
        {
            if (item.type == ItemID.MagicDagger)
            {
                return rand.Next(62, 81);
            }
            return base.ChoosePrefix(item, rand);
        }
    }
}






