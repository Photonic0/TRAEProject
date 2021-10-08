using TRAEProject.Buffs;
using TRAEProject.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TRAEProject.Items.Summoner.Whip;

using static Terraria.ModLoader.ModContent;

namespace TRAEProject
{
    public class TRAEGlobalProjectile : GlobalProjectile
    {
        public override bool InstancePerEntity => true;
        public int AnchorHit = 0;
        public int HitCount = 0;

        // Damage
        public float DamageFalloff = 0f; // How much damage the projectile loses every time it hits an enemy. 
        public float DamageFallon = 1f; // How much damage the projectile gains every time it hits an enemy. 
        public float DirectDamage = 1f; // how much damage the projectile deals when it hits an enemy, independent of the weapon.
        public bool IgnoresDefense = false; // self-explanatory
        public bool cantCrit = false; // self-explanatory
        public bool dontHitTheSameEnemyMultipleTimes = false;// self-explanatory
        // Bouncing
        public bool BouncesOffTiles = false;
        public bool BouncesBackOffTiles = false;
        public float DamageLossOffATileBounce = 0f;
        public bool BouncesOffEnemies = false;
        public bool SmartBouncesOffTiles = false;
        public bool SmartBouncesOffEnemies = false;
        // AI
        public bool homesIn = false;
        public float homingRange = 300f;
        public bool goThroughWallsUntilReachingThePlayer = false; 
        // Adding Buffs
        public int AddsBuff = 0; // Adds a buff when hitting a target
        public int AddsBuffChance = 1; // 1 in [variable] chance of that buff being applied to the target
        public int AddsBuffDuration = 300; // Measured in ticks, since the game runs at 60 frames per second, this base value is 5 seconds.
        public bool BuffDurationScalesWithMeleeSpeed = false; // If true, the Duration gets multiplied by your extra melee speed
        //
        // Explosion
        public bool explodes = false; // set to true to make the projectile explode. 
        public int ExplosionRadius = 80; // Hitbox size of the base explosion. Base value is 80.
        public float ExplosionDamage = 1f; // Makes the explosion deal Increased/decreased damage. 
        public bool DontRunThisAgain = false;
        public bool UsesDefaultExplosion = false; // Regular rocket Explosions. Helpful if you are too lazy/don't need to create a special explosion effect.
        //
        public override void SetDefaults(Projectile projectile)
        {
            // Yoyo Defaults
            // Default: -1f lifetime, 200f Range, 10f Top Speed
            // Wooden Yoyo: 3f lifetime, 130f Range, 9f Top Speed
            // Rally: 5f lifetime, 170f Range, 11f Top Speed
            // Malaise: 7f lifetime, 195f Range, 12.5f Top Speed
            // Artery: 6f lifetime, 207f Range, 12f Top Speed
            // Amazon: 8f lifetime, 215f Range, 13f Top Speed
            // Code1: 9f lifetime, 220f Range, 13f Top Speed
            // Valor: 11f lifetime, 225f Range, 14f Top Speed
            // Cascade: 13f lifetime, 235f Range, 14f Top Speed
            // Format C: 8f lifetime, 235f Range, 15f Top Speed
            // Gradient: 10f lifetime, 250f Range, 12f Top Speed
            // Chik: 16f lifetime, 275f range, 17f Top Speed
            // Amarok: 15f lifetime, 270f range, 14f Top Speed
            // Hel-fire: 12f lifetime, 275f range, 15f Top Speed
            // Code 2: -1f (infinite) lifetime, 280 range, 17f Top Speed
            // Yelets: 14f lifetime, 290f range, 16f Top Speed
            // Kraken: -1f lifetime, 340f range, 16f Top Speed
            // Red's Throw: -1f lifetime, 370f range, 16f Top Speed
            // Valkyrie Yoyo: -1f lifetime, 370f range, 16f Top Speed
            // Eye Of Cthulhu: -1f lifetime, 360f range, 16.5f Top Speed
            // Terrarian: -4f lifetime, 400f range, 17.5f top speed
            // 1f = 1 second
            // 16f = 1 tile
            ProjectileID.Sets.YoyosMaximumRange[ProjectileID.Kraken] = 175f; // 
            ProjectileID.Sets.YoyosLifeTimeMultiplier[ProjectileID.Kraken] = 6f;
            ProjectileID.Sets.YoyosTopSpeed[ProjectileID.Kraken] = 6f;
            ProjectileID.Sets.YoyosLifeTimeMultiplier[ProjectileID.Code1] = -1f;
            ProjectileID.Sets.YoyosLifeTimeMultiplier[ProjectileID.Chik] = 3f;
            ProjectileID.Sets.YoyosMaximumRange[ProjectileID.Chik] = 220f;
            ProjectileID.Sets.YoyosMaximumRange[ProjectileID.HelFire] = 330f; // up from 275f
            //
            if (projectile.aiStyle == 99)
            {
                projectile.usesIDStaticNPCImmunity = true;
                projectile.idStaticNPCHitCooldown = 10;
            }
            //
            switch (projectile.type)
            {            
                case ProjectileID.BookOfSkullsSkull:
                    projectile.timeLeft = 180;
                    return;
                case ProjectileID.CrystalLeafShot:
                    homesIn = true;
                    return;
                case ProjectileID.ShadowBeamFriendly:
                    SmartBouncesOffEnemies = true;
                    projectile.usesLocalNPCImmunity = true;
                    dontHitTheSameEnemyMultipleTimes = true;
                    return;
                case ProjectileID.PulseBolt:
                    SmartBouncesOffTiles = true;
                    SmartBouncesOffEnemies = true;
                    return;
                case ProjectileID.EyeFire:
                    if (Main.expertMode && ServerConfig.Instance.MechChanges)
                    {
                        projectile.extraUpdates = 1; // down from 3(?)
                    }
                    return;
                case ProjectileID.ManaCloakStar:
                    projectile.penetrate = 2;
                    homesIn = true;
					homingRange = 600f;
                    dontHitTheSameEnemyMultipleTimes = true;
					cantCrit = true;
					projectile.tileCollide = false;
					projectile.timeLeft = 120;
                    return;
                // MELEE
                case ProjectileID.CorruptYoyo:
                    AddsBuff = BuffID.Weak;
                    AddsBuffDuration = 120;
                    BuffDurationScalesWithMeleeSpeed = true;
                    return;
                case ProjectileID.BlackCounterweight:
                case ProjectileID.YellowCounterweight:
                case ProjectileID.RedCounterweight:
                case ProjectileID.BlueCounterweight:
                case ProjectileID.PurpleCounterweight:
                case ProjectileID.GreenCounterweight:
                    projectile.extraUpdates = 2; // up from 0
                    projectile.usesIDStaticNPCImmunity = true;
                    projectile.idStaticNPCHitCooldown = 10;
                    return;
                case ProjectileID.Sunfury:
                    AddsBuff = BuffType<Heavyburn>();
                    AddsBuffDuration = 120;
                    return;
                case ProjectileID.FormatC:
                    DamageFalloff = 0.4f;
                    return;
                case ProjectileID.ButchersChainsaw:
                    projectile.penetrate = -1;
                    projectile.usesIDStaticNPCImmunity = true;
                    projectile.idStaticNPCHitCooldown = 10;
                    return;
                case ProjectileID.Spark:
                    projectile.usesLocalNPCImmunity = true;
                    projectile.localNPCHitCooldown = 10;
                    return;
                case ProjectileID.FlaironBubble:
                    projectile.extraUpdates = 1;
                    return;
                case ProjectileID.FlamingJack:
                    projectile.extraUpdates = 1;
                    projectile.scale = 1.25f;
                    return;
                case ProjectileID.SporeCloud:
                    //projectile.scale = 1.4f;
                    projectile.DamageType = DamageClass.Melee;
                    projectile.usesIDStaticNPCImmunity = true;
                    projectile.idStaticNPCHitCooldown = 10;
                    return;
                case ProjectileID.MonkStaffT2:
                    projectile.width = 43;
                    projectile.height = 43;
					projectile.usesLocalNPCImmunity = true;
                    projectile.localNPCHitCooldown = 10;
                    projectile.usesIDStaticNPCImmunity = false;
                    //projectile.idStaticNPCHitCooldown = 10;
                    return;
                case ProjectileID.ChlorophyteOrb: // Revisit
                    projectile.penetrate = 6;
                    return;
                case ProjectileID.PaladinsHammerFriendly:
                    projectile.tileCollide = false;
                    return;
                case ProjectileID.EatersBite:
                    AddsBuff = BuffType<Corrupted>();
                    AddsBuffDuration = 300;
                    BuffDurationScalesWithMeleeSpeed = true;
                    return;
                case ProjectileID.TinyEater:
                    AddsBuff = BuffType<Corrupted>();
                    AddsBuffDuration = 60;
                    BuffDurationScalesWithMeleeSpeed = true;
                    return;
                // 
                // Mage
                case ProjectileID.EighthNote:
                case ProjectileID.TiedEighthNote:
                case ProjectileID.QuarterNote:
                    projectile.penetrate = 5;
                    return;
                case ProjectileID.Typhoon:
                    projectile.timeLeft = 882; // oddly specific but this is apparently equal to 10 seconds for this weapon. Reason for this is in the code probably
                    return;
                case ProjectileID.ToxicFlask:
                    projectile.timeLeft = 75;
                    return;
                case ProjectileID.FlowerPetal: // what the fuck is this projectile, why can't i remember
                    projectile.usesLocalNPCImmunity = true;
					homesIn = true;
					dontHitTheSameEnemyMultipleTimes = true;
                    return;
                case ProjectileID.SharpTears:
                    projectile.penetrate = 5;
                    DamageFallon = 1.42f;
                    return;              
                case ProjectileID.WaterStream:
                    projectile.penetrate = 1;
                    return;
                case ProjectileID.RainbowFront:
                case ProjectileID.RainbowBack:
                    projectile.usesIDStaticNPCImmunity = true;
                    projectile.idStaticNPCHitCooldown = 10;
                    return;
			    case 244:
				  case 238:
					projectile.timeLeft = 480;
					return;
			 case ProjectileID.RainFriendly:
				    projectile.penetrate = 2;
					DamageFalloff = 0.25f;
				    projectile.aiStyle = 1;
                    homesIn = true;
                    homingRange = 120f;
					dontHitTheSameEnemyMultipleTimes = true;
                    return;
                case ProjectileID.Blizzard:
                    projectile.timeLeft = 150;
                    return;
                case ProjectileID.Meteor1:
                case ProjectileID.Meteor2:
                case ProjectileID.Meteor3:
                    projectile.tileCollide = false;
					goThroughWallsUntilReachingThePlayer = true;
                    homesIn = true;
                    homingRange = 100f;
                    return;
                case ProjectileID.ShadowFlame:
		projectile.usesLocalNPCImmunity = true;
                    projectile.localNPCHitCooldown = 10;
                    return;
				 case ProjectileID.Wasp:
				 	projectile.penetrate = 2;
					projectile.timeLeft = 120;
					projectile.usesLocalNPCImmunity = true;
                    projectile.localNPCHitCooldown = 10;
                    return;
				case ProjectileID.NebulaArcanum:
                    projectile.extraUpdates = 1;
                    return;
                ///
                // Ranged
                case ProjectileID.Hellwing:
                    projectile.penetrate = 1;
					homesIn = true;
                    return;
				case ProjectileID.CandyCorn:
                    projectile.usesLocalNPCImmunity = true;
                    projectile.localNPCHitCooldown = 10;
                    return;
                case ProjectileID.CursedBullet:
                    projectile.extraUpdates = 1;
                    return;
                case ProjectileID.CrystalShard:
                    DirectDamage = 0.5f;
                    IgnoresDefense = true;
                    return;
                case ProjectileID.PhantasmArrow:
                    DirectDamage = 1.3f;
                    IgnoresDefense = true;
                    return;
                case ProjectileID.CursedDartFlame:
                    projectile.timeLeft = 75;
                    projectile.penetrate = 1;
                    return;
                case ProjectileID.IchorDart:
                    DirectDamage = 0.8f;
                    return;
                case ProjectileID.CrystalDart:
                    DamageFalloff = 0.2f;
                    DamageLossOffATileBounce = 0.2f;
                    return;
                case ProjectileID.JestersArrow:
                    projectile.penetrate = 7;      
					projectile.usesLocalNPCImmunity = true;
                    projectile.localNPCHitCooldown = 10;
                    return;
				case ProjectileID.UnholyArrow:     
					projectile.usesLocalNPCImmunity = true;
                    projectile.localNPCHitCooldown = 10;
                    return;
                case ProjectileID.VortexBeaterRocket:
                    projectile.penetrate = -1;
                    projectile.scale = 1.15f;
                    explodes = true;
                    ExplosionRadius = 180;
                    DirectDamage = 1.8f;
                    return;
                case ProjectileID.HellfireArrow:
                    projectile.extraUpdates = 1;
                    projectile.usesLocalNPCImmunity = true;
                    projectile.localNPCHitCooldown = 10;
                    return;
                case ProjectileID.GrenadeI:
                case ProjectileID.GrenadeII:
                case ProjectileID.GrenadeIII:
                case ProjectileID.GrenadeIV:
                    projectile.usesLocalNPCImmunity = true;
                    projectile.localNPCHitCooldown = 10;
                    return;
                case ProjectileID.ChlorophyteArrow:
                    projectile.penetrate = 3;
                    BouncesOffTiles = true;
                    projectile.usesLocalNPCImmunity = true;
                    projectile.localNPCHitCooldown = 10;
                    return;
                case ProjectileID.ToxicBubble:
                    projectile.timeLeft = 120;
                    return;
                case ProjectileID.HallowStar:
                case ProjectileID.StarCloakStar:
                    projectile.penetrate = -1;
                    projectile.usesLocalNPCImmunity = true;
                    projectile.localNPCHitCooldown = 10;
                    projectile.tileCollide = false;
                    explodes = true;
                    ExplosionRadius = 80;
                    DamageFalloff = 0.25f;
                    return;        
                case ProjectileID.PlatinumCoin:          // EXPERIMENT
                    projectile.timeLeft = 600;
                    projectile.penetrate = 20;
                    SmartBouncesOffEnemies = true;
                    SmartBouncesOffTiles = true;
                    projectile.usesLocalNPCImmunity = true;
                    projectile.localNPCHitCooldown = 10;
                    return;
                case ProjectileID.MeteorShot:          // Revisit 
                    //projectile.penetrate = 3;
                    //projectile.usesLocalNPCImmunity = true;
                    //projectile.localNPCHitCooldown = 10;
                    DamageFalloff = 0.33f;
                    //DamageLossOffATileBounce = 0.2f;
                    //BouncesBackOffTiles = true;
                    //BouncesOffEnemies = true;
                    return;
                case ProjectileID.MagicDagger:
                    projectile.aiStyle = 1;
                    projectile.extraUpdates = 0;
                    projectile.penetrate = 1;
                    projectile.DamageType = DamageClass.Magic;
                    projectile.timeLeft = 100;
                    projectile.tileCollide = false;
                    IgnoresDefense = true;
                    return;
                case ProjectileID.GoldenShowerFriendly:
                    projectile.usesLocalNPCImmunity = true;
                    projectile.localNPCHitCooldown = 10;
                    return;
				case ProjectileID.FrostBoltStaff:
                    projectile.penetrate = 2;
                    return;
                case ProjectileID.RainbowWhip:
                    AddsBuff = BuffType<KaleidoscopeSecondTag>();
                    AddsBuffDuration = 240;
                    return;
                case ProjectileID.SapphireBolt:
                case ProjectileID.EmeraldBolt:
                case ProjectileID.AmberBolt:
                case ProjectileID.RubyBolt:
                case ProjectileID.DiamondBolt:
                    projectile.penetrate = 2;
                    dontHitTheSameEnemyMultipleTimes = true;
                    projectile.usesLocalNPCImmunity = true;
                    return;
            }
        }

