using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using Terraria;
using Terraria.ID;
using TRAEProject.Changes.Weapon.Ranged.Rockets;
using Terraria.ModLoader;
using TRAEProject.Common;
using static Terraria.ModLoader.ModContent;

namespace TRAEProject.Changes.Weapon.Ranged.Rockets
{
    public class NewGrenades : GlobalProjectile
	{
        public override bool InstancePerEntity => true;
        public void GrenadeAI(Projectile projectile)
        {
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);
            ++projectile.ai[0];
            if (projectile.ai[0] > 15f)
            {
                if (projectile.velocity.Y == 0f)
                {
                    projectile.velocity.X *= 0.95f;
                }
                projectile.velocity.Y += 0.2f;
            }
            int num31 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100);
            Main.dust[num31].scale *= 1f + (float)Main.rand.Next(10) * 0.1f;
            Main.dust[num31].velocity *= 0.2f;
            Main.dust[num31].noGravity = true;
        }       
    }

    public class Grenade : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.height = 14;
            Projectile.width = 14;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.penetrate = 4;
            Projectile.timeLeft = 120; Projectile.usesIDStaticNPCImmunity = true;
            Projectile.idStaticNPCHitCooldown = 10;
            Projectile.GetGlobalProjectile<ProjectileStats>().BouncesOffTiles = true;
            Projectile.GetGlobalProjectile<ProjectileStats>().explodes = true;
            Projectile.GetGlobalProjectile<ProjectileStats>().UsesDefaultExplosion = true;
            Projectile.GetGlobalProjectile<ProjectileStats>().dontExplodeOnTiles = true;
            Projectile.GetGlobalProjectile<ProjectileStats>().ExplosionRadius = 120;
        }

        public override void AI()
        {
			--Projectile.timeLeft; 
            Projectile.GetGlobalProjectile<NewGrenades>().GrenadeAI(Projectile);
        }
    }
    public class DestructiveGrenade : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileType<Grenade>()); 
            Projectile.penetrate = 4;
            Projectile.timeLeft = 120;
        }
        public override void AI()
        {
            Projectile.GetGlobalProjectile<NewGrenades>().GrenadeAI(Projectile);
        }
        public override void Kill(int timeLeft)
        {
            TRAEMethods.DefaultExplosion(Projectile);
            Projectile.GetGlobalProjectile<NewRockets>().DestroyTiles(Projectile, 3);
        }
    }
    public class SuperGrenade : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileType<Grenade>()); 
            Projectile.penetrate = 6;
            Projectile.timeLeft = 120;
            AIType = ProjectileType<Grenade>();
            Projectile.GetGlobalProjectile<ProjectileStats>().explodes = true;
            Projectile.GetGlobalProjectile<ProjectileStats>().UsesDefaultExplosion = true;
            Projectile.GetGlobalProjectile<ProjectileStats>().ExplosionRadius = 180;
        }
        public override void AI()
        {
            Projectile.GetGlobalProjectile<NewGrenades>().GrenadeAI(Projectile);
        }
    }
    public class DirectGrenade : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileType<Grenade>());
            AIType = ProjectileType<Grenade>(); 
            Projectile.penetrate = 3; Projectile.extraUpdates = 1;
            Projectile.timeLeft = 120;
            Projectile.GetGlobalProjectile<ProjectileStats>().DirectDamage = 1.5f;
            Projectile.GetGlobalProjectile<ProjectileStats>().explodes = true;
            Projectile.GetGlobalProjectile<ProjectileStats>().ExplosionRadius = 80;
            Projectile.GetGlobalProjectile<ProjectileStats>().ExplosionDamage = 0.67f;
            Projectile.GetGlobalProjectile<ProjectileStats>().UsesDefaultExplosion = true;
        }
        public override void AI()
        {
            Projectile.GetGlobalProjectile<NewGrenades>().GrenadeAI(Projectile);
        }
    }
    public class MiniNukeGrenade : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileType<Grenade>());
            AIType = ProjectileType<Grenade>();
            Projectile.penetrate = 8;
            Projectile.GetGlobalProjectile<ProjectileStats>().explodes = true;
            Projectile.GetGlobalProjectile<ProjectileStats>().UsesDefaultExplosion = true;
            Projectile.GetGlobalProjectile<ProjectileStats>().ExplosionRadius = 250;
        }

        public override void AI()
        {
            Projectile.GetGlobalProjectile<NewGrenades>().GrenadeAI(Projectile);
        }
    }
    public class DestructiveMiniNukeGrenade : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileType<Grenade>());
            AIType = ProjectileType<Grenade>();
            Projectile.penetrate = 8; Projectile.timeLeft = 120;
            Projectile.GetGlobalProjectile<ProjectileStats>().explodes = true;
            Projectile.GetGlobalProjectile<ProjectileStats>().UsesDefaultExplosion = true;
            Projectile.GetGlobalProjectile<ProjectileStats>().ExplosionRadius = 250;
        }
     
        public override void AI()
        {
            Projectile.GetGlobalProjectile<NewGrenades>().GrenadeAI(Projectile);
        }
     public override void Kill(int timeLeft)
        {
            TRAEMethods.DefaultExplosion(Projectile);
            Projectile.GetGlobalProjectile<NewRockets>().DestroyTiles(Projectile, 7);
        }
    }
    public class ClusterGrenade : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileType<Grenade>());
            AIType = ProjectileType<Grenade>();
            Projectile.penetrate = 5; Projectile.timeLeft = 120;
            Projectile.GetGlobalProjectile<ProjectileStats>().explodes = true;
            Projectile.GetGlobalProjectile<ProjectileStats>().ExplosionRadius = 120;
        }
        public override void AI()
        {
            Projectile.GetGlobalProjectile<NewGrenades>().GrenadeAI(Projectile);
        }
        public override void Kill(int timeLeft)
        {
            Projectile.GetGlobalProjectile<NewRockets>().ClusterRocketExplosion(Projectile);
        }

    }
    public class HeavyGrenade : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileType<Grenade>());
            AIType = ProjectileType<Grenade>();
            Projectile.penetrate = 5;
            Projectile.GetGlobalProjectile<NewRockets>().HeavyRocket = true;
            Projectile.GetGlobalProjectile<ProjectileStats>().explodes = true;
            Projectile.GetGlobalProjectile<ProjectileStats>().ExplosionRadius = 120;
        }
        public override void AI()
        {
            Projectile.GetGlobalProjectile<NewGrenades>().GrenadeAI(Projectile);
        }
    }
}