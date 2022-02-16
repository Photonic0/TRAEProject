using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TRAEProject.Common;
using TRAEProject.Changes.Weapon.Ranged.Rockets;
using static Terraria.ModLoader.ModContent;

namespace TRAEProject.Changes.Weapon.Ranged.Rockets
{ 
    public class NewSnowmanRockets : GlobalProjectile
    {
        //public override bool InstancePerEntity => true;
        public void SnowmanRocketAI(Projectile projectile)
        {
			projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);
			projectile.localAI[1] += 1f;
			if (projectile.timeLeft < 3)
			{
				projectile.alpha = 255; // Projectile becomes invisible
			}
			for (int l = 0; l < 2; l++)
			{
				float num14 = 0f;
				float num15 = 0f;
				if (l == 1)
				{
					num14 = projectile.velocity.X * 0.5f;
					num15 = projectile.velocity.Y * 0.5f;
				}
				if (!(projectile.localAI[1] > 9f))
				{
					continue;
				}
				if (Main.rand.Next(2) == 0)
				{
					int num16 = Dust.NewDust(new Vector2(projectile.position.X + 3f + num14, projectile.position.Y + 3f + num15) - projectile.velocity * 0.5f, projectile.width - 8, projectile.height - 8, DustID.Torch, 0f, 0f, 100);
					Main.dust[num16].scale *= 1.4f + (float)Main.rand.Next(10) * 0.1f;
					Main.dust[num16].velocity *= 0.2f;
					Main.dust[num16].noGravity = true;
					if (Main.dust[num16].type == 152)
					{
						Main.dust[num16].scale *= 0.5f;
						Main.dust[num16].velocity += projectile.velocity * 0.1f;
					}
					else if (Main.dust[num16].type == 35)
					{
						Main.dust[num16].scale *= 0.5f;
						Main.dust[num16].velocity += projectile.velocity * 0.1f;
					}
					else if (Main.dust[num16].type == Dust.dustWater())
					{
						Main.dust[num16].scale *= 0.65f;
						Main.dust[num16].velocity += projectile.velocity * 0.1f;
					}
					if (projectile.type == ProjectileType<MiniNukeSnowman>() || projectile.type == ProjectileType<DestructiveMiniNukeSnowman>())
					{
						Dust dust4 = Main.dust[num16];
						if (dust4.dustIndex != 6000)
						{
							dust4 = Dust.NewDustPerfect(dust4.position, dust4.type, dust4.velocity, dust4.alpha, dust4.color, dust4.scale + 0.5f);
							dust4.velocity = Main.rand.NextVector2Circular(3f, 3f);
							dust4.noGravity = true;
						}
						if (dust4.dustIndex != 6000)
						{
							dust4 = Dust.NewDustPerfect(dust4.position, dust4.type, dust4.velocity, dust4.alpha, dust4.color, dust4.scale + 0.5f);
							dust4.velocity = ((float)Math.PI * 2f * (projectile.timeLeft / 20f)).ToRotationVector2() * 3f;
							dust4.noGravity = true;
						}
					}
				}
				if (Main.rand.Next(2) == 0)
				{
					int num17 = Dust.NewDust(new Vector2(projectile.position.X + 3f + num14, projectile.position.Y + 3f + num15) - projectile.velocity * 0.5f, projectile.width - 8, projectile.height - 8, 31, 0f, 0f, 100, default(Color), 0.5f);
					Main.dust[num17].fadeIn = 0.5f + (float)Main.rand.Next(5) * 0.1f;
					Main.dust[num17].velocity *= 0.05f;
				}
			}
			float num18 = projectile.position.X;
			float num19 = projectile.position.Y;
			float num20 = 600f;
			bool flag3 = false;
			projectile.ai[0] += 1f;
			if (projectile.ai[0] > 30f)
			{
				projectile.ai[0] = 30f;
				for (int m = 0; m < 200; m++)
				{
					if (Main.npc[m].CanBeChasedBy(this))
					{
						float num21 = Main.npc[m].position.X + (float)(Main.npc[m].width / 2);
						float num22 = Main.npc[m].position.Y + (float)(Main.npc[m].height / 2);
						float num23 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num21) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num22);
						if (num23 < num20 && Collision.CanHit(projectile.position, projectile.width, projectile.height, Main.npc[m].position, Main.npc[m].width, Main.npc[m].height))
						{
							num20 = num23;
							num18 = num21;
							num19 = num22;
							flag3 = true;
						}
					}
				}
			}
			if (!flag3)
			{
				num18 = projectile.position.X + (float)(projectile.width / 2) + projectile.velocity.X * 100f;
				num19 = projectile.position.Y + (float)(projectile.height / 2) + projectile.velocity.Y * 100f;
			}
			float num24 = 16f;
			Vector2 vector = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
			float num25 = num18 - vector.X;
			float num26 = num19 - vector.Y;
			float num27 = (float)Math.Sqrt(num25 * num25 + num26 * num26);
			num27 = num24 / num27;
			num25 *= num27;
			num26 *= num27;
			projectile.velocity.X = (projectile.velocity.X * 11f + num25) / 12f;
			projectile.velocity.Y = (projectile.velocity.Y * 11f + num26) / 12f;
		}
	}

    public class SnowmanRocket : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.height = 14;
            Projectile.width = 14;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.penetrate = 4;
            Projectile.timeLeft = 600;
            Projectile.GetGlobalProjectile<ProjectileStats>().explodes = true;
            Projectile.GetGlobalProjectile<ProjectileStats>().UsesDefaultExplosion = true;
            Projectile.GetGlobalProjectile<ProjectileStats>().ExplosionRadius = 120;
        }
        public override void AI()
        {
            Projectile.GetGlobalProjectile<NewSnowmanRockets>().SnowmanRocketAI(Projectile);
        }
    }
    public class DestructiveSnowmanRocket : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileType<SnowmanRocket>());
        }
        public override void AI()
        {

			Projectile.GetGlobalProjectile<NewSnowmanRockets>().SnowmanRocketAI(Projectile);
        }
        public override void Kill(int timeLeft)
        {
            TRAEMethods.DefaultExplosion(Projectile);
            Projectile.GetGlobalProjectile<NewRockets>().DestroyTiles(Projectile, 3);
        }
    }
    public class SuperSnowmanRocket : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileType<SnowmanRocket>());
            AIType = ProjectileType<SnowmanRocket>();
            Projectile.penetrate = 6;
            Projectile.GetGlobalProjectile<ProjectileStats>().explodes = true;
            Projectile.GetGlobalProjectile<ProjectileStats>().UsesDefaultExplosion = true;
            Projectile.GetGlobalProjectile<ProjectileStats>().ExplosionRadius = 180;
        }
        public override void AI()
        {
            Projectile.GetGlobalProjectile<NewSnowmanRockets>().SnowmanRocketAI(Projectile);
        }
    }
    public class DirectSnowmanRocket : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileType<SnowmanRocket>());
            AIType = ProjectileType<SnowmanRocket>();
            Projectile.penetrate = 3;
            Projectile.GetGlobalProjectile<ProjectileStats>().DirectDamage = 1.5f;
            Projectile.GetGlobalProjectile<ProjectileStats>().explodes = true;
            Projectile.GetGlobalProjectile<ProjectileStats>().ExplosionRadius = 80;
            Projectile.GetGlobalProjectile<ProjectileStats>().ExplosionDamage = 0.67f;
            Projectile.GetGlobalProjectile<ProjectileStats>().UsesDefaultExplosion = true;
        }
        public override void AI()
        {
            Projectile.GetGlobalProjectile<NewSnowmanRockets>().SnowmanRocketAI(Projectile);
        }
    }
    public class MiniNukeSnowman : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileType<SnowmanRocket>());
            AIType = ProjectileType<SnowmanRocket>();
            Projectile.penetrate = 8;
            Projectile.GetGlobalProjectile<ProjectileStats>().explodes = true;
            Projectile.GetGlobalProjectile<ProjectileStats>().UsesDefaultExplosion = true;
            Projectile.GetGlobalProjectile<ProjectileStats>().ExplosionRadius = 250;
        }
        public override void AI()
        {
            Projectile.GetGlobalProjectile<NewSnowmanRockets>().SnowmanRocketAI(Projectile);
		}
    }
    public class DestructiveMiniNukeSnowman : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileType<SnowmanRocket>());
            AIType = ProjectileType<SnowmanRocket>();
            Projectile.penetrate = 8;
            Projectile.GetGlobalProjectile<ProjectileStats>().explodes = true;
            Projectile.GetGlobalProjectile<ProjectileStats>().UsesDefaultExplosion = true;
            Projectile.GetGlobalProjectile<ProjectileStats>().ExplosionRadius = 250;
        }
        public override void AI()
        {
			if (Projectile.timeLeft < 3)
            {
				Projectile.alpha = 255; // Projectile becomes invisible
			}
            Projectile.GetGlobalProjectile<NewSnowmanRockets>().SnowmanRocketAI(Projectile);
			
		}
     public override void Kill(int timeLeft)
        {
			TRAEMethods.DefaultExplosion(Projectile);
            Projectile.GetGlobalProjectile<NewRockets>().DestroyTiles(Projectile, 7);
        }
    }
    public class ClusterSnowmanRocket : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileType<SnowmanRocket>());
            AIType = ProjectileType<SnowmanRocket>();
            Projectile.penetrate = 4;
            Projectile.GetGlobalProjectile<ProjectileStats>().explodes = true;
            Projectile.GetGlobalProjectile<ProjectileStats>().ExplosionRadius = 120;
        }
        public override void AI()
        {
            Projectile.GetGlobalProjectile<NewSnowmanRockets>().SnowmanRocketAI(Projectile);
        }
        public override void Kill(int timeLeft)
        {
            Projectile.GetGlobalProjectile<NewRockets>().ClusterRocketExplosion(Projectile);
        }
    }
    public class HeavySnowmanRocket : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileType<SnowmanRocket>());
            AIType = ProjectileType<SnowmanRocket>();
            Projectile.penetrate = 4;
            Projectile.GetGlobalProjectile<NewRockets>().HeavyRocket = true;
            Projectile.GetGlobalProjectile<ProjectileStats>().explodes = true;
            Projectile.GetGlobalProjectile<ProjectileStats>().ExplosionRadius = 120;
        }
        public override void AI()
        {
            Projectile.GetGlobalProjectile<NewSnowmanRockets>().SnowmanRocketAI(Projectile);
        }
    }
}