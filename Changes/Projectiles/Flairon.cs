using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TRAEProject.Common.AIs;

namespace TRAEProject.Changes.Projectiles
{
    public class Flairon : GlobalProjectile
    {
        public override void SetDefaults(Terraria.Projectile projectile)
        {
            if(projectile.type == ProjectileID.Flairon)
            {
                projectile.usesLocalNPCImmunity = true;
                projectile.penetrate = -1;
                projectile.aiStyle = -1;
            }
        }
        public override void ModifyHitNPC(Projectile projectile, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if(projectile.type == ProjectileID.Flairon)
            {
                HeavyFlail.ModifyDamage(projectile, ref damage);
            }
        }
        public override bool PreAI(Terraria.Projectile projectile)
        {
            if(projectile.type == ProjectileID.Flairon)
            {
                HeavyFlail.AI(projectile, 20, 25, 30, 30, 15);
                Player player = Main.player[projectile.owner];
                projectile.rotation = (player.Center - projectile.Center).ToRotation() - (float)Math.PI / 2;

                projectile.ai[1]++;
                if (projectile.ai[1] > 5f)
                {
                    projectile.alpha = 0;
                }
                if ((int)projectile.ai[1] % 4 == 0 && projectile.owner == Main.myPlayer)
                {
                    Vector2 spinningpoint3 = (Main.player[projectile.owner].Center - projectile.Center) * -1f;
                    spinningpoint3.Normalize();
                    spinningpoint3 *= (float)Main.rand.Next(45, 65) * 0.1f;
                    spinningpoint3 = spinningpoint3.RotatedBy((Main.rand.NextDouble() - 0.5) * 1.5707963705062866);
                    Projectile.NewProjectile(projectile.GetProjectileSource_FromThis(), projectile.Center.X, projectile.Center.Y, spinningpoint3.X, spinningpoint3.Y, 405, projectile.damage/2, projectile.knockBack, projectile.owner, -10f);
                }
            }
            return base.PreAI(projectile);
        }
        public override bool OnTileCollide(Projectile projectile, Vector2 oldVelocity)
        {
            if(projectile.type == ProjectileID.Flairon)
            {
                return HeavyFlail.OnTileCollide(projectile, oldVelocity);
            }
            return base.OnTileCollide(projectile, oldVelocity);
        }

    }
}