        public override void ModifyDamageHitbox(Projectile projectile, ref Rectangle hitbox)
        {
            switch (projectile.type)
            {
                case ProjectileID.Blizzard:
                    hitbox.Width = 50;
                    hitbox.Height = 50;
                    return;
            }
        }
        public override bool TileCollideStyle(Projectile projectile, ref int width, ref int height, ref bool fallThrough, ref Vector2 hitboxCenterFrac)
        {
            switch (projectile.type)
            {
                case ProjectileID.ProximityMineI:
                case ProjectileID.ProximityMineII:
                case ProjectileID.ProximityMineIII:
                case ProjectileID.ProximityMineIV:
				case ProjectileID.BallofFrost:
                    fallThrough = false; // prevents these projectiles from falling through platforms
                    return true;
            }
            return true;
        }
        int ChloroBulletTime = 0;
        int timer = 0;
        readonly int bulletsPerRocket = 4; //making this 7 will make it just like vanilla
        readonly int fireRate = 7; //making this 5 will make it just like vanilla
        public override bool PreAI(Projectile projectile)
        {
            Player player = Main.player[projectile.owner];
            if (projectile.type == ProjectileID.ChlorophyteBullet)
            {
                ++ChloroBulletTime; // once this reaches 24, the bullet loses its homing
                if (ChloroBulletTime >= 24) // Due to the bullet having 2 extraUpdates, this happens after 8 frames.
                {
                    // the code for aiStyle 1
					while (projectile.velocity.X >= 16f || projectile.velocity.X <= -16f || projectile.velocity.Y >= 16f || projectile.velocity.Y < -16f)
                    {
                        projectile.velocity.X *= 0.97f;
                        projectile.velocity.Y *= 0.97f;
                    }
					//
					// Dust Trail
                    for (int i = 0; i < 5; i++) // vanilla value is 10, once the homing disappears the trail loses intensity
                    {
                        float x2 = projectile.position.X - projectile.velocity.X / 10f * i;
                        float y2 = projectile.position.Y - projectile.velocity.Y / 10f * i;
                        int Dust = Terraria.Dust.NewDust(new Vector2(x2, y2), 1, 1, 75);
                        Main.dust[Dust].alpha = projectile.alpha;
                        Main.dust[Dust].position.X = x2;
                        Main.dust[Dust].position.Y = y2;
                        Main.dust[Dust].velocity *= 0f;
                        Main.dust[Dust].noGravity = true;
                    }
					//
                    return false;
                }
                return true;
            }
            // Crimson Rod Change
            if (projectile.type == 244)
            {
                int PosX = (int)projectile.Center.X;
                int PosY = (int)(projectile.position.Y + projectile.height);
                projectile.frameCounter++;
                if (projectile.frameCounter > 8)
                {
                    projectile.frameCounter = 0;
                    projectile.frame++;
                    if ((projectile.frame > 2) || projectile.frame > 5)
                    {
                        projectile.frame = 0;
                    }
                }
                projectile.ai[1] += 1f;
                if (projectile.ai[1] >= 3600f)
                {
                    projectile.alpha += 5;
                    if (projectile.alpha > 255)
                    {
                        projectile.alpha = 255;
                        projectile.Kill();
                    }
                }
                projectile.ai[0] += 1f;
                float BloodRainDelay = 13f; // Fire rate. Vanilla value = 10f
                if (projectile.ai[0] > BloodRainDelay)
                {
                    projectile.ai[0] = 0f;
                    if (projectile.owner == Main.myPlayer)
                    {
                        PosX += Main.rand.Next(-14, 15);
                        Projectile.NewProjectile(projectile.GetProjectileSource_FromThis(), PosX, PosY, 0f, 5f, ProjectileID.BloodRain, projectile.damage, 0f, projectile.owner);
                    }
                }
                projectile.localAI[0] += 1f;
                if (!(projectile.localAI[0] >= 10f))
                {
                    return false;
                }
                projectile.localAI[0] = 0f;
                int CloudLimit = 0;
                int ExtraCloud = 0;
                float FoundCloudTimer = 0f;
                int Cloud = projectile.type;
                for (int i = 0; i < 1000; i++)
                {
                    if (Main.projectile[i].active && Main.projectile[i].owner == projectile.owner && Main.projectile[i].type == Cloud && Main.projectile[i].ai[1] < 3600f)
                    {
                        CloudLimit++;
                        if (Main.projectile[i].ai[1] > FoundCloudTimer)
                        {
                            ExtraCloud = i;
                            FoundCloudTimer = Main.projectile[i].ai[1];
                        }
                    }
                }
                if (CloudLimit > 2 || projectile.timeLeft < 120) // only 2 clouds
                {
                    Main.projectile[ExtraCloud].netUpdate = true;
                    Main.projectile[ExtraCloud].ai[1] = 36000f; // the cloud will then disappear
                }
                return false;
            }
			if (projectile.type == 238) // nimbus cloud
			{
				{
				if (projectile.timeLeft < 120)
				projectile.ai[1] = 36000f;
				}
				projectile.ai[0] -= 0.5f;
			}
            if (projectile.type == 615)
            {
                timer++;
                //determine fire rate
                if (timer % fireRate == 0)
                {
                    projectile.ai[1] = -1; //forces VBeater to fire
                }
                else
                {
                    projectile.ai[1] = 3; //forces VBeater to not fire
                }
                projectile.ai[0] = 5; //forces VBeater not to fire a rocket
                if ((timer / fireRate) % bulletsPerRocket == 0)
                {
                    projectile.ai[0] = -1; //forces VBeater to fire a rocket
                }

                //this code preserves the buildup animation
                if (timer >= 40f)
                {
                    projectile.ai[0] += 35 * 2;
                }
                if (timer >= 80f)
                {
                    projectile.ai[0] += 35;
                }
                if (timer >= 120f)
                {
                    projectile.ai[0] += 35;
                }
            }
            return true;
        }
        
