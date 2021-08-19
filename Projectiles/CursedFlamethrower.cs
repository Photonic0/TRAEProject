using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace TRAEProject.Projectiles
{
    public class CursedFlamethrower : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("CursedFlamethrower");     //The English name of the Projectile
        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.EyeFire);
            AIType = ProjectileID.EyeFire;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.hostile = false;
            Projectile.friendly = true;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Projectile.damage -= (int)(Projectile.damage * 0.1);
        }
        public override void AI()
        {
            Projectile.localAI[0] += 1f;
            if (Projectile.localAI[0] > 9f)
            {
                for (int i = 0; i < 4; i++)
                {
                    Vector2 ProjectilePosition = Projectile.position;
                    ProjectilePosition -= Projectile.velocity * (i * 0.25f);
                    Projectile.alpha = 255;
                    // Important, changed 173 to 178!
                    int dust = Dust.NewDust(ProjectilePosition, 1, 1, 75, 0f, 0f, 0, default(Color), 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].position = ProjectilePosition;
                    Main.dust[dust].scale = Main.rand.Next(70, 110) * 0.013f;
                    Main.dust[dust].velocity *= 0.2f;
                }
            }
        }
    }
}

