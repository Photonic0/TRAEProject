using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace TRAEProject.Projectiles
{
    public class Ichorthrower : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ichorthrower");     //The English name of the Projectile
        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.GoldenShowerFriendly);
            AIType = ProjectileID.GoldenShowerFriendly;
            Projectile.DamageType = DamageClass.Ranged;
        }
    }
}

