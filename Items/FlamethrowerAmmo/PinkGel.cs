using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
namespace TRAEProject.Items.FlamethrowerAmmo
{
    public class PinkGel : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            if (item.type == ItemID.PinkGel)
            {
                item.damage = 10;
                item.DamageType = DamageClass.Ranged;
                item.knockBack = 1f;
                item.consumable = true;
                item.shoot = ProjectileType<PinkGelP>();
                item.ammo = AmmoID.Gel;
                item.maxStack = 3000;
            }    
        }
    }
    public class PinkGelP : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("PinkFlamethrower");     //The English name of the Projectile
        
            }
            public override string Texture => "Terraria/Images/Item_0";
        public override void SetDefaults()
        {
            Projectile.width = 6;
            Projectile.height = 6;
            Projectile.alpha = 255;
            Projectile.penetrate = 3;
            Projectile.extraUpdates = 2; Projectile.timeLeft = 60;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.hostile = false;
            Projectile.friendly = true;            Projectile.usesLocalNPCImmunity = true;
Projectile.GetGlobalProjectile<TRAEGlobalProjectile>().dontHitTheSameEnemyMultipleTimes = true;
            Projectile.GetGlobalProjectile<TRAEGlobalProjectile>().BouncesOffTiles = true;
            Projectile.GetGlobalProjectile<TRAEGlobalProjectile>().AddsBuff = BuffID.OnFire;
            Projectile.GetGlobalProjectile<TRAEGlobalProjectile>().AddsBuffDuration = 300;
            Projectile.GetGlobalProjectile<TRAEGlobalProjectile>().DamageFalloff = 0.15f;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return false;
        }
        public override void AI()
        {
            float dustScale = 1f;
            if (Projectile.ai[0] == 0f)
                dustScale = 0.25f;
            else if (Projectile.ai[0] == 1f)
                dustScale = 0.5f;
            else if (Projectile.ai[0] == 2f)
                dustScale = 0.75f;
            else if (Projectile.ai[0] > 2f)
                Projectile.ai[0] = 0f;
            if (Main.rand.Next(2) == 0)
            {
                for (int i = 0; i < 2; ++i)
                {
                    Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.PinkTorch, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100);

                    // Some dust will be large, the others small and with gravity, to give visual variety.
                    if (Main.rand.NextBool(3))
                    {
                        dust.noGravity = true;
                        dust.scale *= 3f;
                        dust.velocity.X *= 2f;
                        dust.velocity.Y *= 2f;
                    }

                    dust.scale *= 1.5f;
                    dust.velocity *= 1.2f;
                    dust.scale *= dustScale;
                }
            }
            Projectile.ai[0] += 1f;
        }
        public override void ModifyDamageHitbox(ref Rectangle hitbox)
        {
            int size = 30;
            hitbox.X -= size;
            hitbox.Y -= size;
            hitbox.Width += size * 2;
            hitbox.Height += size * 2;
        }
    }
}