        public override void AI(Projectile projectile)
        {
            Player player = Main.player[projectile.owner];
            if (ProjectileID.Sets.IsAWhip[projectile.type] || projectile.type == ProjectileType<WhipProjectile>())
            {
                for (int i = 0; i < 1000; i++)
                {
                    if (Main.projectile[i].active && Main.projectile[i].owner == projectile.owner && Main.projectile[i].type == projectile.type && Main.projectile[i].whoAmI != projectile.whoAmI)
                    {
                        Main.projectile[i].Kill();
                    }
                }
            }
            if (goThroughWallsUntilReachingThePlayer)
            {
                if (projectile.position.Y > player.position.Y)
                {
                    projectile.tileCollide = true;
                }
            }
            if (homesIn)
            {
                Vector2 move = Vector2.Zero;
                bool target = false;
                float distance = homingRange;
                for (int k = 0; k < 200; k++)
                {
                    if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5 && !Main.npc[k].immortal && projectile.localNPCImmunity[k] != 1)
                    {
                        Vector2 newMove = Main.npc[k].Center - projectile.Center;
                        float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
                        if (distanceTo < distance)
                        {
                            move = newMove;
                            target = true;
                            distance = distanceTo;
                        }
                        if (target)
                        {
                            float scaleFactor2 = projectile.velocity.Length();
                            move.Normalize();
                            move *= scaleFactor2;
                            projectile.velocity = (projectile.velocity * 24f + move) / 25f;
                            projectile.velocity.Normalize();
                            projectile.velocity *= scaleFactor2;
                        }
                    }
                }
                return;
            }
            if (explodes && projectile.timeLeft == 3)
            {
                TRAEMethods.Explode(projectile, ExplosionRadius, ExplosionDamage);
                return;
            }
            if (projectile.counterweight)
            {
                projectile.damage = player.HeldItem.damage;
                return;
            }
            switch (projectile.type)
            {
                case ProjectileID.UnholyTridentFriendly:
                    projectile.ai[0] += 1f;
                    if (projectile.ai[0] >= 30.0)
                    {
                        if (projectile.ai[0] < 100.0)
                            projectile.velocity = Vector2.Multiply(projectile.velocity, 1.06f);
                        else
                            projectile.ai[0] = 200f;
                    }
                    return;
                case ProjectileID.BloodRain:
                    projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);
                    return;
                case ProjectileID.SharpTears:
                    projectile.ai[0] -= 0.8f;
                    return;
                case ProjectileID.SharknadoBolt:
                    projectile.hostile = false;
                    return;
                case ProjectileID.Sharknado:
                case ProjectileID.Cthulunado:
                    projectile.localAI[1] += 1f; // cannot damage the player before 60 updates
                    if (projectile.localAI[1] <= 60f)
                        projectile.hostile = false;
                    else
                        projectile.hostile = true;
                    return;

