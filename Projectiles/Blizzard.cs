using Microsoft.Xna.Framework;
using TRAEProject;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TRAEProject.Projectiles
{
    class Blizzard : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 1;
            Projectile.height = 1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.timeLeft = 600;
            Projectile.alpha = 255;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;

        }
        public virtual bool? CanHitNPC(Projectile projectile, NPC target)
        {
            return false;
        }
        // Note, this Texture is actually just a blank texture, FYI.

        readonly int fireRate = 10;
        readonly int[] offSetCenter = {3, 4, 5};
        readonly int projectilesPerShot = 4;
        readonly int projectileType = ProjectileID.Blizzard;
        readonly float velocity = 10;
        readonly int SpreadX = 300;
        readonly int SpreadY = 800;
        public override void AI()
        {
            Projectile.localAI[0] += 1f;
            if (Projectile.localAI[0] > fireRate)
            {
                Projectile.localAI[0] -= fireRate;
                TRAEMethods.SpawnProjectilesFromAbove(Projectile.GetProjectileSource_FromThis(), Projectile.position, projectilesPerShot, SpreadX, SpreadY, offSetCenter, velocity, projectileType, Projectile.damage, Projectile.knockBack, Projectile.owner);
            }
        }
    }
}