using TRAEProject.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using static Terraria.ModLoader.ModContent;

namespace TRAEProject.Changes.Projectiles
{
    public class MagicProjectile : GlobalProjectile
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
		  public bool onlyBounceOnce = false;
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
                // 
                // Mage
                case ProjectileID.BookOfSkullsSkull:
                    projectile.timeLeft = 180;
                    return;       
                case ProjectileID.ShadowBeamFriendly:
                    SmartBouncesOffEnemies = true;
                    projectile.usesLocalNPCImmunity = true;
                    dontHitTheSameEnemyMultipleTimes = true;
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
                case ProjectileID.GoldenShowerFriendly:
                    projectile.usesLocalNPCImmunity = true;
                    projectile.localNPCHitCooldown = 10;
                    return;
				case ProjectileID.FrostBoltStaff:
                    projectile.penetrate = 2;
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
				case ProjectileID.BallofFrost:
                    fallThrough = false; // prevents these projectiles from falling through platforms
                    return true;
            }
            return true;
        }
        int timer = 0; 
        readonly int fireRate = 7; //making this 5 will make it just like vanilla

        public override bool PreAI(Projectile projectile)
        {
            Player player = Main.player[projectile.owner];
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
            return true;
        }
        
        public override void AI(Projectile projectile)
        {
            Player player = Main.player[projectile.owner];           
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
            }                    
        }    
       
        public override bool PreKill(Projectile projectile, int timeLeft)
        { 
            switch (projectile.type)
            {                
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
             
            }
            return true;
        }       
    }
}