using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TRAEProject.Changes.Weapon.Ranged.Rockets;
using TRAEProject.NewContent.Items.Summoner.AbsoluteZero;
using TRAEProject.NewContent.Items.FlamethrowerAmmo;
using static Terraria.ModLoader.ModContent;
using TRAEProject.NewContent.Items.Weapons.Launchers.CryoCannon;
using TRAEProject.Common;

namespace TRAEProject.Changes.Weapon
{
    public class FreezingProjectile : GlobalProjectile
    {
        public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
        {
            if (target.HasBuff(BuffType<AbsoluteZeroTag>()) && crit == true && projectile.minion)
            {
                target.GetGlobalNPC<Freeze>().FreezeMe(target, damage / 4);
            }
            if (projectile.GetGlobalProjectile<CryoRockets>().IceRocket && projectile.GetGlobalProjectile<NewRockets>().HeavyRocket == true)
            {
                target.GetGlobalNPC<Freeze>().FreezeMe(target, 240);
            }
            if (projectile.GetGlobalProjectile<CryoRockets>().IceRocket)
            {
                target.GetGlobalNPC<Freeze>().FreezeMe(target, 120);
            }
            if (projectile.type == ProjectileType<FrozenGelP>() && Main.rand.Next(10) == 0)
            {
                target.GetGlobalNPC<Freeze>().FreezeMe(target, damage / 3);
            }
            switch(projectile.type)
            {
                case ProjectileID.FrostBoltSword:
                    target.GetGlobalNPC<Freeze>().FreezeMe(target, 60);
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
                        target.GetGlobalNPC<Freeze>().FreezeMe(target, 90);
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
