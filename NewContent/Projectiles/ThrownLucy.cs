using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TRAEProject.Common;
namespace TRAEProject.NewContent.Projectiles
{
    public class ThrownLucy : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("ThrownLucy");     //The English name of the Projectile
        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.CombatWrench);           //The width of Projectile hitbox
            AIType = ProjectileID.CombatWrench;
            Projectile.width = 42;
            Projectile.height = 34;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.extraUpdates = 1;

            //Projectile.usesLocalNPCImmunity = true;
            //Projectile.localNPCHitCooldown = 10;
            Projectile.penetrate = 2;
        }
        public class AutoThrowLucy : ModPlayer
        {
            public override void PostUpdateEquips()
            {
                if (Player.HeldItem.type == ItemID.LucyTheAxe)
                {
                    Player.autoReuseGlove = false;
                }
            }
            public override void PostItemCheck()
            {
       
                if (Player.HeldItem.type == ItemID.LucyTheAxe)
                {
                   
                    if (Main.mouseRight && Player.ownedProjectileCounts[Player.HeldItem.shoot] == 0 && Player.itemTime == 0)
                    {
                        Player.altFunctionUse = 2;
                        Player.itemAnimationMax = Player.itemAnimation = Player.HeldItem.useAnimation;

                    }
                }
                return;
            }
        }
    }
}