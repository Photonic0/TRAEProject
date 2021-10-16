
using TRAEProject.Buffs;
using TRAEProject.Projectiles;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.DataStructures;

namespace TRAEProject
{
    public class TRAEGlobalItem : GlobalItem
    {
        public override bool InstancePerEntity => true;
  
        public int BaseDamage = 1;
        public float baseVelocity = 1f;
        public override GlobalItem Clone(Item item, Item itemClone)
        {
            return base.Clone(item, itemClone);
        }
        public override void SetDefaults(Item item)
        {

			if (item.ammo > 0 && item.type != ItemID.SilverCoin && item.type != ItemID.GoldCoin && item.type != ItemID.CopperCoin && item.type != ItemID.PlatinumCoin && item.type != ItemID.PlatinumCoin && item.type != ItemID.Ale && item.type != ItemID.SandBlock)
            {
                item.maxStack = 3000;
            }
            switch (item.type)
            {
                case ItemID.AdamantitePickaxe:
			       item.useTime = 7; // down from 8
                    item.useAnimation = 7;
				   return;
				// PHM SWORD LAND
                case ItemID.CopperBroadsword:
                    item.damage = 13;
					item.scale = 1.25f;
                    item.useTime = 20;
                    item.useAnimation = 20;
                    return;
                case ItemID.TinBroadsword:
                    item.damage = 14;
                    item.scale = 1.25f;
					item.useTime = 20;
                    item.useAnimation = 20;
                    return;
                case ItemID.IronBroadsword:
                    item.damage = 15;
					item.scale = 1.25f;
                    item.useTime = 20;
                    item.useAnimation = 20;
                    return;
                case ItemID.LeadBroadsword:
                    item.damage = 16;
					item.scale = 1.25f;
                    item.useAnimation = 20;
					item.useTime = 20;
                    return;
                case ItemID.SilverBroadsword:
                    item.damage = 17;
					item.scale = 1.25f;
                    item.useTime = 20;
                    item.useAnimation = 20;
                    return;
                case ItemID.TungstenBroadsword:
                    item.damage = 18;
					item.scale = 1.25f;
                    item.useTime = 20;
                    item.useAnimation = 20;
                    return;
                case ItemID.GoldBroadsword:
                    item.damage = 19;
					item.scale = 1.25f;
                    item.useTime = 18;
                    item.useAnimation = 18;
                    return;
                case ItemID.PlatinumBroadsword:
                    item.damage = 20;
					item.scale = 1.25f;
                    item.useTime = 18;
                    item.useAnimation = 18;
                    return;
                case ItemID.AntlionClaw:
                    item.useTime = 11;
                    item.useAnimation = 11;
                    return;
                case ItemID.ZombieArm:
                    item.damage = 15; // up from 12
                    item.useTime = 20;
                    item.useAnimation = 20;
                    item.knockBack = 8.25f;
                    item.autoReuse = true;
                    return;
                case ItemID.BoneSword:
                    item.damage = 24;
					item.scale = 1.33f;
                    item.autoReuse = true;
                    item.value = 500000;
                    return;
                //phaseblades
                case ItemID.PurplePhaseblade:
                    item.damage = 29;
                    item.crit = 8;
                    item.knockBack = 0.1f;
                    item.useTime = 25;
                    item.useAnimation = 25;
                    item.shoot = ProjectileType<Blank>();
                    item.autoReuse = true;
                    item.useTurn = false;
                    return;
                case ItemID.YellowPhaseblade:
                    item.damage = 29;
                    item.crit = 10;
                    item.knockBack = 0.1f;
                    item.useTime = 25;
                    item.useAnimation = 25;
                    item.shoot = ProjectileType<Blank>();
                    item.autoReuse = true;
                    item.useTurn = false;
                    return;
                case ItemID.BluePhaseblade:
                    item.damage = 29;
                    item.crit = 12;
                    item.knockBack = 0.1f;
                    item.useTime = 25;
                    item.useAnimation = 25;
                    item.shoot = ProjectileType<Blank>();
                    item.autoReuse = true;
                    item.useTurn = false;
                    return;
                case ItemID.GreenPhaseblade:
                    item.damage = 29;
                    item.crit = 14;
                    item.knockBack = 0.1f;
                    item.useTime = 25;
                    item.useAnimation = 25;
                    item.autoReuse = true;
                    item.useTurn = false;
                    return;
                case ItemID.RedPhaseblade:
                    item.damage = 29;
                    item.crit = 16;
                    item.knockBack = 0.1f;
                    item.useTime = 25;
                    item.useAnimation = 25;
                    item.autoReuse = true;
                    item.useTurn = false;
                    return;
                case ItemID.WhitePhaseblade:
                    item.damage = 29;
                    item.crit = 18;
                    item.knockBack = 0.1f;
                    item.useTime = 25;
                    item.useAnimation = 25;
                    item.autoReuse = true;
                    item.useTurn = false;
                    return;
                // more swords
                case ItemID.LightsBane:
                    item.damage = 21;
                    item.useTime = 17;
                    item.useAnimation = 17;
                    item.shoot = ProjectileType<Blank>();
                    return;
                case ItemID.BloodButcherer:
                    item.damage = 24;
                    item.useTime = 25;
                    item.useAnimation = 25;
                    item.shoot = ProjectileType<Blank>();
                    return;
                case ItemID.Muramasa:
                    item.shoot = ProjectileType<Blank>();
                    item.useTurn = false;
                    return;
                case ItemID.BladeofGrass:
                    item.useTime = 30;
                    item.useAnimation = 30;
                    item.shoot = ProjectileType<Blank>();
                    return;
                case ItemID.FieryGreatsword:
                    item.useTime = 42;
                    item.useAnimation = 42;
                    item.autoReuse = true;
                    return;
                case ItemID.NightsEdge:
                    item.shoot = ProjectileType<NightsBeam>();
                    item.damage = 38;
                    item.useTime = 60;
                    item.useAnimation = 30;
                    item.autoReuse = true;
                    item.shootSpeed = 7f;
                    return;
                case ItemID.ChainKnife:
                    item.crit = 12;
                    item.autoReuse = true;
                    item.value = 50000;
                    return;

                case ItemID.VampireKnives:
                    item.damage = 41; // up from 29
                    return;
                case ItemID.PurpleClubberfish:
                    item.scale = 1.4f;
                    item.damage = 34;
                    item.autoReuse = true;
                    return;
                case ItemID.IceBoomerang:
                    item.damage = 22; // up from 16
                    item.crit = 12; // up from 6%
                    return;
                case ItemID.Flamarang:
                    item.damage = 45; // up from 32
                    return;
                case ItemID.BlueMoon:
                    item.damage = 32;
                    item.crit = 11;
                    return;
                case ItemID.Sunfury:
                    item.damage = 16;
                    item.crit = 4;
                    return;    
				case ItemID.Flairon:
                    item.noMelee = false;
                    return;
                case ItemID.HelFire:
                    item.damage = 39;
                    item.knockBack = 7f;
                    return;
                case ItemID.Cascade:
                    item.damage = 27; // up from 27
                    return;
                case ItemID.Gradient:
                    item.damage = 29;
                    item.knockBack = 6f;
                    return;
                case ItemID.Chik:
                    item.damage = 39;
                    item.knockBack = 1f;
                    return;
                case ItemID.Kraken:
                    item.damage = 88; // vanilla value = 95
                    return;
                /// SUMMONER
                case ItemID.ThornWhip:
                    item.damage = 19; // up from 18
                    return;
                case ItemID.BoneWhip:
                    item.damage = 29; // down from 29
                    return;
                case ItemID.SwordWhip:
                    item.damage = 59;
                    return;
                case ItemID.ScytheWhip:
                    item.damage = 111; // up from 100
                    return;
                case ItemID.RainbowWhip:
                    item.damage = 250; // up from 180
                    item.autoReuse = true;
                    return;
                /// RANGED 
                case ItemID.Boomstick:
                    item.damage = 11; // down from 14
                    return;
			    case ItemID.BeesKnees:
                    item.damage = 18; // down from 23?
                    return;
				case ItemID.Revolver:
                    item.damage = 30; // up from 20
                    item.value = 250000; // 25 gold
                    return;
                case ItemID.Flamethrower:
                    item.damage = 14; // down from 35
                    item.shootSpeed = 5.33f; // down from 7
                    item.useAnimation = 60; // down from 30
                    item.useTime = 10; // up from 6
                    item.knockBack = 0.25f; // down from 0.3
                    return;
                case ItemID.EldMelter:
				    item.damage = 30;
                    item.useAnimation = 60; // up from 30
                    item.useTime = 6; // up from 6
                    return;
                case ItemID.Harpoon:
                    item.shoot = ProjectileType<Harpoon>();
                    item.shootSpeed = 22f;
                    item.useAnimation = 36;
                    item.useTime = 36;
                    return;
                case ItemID.FlintlockPistol:
                    item.damage = 6; // down from 10
                    item.useAnimation = 8; // down from 16
                    item.useTime = 8; // down from 16
                    item.shootSpeed = 7f;
                    item.autoReuse = false; //These are minishark's stats, BUT this weapon doesn't autofire
                    return;
                case ItemID.Handgun:
                    item.damage = 20; // up from 17
                    return;
                //case ItemID.Marrow: // REVISIT
                //case ItemID.IceBow:
                //    item.damage = 40;
                //    item.crit = 4;
                //    item.useTime = 23;
                //    item.useAnimation = 23;
                //    item.autoReuse = true;
                //    return;
                case ItemID.Toxikarp:
                    item.useTime = 14;
                    item.useAnimation = 14;
                    return;
                case ItemID.DaedalusStormbow: // REVISIT
                    item.damage = 30;
                    return;
                case ItemID.Megashark:
                    item.damage = 20; // down from 26
                    return;
                case ItemID.TheUndertaker:
                case ItemID.SniperRifle:
                    item.autoReuse = true;
                    return;
                case ItemID.JackOLanternLauncher:
                    item.shootSpeed = 14f; // up from 7
                    return;
                case ItemID.CandyCornRifle:
                    item.damage = 60; // up from 44
                    return;
                case ItemID.StakeLauncher:
                    item.useTime = 15;
                    item.useAnimation = 15;
                    return;
                case ItemID.TacticalShotgun:
                    item.damage = 34; // up from 29
                    item.useTime = 32; // down from 34
                    item.useAnimation = 32; // down from 34
                    return;
                case ItemID.NailGun:
                    item.damage = 110; // up from 85
                    return;
    
                case ItemID.Tsunami:
                    item.damage = 79;
                    item.useTime = 40;
                    item.useAnimation = 40;
                    return;          
			    case ItemID.FairyQueenRangedItem:
					item.damage = 40; // down from 50
				    return;
                case ItemID.ChainGun:
                    item.damage = 41; // up from 31
                    return;
                case ItemID.Phantasm:
                    item.damage = 40; // down from 50
                    return;
                case ItemID.VortexBeater:
                    item.damage = 42;
                    return;
                case ItemID.MeteorShot:
                    item.damage = 7;
                    return;
                case ItemID.CrystalBullet:
                    item.damage = 7; // down from 9
                    return;
                case ItemID.NanoBullet:
                    item.damage = 10; // unchanged
                    item.knockBack = 7f;
                    return;
                case ItemID.MoonlordBullet:
                    item.damage = 50; // up from 20
                    return;
                case ItemID.FlamingArrow:
                    item.shootSpeed = 5f;
                    item.knockBack = 6f;
                    return;
                case ItemID.HolyArrow:
                    item.damage = 10;
                    return;
                case ItemID.IchorArrow:
                    item.damage = 14;
                    return;
                case ItemID.HellfireArrow:
                    item.damage = 14;
                    item.shootSpeed = 3.5f;
                    return;     
			    case ItemID.ChlorophyteArrow:
                    item.damage = 10; // down from 16
                    item.knockBack = 2f; // down from 3.5
                    return;
                // equipment
                case ItemID.Rally:
                    item.value = 50000;
                    return;
                case ItemID.PharaohsMask:
                    item.defense = 2;
                    item.vanity = false;
                    return;
                case ItemID.PharaohsRobe:
                    item.defense = 3;
                    item.vanity = false;
                    return;
                case ItemID.RuneHat:
                    item.defense = 4;
                    item.vanity = false;
                    return;
                case ItemID.RuneRobe:
                    item.defense = 8;
                    item.vanity = false;
                    return;
                case ItemID.PirateHat:
                    item.defense = 7;
                    item.rare = ItemRarityID.Orange;
                    item.vanity = false;
                    return;
                case ItemID.PirateShirt:
                    item.defense = 12;
                    item.rare = ItemRarityID.Orange;
                    item.vanity = false;
                    return;
                case ItemID.PiratePants:
                    item.defense = 9;
                    item.rare = ItemRarityID.Orange;
                    item.vanity = false;
                    return;
             
                case ItemID.WoodGreaves:
                    item.defense = 1;
                    return;
                case ItemID.BorealWoodBreastplate:
                case ItemID.PalmWoodBreastplate:
                case ItemID.EbonwoodHelmet:
                case ItemID.EbonwoodGreaves:
                case ItemID.ShadewoodHelmet:
                case ItemID.ShadewoodGreaves:
                case ItemID.RichMahoganyHelmet:
                case ItemID.RichMahoganyBreastplate:
                case ItemID.RichMahoganyGreaves:
                    item.defense = 2;
                    return;
                case ItemID.CopperHelmet:
                case ItemID.CopperGreaves:
                case ItemID.TinGreaves:
                    item.defense = 3;
                    return;
                case ItemID.CopperChainmail:
                case ItemID.TinHelmet:
                case ItemID.TinChainmail:
                case ItemID.IronHelmet:
                case ItemID.AncientIronHelmet:
                case ItemID.IronGreaves:
                case ItemID.LeadGreaves:
                    item.defense = 4;
                    return;
                case ItemID.IronChainmail:
                case ItemID.LeadChainmail:
                case ItemID.LeadHelmet:
                case ItemID.SilverGreaves:
                case ItemID.TungstenGreaves:
                case ItemID.SilverHelmet:
                case ItemID.FossilHelm:
                case ItemID.FossilPants:
                    item.defense = 5;
                    return;
                case ItemID.JungleHat:
                case ItemID.TungstenHelmet:
                case ItemID.TungstenChainmail:
                case ItemID.SilverChainmail:
                case ItemID.GoldHelmet:
                case ItemID.GoldGreaves:
                case ItemID.AncientGoldHelmet:
                case ItemID.PlatinumGreaves:
                case ItemID.FossilShirt:
                    item.defense = 6;
                    return;
                case ItemID.MythrilHat:
                case ItemID.GoldChainmail:
                case ItemID.PlatinumChainmail:
                case ItemID.PlatinumHelmet:
                case ItemID.ShadowHelmet:
                case ItemID.CrimsonHelmet:
                case ItemID.AncientShadowHelmet:
                case ItemID.ShadowGreaves:
                case ItemID.CrimsonGreaves:
                case ItemID.AncientShadowGreaves:
                    item.defense = 7;
                    return; 
                case ItemID.FleshKnuckles:
                case ItemID.BerserkerGlove:
                    item.defense = 10;
                    return;
                case ItemID.AncientArmorHat:
                    item.defense = 13;
                    item.vanity = false;
                    return;
                case ItemID.AncientArmorShirt:
                    item.defense = 18;
                    item.vanity = false;
                    return;
                case ItemID.AncientArmorPants:
                    item.defense = 11;
                    item.vanity = false;
                    return;
                case ItemID.DjinnsCurse:
                    item.defense = 12;
                    item.vanity = false;
                    return;
                case ItemID.SpectreMask:
                case ItemID.SpectreHood:
                    item.defense = 12;
                    return;

                case ItemID.ObsidianHorseshoe:
                    item.SetNameOverride("Heavy Horseshoe");
                    return;
                case ItemID.ObsidianWaterWalkingBoots:
                    item.SetNameOverride("Heavy Rocket Boots");
                    return;
                case ItemID.MoonShell:
                    item.SetNameOverride("Monster Shell");
                    return;
                case ItemID.ManaRegenerationBand:
                    item.SetNameOverride("Band of Dual Regeneration");
                    return;
                case ItemID.MagicDagger: // REVISIT
                    item.useStyle = 0;
                    item.mana = 0;
                    item.damage = 0;
                    item.crit = 0;
                    item.knockBack = 0f;
                    item.useTime = 0;
                    item.useAnimation = 0;
                    item.accessory = true;
                    return;
                case ItemID.StrangeBrew:
                    item.healMana = 0;
                    return;
                case ItemID.BottledHoney:
                    item.healLife = 70;
                    return;
                case ItemID.FastClock:
                    item.value = 100000;
                    return;
            }
            baseVelocity = item.shootSpeed;
            BaseDamage = item.damage;
            return;
        }
        public override void PostReforge(Item item)
        {
            baseVelocity = item.shootSpeed;
			BaseDamage = item.damage;
        }

