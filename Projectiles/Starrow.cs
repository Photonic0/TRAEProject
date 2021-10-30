using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TRAEProject.Changes.Projectiles;
namespace TRAEProject.Projectiles
{
    public class Starrow: ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Starrow");     //The English name of the Projectile
        }

        public override void SetDefaults()
        {
            Projectile.width = 18;            
            Projectile.height = 32;
            Projectile.scale = 1f;
            Projectile.aiStyle = 1;
            Projectile.friendly = true;        
            Projectile.DamageType = DamageClass.Ranged;
            AIType = ProjectileID.HolyArrow;
            //Projectile.usesLocalNPCImmunity = true;
            //Projectile.localNPCHitCooldown = 10;
            Projectile.penetrate = 2;          
            Projectile.timeLeft = 120;                  
            Projectile.tileCollide = false;       
            Projectile.extraUpdates = 0;
            Projectile.GetGlobalProjectile<TRAEGlobalProjectile>().goThroughWallsUntilReachingThePlayer = true;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Projectile.damage -= (int)(Projectile.damage * 0.25); 
        }
    }
}