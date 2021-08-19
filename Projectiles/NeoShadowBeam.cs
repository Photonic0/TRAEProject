using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TRAEProject.Projectiles
{  
    class NeoShadowBeam : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 4;
            Projectile.height = 4;
            // NO! Projectile.aiStyle = 48;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.extraUpdates = 100;
            Projectile.timeLeft = 300; // lowered from 300
            Projectile.alpha = 255;
            Projectile.penetrate = -1;
        }        
        int limit = 6;
        int BeamColor = 65;
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            limit -= 1;
            if (limit >= 5)
            {
                Projectile.damage *= 2;
                BeamColor = 173;
            }
            if (limit >= 0)
            {
                Projectile.damage += (int)(Projectile.damage * 0.15);
            }
            if (limit <= 0)
            {
                BeamColor = 205;
            }
            if (Projectile.velocity.X != oldVelocity.X)
            {
                Projectile.position.X = Projectile.position.X + Projectile.velocity.X;
                Projectile.velocity.X = -oldVelocity.X;
            }
            if (Projectile.velocity.Y != oldVelocity.Y)
            {
                Projectile.position.Y = Projectile.position.Y + Projectile.velocity.Y;
                Projectile.velocity.Y = -oldVelocity.Y;
            }
            return false; // return false because we are handling collision
        }
        public override void AI()
        {
            Projectile.localAI[0] += 1f;
            if (Projectile.localAI[0] > 9f)
            {
                for (int i = 0; i < 1; i++)
                {
                    Vector2 ProjectilePosition = Projectile.position;
                    ProjectilePosition -= Projectile.velocity * (i * 0.25f);
                    Projectile.alpha = 255;
                    int dust = Dust.NewDust(ProjectilePosition, 1, 1, BeamColor, 0f, 0f, 0, default, 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].position = ProjectilePosition;
                    Main.dust[dust].scale = Main.rand.Next(70, 100) * 0.010f;
                    Main.dust[dust].velocity *= 0.2f;
                }
            }
        }
    }
}