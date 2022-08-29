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
    public class NewMines : GlobalProjectile
    {
        //public override bool InstancePerEntity => true;
        public void MineAI(Projectile projectile)
        {
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);
   
            if (projectile.velocity.X > -0.1 && projectile.velocity.X < 0.1)
            {
                projectile.velocity.X = 0f;
            }
            if (projectile.velocity.Y > -0.1 && projectile.velocity.Y < 0.1)
            {
                projectile.velocity.Y = 0f;
            }
      
            if (projectile.velocity.X > -0.2 && projectile.velocity.X < 0.2 && projectile.velocity.Y > -0.2 && projectile.velocity.Y < 0.2)
            {
                projectile.alpha += 2; // twice as fast
                if (projectile.alpha > 200)
                {
                    projectile.alpha = 200;
                }
            }
            else
            {
                projectile.velocity.Y += 0.25f;
                projectile.alpha = 0;
                int num32 = Dust.NewDust(new Vector2(projectile.position.X + 3f, projectile.position.Y + 3f) - projectile.velocity * 0.5f, projectile.width - 8, projectile.height - 8, 31, 0f, 0f, 100);
                Main.dust[num32].scale *= 1.6f + (float)Main.rand.Next(5) * 0.1f;
                Main.dust[num32].velocity *= 0.05f;
                Main.dust[num32].noGravity = true;
            }
        }
    }

    public class Mine : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.height = 10;
            Projectile.width = 10;
            Projectile.friendly = true; 
            Projectile.GetGlobalProjectile<NewRockets>().IsARocket = true;

            ProjectileID.Sets.IsAMineThatDealsTripleDamageWhenStationary[Projectile.type] = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.penetrate = 4;
            Projectile.timeLeft = 3600; 
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown= 10;
            Projectile.GetGlobalProjectile<NewRockets>().IsARocket = true;

            Projectile.GetGlobalProjectile<ProjectileStats>().explodes = true;
            Projectile.GetGlobalProjectile<ProjectileStats>().dontExplodeOnTiles = true;
            Projectile.GetGlobalProjectile<ProjectileStats>().UsesDefaultExplosion = true;
            Projectile.GetGlobalProjectile<ProjectileStats>().ExplosionRadius = 120;
        }
        public override void AI()
        {
            Projectile.GetGlobalProjectile<NewMines>().MineAI(Projectile);
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.velocity.X = 0f;
            Projectile.velocity.Y = 0f;
            return false;
        }

    }
    public class DestructiveMine : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileType<Mine>());
            Projectile.GetGlobalProjectile<ProjectileStats>().dontExplodeOnTiles = true;
            Projectile.GetGlobalProjectile<NewRockets>().IsARocket = true;

            ProjectileID.Sets.IsAMineThatDealsTripleDamageWhenStationary[Projectile.type] = true;
        }
        public override void AI()
        {
            Projectile.GetGlobalProjectile<NewMines>().MineAI(Projectile);
        }
  
        public override void Kill(int timeLeft)
        {
            TRAEMethods.DefaultExplosion(Projectile);
            Projectile.GetGlobalProjectile<ProjectileStats>().dontExplodeOnTiles = true;

            Projectile.GetGlobalProjectile<NewRockets>().DestroyTiles(Projectile, 3);
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.velocity.X = 0f;
            Projectile.velocity.Y = 0f;
            return false;
        }
    }
    public class SuperMine : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileType<Mine>());
            AIType = ProjectileType<Mine>();
            Projectile.penetrate = 5;
            ProjectileID.Sets.IsAMineThatDealsTripleDamageWhenStationary[Projectile.type] = true;
            Projectile.GetGlobalProjectile<ProjectileStats>().dontExplodeOnTiles = true;
            Projectile.GetGlobalProjectile<NewRockets>().IsARocket = true;

            Projectile.GetGlobalProjectile<ProjectileStats>().explodes = true;
            Projectile.GetGlobalProjectile<ProjectileStats>().UsesDefaultExplosion = true;
            Projectile.GetGlobalProjectile<ProjectileStats>().ExplosionRadius = 180;
        }
        public override void AI()
        {
            Projectile.GetGlobalProjectile<NewMines>().MineAI(Projectile);
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.velocity.X = 0f;
            Projectile.velocity.Y = 0f;
            return false;
        }
    }
    public class DirectMine : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileType<Mine>());
            AIType = ProjectileType<Mine>();
            Projectile.penetrate = 3;
            Projectile.extraUpdates = 1; Projectile.GetGlobalProjectile<NewRockets>().IsARocket = true;

            ProjectileID.Sets.IsAMineThatDealsTripleDamageWhenStationary[Projectile.type] = true;
            Projectile.GetGlobalProjectile<ProjectileStats>().DirectDamage = 1.5f;
            Projectile.GetGlobalProjectile<ProjectileStats>().explodes = true;
            Projectile.GetGlobalProjectile<ProjectileStats>().dontExplodeOnTiles = true;
           Projectile.GetGlobalProjectile<ProjectileStats>().ExplosionRadius = 80;
            Projectile.GetGlobalProjectile<ProjectileStats>().ExplosionDamage = 0.67f;
            Projectile.GetGlobalProjectile<ProjectileStats>().UsesDefaultExplosion = true;
        }
        public override void AI()
        {
            Projectile.GetGlobalProjectile<NewMines>().MineAI(Projectile);
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.velocity.X = 0f;
            Projectile.velocity.Y = 0f;
            return false;
        }
    }
    public class MiniNukeMine : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileType<Mine>());
            AIType = ProjectileType<Mine>();
            ProjectileID.Sets.IsAMineThatDealsTripleDamageWhenStationary[Projectile.type] = true;
            Projectile.penetrate = 5;
            Projectile.GetGlobalProjectile<ProjectileStats>().explodes = true; Projectile.GetGlobalProjectile<ProjectileStats>().dontExplodeOnTiles = true;
            Projectile.GetGlobalProjectile<NewRockets>().IsARocket = true;

            Projectile.GetGlobalProjectile<ProjectileStats>().UsesDefaultExplosion = true;
            Projectile.GetGlobalProjectile<ProjectileStats>().ExplosionRadius = 250;
        }
      
        public override void AI()
        {
            Projectile.GetGlobalProjectile<NewMines>().MineAI(Projectile);
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.velocity.X = 0f;
            Projectile.velocity.Y = 0f;
            return false;
        }
    }
    public class DestructiveMiniNukeMine : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileType<Mine>());
            AIType = ProjectileType<Mine>();
            ProjectileID.Sets.IsAMineThatDealsTripleDamageWhenStationary[Projectile.type] = true;
            Projectile.penetrate = 5; Projectile.GetGlobalProjectile<ProjectileStats>().dontExplodeOnTiles = true;
            Projectile.GetGlobalProjectile<NewRockets>().IsARocket = true;

            Projectile.GetGlobalProjectile<ProjectileStats>().explodes = true;
            Projectile.GetGlobalProjectile<ProjectileStats>().ExplosionRadius = 250;
        }
 
        public override void AI()
        {
            Projectile.GetGlobalProjectile<NewMines>().MineAI(Projectile);
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.velocity.X = 0f;
            Projectile.velocity.Y = 0f;
            return false;
        }
        public override void Kill(int timeLeft)
        {
            TRAEMethods.DefaultExplosion(Projectile);
            Projectile.GetGlobalProjectile<NewRockets>().DestroyTiles(Projectile, 7);
        }
    }
    public class ClusterMine : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileType<Mine>());
            AIType = ProjectileType<Mine>();
            Projectile.penetrate = 3; Projectile.GetGlobalProjectile<ProjectileStats>().dontExplodeOnTiles = true;
            Projectile.GetGlobalProjectile<NewRockets>().IsARocket = true;

            Projectile.GetGlobalProjectile<ProjectileStats>().explodes = true;
            Projectile.GetGlobalProjectile<ProjectileStats>().ExplosionRadius = 120;
        }
        public override void AI()
        {
            Projectile.GetGlobalProjectile<NewMines>().MineAI(Projectile);
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.velocity.X = 0f;
            Projectile.velocity.Y = 0f;
            return false;
        }
        public override void Kill(int timeLeft)
        {
            Projectile.GetGlobalProjectile<NewRockets>().ClusterRocketExplosion(Projectile);
        }

    }
    public class HeavyMine : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileType<Mine>());
            AIType = ProjectileType<Mine>();
            Projectile.penetrate = 5; Projectile.GetGlobalProjectile<NewRockets>().IsARocket = true;

            Projectile.GetGlobalProjectile<NewRockets>().HeavyRocket = true;
            Projectile.GetGlobalProjectile<ProjectileStats>().explodes = true;
            Projectile.GetGlobalProjectile<ProjectileStats>().UsesDefaultExplosion = true;
            Projectile.GetGlobalProjectile<ProjectileStats>().dontExplodeOnTiles = true;

            Projectile.GetGlobalProjectile<ProjectileStats>().ExplosionRadius = 120;
        }
        public override void AI()
        {
            Projectile.GetGlobalProjectile<NewMines>().MineAI(Projectile);
        }   
		public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.velocity.X = 0f;
            Projectile.velocity.Y = 0f;
            return false;
        }
    }
}