        public override void ModifyWeaponDamage(Item item, Player player, ref StatModifier damage, ref float flat)
        {
            if (!player.armor[0].IsAir && player.armor[0].type == ItemID.ShroomiteHelmet && item.CountsAsClass(DamageClass.Ranged) && (item.ammo == AmmoID.None) && !(item.useAmmo == AmmoID.Bullet) && !(item.useAmmo == AmmoID.Arrow) && !(item.useAmmo == AmmoID.Rocket) && !(item.useAmmo == AmmoID.StyngerBolt) && !(item.useAmmo == AmmoID.JackOLantern) && !(item.useAmmo == AmmoID.NailFriendly) && !(item.useAmmo == AmmoID.Stake) && !(item.useAmmo == AmmoID.CandyCorn))
            {
                damage *= 1.15f;
            }
            if (player.GetModPlayer<TRAEPlayer>().shackle)
            {
                flat += 1;
            }
        }
        public virtual bool ConsumeAmmo(Item weapon, Item ammo)
        {
            Player player = Main.player[weapon.playerIndexTheItemIsReservedFor];
            if (weapon.CountsAsClass(DamageClass.Ranged) && player.ammoPotion)
            {
                if (weapon.type != ItemID.StarCannon && weapon.type != ItemID.Clentaminator && weapon.type != ItemID.CoinGun)
                {
                    return false;
                }
            }
            return true;
        }
        public override void PickAmmo(Item weapon, Item ammo, Player player, ref int type, ref float speed, ref int damage, ref float knockback)
        {
            if (weapon.type == ItemID.VortexBeater && (ammo.type == ItemID.MusketBall || ammo.type == ItemID.EndlessMusketPouch))
            {
                type = ProjectileType<LilRocket>();
            }
        }
        public override bool AltFunctionUse(Item item, Player player)
        {
            if (item.type == ItemID.DirtRod)
            {
                return true; // if you can do something with right click
            }
            return false;
        }
        public override bool CanUseItem(Item item, Player player)
        {
            if (item.type == ItemID.DirtRod)
                if (player.altFunctionUse == 2)
                {
                    item.tileWand = 2;
                    item.useTurn = true;
                    player.tileSpeed /= 1.5f;
                    item.scale = 1.7f;
                    item.shoot = 0;
                    item.useAnimation = 10;
                    item.useTime = 10;
                    item.tileBoost = 11;
                    item.autoReuse = true;
                    item.createTile = TileID.Dirt;
                }
                else
                {
                    item.tileWand = 0;
                    item.createTile = 0;
                    item.channel = true;
                    item.shoot = 17;
                    item.scale = 1.7f;
                    item.UseSound = SoundID.Item8;
                    item.useAnimation = 10;
                    item.useTime = 10;
                    item.autoReuse = true;
                    item.noMelee = true;
                }
            return base.CanUseItem(item, player);
        }

