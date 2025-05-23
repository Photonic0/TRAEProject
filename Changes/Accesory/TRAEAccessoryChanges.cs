using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using TRAEProject;
using System.Collections.Generic;
using Terraria.Utilities;
using TRAEProject.NewContent.Buffs;
using TRAEProject.Changes;
using TRAEProject.NewContent.Items.Accesories.EvilEye;
using TRAEProject.NewContent.Items.Accesories.ShadowflameCharm;
using TRAEProject.Changes.Items;
using TRAEProject.Common.ModPlayers;
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
        BuffID.Electrified, BuffID.ShadowFlame, BuffID.WitheredWeapon, BuffID.WitheredArmor, BuffID.Dazed, BuffID.Burning}; // 

        void CelestialStoneStats(Player player)
        {
            player.skyStoneEffects = false;
            player.GetDamage<GenericDamageClass>() += 0.08f;
            player.GetCritChance<GenericDamageClass>() += 2;
            player.statDefense += 4;
            player.lifeRegen++;
            player.statManaMax2 += 20;
            player.GetAttackSpeed(DamageClass.Melee) += 0.05f;
            player.GetModPlayer<RangedStats>().chanceNotToConsumeAmmo += 10;
        }
        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            switch (item.type)
            {
                case ItemID.FastClock:
                    Main.time += 4;
                    player.buffImmune[BuffID.Slow] = false;
                    break;
                case ItemID.Bezoar:
                    player.GetModPlayer<Bezoar>().bezoar = true;
                    player.buffImmune[BuffID.Poisoned] = false;
                    break;
                case ItemID.AdhesiveBandage:
                    player.GetModPlayer<BandAid>().Bandaid = true;
                    player.buffImmune[BuffID.Bleeding] = false;
                    break;
                case ItemID.MedicatedBandage:
                    player.GetModPlayer<Bezoar>().bezoar = true;
                    player.GetModPlayer<BandAid>().Bandaid = true;
                    player.buffImmune[BuffID.Poisoned] = false;
                    player.buffImmune[BuffID.Bleeding] = false;
                    break;
                case ItemID.Blindfold:
                    player.AddBuff(BuffID.Obstructed, 1);
                    player.buffImmune[BuffID.Darkness] = false;
                    break;
                case ItemID.Nazar:
                    player.GetModPlayer<NazarDebuffs>().Nazar += 1;
                    player.buffImmune[BuffID.Cursed] = false;
                    break;
                case ItemID.CountercurseMantra:
                    player.GetModPlayer<NazarDebuffs>().Nazar += 1;
                    foreach (int i in AnkhDebuffList)
                    {
                        player.buffImmune[i] = true;
                    }
                    break;
                case ItemID.AnkhShield:
				player.fireWalk = false;
                    foreach (int i in AnkhDebuffList)
                    {
                        player.buffImmune[i] = true;
                    }
                    break;
                case ItemID.AnkhCharm:
                    foreach (int i in AnkhDebuffList)
                    {
                        player.buffImmune[i] = true;
                    }
                    break;
                case ItemID.RoyalGel:
                    player.GetModPlayer<Defense>().RoyalGel = true;
                    break;

                case ItemID.MoltenCharm:
                    player.lavaImmune = true;
                    player.GetModPlayer<ShadowflameCharmPlayer>().MoltenCharm += 1;
                    player.fireWalk = false;
                    break;
                case ItemID.StarVeil:
                    player.starCloakItem = null;
                    player.GetModPlayer<OnHitItems>().NewstarsOnHit = true;
                    break;
                case ItemID.MechanicalGlove:
                    player.kbGlove = false;
                    player.meleeScaleGlove = false;
                    break;
                case ItemID.MoonShell:
                    if (player.statLife > player.statLifeMax2 * 0.67)
                    {
                        player.buffImmune[BuffID.Werewolf] = true;
                    }
                    player.GetModPlayer<AccesoryEffects>().wErewolf = true;
                    if (player.statLife < player.statLifeMax2 * 0.5)
                        player.AddBuff(BuffID.IceBarrier, 1, false);
                    player.wolfAcc = false;
                    break;
                case ItemID.MoonCharm:
                    player.GetModPlayer<AccesoryEffects>().wErewolf = true;
                    player.wolfAcc = false;
                    break;
                // CELESTIAL STONE CHANGES
                case ItemID.CelestialStone:
                    CelestialStoneStats(player);

                    // total stats: +8% damage, +2% crit, +0.5 hp/s, +4 defense. +5% melee speed, +20 max mana, +5% movement speed, 10% chance not to consume ammo
                    break;
                case ItemID.MoonStone:
                    if (!Main.dayTime)
                    {
                        CelestialStoneStats(player);
                    }
                    break;
                case ItemID.SunStone:
                    if (Main.dayTime)
                    {
                        CelestialStoneStats(player);

                    }
                    break;
                case ItemID.CelestialShell:
                    CelestialStoneStats(player);
                    player.wolfAcc = false;
                    break;
                case ItemID.BandofStarpower:
                    player.GetModPlayer<Mana>().manaRegenBoost += 0.1f;                    player.statManaMax2 -= 20;
                    break;
                case ItemID.ManaRegenerationBand:
                    player.statManaMax2 -= 20;

                    player.GetModPlayer<Mana>().manaRegenBoost += 0.1f;
                    player.lifeRegen += 2;
                    break;
                case ItemID.MagicCuffs:
                    player.GetModPlayer<OnHitItems>().magicCuffsCount += 1; // the duration of the buff is the Hit's damage multiplied by this number, then multiplied by 3. This also decides how much mana is recovered.
                    player.statManaMax2 -= 20;
                    player.magicCuffs = false;
                    break;
                case ItemID.CelestialCuffs:
                    player.statManaMax2 -= 20;
                    player.GetModPlayer<OnHitItems>().magicCuffsCount += 1;
                    player.magicCuffs = false;
                    player.GetModPlayer<Mana>().celestialCuffsOverload = true;
                    break;
                case ItemID.StarCloak:
                    player.starCloakItem = null;
                    player.GetModPlayer<OnHitItems>().NewstarsOnHit = true;
                    break;
                case ItemID.ManaCloak:
                    player.starCloakItem_manaCloakOverrideItem = item;
                    player.GetModPlayer<Mana>().manaCloak = true;
                    player.manaCost += 0.08f;
                    break;
                case ItemID.ManaFlower:
                case ItemID.MagnetFlower:
                    player.GetModPlayer<Mana>().newManaFlower = true;
                    player.manaCost += 0.08f;
                    break;
                case ItemID.ArcaneFlower:
                    player.manaCost += 0.08f;
                    player.GetModPlayer<Mana>().newManaFlower = true;
                    player.GetDamage<MagicDamageClass>() += 0.05f;
                    player.GetCritChance<MagicDamageClass>() += 5;
                    break;
                case ItemID.CelestialEmblem:
                    player.GetDamage<MagicDamageClass>() -= 0.03f;
                    break;
                case ItemID.DestroyerEmblem:
                    player.GetDamage<GenericDamageClass>() -= 0.1f;
                    player.GetCritChance<GenericDamageClass>() += 14;
                    break;
                case ItemID.HerculesBeetle:
                    ++player.maxTurrets;
                    player.GetDamage<SummonDamageClass>() -= 0.15f;
                    break;
                case ItemID.NecromanticScroll:
                    player.GetModPlayer<SummonStats>().minionCritChance += 5;
                    player.GetDamage<SummonDamageClass>() -= 0.1f;
                    break;
                case ItemID.PapyrusScarab:
                    ++player.maxTurrets;
                    player.GetModPlayer<SummonStats>().minionCritChance += 5;
                    player.GetDamage<SummonDamageClass>() -= 0.15f;
                    break;
                case ItemID.HeroShield:
                    player.hasPaladinShield = false;
                    break;
                case ItemID.BerserkerGlove:
                    player.kbGlove = false;
                    player.meleeScaleGlove = false;
                    break;
                case ItemID.SquireShield:
                    player.dd2Accessory = false;
                    player.GetDamage<MeleeDamageClass>() += 0.07f;
                    ++player.maxTurrets;
                    break;
                case ItemID.ApprenticeScarf:
                    ++player.maxTurrets;
                    player.GetDamage<SummonDamageClass>() -= 0.1f;
                    player.GetDamage<MagicDamageClass>() += 0.07f;
                    player.dd2Accessory = false;
                    break;
                case ItemID.MonkBelt:
                    ++player.maxTurrets;
                    player.GetDamage<SummonDamageClass>() += 0.07f;
                    player.dd2Accessory = false;
                    break;
                case ItemID.HuntressBuckler:
                    ++player.maxTurrets;
                    player.GetDamage<RangedDamageClass>() += 0.07f;
                    player.dd2Accessory = false;
                    break;
                case ItemID.RifleScope:
                    player.GetModPlayer<RangedStats>().GunScope = true;
                    player.GetModPlayer<RangedStats>().gunVelocity += 0.5f; 
                    break;
                case ItemID.SniperScope:
                    player.GetModPlayer<RangedStats>().GunScope = true;
                    player.GetModPlayer<RangedStats>().gunVelocity += 0.5f;
                    player.GetDamage<RangedDamageClass>() -= 0.1f;
                    break;
    
            }
        }
        public override void ModifyShootStats(Item item, Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (item.CountsAsClass(DamageClass.Ranged))
            {
                velocity *= player.GetModPlayer<RangedStats>().rangedVelocity; 
                if (item.useAmmo == AmmoID.Bullet || item.useAmmo == AmmoID.CandyCorn)
                {
                    velocity *= player.GetModPlayer<RangedStats>().gunVelocity;
                }
            }
          
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            switch (item.type)
            {
                
                case ItemID.SquireShield:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.Text = "7% increased melee damage";
                        }
                    }
                    break;
                case ItemID.ApprenticeScarf:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.Text = "7% increased magic damage";
                        }
                    }
                    break;
                case ItemID.HuntressBuckler:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.Text = "7% increased ranged damage";
                        }
                    }
                    break;
                case ItemID.MonkBelt:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.Text = "7% increased summon damage";
                        }
                    }
                    break;
                case ItemID.Bezoar:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = "Significantly increases potency of friendly Poison";
                        }
                    }
                    break;
                case ItemID.AdhesiveBandage:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = "Increases potency of friendly debuffs by 50%";
                        }
                    }
                    break;
                case ItemID.MedicatedBandage:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = "Significantly increases potency of friendly Poison\nIncreases potency of friendly debuffs by 50%";
                        }
                    }
                    break;
                case ItemID.Blindfold:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = "";
                        }
                    }
                    break;
                case ItemID.FastClock:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = "Time goes by faster when equipped";
                        }
                    }
                    break;
                case ItemID.Nazar:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = "Unleashes curses to the wielder and nearby enemies when damaged" +
                                "\nCurses either deal damage over time, reduce contact damage by 20% or defense by 25";
                        }
                    }
                    break;
                case ItemID.CountercurseMantra:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = "Provides immunity to a large number of debuffs\nUnleashes curses to nearby enemies when damaged";
                        }
                    }
                    break;
                case ItemID.HoneyComb:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {

                            line.Text = "Releases bees and increases life regeneration when damaged";
                        }
                    }
                    break;
          
       
                case ItemID.Shackle:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Defense")
                        {
                            line.Text += "\nTemporarily increases defense when damaged";
                        }
                    }
                    break;
                case ItemID.BandofStarpower:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = "Increases mana regeneration rate by 10%";
                        }
                        if (line.Mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.Text = "";
                        }
                    }
                    break;
                case ItemID.ManaRegenerationBand:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = "Increases mana and health regeneration rate";
                        }
                        if (line.Mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.Text = "";
                        }
                    }
                    break;
                case ItemID.AnkhShield:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = "Grants immunity to knockback and most debuffs";
                        }
                        if (line.Mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.Text = "";
                        }
                    }
                    break;
                case ItemID.MagicCuffs:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = "Restores mana when damaged";
                        }
                        if (line.Mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.Text = "Can go over maximum mana";
                        }
                    }
                    break;
                case ItemID.CelestialCuffs:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = "Restores mana when damaged, can go over maximum mana";
                        }
                        if (line.Mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.Text = "Increases pickup range for mana stars";
                        }
                        if (line.Mod == "Terraria" && line.Name == "Tooltip2")
                        {
                            line.Text = "";
                        }
                    }
                    break;
                case ItemID.MechanicalGlove:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = "12% increased melee damage and speed";
                        }
                        if (line.Mod == "Terraria" && line.Name == "Tooltip1")
                        {
                           line.Text = "Enables autoswing for melee weapons";
                        }
                        if (line.Mod == "Terraria" && line.Name == "Tooltip2")
                        {
                            line.Text = "";
                        }
                        if (line.Mod == "Terraria" && line.Name == "Tooltip3")
                        {
                            line.Text = "";
                        }
                    }
                    break;
                case ItemID.CrossNecklace:
                case ItemID.StarVeil:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text += "\nMore effective on strong hits";
                        }
                    }
                    break;
                case ItemID.MagnetFlower:
                case ItemID.ManaFlower:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = "Magic critical strikes have a chance to spawn a mana star";
                        }
                    }
                    break;
                case ItemID.ArcaneFlower:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = "Magic critical strikes have a chance to spawn a mana star\n5% increased magic damage and critical strike chance";
                        }
                    }
                    break;
                case ItemID.ManaCloak:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = "Magic critical strikes have a chance to cause a damaging star to fall";
                        }
                        if (line.Mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.Text = "Stars restore mana when collected";
                        }
                        if (line.Mod == "Terraria" && line.Name == "Tooltip2")
                        {
                            line.Text = "Automatically uses mana potions when needed";
                        }
                        if (line.Mod == "Terraria" && line.Name == "Tooltip3")
                        {
                            line.Text = "";
                        }
                    }
                    break;
                case ItemID.DestroyerEmblem:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = "22% increased critical strike chance";
                        }
                        if (line.Mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.Text = "";
                        }
                    }
                    break;
                case ItemID.CelestialEmblem:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.Text = "12% increased magic damage";
                        }
                    }
                    break;
                case ItemID.HeroShield:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = "Grants immunity to knockback";
                        }
                        if (line.Mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.Text = "Enemies are more likely to target you";
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
                    break;
                case ItemID.BerserkerGlove:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = "12% increased melee speed";
                        }
                        if (line.Mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.Text = "Enables auto swing for melee weapons\nEnemies are more likely to target you";
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
                    break;
                case ItemID.MoltenCharm:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = "Minion damage is stored as Fire energy, up to 3000\nWhip strikes summon a friendly Molten Apparition for every 750 damage stored";
                        }
                        if (line.Mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.Text = "The wearer is immune to lava";
                        }
                    }
                    break;
                case ItemID.RoyalGel:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text += "\nReduces damage of one hit by 25 every 30 seconds";
                        }
                    }
                    break;
                case ItemID.MoonCharm:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = "Turns the holder into a werewolf when missing health";
                        }
                    }
                    break;
                case ItemID.MoonShell:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = "Turns the holder into a werewolf when missing health and into a merfolk when entering water\nPuts a shell around the owner when below 50% life";
                        }
                    }
                    break;
                case ItemID.SunStone:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = "Minor increases to damage, maximum mana, chance not to consume ammo,";
                        }

                    }
                    break;
                case ItemID.MoonStone:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = "Minor increases to damage, maximum mana, chance not to consume ammo,";
                        }

                    }
                    break;
                case ItemID.CelestialStone:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = "Minor increases to damage, maximum mana, chance not to consume ammo,";
                        }
                        if (line.Mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.Text = "melee speed, critical strike chance, life regeneration,";
                        }
                    }
                    break;
                case ItemID.CelestialShell:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = "Turns into holder into a merfolk when entering water";
                        }
                        if (line.Mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.Text = "Minor increases to damage, maximum mana,";
                        }
                        if (line.Mod == "Terraria" && line.Name == "Tooltip2")
                        {
                            line.Text = "chance not to consume ammo, melee speed,";
                        }
                    }
                    break;
                case ItemID.NecromanticScroll:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.Text = "Gives minions a 5% chance to crit";
                        }
                    }
                    break;
                case ItemID.HerculesBeetle:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = "Increases your maximum number of sentries by 1";
                        }
                    }
                    break;
                case ItemID.PapyrusScarab:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = "Increases your max number of minions and sentries by 1";
                        }
                        if (line.Mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.Text = "Gives minions a 5% chance to crit";
                        }
                    }
                    break;
                case ItemID.MagicQuiver:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = "Your arrows will bounce towards nearby enemies, losing 33% damage in the process";
                        }
                        if (line.Mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.Text = "";
                        }
                    }
                    break;
                case ItemID.StalkersQuiver:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = "Your arrows will bounce towards nearby enemies, losing 33% damage in the process";

                        }
                        if (line.Mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.Text = "5% increased ranged damage and critical strike chance";
                        }
                    }
                    break;

                case ItemID.RifleScope:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = "Increases view range for guns (right click to zoom out!)";
                        }
                        if (line.Mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.Text = "Increases ranged velocity and tightens gun spread";
                        }
                    }
                    break;
                case ItemID.SniperScope:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.Text = "Increases ranged velocity and tightens gun spread\n10% increased ranged critical strike chance";
                        }
                    }
                    break;
                case ItemID.ReconScope:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text = "Increases view range for guns (right click to zoom out!)";
                        }
                        if (line.Mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.Text = "Increases ranged velocity and tightens gun spread";
                        }
                        if (line.Mod == "Terraria" && line.Name == "Tooltip2")
                        {
                            line.Text = "Your ranged attacks will bounce towards their nearby enemy";
                        }
                    }
                    break;
                case ItemID.ShinyStone:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text += "\nIncreases life regeneration by 2hp/s when on the ground";
                        }
                    }
                    return;
            }
        }
    }
}






