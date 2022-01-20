using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace TRAEProject.NewContent.Projectiles
{
    public class BigBubble : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("BigBubble");     //The English name of the projectile
        }
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.Bubble);           //The width of projectile hitbox
            Projectile.aiStyle = 95;
            Projectile.scale = 0.8f;
            Projectile.timeLeft = 60;
        }
        //public override void AI()
        //{
        //    projectile.velocity *= 1.01f;
        //}
    }
}
    


