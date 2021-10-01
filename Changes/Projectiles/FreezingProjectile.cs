using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TRAEProject.Items.Summoner.AbsoluteZero;
using TRAEProject.Common.GlobalNPCs;
using TRAEProject.Items.FlamethrowerAmmo;
using static Terraria.ModLoader.ModContent;

namespace TRAEProject.Changes.Projectiles
{
    public class FreezingProjectile : GlobalProjectile
    {
        public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
        {
            if (target.HasBuff(BuffType<AbsoluteZeroTag>()) && crit == true && projectile.minion)
            {
                target.GetGlobalNPC<Freeze>().FreezeMe(target, damage / 4);
            }
            if (projectile.type == ProjectileType<FrozenGelP>())
            {
                target.GetGlobalNPC<Freeze>().FreezeMe(target, damage / 4);
            }
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
