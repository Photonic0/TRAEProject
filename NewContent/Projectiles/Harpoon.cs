using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria;
namespace TRAEProject.NewContent.Projectiles
{
    public class Harpoon : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Harpoon");     
        }
        public override void SetDefaults()
        {
            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.scale = 1.15f;
            Projectile.aiStyle = 1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 180;
            Projectile.tileCollide = true;
            Projectile.extraUpdates = 0;
        }

        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);
        }
    } 
}