                case ProjectileID.NebulaSphere:
                    {
                        if (Main.expertMode)
                        {
                            bool flag4 = false;
                            projectile.localAI[1] += 1f;
                            if (projectile.localAI[1] >= 6f)
                            {
                                projectile.localAI[1] = 6f;
                                flag4 = true;
                            }
                            if (flag4)
                            {
                                projectile.localAI[1] = 0f;
                                projectile.height += 1;
                                projectile.width += 1;
                            }
                            projectile.scale += 0.005f;
                        }
                        return;
                    }
                case ProjectileID.Gradient:
                    {
                        float PosX = projectile.position.X;
                        float PosY = projectile.position.Y;
                        float Float1 = 600f;
                        bool flag4 = false;
                        if (projectile.owner == Main.myPlayer)
                        {
                            projectile.localAI[1] += 1f + (1 * player.meleeSpeed);
                            if (projectile.localAI[1] > 90f)
                            {
                                projectile.localAI[1] = 90f;
                                for (int o = 0; o < 200; ++o)
                                {
                                    if (Main.npc[o].CanBeChasedBy(this, false))
                                    {
                                        float posX = Main.npc[o].position.X + (Main.npc[o].width / 2);
                                        float posY = Main.npc[o].position.Y + (Main.npc[o].height / 2);
                                        float num228 = Math.Abs(projectile.position.X + (projectile.width / 2) - posX) + Math.Abs(projectile.position.Y + (projectile.height / 2) - posY);
                                        if (num228 < Float1 && Collision.CanHit(projectile.position, projectile.width, projectile.height, Main.npc[o].position, Main.npc[o].width, Main.npc[o].height))
                                        {
                                            Float1 = num228;
                                            PosX = posX;
                                            PosY = posY;
                                            flag4 = true;
                                        }
                                    }
                                }
                            }

                        }
                        if (flag4)
                        {
                            projectile.localAI[1] = 0f;
                            float num229 = 14f;
                            Vector2 vector19 = new Vector2(projectile.position.X + projectile.width * 0.5f, projectile.position.Y + projectile.height * 0.5f);
                            float velX = PosX - vector19.X;
                            float velY = PosY - vector19.Y;
                            float sqrRoot = (float)Math.Sqrt(velX * velX + velY * velY);
                            sqrRoot = num229 / sqrRoot;
                            velX *= sqrRoot;
                            velY *= sqrRoot;
                            int bone = Projectile.NewProjectile(projectile.GetProjectileSource_FromThis(), vector19.X, vector19.Y, velX, velY, ProjectileID.BoneGloveProj, projectile.damage * 2, projectile.knockBack, Main.myPlayer, 0f, 0f);
                            Main.projectile[bone].DamageType = DamageClass.Melee;
                        }
                        return;
                    }
                case ProjectileID.Kraken:
                    {
                        float PosX = projectile.position.X;
                        float PosY = projectile.position.Y;
                        float Range = 500f;
                        bool flag4 = false;
                        if (projectile.owner == Main.myPlayer)
                        {
                            projectile.localAI[1] += 1f;
                            if (projectile.localAI[1] >= 15f)
                            {
                                projectile.localAI[1] = 15f;
                                for (int o = 0; o < 200; ++o)
                                {
                                    if (Main.npc[o].CanBeChasedBy(this, false))
                                    {
                                        float posX = Main.npc[o].position.X + (Main.npc[o].width / 2);
                                        float posY = Main.npc[o].position.Y + (Main.npc[o].height / 2);
                                        float Distance = Math.Abs(projectile.position.X + (projectile.width / 2) - posX) + Math.Abs(projectile.position.Y + (projectile.height / 2) - posY);
                                        if (Distance < Range && Collision.CanHit(projectile.position, projectile.width, projectile.height, Main.npc[o].position, Main.npc[o].width, Main.npc[o].height))
                                        {
                                            Range = Distance;
                                            PosX = posX;
                                            PosY = posY;
                                            flag4 = true;
                                        }
                                    }
                                }
                            }

                        }
                        if (flag4)
                        {
                            projectile.localAI[1] = 0f;
                            float num229 = 14f;
                            Vector2 vector19 = new Vector2(projectile.position.X + projectile.width * 0.5f, projectile.position.Y + projectile.height * 0.5f);
                            float velX = PosX - vector19.X;
                            float velY = PosY - vector19.Y;
                            float sqrRoot = (float)Math.Sqrt(velX * velX + velY * velY);
                            sqrRoot = num229 / sqrRoot;
                            velX *= sqrRoot;
                            velY *= sqrRoot;
                            Projectile.NewProjectile(projectile.GetProjectileSource_FromThis(), vector19.X, vector19.Y, velX, velY, ProjectileType<PhantomTentacle>(), projectile.damage, projectile.knockBack, Main.myPlayer, 0f, 0f);
                        }
                        return;
                    }
                case ProjectileID.FormatC:
                    {
                        bool flag4 = false;
                        int mult = 1;
                        projectile.scale = 1f + (float)projectile.damage / 1000;
                        projectile.localAI[1] += 1f;
                        if (projectile.localAI[1] >= 36f && projectile.damage <= 300)
                        {
                            mult += 1;
                            projectile.damage += projectile.damage / mult;
                            Terraria.Audio.SoundEngine.PlaySound(SoundID.DD2_MonkStaffGroundImpact, (int)projectile.position.X, (int)projectile.position.Y);
                            for (int i = 0; i < 25; i++)
                            {
                                // Create a new dust
                                Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 64, 10f, 10f, 0, default, 2f);
                                dust.velocity *= Main.rand.NextFloat(-1.5f, 1.5f);
                                dust.noGravity = true;
                            }
                            projectile.localAI[1] = 45f;
                            flag4 = true;
                        }
                        if (flag4)
                        {
                            projectile.localAI[1] = 0f;
                        }
                        return;
                    }
                case ProjectileID.ToxicBubble:
                    {
                        if (projectile.scale < 1.5f)
                        {
                            projectile.scale *= 1.004f;                     
                        }
                    }
                    return;
    
            }                    
        }
       
        public override bool OnTileCollide(Projectile projectile, Vector2 oldVelocity)
        {
            if (explodes /*&&!Doesn'tExplodeOnTileCollide*/) // If you want a projectile that doesn't explode in contact with tiles, make the second variable.//
            {
                TRAEMethods.Explode(projectile, ExplosionRadius, ExplosionDamage);
                if (UsesDefaultExplosion)
                {
                    TRAEMethods.DefaultExplosion(projectile);
                }
                return false;
            }
            if (BouncesOffTiles)
            {
                projectile.velocity.Y = -projectile.oldVelocity.Y;
            }
            if (BouncesBackOffTiles)
            { 
                projectile.velocity.X = -projectile.oldVelocity.X;
                projectile.velocity.Y = -projectile.oldVelocity.Y;
            }
            if (DamageLossOffATileBounce > 0)
                projectile.damage -= (int)(projectile.damage * DamageLossOffATileBounce);
            if (SmartBouncesOffTiles)
            {
                int[] array = new int[10];
                int num6 = 0;
                int Range = 700;
                int num8 = 20;
                for (int j = 0; j < 200; j++)
                {
                    if (Main.npc[j].CanBeChasedBy(this, false) && projectile.localNPCImmunity[j] != 1)
                    {
                        float DistanceBetweenProjectileAndEnemy = (projectile.Center - Main.npc[j].Center).Length();
                        if (DistanceBetweenProjectileAndEnemy > num8 && DistanceBetweenProjectileAndEnemy < Range && Collision.CanHitLine(projectile.Center, 1, 1, Main.npc[j].Center, 1, 1))
                        {
                            array[num6] = j;
                            num6++;
                            if (num6 >= 9)
                            {
                                break;
                            }
                        }
                    }
                }
                if (num6 > 0)
                {
                    num6 = Main.rand.Next(num6);
                    Vector2 value2 = Main.npc[array[num6]].Center - projectile.Center;
                    float scaleFactor2 = projectile.velocity.Length();
                    value2.Normalize();
                    projectile.velocity = value2 * scaleFactor2;
                    projectile.netUpdate = true;
                }
                return false;
            }
            switch (projectile.type)
            {
                case ProjectileID.ProximityMineI:
                case ProjectileID.ProximityMineII:
                case ProjectileID.ProximityMineIII:
                case ProjectileID.ProximityMineIV:
                    projectile.velocity.X *= 0f;
                    projectile.velocity.Y *= 0f;
                    return false;
                case ProjectileID.ChlorophyteOrb:
                    {
                        projectile.penetrate -= 1; 
                        projectile.velocity.X = -projectile.oldVelocity.X;
                        projectile.velocity.Y = -projectile.oldVelocity.Y;
                    }
                    return false;
                case ProjectileID.CursedBullet:
                    {
                        Projectile.NewProjectile(projectile.GetProjectileSource_FromThis(), projectile.position.X, projectile.position.Y, 0f, 0f, ProjectileID.CursedDartFlame, (projectile.damage * 1), 0, projectile.owner, 0f, 0f);
                        return true;
                    }
                case ProjectileID.NanoBullet:
                case ProjectileID.ChlorophyteArrow:
                    {
                        return false;
                    }
            }
            return true;
        }

        private static int tillinsta = 0;
        private static int shootDelay = 0;

        public override void ModifyHitPlayer(Projectile projectile, Player target, ref int damage, ref bool crit) // SIMPLIFY THIS
        {
            switch (projectile.type)
            {
                case ProjectileID.DeathLaser:
                    {
                        foreach (NPC enemy in Main.npc)
                        {
                            if (enemy.type == NPCID.Retinazer && Main.expertMode)
                            {
                                damage *= 90;
                                damage /= 100;
                            }
                        }
                    }
                    return;
                case ProjectileID.EyeLaser:
                case ProjectileID.EyeFire:
                    {
                        if (Main.expertMode && ServerConfig.Instance.MechChanges)
                        {
                            damage *= 90;
                            damage /= 100;
                        }
                    }
                    return;
                case ProjectileID.StardustSoldierLaser:
                    {
                        damage *= 80;
                        damage /= 100;
                    }
                    return;
                case ProjectileID.StardustJellyfishSmall:
                    {
                        damage *= 65;
                        damage /= 100;
                    }
                    return;
                case ProjectileID.NebulaLaser:
                    {
                        damage *= 85;
                        damage /= 100;
                    }
                    return;
                case ProjectileID.NebulaBolt:
                case ProjectileID.VortexAcid:
                    {
                        damage *= 80;
                        damage /= 100;
                    }
                    return;
                case ProjectileID.VortexLightning:
                    {
                        damage *= 25;
                        damage /= 10;
                    }
                    return;
            }
        }
        public override void ModifyHitNPC(Projectile projectile, NPC target, ref int damage, ref float knockback, ref bool crit,ref int hitDirection)
        {
            Player player = Main.player[projectile.owner];
            damage = (int)(damage * DirectDamage);
            if (IgnoresDefense && target.type != NPCID.DungeonGuardian)
            {
                int finalDefense = target.defense - player.armorPenetration;
                target.ichor = false;
                target.betsysCurse = false;
                if (finalDefense < 0)
                {
                    finalDefense = 0;
                }
                damage += finalDefense / 2;
            }
			if (cantCrit)
			{
				crit = false;
			}
        }
        public override void OnHitPlayer(Projectile projectile, Player target, int damage, bool crit)
        {
            if (explodes)
            {
                TRAEMethods.Explode(projectile, ExplosionRadius, ExplosionDamage);
                if (UsesDefaultExplosion)
                {
                    TRAEMethods.DefaultExplosion(projectile);
                }

            }
            switch (projectile.type)
            {
                case ProjectileID.EyeLaser:
                    if (Main.expertMode)
                    {
                        foreach (NPC enemy in Main.npc)
                        {
                            if (enemy.type == NPCID.Retinazer)
                            {
                                int length = Main.rand.Next(90, 180);
                                target.AddBuff(BuffID.BrokenArmor, length, false);
                            }
                        }
                    }
                    return;
                case ProjectileID.DeathLaser:
                    {
                        if (Main.expertMode)
                        {
                            foreach (NPC enemy in Main.npc)
                            {
                                if (enemy.type == NPCID.Retinazer)
                                {
                                        int length = Main.rand.Next(90, 180);
                                        target.AddBuff(BuffID.BrokenArmor, length, false);
                                }
                            }
                        }
                        return;
                    }
            }
        }
        public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
        {
            if (dontHitTheSameEnemyMultipleTimes)
                projectile.localNPCImmunity[target.whoAmI] = -1; // this makes the enemy invincible to the projectile.
            if (explodes)
            {
                TRAEMethods.Explode(projectile, ExplosionRadius, ExplosionDamage);
                if (UsesDefaultExplosion)
                {
                    TRAEMethods.DefaultExplosion(projectile);
                }
            }
            if (BouncesOffEnemies)
            {
                projectile.velocity.X = -projectile.oldVelocity.X;
                projectile.velocity.Y = -projectile.oldVelocity.Y;
            }
            if (SmartBouncesOffEnemies)
            {
                projectile.localNPCImmunity[target.whoAmI] = -1;
                target.immune[projectile.owner] = 0;
                int[] array = new int[10];
                int num6 = 0;
                int num7 = 700;
                int num8 = 20;
                for (int j = 0; j < 200; j++)
                {
                    if (Main.npc[j].CanBeChasedBy(this, false) || Main.npc[j].type == NPCID.DetonatingBubble && projectile.localNPCImmunity[target.whoAmI] != -1/*see "dontHitTheSameEnemyMultipleTimes" above*/)
                    {
                        float num9 = (projectile.Center - Main.npc[j].Center).Length();
                        if (num9 > num8 && num9 < num7 && Collision.CanHitLine(projectile.Center, 1, 1, Main.npc[j].Center, 1, 1))
                        {
                            array[num6] = j;
                            num6++;
                            if (num6 >= 9)
                            {
                                break;
                            }
                        }
                    }
                }
                if (num6 > 0)
                {
                    num6 = Main.rand.Next(num6);
                    Vector2 value2 = Main.npc[array[num6]].Center - projectile.Center;
                    float scaleFactor2 = projectile.velocity.Length();
                    value2.Normalize();
                    projectile.velocity = value2 * scaleFactor2;
                    projectile.netUpdate = true;
                }
                return;
            }        
            Player player = Main.player[projectile.owner];
            // Damage Fall off
            projectile.damage -= (int)(projectile.damage * DamageFalloff);
            projectile.damage = (int)(projectile.damage * DamageFallon);
            //
            if (Main.rand.Next(AddsBuffChance) == 0)
            {
                int length = BuffDurationScalesWithMeleeSpeed ? (int)(AddsBuffDuration * (1 + player.meleeSpeed)) : AddsBuffDuration; 
                target.AddBuff(AddsBuff, length, false);          
            }
            if (player.GetModPlayer<TRAEPlayer>().MagicDagger && projectile.type != ProjectileID.MagicDagger && projectile.type != ProjectileType<MagicDaggerNeo>())
            {
                if (Main.rand.Next(2) == 0)
                {
                    player.GetModPlayer<TRAEPlayer>().MagicDaggerSpawn(player, damage, knockback);
                }
            }
            if (player.HasBuff(BuffID.WeaponImbueNanites) && (projectile.DamageType == DamageClass.Melee || projectile.aiStyle == 165 || projectile.type == ProjectileType<WhipProjectile>()))
            {
                player.AddBuff(BuffType<NanoHealing>(), 60, false);
            }
            switch (projectile.type)
            {
                case ProjectileID.NanoBullet:
                    {
                        player.AddBuff(BuffType<NanoHealing>(), 60, false);
                        return;
                    }
                      
                // melee
                case ProjectileID.Chik:
                    {
                        int shards = damage / 10;
                        for (int i = 0; i < shards; i++)
                        {
                            float velX = (0f - projectile.velocity.X) * Main.rand.Next(40, 70) * 0.01f + Main.rand.Next(-20, 21) * 0.5f;
                            float velY = (0f - projectile.velocity.Y) * Main.rand.Next(40, 70) * 0.01f + Main.rand.Next(-20, 21) * 0.5f;
                            Projectile.NewProjectile(projectile.GetProjectileSource_FromThis(), projectile.position.X + velX, projectile.position.Y + velY, velX, velY, ProjectileID.CrystalShard, 1, 0, projectile.owner, 0f, 0f);
                        }
                        return;
                    }
                case ProjectileID.Cascade:
                    {
                        ++HitCount;
                        if (HitCount >= 5)
                            projectile.Kill();
                        return;
                    }
                case ProjectileID.CrimsonYoyo:
                    {
                        player.lifeRegenCount += 30;
                        return;
                    }   
                case ProjectileID.PalladiumPike:
                    {
                        float length = 300 / (player.meleeSpeed / player.meleeSpeed * 0.94f); /// Duration increases by about 0.1475 seconds for each melee speed point, i think
                        player.AddBuff(58, (int)length, false);
                        return;
                    }              
            }    
        }
        public override bool PreKill(Projectile projectile, int timeLeft)
        { 
            switch (projectile.type)
            {
                case ProjectileID.Cascade:
                    {
                        projectile.position.X += projectile.width / 2;
                        projectile.position.Y += projectile.height / 2;
                        projectile.width = projectile.height = 125;
                        projectile.position.X -= projectile.width / 2;
                        projectile.position.Y -= projectile.height / 2;
                        projectile.position.X += projectile.width / 2;
                        projectile.position.Y += projectile.height / 2;
                        projectile.width = projectile.height = 125;
                        projectile.position.X -= (projectile.width / 2);
                        projectile.position.Y -= (projectile.height / 2);
                        for (int k = 0; k < 200; k++)
                        {
                            NPC nPC = Main.npc[k];
                            if (nPC.active && !nPC.friendly && nPC.damage > 0 && !nPC.dontTakeDamage && Vector2.Distance(projectile.Center, nPC.Center) <= 125)
                            {
                                Main.player[projectile.owner].ApplyDamageToNPC(nPC, (int)(projectile.damage * 2), 0f, 0, crit: false);
                                if (nPC.FindBuffIndex(BuffID.OnFire) == -1)
                                {
                                    nPC.AddBuff(BuffID.OnFire, 120);
                                }
                            }
                        }
                        TRAEMethods.DefaultExplosion(projectile);
                        return false;
                    }
                case ProjectileID.ToxicFlask:
                    {
                        for (int num332 = 0; num332 < 1000; num332++)
                        {
                            if (Main.projectile[num332].active && Main.projectile[num332].owner == projectile.owner && Main.projectile[num332].type == ProjectileType<ToxicCloud>())
                            {
                                Main.projectile[num332].ai[1] = 600f;
                            }
                        }
                        Terraria.Audio.SoundEngine.PlaySound(SoundID.Item107, projectile.position);
                        Gore.NewGore(projectile.Center, -projectile.oldVelocity * 0.2f, 704);
                        Gore.NewGore(projectile.Center, -projectile.oldVelocity * 0.2f, 705);
                        if (projectile.owner == Main.myPlayer)
                        {
                            int ToxicCloudsSpawned = Main.rand.Next(34, 37);
                            for (int num375 = 0; num375 < ToxicCloudsSpawned; num375++)
                            {
                                Vector2 vector22 = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
                                vector22.Normalize();
                                vector22 *= Main.rand.Next(10, 101) * 0.02f;
                                Projectile.NewProjectile(projectile.GetProjectileSource_FromThis(), projectile.Center.X, projectile.Center.Y, vector22.X, vector22.Y, ProjectileType<ToxicCloud>(), projectile.damage, 1f, projectile.owner);
                            }
                        }
                    }
                    return false;
                case ProjectileID.VortexBeaterRocket:
                    {
                        Terraria.Audio.SoundEngine.PlaySound(SoundID.Item14, projectile.position);
                        for (int i = 0; i < 4; i++)
                        {
                            Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, default, 1.5f);
                        }
                        for (int i = 0; i < 40; i++)
                        {
                            int Dust = Terraria.Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 229, 0f, 0f, 200, default, 2.5f);
                            Main.dust[Dust].noGravity = true;
                            Dust dust = Main.dust[Dust];
                            dust.velocity *= 2f;
                            Dust = Terraria.Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 229, 0f, 0f, 200, default, 1.5f);
                            dust = Main.dust[Dust];
                            dust.velocity *= 1.2f;
                            Main.dust[Dust].noGravity = true;
                        }
                        for (int i = 0; i < 1; i++)
                        {
                            int num371 = Gore.NewGore(projectile.position + new Vector2(projectile.width * Main.rand.Next(100) / 100f, projectile.height * Main.rand.Next(100) / 100f) - Vector2.One * 10f, default, Main.rand.Next(61, 64));
                            Gore gore = Main.gore[num371];
                            gore.velocity *= 0.3f;
                            Main.gore[num371].velocity.X += Main.rand.Next(-10, 11) * 0.05f;
                            Main.gore[num371].velocity.Y += Main.rand.Next(-10, 11) * 0.05f;
                        }
                        return false;
                    }        
                case ProjectileID.DirtBall:
                    {
                        Item.NewItem(projectile.getRect(), ItemID.DirtBlock, 1);
                        return false;
                    }
                case ProjectileID.HolyArrow:
                    {
                        Terraria.Audio.SoundEngine.PlaySound(SoundID.Item10, projectile.position);
                        for (int i = 0; i < 10; ++i)
                        {
                            Dust.NewDust(projectile.position, projectile.width, projectile.height, 58, projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 150, default, 1.2f);
                        }
                        for (int i = 0; i < 3; ++i)
                        {
                            Gore.NewGore(projectile.position, new Vector2(projectile.velocity.X * 0.05f, projectile.velocity.Y * 0.05f), Main.rand.Next(16, 18), 1f);
                        }
                        int[] spread = { 1 };
                        TRAEMethods.SpawnProjectilesFromAbove(projectile.GetProjectileSource_FromThis(), projectile.Center, 1, 400, 750, spread, 22, ProjectileID.HallowStar, (int)(projectile.damage * 0.5), projectile.knockBack, projectile.owner);
                        return false;
                    }
                case ProjectileID.StarCloakStar:
                case ProjectileID.HallowStar:
                    {
                        Terraria.Audio.SoundEngine.PlaySound(SoundID.Item10, projectile.position);
                        int DustCount = 30;
                        int[] DustTypes = { 15, 57, 58 };
                        for (int i = 0; i < DustCount; ++i)
                        {
                            Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, Main.rand.Next(DustTypes), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f, 150, default(Color), 1.5f);
                            dust.noGravity = true;
                        }
                        return false;
                    }
            }
            return true;
        }
        public override void Kill(Projectile projectile, int timeLeft)
        {
            switch (projectile.type)
            {
                case ProjectileID.VortexVortexLightning:
                    {
                        int stormChance = Main.rand.Next(0, 2);
                        if (stormChance == 0 && Main.expertMode)
                        {
                            NPC.NewNPC((int)projectile.position.X, (int)projectile.position.Y, NPCID.VortexRifleman);
                        }
                    }
                    return;
                case ProjectileID.ToxicBubble:
                    {
                        int drops = (int)(1 * Math.Pow(projectile.scale, 3));
                        for (int i = 0; i < drops; i++)
                        {
                            float velX = Main.rand.Next(-2, 2);
                            float velY = Main.rand.NextFloat(10, 20);
                            int buble = Projectile.NewProjectile(projectile.GetProjectileSource_FromThis(), projectile.position.X + velX, projectile.position.Y, velX, velY, ProjectileType<ToxicDrop>(), (int)(projectile.damage * 0.67), 0, projectile.owner, 0f, 0f);
                            Main.projectile[buble].scale *= projectile.scale;
                        }
                        return;
                    }
            }    
        }        
    }
}