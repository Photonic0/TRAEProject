using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TRAEProject.Buffs;
using TRAEProject.Projectiles;
using static Terraria.ModLoader.ModContent;

namespace TRAEProject.Changes.Projectiles
{
    public class MinionChanges : GlobalProjectile
    {
        public override bool InstancePerEntity => true;
        public override void SetDefaults(Projectile projectile)
        {
            switch (projectile.type)
            {
                case ProjectileID.MiniSharkron:
                    return;
                case ProjectileID.Tempest:
                    projectile.usesLocalNPCImmunity = true;
                    projectile.localNPCHitCooldown = 15;
                    return;
                case ProjectileID.Retanimini:
                case ProjectileID.Spazmamini:
                    projectile.tileCollide = false;
                    projectile.usesIDStaticNPCImmunity = false;
                    projectile.usesLocalNPCImmunity = true; ;
                    return;
                case ProjectileID.MiniRetinaLaser:
                    projectile.GetGlobalProjectile<TRAEGlobalProjectile>().homesIn = true;
                    projectile.GetGlobalProjectile<TRAEGlobalProjectile>().dontHitTheSameEnemyMultipleTimes = true;
                    projectile.usesIDStaticNPCImmunity = false;
                    projectile.usesLocalNPCImmunity = true;
                    projectile.localNPCHitCooldown = 10;
                    return;
                case ProjectileID.CoolWhip:
                    projectile.GetGlobalProjectile<TRAEGlobalProjectile>().AddsBuff = BuffType<CoolWhipTag>();
                    projectile.GetGlobalProjectile<TRAEGlobalProjectile>().AddsBuffDuration = 240;
                    return;
                case ProjectileID.DeadlySphere:
				projectile.extraUpdates = 1;
       projectile.usesIDStaticNPCImmunity = false;
                    projectile.usesLocalNPCImmunity = true;
                    projectile.localNPCHitCooldown = 10;
                    return;
                case ProjectileID.DangerousSpider:
                case ProjectileID.VenomSpider:
                case ProjectileID.JumperSpider:
                    projectile.usesIDStaticNPCImmunity = false;
                    projectile.usesLocalNPCImmunity = true;
                    projectile.localNPCHitCooldown = 30;
                    return;
                case ProjectileID.HornetStinger:
                    projectile.extraUpdates = 2;
                    projectile.GetGlobalProjectile<TRAEGlobalProjectile>().homesIn = true;
                    projectile.GetGlobalProjectile<TRAEGlobalProjectile>().homingRange = 150f;
                    return;
                case ProjectileID.Smolstar:
                    projectile.usesLocalNPCImmunity = true;
                    projectile.localNPCHitCooldown = 48; // up from 40
                    return;
                case ProjectileID.ImpFireball:
                    projectile.usesIDStaticNPCImmunity = false;
                    projectile.usesLocalNPCImmunity = true;
                    projectile.localNPCHitCooldown = 10;
                    return;
                case ProjectileID.VampireFrog:
                    projectile.usesIDStaticNPCImmunity = false;
                    projectile.usesLocalNPCImmunity = true;
                    projectile.localNPCHitCooldown = 15; // up from 10, static 
                    return;
                case ProjectileID.PygmySpear: // revisit
                    projectile.penetrate = 2;
                    projectile.usesLocalNPCImmunity = true;
                    projectile.localNPCHitCooldown = 10;
                    return;
            }

        }
        public override void AI(Projectile projectile)
        {
            switch (projectile.type)
            {
                case ProjectileID.DeadlySphere:
					projectile.ai[1] += 2f;
					return;
				case ProjectileID.BatOfLight:
                    projectile.localNPCHitCooldown = (int)projectile.ai[0];
                    return;
                case ProjectileID.FlyingImp:
                    {
                        if (projectile.ai[1] < 0f)
                        {
                            projectile.ai[1] -= 0.2f; // Needs to reach 90f to shoot
                        }
                    }
                    return;
                case ProjectileID.Smolstar:
                    {
                        if (projectile.ai[0] == -1f)
                        {
                            projectile.ai[1] -= 0.2f; // when it reaches 9f, attack.                 
                        }
                        return;
                    }
                case ProjectileID.Tempest:
                    {
                        projectile.ai[1] += 3; // fires faster
                    }
                    return;
            }    
        }
        public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
        {
            if ((projectile.minion || ProjectileID.Sets.MinionShot[projectile.type]) && target.HasBuff(BuffID.RainbowWhipNPCDebuff) && crit == true)
            {
                float VelocityX = Main.rand.Next(-35, 36) * 0.02f;
                float VelocityY = Main.rand.Next(-35, 36) * 0.02f;
                VelocityX *= 10f;
                VelocityY *= 10f;
                Projectile.NewProjectile(projectile.GetProjectileSource_FromThis(), target.Center.X, target.Center.Y, VelocityX, VelocityY, ProjectileType<KaleidoscopeProjectile>(), (int)(projectile.damage * 0.5), 0, projectile.owner, 0, 0f);
            }
            switch (projectile.type)
            {
                case ProjectileID.JumperSpider:
                case ProjectileID.VenomSpider:
                case ProjectileID.DangerousSpider:
                    {
                        projectile.localAI[1] = 30f; // up from 20
                        return;
                    }
            }
        }
        public override void ModifyHitNPC(Projectile projectile, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (projectile.minion|| ProjectileID.Sets.MinionShot[projectile.type])
            {
                damage += target.GetGlobalNPC<ChangesNPCs>().TagDamage;
                if (Main.rand.Next(100) < target.GetGlobalNPC<ChangesNPCs>().TagCritChance)
                {
                    crit = true;
                }
            }
        }
        NPC target;
        public override bool PreAI(Projectile projectile)
        {
            if (projectile.type == ProjectileID.Tempest)
            {
                //linking the minion to the player
                Player player = Main.player[projectile.owner];
                if (Main.player[projectile.owner].dead)
                {
                    Main.player[projectile.owner].sharknadoMinion = false;
                }
                if (Main.player[projectile.owner].sharknadoMinion)
                {
                    projectile.timeLeft = 2;
                }

                //sharknados push each other when too close
                float disturbanceVelocity = 0.1f;
                float disturbanceDistance = projectile.width;
                disturbanceDistance *= 2f;
                for (int m = 0; m < 1000; m++)
                {
                    if (m != projectile.whoAmI && Main.projectile[m].active && Main.projectile[m].owner == projectile.owner && Main.projectile[m].type == projectile.type && Math.Abs(projectile.position.X - Main.projectile[m].position.X) + Math.Abs(projectile.position.Y - Main.projectile[m].position.Y) < disturbanceDistance)
                    {
                        if (projectile.position.X < Main.projectile[m].position.X)
                        {
                            projectile.velocity.X -= disturbanceVelocity;
                        }
                        else
                        {
                            projectile.velocity.X += disturbanceVelocity;
                        }
                        if (projectile.position.Y < Main.projectile[m].position.Y)
                        {
                            projectile.velocity.Y -= disturbanceVelocity;
                        }
                        else
                        {
                            projectile.velocity.Y += disturbanceVelocity;
                        }
                    }
                }

                //manage alpha
                projectile.tileCollide = false;
                if (Collision.SolidCollision(projectile.position, projectile.width, projectile.height))
                {
                    projectile.alpha += 20;
                    if (projectile.alpha > 150)
                    {
                        projectile.alpha = 150;
                    }
                }
                else
                {
                    projectile.alpha -= 50;
                    if (projectile.alpha < 60)
                    {
                        projectile.alpha = 60;
                    }
                }

                //movement
                if (!Collision.CanHitLine(projectile.Center, 1, 1, Main.player[projectile.owner].Center, 1, 1))
                {
                    projectile.ai[0] = 1f;
                }
                float speed = 16f;
                Vector2 diff = player.Center - projectile.Center + new Vector2(0f, -20f);
                float num25 = diff.Length();
                if (num25 > 200f)
                {
                    speed = 32f;
                }
                if (num25 < 100f && projectile.ai[0] == 1f && !Collision.SolidCollision(projectile.position, projectile.width, projectile.height))
                {
                    projectile.ai[0] = 0f;
                    projectile.netUpdate = true;
                }
                if (num25 > 2000f)
                {
                    projectile.position.X = Main.player[projectile.owner].Center.X - (float)(projectile.width / 2);
                    projectile.position.Y = Main.player[projectile.owner].Center.Y - (float)(projectile.width / 2);
                }

                if (Math.Abs(diff.X) > 40f || Math.Abs(diff.Y) > 10f)
                {
                    diff.Normalize();
                    diff *= speed;
                    diff *= new Vector2(1.25f, 0.65f);
                    projectile.velocity = (projectile.velocity * 20f + diff) / 21f;
                }
                else
                {
                    if (projectile.velocity.X == 0f && projectile.velocity.Y == 0f)
                    {
                        projectile.velocity.X = -0.15f;
                        projectile.velocity.Y = -0.05f;
                    }
                    projectile.velocity *= 1.01f;
                }

                //animation and dust
                int num27 = 2;
                projectile.frameCounter++;
                if (projectile.frameCounter >= 6 * num27)
                {
                    projectile.frameCounter = 0;
                }
                projectile.frame = projectile.frameCounter / num27;
                if (Main.rand.Next(5) == 0)
                {
                    int num28 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 217, 0f, 0f, 100, default(Color), 2f);
                    Main.dust[num28].velocity *= 0.3f;
                    Main.dust[num28].noGravity = true;
                    Main.dust[num28].noLight = true;
                }
                if (projectile.velocity.X > 0f)
                {
                    projectile.spriteDirection = (projectile.direction = -1);
                }
                else if (projectile.velocity.X < 0f)
                {
                    projectile.spriteDirection = (projectile.direction = 1);
                }

                //attack cooldown
                projectile.ai[1] += 1f;
                if (Main.rand.Next(3) != 0)
                {
                    projectile.ai[1] += 1f;
                }
                if (projectile.ai[1] > 50f)
                {

                    if (TRAEMethods.ClosestNPC(ref target, 500 * 16, player.Center, false, player.MinionAttackTargetNPC))
                    {

                        if (Main.myPlayer == projectile.owner)
                        {
                            float shootSpeed = 20;
                            float calculatedShootAngle = TRAEMethods.PredictiveAim(projectile.Center, shootSpeed, target.Center, target.velocity, out _);
                            if (!float.IsNaN(calculatedShootAngle))
                            {
                                Projectile.NewProjectile(projectile.GetProjectileSource_FromThis(), projectile.Center, TRAEMethods.PolarVector(shootSpeed, calculatedShootAngle), ProjectileID.MiniSharkron, projectile.damage, projectile.knockBack, projectile.owner);
                            }



                        }
                        projectile.ai[1] = 0f;
                        projectile.netUpdate = true;
                    }

                }


                return false;
            }
            if (projectile.type == ProjectileID.MiniSharkron)
            {
                projectile.ai[0] = projectile.timeLeft < (3600 - (16 * 5000) / 10) ? 45 : 0;
            }
            return base.PreAI(projectile);
        }
    }
    public class SummonTags : GlobalBuff
    {
        
        public override void Update(int type, NPC npc, ref int buffIndex)
        {
            switch (type)
            {
                case BuffID.MaceWhipNPCDebuff:
                    npc.GetGlobalNPC<ChangesNPCs>().TagCritChance += 15;
                    return;
                case BuffID.RainbowWhipNPCDebuff:
                    npc.GetGlobalNPC<ChangesNPCs>().TagCritChance += 10;
                    return;
            }
        }
    }
}