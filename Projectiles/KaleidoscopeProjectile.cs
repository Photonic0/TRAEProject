using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace TRAEProject.Projectiles
{
    public class KaleidoscopeProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Totally Not Nightglow's projectile dealing summoner damage");   
        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.FairyQueenMagicItemShot);
            AIType = ProjectileID.FairyQueenMagicItemShot;
            Projectile.DamageType = DamageClass.Summon;
        }
    }
}

