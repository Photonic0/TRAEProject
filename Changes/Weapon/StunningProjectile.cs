using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TRAEProject.Changes.Weapon.Ranged.Rockets;
using TRAEProject.NewContent.Items.Weapons.Launchers.CryoCannon;
using TRAEProject.Common;
using static Terraria.ModLoader.ModContent;
namespace TRAEProject.Changes.Weapon
{
    public class StunningProjectile : GlobalProjectile
    {
        public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
        {
            if (projectile.GetGlobalProjectile<CryoRockets>().IceRocket && projectile.GetGlobalProjectile<NewRockets>().HeavyRocket == true)
            {
                target.GetGlobalNPC<Stun>().StunMe(target, 240);
            }
            if (projectile.GetGlobalProjectile<NewRockets>().HeavyRocket == true)
            {
                target.GetGlobalNPC<Stun>().StunMe(target, 120);
            }
            switch(projectile.type)
            {
                case ProjectileID.TheDaoofPow:
                    if (Main.rand.Next(3) == 0)
                    { 
                        target.GetGlobalNPC<Stun>().StunMe(target, 60); 
                    }
                
                    break;
            }
        }
    }
}
