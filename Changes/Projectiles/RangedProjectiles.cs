using TRAEProject.Buffs;
using TRAEProject.Projectiles;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using static Terraria.ModLoader.ModContent;

namespace TRAEProject.Changes.Projectiles
{
    public class RangedProjectile : GlobalProjectile
    {
        public override bool InstancePerEntity => true;
        public override void SetDefaults(Projectile projectile)
        {
            switch (projectile.type)
            {
                case ProjectileID.Hellwing:
                    projectile.penetrate = 1;
                    projectile.GetGlobalProjectile<TRAEGlobalProjectile>().homesIn = true;
                    return;
				case ProjectileID.CandyCorn:
                    projectile.usesLocalNPCImmunity = true;
                    projectile.localNPCHitCooldown = 10;
                    return;
                case ProjectileID.CursedBullet:
                    projectile.extraUpdates = 1;
                    return;
                case ProjectileID.CrystalShard:
                    projectile.GetGlobalProjectile<TRAEGlobalProjectile>().DirectDamage = 0.5f;
                    projectile.GetGlobalProjectile<TRAEGlobalProjectile>().IgnoresDefense = true;
                    return;
                case ProjectileID.Electrosphere:
                    projectile.usesIDStaticNPCImmunity = true;
                    projectile.idStaticNPCHitCooldown = 10;
                    return;
                case ProjectileID.CursedDartFlame:
                    projectile.timeLeft = 75;
                    projectile.penetrate = 1;
                    return;
                case ProjectileID.IchorDart:
                    projectile.GetGlobalProjectile<TRAEGlobalProjectile>().DirectDamage = 0.8f;
                    return;
                case ProjectileID.CrystalDart:
                    projectile.GetGlobalProjectile<TRAEGlobalProjectile>().DamageFalloff = 0.2f;
                    projectile.GetGlobalProjectile<TRAEGlobalProjectile>().DamageLossOffATileBounce = 0.2f;
                    return;
                case ProjectileID.JestersArrow:
                    projectile.penetrate = 7;      
					projectile.usesLocalNPCImmunity = true;
                    projectile.localNPCHitCooldown = 10;
                    return;
                case ProjectileID.CursedArrow:
                    projectile.extraUpdates = 1;
                    return;
                case ProjectileID.UnholyArrow:     
					projectile.usesLocalNPCImmunity = true;
                    projectile.localNPCHitCooldown = 10;
                    return;
                case ProjectileID.VortexBeaterRocket:
                    projectile.penetrate = -1;
                    projectile.scale = 1.15f;
                    projectile.GetGlobalProjectile<TRAEGlobalProjectile>().explodes = true;
                    projectile.GetGlobalProjectile<TRAEGlobalProjectile>().ExplosionRadius = 180;
                    projectile.GetGlobalProjectile<TRAEGlobalProjectile>().DirectDamage = 1.8f;
                    return;
                case ProjectileID.HellfireArrow:
                    projectile.extraUpdates = 1;
                    projectile.usesLocalNPCImmunity = true;
                    projectile.localNPCHitCooldown = 10;
                    return;
                case ProjectileID.IchorBullet:
                    projectile.GetGlobalProjectile<TRAEGlobalProjectile>().BouncesOffTiles = true;
                    projectile.GetGlobalProjectile<TRAEGlobalProjectile>().onlyBounceOnce = true;
                    return;
                case ProjectileID.GrenadeI:
                case ProjectileID.GrenadeII:
                case ProjectileID.GrenadeIII:
                case ProjectileID.GrenadeIV:
                    projectile.usesLocalNPCImmunity = true;
                    projectile.localNPCHitCooldown = 10;
                    return;
                case ProjectileID.ToxicBubble:
                    projectile.timeLeft = 120;
                    return;
                case ProjectileID.BoneArrow:
                    projectile.penetrate = 3; 
                    projectile.GetGlobalProjectile<TRAEGlobalProjectile>().BouncesOffTiles = true;
                    projectile.GetGlobalProjectile<TRAEGlobalProjectile>().onlyBounceOnce = true;
                    return;
                case ProjectileID.HallowStar:
                    projectile.penetrate = -1;
                    projectile.usesLocalNPCImmunity = true;
                    projectile.localNPCHitCooldown = 10;
                    projectile.tileCollide = false;
                    projectile.GetGlobalProjectile<TRAEGlobalProjectile>().explodes = true;
                    projectile.GetGlobalProjectile<TRAEGlobalProjectile>().ExplosionRadius = 80;
                    projectile.GetGlobalProjectile<TRAEGlobalProjectile>().DamageFalloff = 0.25f;
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
                    fallThrough = false; // prevents these projectiles from falling through platforms
                    return true;
            }
            return true;
        }
        int ChloroBulletTime = 0;
        readonly int bulletsPerRocket = 4; //making this 7 will make it just like vanilla
         int timer = 0; 
        readonly int fireRate = 7; //making this 5 will make it just like vanilla

        public override bool PreAI(Projectile projectile)
        {
            Player player = Main.player[projectile.owner];
			if (projectile.type == ProjectileID.ChlorophyteArrow)
			{
                projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);
                ++ChloroBulletTime;
                if (ChloroBulletTime <= 24)
                {
                    Vector2 move = Vector2.Zero;
                    bool target = false;
                    float distance = 300f;
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
                    return false;
                }
                return true;
            }

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
            switch (projectile.type)
            {
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
            switch (projectile.type)
            {
                case ProjectileID.ProximityMineI:
                case ProjectileID.ProximityMineII:
                case ProjectileID.ProximityMineIII:
                case ProjectileID.ProximityMineIV:
                    projectile.velocity.X *= 0f;
                    projectile.velocity.Y *= 0f;
                    return false;      
                case ProjectileID.CursedBullet:
                    {
                        Projectile.NewProjectile(projectile.GetProjectileSource_FromThis(), projectile.position.X, projectile.position.Y, 0f, 0f, ProjectileID.CursedDartFlame, (projectile.damage * 1), 0, projectile.owner, 0f, 0f);
                        return true;
                    }
                case ProjectileID.NanoBullet:
                case ProjectileID.ChlorophyteArrow:
                    {
                        projectile.Kill();
						return false;
                    }
            }
            return true;
        }

        private static int tillinsta = 0;
        private static int shootDelay = 0;
           
        public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
        {
           
            Player player = Main.player[projectile.owner];
            switch (projectile.type)
            {
                case ProjectileID.NanoBullet:
                    {
                        player.AddBuff(BuffType<NanoHealing>(), 60, false);
                        return;
                    }
                      
                // melee
            }               
        }
        public override bool PreKill(Projectile projectile, int timeLeft)
        { 
            switch (projectile.type)
            {
              
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