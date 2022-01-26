using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TRAEProject.Changes.Weapon.Ranged.Rockets;
using TRAEProject.Common;
using static Terraria.ModLoader.ModContent;
namespace TRAEProject.Changes.Weapon
{
    public class StunningProjectile : GlobalProjectile
    {
        public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
        {
            if (projectile.GetGlobalProjectile<NewRockets>().HeavyRocket == true)
            {
                target.GetGlobalNPC<Stun>().StunMe(target, 60);
            }
            switch(projectile.type)
            {
                case ProjectileID.TheDaoofPow:
                    target.GetGlobalNPC<Stun>().StunMe(target, 90);
                    break;
            }
        }
    }
}
