using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TRAEProject.Changes.Dreadnautilus
{
    public class BloodShot : GlobalProjectile
    {
        public override void SetDefaults(Projectile projectile)
        {
            if (projectile.type == ProjectileID.BloodNautilusShot || projectile.type == ProjectileID.BloodShot)
            {
                projectile.ignoreWater = true;
                projectile.tileCollide = false;
                projectile.timeLeft = 60 * 5;
            }
        }
        public override void AI(Projectile projectile)
        {
            if (projectile.type == ProjectileID.BloodNautilusShot)
            {
                projectile.ai[0] -= 0.5f;
            }
        }
        public override bool PreDraw(Projectile projectile, ref Color lightColor)
        {
            if(projectile.type == ProjectileID.BloodNautilusShot || projectile.type == ProjectileID.BloodShot)
            {
                lightColor = Color.White;
            }
            return base.PreDraw(projectile, ref lightColor);
        }
        public override void ModifyHitPlayer(Projectile projectile, Player target, ref int damage, ref bool crit)
        {
            if(projectile.type == ProjectileID.BloodShot && NPC.AnyNPCs(NPCID.BloodSquid))
            {
                damage = (int)(damage * 0.6f);
            }
        }
    }
}
