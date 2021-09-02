using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TRAEProject.Common.GlobalNPCs;

namespace TRAEProject.Changes.Projectiles
{
    public class FreezingProjectile : GlobalProjectile
    {
        public override void OnHitNPC(Terraria.Projectile projectile, NPC target, int damage, float knockback, bool crit)
        {
            switch(projectile.type)
            {
                case ProjectileID.FrostBoltSword:
                    target.GetGlobalNPC<Freeze>().FreezeMe(target, 180);
                    break;
                case ProjectileID.BallofFrost:
                    target.GetGlobalNPC<Freeze>().FreezeMe(target, 60);
                    break;
                case ProjectileID.FrostArrow:
                    target.GetGlobalNPC<Freeze>().FreezeMe(target, 60);
                    break;
                case ProjectileID.IceBoomerang:
                    if (Main.rand.Next(4) == 0)
                    {
                        target.GetGlobalNPC<Freeze>().FreezeMe(target, 120);
                    }
                    break;
                case ProjectileID.FrostBoltStaff:
                    if (Main.rand.Next(3) == 0)
                    {
                        target.GetGlobalNPC<Freeze>().FreezeMe(target, 90);
                    }
                    break;

            }
        }
    }
}