        public override void ModifyHitNPC(Item item, Player player, NPC target, ref int damage, ref float knockBack, ref bool crit)
        {
            if (item.type == ItemID.BreakerBlade)
            {
                if (target.life >= target.lifeMax * 0.9)
                {
                    Terraria.Audio.SoundEngine.PlaySound(SoundID.Item14, target.position);
                    for (int i = 0; i < 20; ++i)
                    {
                        int Fire = Dust.NewDust(new Vector2(target.position.X, target.position.Y), target.width, target.height, DustID.Torch, 0f, 0f, 100, default(Color), 3f);
                        Main.dust[Fire].noGravity = true;
                        Main.dust[Fire].velocity *= 4f;
                        int Fire2 = Dust.NewDust(new Vector2(target.position.X, target.position.Y), target.width, target.height, DustID.Torch, 0f, 0f, 100, default(Color), 2f);
                        Main.dust[Fire2].velocity *= 2f;
                    }
                    return;
                }
            }
        }
        
        public override void OnHitNPC(Item item, Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if (player.GetModPlayer<TRAEPlayer>().MagicDagger)
            {
                if (Main.rand.Next(2) == 0)
                {
                    player.GetModPlayer<TRAEPlayer>().MagicDaggerSpawn(player, damage, knockBack);
                }
            }
            if (player.inferno)
            {
                Lighting.AddLight((int)(target.Center.X / 16f), (int)(target.Center.Y / 16f), 0.65f, 0.4f, 0.1f);
                Vector2 spinningpoint1 = ((float)Main.rand.NextDouble() * 6.283185f).ToRotationVector2();
                Vector2 spinningpoint2 = spinningpoint1;
                float RandomEvenNumberBetweenSixAndTen = Main.rand.Next(3, 5) * 2;
                int Twenty = 20;
                float OneOrMinusOne = Main.rand.Next(2) == 0 ? 1f : -1f; // one in three chance of it being 1
                bool flag = true;
                for (int i = 0; i < Twenty * RandomEvenNumberBetweenSixAndTen; ++i) // makes 120 or 240 dusts total
                {
                    if (i % Twenty == 0)
                    {
                        spinningpoint2 = spinningpoint2.RotatedBy(OneOrMinusOne * (6.28318548202515 / RandomEvenNumberBetweenSixAndTen), default);
                        spinningpoint1 = spinningpoint2;
                        flag = !flag;
                    }
                    else
                    {
                        float num4 = 6.283185f / (Twenty * RandomEvenNumberBetweenSixAndTen);
                        spinningpoint1 = spinningpoint1.RotatedBy(num4 * OneOrMinusOne * 3.0, default);
                    }
                    float num5 = MathHelper.Lerp(7.5f, 60f, i % Twenty / Twenty);
                    int index2 = Dust.NewDust(new Vector2(target.Center.X, target.Center.Y), 6, 6, 127, 0.0f, 0.0f, 100, default, 3f);
                    Dust dust1 = Main.dust[index2];
                    dust1.velocity = Vector2.Multiply(dust1.velocity, 0.1f);
                    Dust dust2 = Main.dust[index2];
                    dust2.velocity = Vector2.Add(dust2.velocity, Vector2.Multiply(spinningpoint1, num5));
                    if (flag)
                        Main.dust[index2].scale = 0.9f;
                    Main.dust[index2].noGravity = true;

                }
                float range = 100f;
                int RingDamage = damage / 10;
                for (int k = 0; k < 200; k++)
                {
                    NPC nPC = Main.npc[k];
                    if (nPC.active && !nPC.friendly && nPC.damage > 0 && !nPC.dontTakeDamage && Vector2.Distance(target.Center, nPC.Center) <= range)
                    {
                        int finalDefense = nPC.defense - player.armorPenetration;
                        nPC.ichor = false;
                        nPC.betsysCurse = false;
                        if (finalDefense < 0)
                        {
                            finalDefense = 0;
                        }
                        RingDamage += finalDefense / 2;
                        player.ApplyDamageToNPC(nPC, RingDamage, 0f, 0, crit: false);
                        if (nPC.FindBuffIndex(BuffID.OnFire) == -1)
                        {
                            nPC.AddBuff(BuffID.OnFire, 120);
                        }
                    }
                }
            }
            if (item.type == ItemID.BloodButcherer)
            {
                if (Main.rand.Next(2) == 0) // 50% chance
                {
                    player.HealEffect(1, true);
                    player.statLife += 1;
                    return;
                }
            }
            if (item.type == ItemID.BladeofGrass)
            {
                if (Main.rand.Next(3) == 0)
                {
                    float PositionX = player.position.X - Main.rand.Next(-50, 50);
                    float PositionY = player.position.Y - Main.rand.Next(-50, 50);
                    Projectile.NewProjectile(player.GetProjectileSource_Item(item), PositionX, PositionY, 0, 0, ProjectileID.SporeTrap, damage, knockBack, player.whoAmI);
                    return;
                }
            }
            if (item.type == ItemID.FieryGreatsword)
            {
                target.AddBuff(BuffType<Heavyburn>(), 120, false);
                return;
            }
            if (player.HasBuff(BuffID.WeaponImbueNanites))
            {
                player.AddBuff(BuffType<NanoHealing>(), 60, false);
            }
            if (item.type == ItemID.Cutlass)
            {
                if (target.active && !target.dontTakeDamage && !target.friendly && target.lifeMax > 5 && !target.immortal && !target.SpawnedFromStatue)
                {
                    int amount = damage / 2;
                    player.QuickSpawnItem(ItemID.CopperCoin, amount);
                    return;
                }
            }
        }
        /// SHOOT STUFF

