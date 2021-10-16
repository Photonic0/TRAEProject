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
            case ItemID.ArcticDivingGear:
            case ItemID.JellyfishDivingGear:
            case ItemID.JellyfishNecklace:
                if (player.wet)
                {
                    player.AddBuff(BuffID.Hunter, 60);
                }
                return;
            case ItemID.WaterWalkingBoots:
                player.GetModPlayer<TRAEPlayer>().waterRunning = true;
                player.waterWalk = true;
                return;
            case ItemID.ObsidianHorseshoe:
                player.fireWalk = false;
                player.GetModPlayer<TRAEPlayer>().FastFall = true;
                return;
            case ItemID.ObsidianWaterWalkingBoots:
                player.waterWalk2 = false;
                player.rocketBoots = 1;
                player.rocketTimeMax += 4;
                //player.wingTimeMax += 7;
                player.GetModPlayer<TRAEPlayer>().FastFall = true;
                player.noFallDmg = true;
                player.fireWalk = false;
                player.buffImmune[BuffID.Burning] = false; 
                return;
            case ItemID.LavaCharm:
                player.GetModPlayer<TRAEPlayer>().LavaShield = true;
                return;
            case ItemID.LavaWaders:
                player.GetModPlayer<TRAEPlayer>().waterRunning = true;
                player.GetModPlayer<TRAEPlayer>().LavaShield = true;
                player.fireWalk = false;
				player.lavaImmune = true;
				player.lavaRose = false;
                return;
            case ItemID.HiveBackpack:
                player.GetModPlayer<TRAEPlayer>().Hivepack = true;
                player.strongBees = false;
                return;
            case ItemID.RoyalGel:
                player.GetModPlayer<TRAEPlayer>().RoyalGel = true;
                return;
            case ItemID.FrogLeg:
            case ItemID.FrogWebbing:
            case ItemID.FrogFlipper:
            case ItemID.AmphibianBoots:
                player.frogLegJumpBoost = false;
                player.extraFall += 15;
                player.jumpSpeedBoost += 1.4f;
                return;
            case ItemID.FrogGear:
                player.frogLegJumpBoost = false;
                player.accFlipper = true; 
                player.dashType = 2;
                player.spikedBoots = 0; 
                player.extraFall += 15;
                player.jumpSpeedBoost += 1.4f;
                return;     
			case ItemID.Aglet:
                player.moveSpeed += 0.05f;
                return;
            case ItemID.AnkletoftheWind:
                player.jumpSpeedBoost += 0.5f;
                return;
      
            case ItemID.FrostsparkBoots:
                player.rocketTimeMax = 0;
                player.accRunSpeed = 6f;
                player.moveSpeed -= 0.08f;
                player.GetModPlayer<TRAEPlayer>().icceleration = true;
                return;
            case ItemID.TerrasparkBoots:
                player.iceSkate = false;
                player.lavaMax -= 42; 
                player.fireWalk = false;
                player.waterWalk = false;
                player.rocketTimeMax = 0;
                player.accRunSpeed = 9f;
                player.moveSpeed -= 0.08f;
                return;
            case ItemID.LightningBoots:
                player.moveSpeed += 0.02f;
                player.jumpSpeedBoost += 0.5f;
                player.rocketTimeMax = 7;
                player.accRunSpeed = 6.75f;
                return;
            case ItemID.RocketBoots:
                player.rocketTimeMax = 7;
                return;
			case ItemID.BundleofBalloons:
                player.noFallDmg = true;
                return;
            case ItemID.MoltenCharm:
            player.lavaImmune = true;
                player.GetModPlayer<ShadowflameCharmPlayer>().MoltenCharm += 1; 
                player.fireWalk = false;
                return;
            case ItemID.IceSkates:
                player.GetModPlayer<TRAEPlayer>().icceleration = true;
                return;

            case ItemID.BalloonHorseshoeHoney:
            case ItemID.HoneyBalloon:
                player.GetModPlayer<TRAEPlayer>().honeyBalloon = true;
                return;
            case ItemID.BeeCloak:
                player.honeyCombItem = null;
                player.starCloakItem = null;
                player.GetModPlayer<TRAEPlayer>().NewbeesOnHit = true;
                return;
            case ItemID.CrossNecklace:
            case ItemID.StarVeil:
                player.starCloakItem = null;
                player.GetModPlayer<TRAEPlayer>().NewstarsOnHit = true;
                return;
            case ItemID.MagicQuiver:
                player.magicQuiver = false;
                player.GetModPlayer<TRAEPlayer>().MagicQuiver = true;
                return;
            case ItemID.MechanicalGlove:
                player.kbGlove = false;
                player.meleeScaleGlove = false;
                return;
            case ItemID.Shackle:
                player.GetModPlayer<TRAEPlayer>().shackle = true;
                return;
            case ItemID.PocketMirror:
                player.GetModPlayer<TRAEPlayer>().pocketMirror = true;
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
                player.GetModPlayer<TRAEPlayer>().magicCuffsCount += 1; // the duration of the buff is the Hit's damage multiplied by this number, then multiplied by 3. This also decides how much mana is recovered.
                player.statManaMax2 -= 20;
				player.magicCuffs = false;
                return;
            case ItemID.CelestialCuffs:
                player.statManaMax2 -= 20;
				player.GetModPlayer<TRAEPlayer>().magicCuffsCount += 1;
			    player.magicCuffs = false;
                player.GetModPlayer<Mana>().celestialCuffsOverload = true;
                return;
            case ItemID.StarCloak:
                player.starCloakItem = null;
                player.GetModPlayer<TRAEPlayer>().NewstarsOnHit = true;
                return;

            case ItemID.EmpressFlightBooster:
                player.jumpSpeedBoost -= 2.4f;
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
            case ItemID.HoneyBalloon:
                foreach (TooltipLine line in tooltips)
                {
                    if (line.mod == "Terraria" && line.Name == "Tooltip0")
                    {
                        line.text = "Releases bees and douses you in honey when damaged";
                    }
                    if (line.mod == "Terraria" && line.Name == "Tooltip1")
                    {
                        line.text = "Increases jump height and life regeneration";
                    }
                }
                return;
            case ItemID.BalloonHorseshoeHoney:
                foreach (TooltipLine line in tooltips)
                {
                    if (line.mod == "Terraria" && line.Name == "Tooltip0")
                    {
                        line.text = "Releases bees and douses you in honey when damaged and negates fall damage";
                    }
                    if (line.mod == "Terraria" && line.Name == "Tooltip1")
                    {
                        line.text = "Increases jump height and life regeneration";
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
            case ItemID.IceSkates:
                foreach (TooltipLine line in tooltips)
                {
                    if (line.mod == "Terraria" && line.Name == "Tooltip0")
                    {
                        line.text = "Increases acceleration\nIncreases mobility in ice";
                    }
                }
                return;
            case ItemID.FrostsparkBoots:
                foreach (TooltipLine line in tooltips)
                {
                    if (line.mod == "Terraria" && line.Name == "Tooltip0")
                    {
                        line.text = "Allows super fast running and increases mobility in ice";
                    }
                    if (line.mod == "Terraria" && line.Name == "Tooltip1")
                    {
                        line.text = "Increases acceleration";
                    }
                }
                return;
			case ItemID.Aglet:        
			foreach (TooltipLine line in tooltips)
                {
                    if (line.mod == "Terraria" && line.Name == "Tooltip0")
                    {
                        line.text = "10% increased movement speed";
                    }
                }
                return;
            case ItemID.AnkletoftheWind:
                foreach (TooltipLine line in tooltips)
                {
                    if (line.mod == "Terraria" && line.Name == "Tooltip0")
                    {
                        line.text = "10% increased movement and jump speed";
                    }
                }
                return;
            case ItemID.LightningBoots:
                foreach (TooltipLine line in tooltips)
                {
                    if (line.mod == "Terraria" && line.Name == "Tooltip1")
                    {
                        line.text = "10% increased movement and jump speed";
                    }
                }
                return;
            case ItemID.TerrasparkBoots:
                foreach (TooltipLine line in tooltips)
                {
                    if (line.mod == "Terraria" && line.Name == "Tooltip0")
                    {
                        line.text = "The wearer can run extremely fast";
                    }
                    if (line.mod == "Terraria" && line.Name == "Tooltip1")
                    {
                        line.text = "";
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
            case ItemID.WaterWalkingBoots:
                foreach (TooltipLine line in tooltips)
                {
                    if (line.mod == "Terraria" && line.Name == "Tooltip0")
                    {
                        line.text = "The wearer can walk on water\nIncreases running speed when walking on a liquid";
                    }
                }
                return;
            case ItemID.ObsidianHorseshoe:
                foreach (TooltipLine line in tooltips)
                {
                    if (line.mod == "Terraria" && line.Name == "Tooltip0")
                    {
                        line.text = "Negates fall damage";
                    }
                    if (line.mod == "Terraria" && line.Name == "Tooltip1")
                    {
                        line.text = "Hold DOWN to increase falling speed";
                    }
                }
                return;
            case ItemID.ObsidianWaterWalkingBoots:
                foreach (TooltipLine line in tooltips)
                {
                    if (line.mod == "Terraria" && line.Name == "Tooltip0")
                    {
                        line.text = "Allows extended flight";
                    }
                    if (line.mod == "Terraria" && line.Name == "Tooltip1")
                    {
                        line.text = "Hold DOWN to increase falling speed";
                    }
                    if (line.mod == "Terraria" && line.Name == "Tooltip2")
                    {
                        line.text = "Grants immunity to fall damage";
                    }
                }
                return;
            case ItemID.LavaCharm:
                foreach (TooltipLine line in tooltips)
                {
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text += "\nShields the wearer when entering lava";
                        }
                    }
                }
                return;
            case ItemID.LavaWaders:
                foreach (TooltipLine line in tooltips)
                {
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "Increases movement speed and shields the wearer when entering liquids";
                        }
                        if (line.mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.text = "Allows walking on water and grants immunity to lava";
                        }
                    }
                }
                return;
            case ItemID.JellyfishNecklace:
                foreach (TooltipLine line in tooltips)
                {
                    if (line.mod == "Terraria" && line.Name == "Tooltip0")
                    {
                        line.text = "Provides light and reveals enemies under water";
                    }
                }
                return;
            case ItemID.JellyfishDivingGear:
                foreach (TooltipLine line in tooltips)
                {
                    if (line.mod == "Terraria" && line.Name == "Tooltip1")
                    {
                        line.text = "Provides light and reveals enemies under water";
                    }
                }
                return;
            case ItemID.ArcticDivingGear:
                foreach (TooltipLine line in tooltips)
                {
                    if (line.mod == "Terraria" && line.Name == "Tooltip1")
                    {
                        line.text = "Provides light and reveals enemies under water\nPuts a barrier around the wearer when below 50% health";
                    }
                }
                return;
            case ItemID.HiveBackpack:
                foreach (TooltipLine line in tooltips)
                {
                    if (line.mod == "Terraria" && line.Name == "Tooltip0")
                    {
                        line.text = "Stores up to 16 bees while grounded, releases them while in mid-air\nIncreases jump height by 25%, and slightly more for every bee stored\nDamage, recharge delay and release rate doubled when honeyed";
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
            case ItemID.FrogGear:
                foreach (TooltipLine line in tooltips)
                {
                    if (line.mod == "Terraria" && line.Name == "Tooltip1")
                    {
                        line.text = "Allows the wearer to perform a short dash";
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






