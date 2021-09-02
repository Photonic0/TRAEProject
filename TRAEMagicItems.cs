
using TRAEProject.Buffs;
using TRAEProject.Projectiles;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.DataStructures;
using TRAEProject.Changes;

namespace TRAEProject
{
    public class TRAEMagicItem : GlobalItem
    {
        public override bool InstancePerEntity => true;
        public override GlobalItem Clone(Item item, Item itemClone)
        {
            return base.Clone(item, itemClone);
        }
        public override void SetDefaults(Item item)
        {

            switch (item.type)
            {
                // MAGIC 
                case ItemID.AmethystStaff:
                    item.damage = 21; // up from 14
                    item.mana = 20; // up from 3
                    return;
                case ItemID.TopazStaff:
                    item.damage = 22; // up from 15
                    item.mana = 19; // up from 4
                    return; 
                case ItemID.SapphireStaff:
                    item.damage = 23; // up from 17
                    item.mana = 17; // up from 5
                    return;
                case ItemID.EmeraldStaff:
                    item.damage = 24; // up from 14
                    item.mana = 16; // up from 3
                    return;
		         case ItemID.RubyStaff:
             case ItemID.AmberStaff:
			     item.damage = 25; // up from 21
                    item.mana = 14; // up from 7
                    return;
                case ItemID.DiamondStaff:
                    item.damage = 26; // up from 23
                    item.mana = 13; // up from 8
                    return;
                case ItemID.FrostStaff:
                    item.damage = 27; 
                    item.mana = 20;
                    item.useTime = 32;
                    item.useAnimation = 32;
                    return;
                case ItemID.WandofSparking:
                    item.mana = 5; // up from 2
                    return;
                case ItemID.ThunderStaff:
                    item.damage = 24; // up from 12
                    item.mana = 21; // up from 5
                    return;
                case ItemID.Vilethorn:
                    item.mana = 30; // up from 10
                    return;
                case ItemID.CrimsonRod:
                    item.damage = 10; // down from 12
                    item.mana = 100; // up from 10
                    return;
                case ItemID.SpaceGun:
                    item.damage = 22; // up from 17
					item.mana = 10; // up from 6
                    item.useTime = 20; // up from 17
                    item.useAnimation = 20;
					return;
		        case ItemID.PoisonStaff:
                    item.damage = 15; // down from 48
                    item.mana = 45; // up from 22                  
                    return; 
                case ItemID.BeeGun:
                    item.damage = 9; 
				    item.useTime = 18; // down from 16
                    item.useAnimation = 18;
                    item.mana = 22; // up from 6
                    return;
                case ItemID.BookofSkulls:
                    item.mana = 50;
                    item.damage = 19;
                    item.value = 100000;
                    return;
                case ItemID.ZapinatorGray:
                case ItemID.ZapinatorOrange:
                    item.damage = 9; // down from 12
                    item.mana = 32; // up from 16
                    return;
				case ItemID.AquaScepter:
                    item.damage = 18; // vanilla value: 16
                    item.useTime = 16; // down from 16
                    item.useAnimation = 16;
                    item.mana = 10; // up from 6
                    return;
			    case ItemID.MagicMissile:
                    item.damage = 33; // up from 27
                    return;
                case ItemID.WaterBolt:
                    item.damage = 22; // down from 19
                    item.mana = 23; // up from 10
                    return;
				case ItemID.DemonScythe:
                    item.mana = 28; // up from 14
                    return;
                case ItemID.Flamelash:
                    item.damage = 40; // up from 19
					item.mana = 35; // up from 20
                    return;
                case ItemID.FlowerofFire:
                    item.damage = 48; 
                    item.useTime = 14; 
                    item.useAnimation = 14;
                    item.mana = 20;
					item.shootSpeed = 9f;
                    item.autoReuse = true;					
                    return;
			    case ItemID.FlowerofFrost:
                    item.damage = 60; 
                    item.useTime = 14; 
                    item.useAnimation = 14;
                    item.mana = 20;
					item.shootSpeed = 12f;
                    item.autoReuse = true;					
                    return;
                case ItemID.SharpTears:
                    item.mana = 40; // up from 20
                    return;
                case ItemID.CursedFlames:
                    item.useTime = 18; // up from 15
                    item.useAnimation = 18;
					return;
                case ItemID.GoldenShower:
                    item.mana = 14; // up from 7
                    return;
				case ItemID.CrystalStorm:
                    item.mana = 6; // up from 5
					item.useTime = 7; // up from 7
                    item.useAnimation = 7;
                    return;
                case ItemID.LaserRifle:
                    item.damage = 33;
                    return;
                case ItemID.SkyFracture:
                    item.damage = 48;
                    item.mana = 30; // up from 17
                    return;
                case ItemID.SpiritFlame:
                    item.useTime = 20; // down from 22
                    item.useAnimation = 20;
                    return;
                case ItemID.ClingerStaff:
                    item.mana = 150; // up from 40
                    return;
                case ItemID.CrystalSerpent:
                    item.mana = 19; // up from 9
                    return;
                case ItemID.CrystalVileShard:
                    item.mana = 18; // up from 13
                    return;
                case ItemID.MagicalHarp:
                    item.mana = 8; // up from 13
                    item.knockBack = 5f;
                    return;
                case ItemID.MeteorStaff:
                    item.damage = 64; // up from 53
                    return;
                case ItemID.RainbowRod:
                    item.mana = 36; // up from 21
                    return;
                case ItemID.ShadowFlameHexDoll:
                    item.mana = 19; // up from 6
                    return;
                case ItemID.NimbusRod:
				item.damage = 36; // base value: 36
                    item.mana = 100; // up from 22                  
                    return; 
                case ItemID.WaspGun:
                    item.damage = 31; // base value: 31
                    return;					
                case ItemID.UnholyTrident:
                    item.damage = 111;
                    item.useTime = 20; // up from 17
                    item.useTime = 20; // up from 17
                    item.mana = 22; // up from 22
                    item.shootSpeed = 0.66f;
                    item.knockBack = 6.66f;
                    return;
                case ItemID.HeatRay:
				item.damage = 100;
                    item.crit = 20; // up from 4%
                    return;
                case ItemID.LeafBlower:
                    item.useAnimation = 6;
                    item.useTime = 6;
                    return;
                case ItemID.NettleBurst:
                    item.mana = 24; // up from 12
                    return;
                case ItemID.StaffofEarth:
                    item.mana = 25; // up from 18
                    return;
                case ItemID.VenomStaff:
                    item.mana = 33; // up from 18
                    return;
                case ItemID.ApprenticeStaffT3:
                    item.mana = 20; // up from 14
                    return;
                case ItemID.BlizzardStaff:
                    item.autoReuse = false;
                    item.useAnimation = 25; 
                    item.useTime = 25;
                    item.mana = 250; // up form 9
                    return;
                case ItemID.BubbleGun:
                    item.mana = 12;
                    return;
                case ItemID.MagnetSphere:
                    item.mana = 150;
                    return;
                case ItemID.FairyQueenMagicItem:
                    item.mana = 40;
                    return;
                case ItemID.RainbowGun:
                    item.mana = 120;
                    item.useAnimation = 15; // down from 15
                    item.useTime = 15;
                    return;
                case ItemID.RazorbladeTyphoon:
                    item.damage = 60; // Vanilla value: 60
                    item.useTime = 25; // down from 40
                    item.useAnimation = 25; // down from 40
                    item.autoReuse = false; // changed from true
                    item.mana = 150; // up from 16
                    return;
                case ItemID.InfernoFork:
                    item.autoReuse = true;
                    item.useTime = 30; // vanilla value: 30
                    item.useAnimation = 30; // vanilla value: 30
                    return;
                case ItemID.ShadowbeamStaff:
                    item.damage = 64;
                    item.mana = 14;
                    return;
                case ItemID.ToxicFlask:
                    item.mana = 60;
                    return;
                case ItemID.LunarFlareBook:
                    item.damage = 130;
                    item.useTime = 13; 
                    item.useAnimation = 13; 
                    item.mana = 10;
                    return;
                case ItemID.NebulaBlaze:
                    item.damage = 150; // up from 130
                    return;
                case ItemID.LesserManaPotion:
                    item.healMana = 100;
                    return;
                case ItemID.ManaPotion:
                    item.healMana = 200;
                    return;
                case ItemID.GreaterManaPotion:
                    item.healMana = 300;
                    return;
                case ItemID.SuperManaPotion:
                    item.healMana = 400;
                    return;
            }
            return;
        }
        public override void OnConsumeItem(Item item, Player player)
        {
            switch (item.type)
            {
                case ItemID.LesserManaPotion:
                case ItemID.ManaPotion:
                case ItemID.GreaterManaPotion:
                case ItemID.SuperManaPotion:
                    player.AddBuff(BuffID.ManaSickness, 3000, false);
                    return;
            }
            return;
        }
        public override bool CanUseItem(Item item, Player player)
        {
            if (item.healMana > 0 && player.HasBuff(BuffID.ManaSickness))
            {
                return false;
            }
            return true;
        }
        public override void ModifyManaCost(Item item, Player player, ref float reduce, ref float mult)
        {
            switch (item.type)
            {
                case ItemID.LaserRifle: // NOT IN CHANGELOG
                    if (player.spaceGun)
                        mult = 0;
                    return;
            }
        }
        /// SHOOT STUFF
        private static int shootDelay = 1;
        public int useCount = 0;
        public override bool Shoot(Item item, Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 mousePosition = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
            switch (item.type)
            {
                case ItemID.AquaScepter:
                    {
                        int numberProjectiles = 2;
                        for (int i = 0; i < numberProjectiles; i++)
                        {
                            Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(10)); // 10 degree spread.
                            Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
                        }
                        return false; // return false because we don't want tmodloader to shoot projectile
                    }
                case ItemID.RazorbladeTyphoon:
                    {
                        for (int i = 0; i < 1000; i++)
                        {
                            if (Main.projectile[i].type == ProjectileID.Typhoon && Main.projectile[i].active && Main.projectile[i].owner == player.whoAmI)
                            {
                                Main.projectile[i].Kill();
                            }
                        }
                        return true;
                    }      
            }
            return true;       
        }
        public override void GrabRange(Item item, Player player, ref int grabRange)
        {
            // based off Qwerty's code for Recovery from his mod.
            if ((item.type == ItemID.Star || item.type == ItemID.SoulCake || item.type == ItemID.SugarPlum))
            {
                grabRange += 100; // vanilla's range for these is 250, this makes it 350.
            }
			return;
        }
        public override bool OnPickup(Item item, Player player)
        {
            // based off Qwerty's code for Recovery from his mod.
            if (item.type == ItemID.Star || item.type == ItemID.SoulCake || item.type == ItemID.SugarPlum)
            {
                Terraria.Audio.SoundEngine.PlaySound(SoundID.Grab, (int)player.position.X, (int)player.position.Y, 1, 1f, 0f);
                if(player.GetModPlayer<Mana>().celestialCuffsOverload)
                {
                    player.GetModPlayer<Mana>().GiveManaOverloadable(10);
                }
                else
                {
                    player.statMana += 10;
                    if (Main.myPlayer == player.whoAmI)
                    {
                        player.ManaEffect(10);
                    }
                    if (player.statMana > player.statManaMax2)
                    {
                        player.statMana = player.statManaMax2;
                    }
                }
                return false;
            }
            if (item.type == ItemID.ManaCloakStar)
            {
                Terraria.Audio.SoundEngine.PlaySound(SoundID.Grab, (int)player.position.X, (int)player.position.Y, 1, 1f, 0f);
                player.statMana += 10;
                if (Main.myPlayer == player.whoAmI)
                {
                    player.ManaEffect(10);
                }
                if (player.statMana > player.statManaMax2)
                {
                    player.statMana = player.statManaMax2;
                }
                return false;
            }
                return base.OnPickup(item, player);
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            switch (item.type)
            {
                case ItemID.CursedFlames:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "Fires a cursed inferno";
                        }
                    }
                    return;
                case ItemID.AquaScepter:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "Shoots a double high pressure jet of water";
                        }
                    }
                    return;
            }
        }
    }
}