        public override void OnConsumeItem(Item item, Player player)
        {
            switch (item.type)
            {
                case ItemID.StrangeBrew:
                    int wrathchance = Main.rand.Next(1, 10);
                    int[] buffs = new int[] { BuffID.Ironskin, BuffID.Regeneration, BuffID.Swiftness };
                    int buff = Main.rand.Next(buffs);
                    if (wrathchance != 1)
                    {
                        player.AddBuff(buff, 7200, false);
                        return;
                    }
                    else
                    {
                        player.AddBuff(BuffID.Wrath, 7200, false);
                        return;
                    }
                case ItemID.BottledHoney:
                    player.AddBuff(BuffID.Honey, 2400, false);
                    return;
            }
            return;
        }
        private static int shootDelay = 1;
        public int useCount = 0;
        public override Vector2? HoldoutOffset(int type)
        {
            if (type == ItemID.Flamethrower || type == ItemID.EldMelter)
            {
                return new Vector2(0, -2); // If your own flamethrower is being held wrong, edit these values. You can test out holdout offsets using Modder's Toolkit.
            }
            return base.HoldoutOffset(type);
        }
        public override bool CanConsumeAmmo(Item weapon, Player player)
        {
            if (weapon.type == ItemID.Flamethrower || weapon.type == ItemID.EldMelter)
            { // To make this item only consume ammo during the first jet, we check to make sure the animation just started. ConsumeAmmo is called 5 times because of item.useTime and item.useAnimation values in SetDefaults above.
                return player.itemAnimation >= player.itemAnimationMax - 4;
            }
            return base.CanConsumeAmmo(weapon, player);
        }
        public override bool Shoot(Item item, Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 mousePosition = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
            switch (item.type)
            {
                case ItemID.Flamethrower:
                case ItemID.EldMelter:
                    {
                        Vector2 muzzleOffset = Vector2.Normalize(new Vector2(velocity.X, velocity.Y)) * 54f; //This gets the direction of the flame projectile, makes its length to 1 by normalizing it. It then multiplies it by 54 (the item width) to get the position of the tip of the flamethrower.
                        if (Collision.CanHit(position, 6, 6, position + muzzleOffset, 6, 6))
                        {
                            position += muzzleOffset;
                        }
                        // This is to prevent shooting through blocks and to make the fire shoot from the muzzle.
                        return true;
                    }
                case ItemID.ChristmasTreeSword:
                    {
                        int chance = Main.rand.Next(5);
                        int numberOrnaments = 3 + Main.rand.Next(3, 4); // 4 or 5 shots
                        int numberLights = 1 + Main.rand.Next(1, 2); // 4 or 5 shots
                        for (int i = 0; i < numberLights; i++)
                        {
                            Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(24));
                            Projectile.NewProjectile(player.GetProjectileSource_Item(item), position, perturbedSpeed * 0.95f, ProjectileType<LightsLong>(), damage, knockback * 1.5f, player.whoAmI);
                        }
                        for (int i = 0; i < numberOrnaments; i++)
                        {
                            Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(30));
                            Projectile.NewProjectile(player.GetProjectileSource_Item(item), position, perturbedSpeed * 1.2f, ProjectileID.OrnamentFriendly, (int)(damage * 0.9), knockback, player.whoAmI);
                        }
                        if (chance == 0)
                        {
                            for (int i = 0; i < 10; i++)
                            {
                                Dust dust = Dust.NewDustDirect(player.position, player.width, player.height, 57, 0f, 0f, 255, default, Main.rand.Next(20, 26) * 0.1f);
                                dust.noLight = true;
                                dust.noGravity = true;
                                dust.velocity *= 0.5f;
                            }
                            Projectile.NewProjectile(player.GetProjectileSource_Item(item), position, velocity * 1.8f, ProjectileType<Star1>(), (int)(damage * 1.8), knockback, player.whoAmI);
                            Terraria.Audio.SoundEngine.PlaySound(SoundID.Item25);
                            return false;
                        }
                        return false;
                    }
                case ItemID.NightsEdge:
                        Terraria.Audio.SoundEngine.PlaySound(SoundID.Item8);
                        return true;
            }
            return true;       
        }
        public override void HoldItem(Item item, Player player)
        {
            if (item.type == ItemID.NightsEdge)
            {
                if (player.itemTime == 1 && player.whoAmI == Main.myPlayer)
                {
                    Terraria.Audio.SoundEngine.PlaySound(SoundID.MaxMana);
                    for (int i = 0; i < 5; i++)
                    {
                        Dust dust = Dust.NewDustDirect(player.position, player.width, player.height, 173, 0f, 0f, 255, default, Main.rand.Next(20, 26) * 0.1f);
                        dust.noLight = true;
                        dust.noGravity = true;
                        dust.velocity *= 0.5f;
                    }
                    return;
                }
            }
            return;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            switch (item.type)
            {
                case ItemID.Cutlass:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Knockback")
                        {
                            line.text += "\nCreates money on enemy hits";
                        }
                    }
                    return;
                case ItemID.PalladiumPike:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Knockback")
                        {
                            line.text += "\nIncreases health regeneration after striking an enemy";
                        }
                    }
                    return;
                case ItemID.OrichalcumHalberd:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Knockback")
                        {
                            line.text += "\nCreates damaging petals on contact";
                        }
                    }
                    return;
                case ItemID.MagicDagger:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "Summons magic daggers when striking an enemy";
                        }
                    }
                    return;
                case ItemID.BloodButcherer:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Material")
                        {
                            line.text += "\nChance to heal the user on contact";
                        }
                    }
                    return;
                case ItemID.BladeofGrass:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text += "\nCreates a spore on contact";
                        }
                    }
                    return;
                case ItemID.ChristmasTreeSword:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "Shoots christmas decorations";
                        }
                    }
                    return;
                case ItemID.Chik:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Knockback")
                        {
                            line.text += "\nCauses an explosion of crystal shards on hit";
                        }
                    }
                    return;
                case ItemID.FormatC:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Knockback")
                        {
                            line.text += "\nCharges power as it is held out";
                        }
                    }
                    return;
                case ItemID.Gradient:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Knockback")
                        {
                            line.text += "\nFires Bones at enemies";
                        }
                    }
                    return;
                case ItemID.Kraken:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Knockback")
                        {
                            line.text += "\nReleases a tentacle made out of lost souls while held out";
                        }
                    }
                    return;
                case ItemID.Cascade:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Knockback")
                        {
                            line.text += "\nHighly Volatile";
                        }
                    }
                    return;
                case ItemID.Sunfury:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Knockback")
                        {
                            line.text += "\nInflicts a heavy burn on enemies";
                        }
                    }
                    return;
                case ItemID.ArcheryPotion:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "Increases arrow damage by 10% and arrow speed by 20%";
                        }
                    }
                    return; 
                case ItemID.TitanPotion:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "50% increased knockback and 10% increased melee weapon size";
                        }
                    }
                    return;
                case ItemID.InfernoPotion:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "Attacks create fiery explosions, dealing 10% damage in a small area and igniting foes";
                        }
                    }
                    return;
                case ItemID.AmmoReservationPotion:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "Prevents most ammo consumption while active";
                        }
                    }
                    return;
                case ItemID.FlaskofNanites:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "Melee attacks confuse enemies and increase health regeneration";
                        }
                    }
                    return;
                case ItemID.NanoBullet:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "Causes confusion and increases health regeneration";
                        }
                    }
                    return;    
			 case ItemID.ChlorophyteArrow:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "Chases after your enemies";
                        }
                    }
                    return;
                case ItemID.VenusMagnum:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text += "\n33% chance to not consume ammo";
                        }
                    }
                    return;
                case ItemID.ChainGun:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "66% chance to not consume ammo";
                        }
                    }
                    return;
             
                case ItemID.ChainGuillotines:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Knockback")
                        {
                            line.text += "\nOccasionally executes its target";
                        }
                    }
                    return;
                case ItemID.VampireKnives:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "Throw life stealing daggers";
                        }
                    }
                    return;
                case ItemID.CoolWhip:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text += "\n8 summon tag damage";
                        }
                    }
                    return;
                case ItemID.MaceWhip:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.text = "15% summon tag critical strike chance";
                        }
                    }
                    return;
                case ItemID.ScytheWhip:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text += "\n10 summon tag damage";
                        }
                    }
                    return;
                case ItemID.RainbowWhip:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "50 summon tag damage";
                        }
                        if (line.mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.text = "30% summon tag critical strike chance\nColorful destruction comes out of enemies hit by summons";
                        }
                    }
                    return;
                case ItemID.StardustDragonStaff:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "Summons a lunar dragon to fight for you";
                        }
                    }
                    return;
                case ItemID.MoonlordTurretStaff:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.text = "Summons a stardust portal to shoot lasers at your enemies";
                        }
                    }
                    return;
            }
        }
    }
}
