using Microsoft.Xna.Framework;
using TRAEProject.NewContent.Items.Accesories.MechanicalEye;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TRAEProject.Common.ModPlayers;
using TRAEProject.Changes.Weapon.Ranged.Rockets;
using TRAEProject.Common;
namespace TRAEProject.Changes.Accesory
{
    public class AccessoryStats : GlobalItem
    {
        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            if (item.type == ItemID.MagicQuiver)
            {
                player.magicQuiver = false; 
                player.arrowDamage -= 0.091f;
                player.GetModPlayer<RangedStats>().Magicquiver += 1;
            }
            if (item.type == ItemID.MoltenQuiver)
            {
                player.magicQuiver = false; 
                player.arrowDamage -= 0.091f;
                player.GetModPlayer<RangedStats>().Magicquiver += 1;
                player.GetModPlayer<CritDamage>().arrowCritDamage += 0.2f;
            }
            if (item.type == ItemID.StalkersQuiver)
            {
                player.magicQuiver = false;
                player.arrowDamage -= 0.091f;
                player.GetModPlayer<RangedStats>().Magicquiver += 1;
                player.GetDamage<RangedDamageClass>() += 0.05f;
                player.GetCritChance<RangedDamageClass>() += 5;
            }
            if (item.type == ItemID.ReconScope)
            {
                player.GetModPlayer<RangedStats>().rangedVelocity += 0.5f;
                player.GetModPlayer<RangedStats>().ReconScope += 1;
                player.GetDamage<RangedDamageClass>() -= 0.1f;

                player.GetCritChance<RangedDamageClass>() -= 10;
            }
        }
    }
    public class ScopeAndQuiver : GlobalProjectile
    {

        public override bool InstancePerEntity => true;

        public int smartbounces = 0;
        public bool hasBounced = false;
        public bool stunOnCrit = false;
        public bool otherAmmo = false;
        public bool AffectedByAlphaScope = false;
        public bool AffectedByReconScope = false;
        public float timer = 0;
        public override void SetDefaults(Projectile projectile)
        {
            switch (projectile.type)
            {
                case ProjectileID.PulseBolt:
                case ProjectileID.Stake:
                case ProjectileID.Hellwing:
                    projectile.arrow = true;
                    return;
                case ProjectileID.Bullet:
                case ProjectileID.MeteorShot:
                case ProjectileID.CrystalBullet:
                case ProjectileID.CrystalShard:
                case ProjectileID.CursedBullet:
                case ProjectileID.IchorBullet:
                case ProjectileID.BulletHighVelocity:
                case ProjectileID.ExplosiveBullet:
                case ProjectileID.GoldenBullet:
                case ProjectileID.PartyBullet:
                case ProjectileID.VenomBullet:
                case ProjectileID.ChlorophyteBullet:
                case ProjectileID.NanoBullet:
                case ProjectileID.MoonlordBullet:
                    AffectedByReconScope = true; 
                    AffectedByAlphaScope = false;
                    break;
            }
            if (projectile.arrow)
            {
                AffectedByReconScope = true; 
                AffectedByAlphaScope = true;
            }
            if (projectile.GetGlobalProjectile<NewRockets>().IsARocket)
            {
                AffectedByAlphaScope = true;
            }
            if (AffectedByReconScope)
            {
                AffectedByAlphaScope = true;
            }
        }
        public override void AI(Projectile projectile)
        {
            Player player = Main.player[projectile.owner];
            if (!projectile.GetGlobalProjectile<NewRockets>().IsARocket)
            {
                if (projectile.arrow && smartbounces < player.GetModPlayer<RangedStats>().Magicquiver + player.GetModPlayer<RangedStats>().ReconScope && !hasBounced)
                {
                    smartbounces += player.GetModPlayer<RangedStats>().Magicquiver;
                    smartbounces += player.GetModPlayer<RangedStats>().ReconScope;
                }
                if (projectile.CountsAsClass(DamageClass.Ranged) && AffectedByReconScope && smartbounces < player.GetModPlayer<RangedStats>().ReconScope && !hasBounced)
                {
                    smartbounces += player.GetModPlayer<RangedStats>().ReconScope;
                }
                if (projectile.CountsAsClass(DamageClass.Ranged) && AffectedByAlphaScope && smartbounces < player.GetModPlayer<RangedStats>().AlphaScope && !hasBounced)
                {
                    smartbounces += player.GetModPlayer<RangedStats>().AlphaScope;
                }
            }
        }
        public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
        {
            if (smartbounces > 0 && projectile.penetrate > 1)
            {
                QuiverBounce(projectile);
            }
        }        
        public override bool OnTileCollide(Projectile projectile, Vector2 oldVelocity)
        {
            Player player = Main.player[projectile.owner];
            if (smartbounces > 0)
            {                
                int[] array = new int[10];
                int num6 = 0;
                int Range = 500;
                int num8 = 20;
                for (int j = 0; j < 200; j++)
                {
                    if (Main.npc[j].CanBeChasedBy(this, false) && projectile.localNPCImmunity[j] != 1)
                    {
                        float DistanceBetweenProjectileAndEnemy = (projectile.Center - Main.npc[j].Center).Length();
                        if (DistanceBetweenProjectileAndEnemy > num8 && DistanceBetweenProjectileAndEnemy < Range && Collision.CanHitLine(projectile.Center, 1, 1, Main.npc[j].Center, 1, 1))
                        {
                            array[num6] = j;
                            num6++;
                            if (num6 >= 9)
                            {
                                break;
                            }
                        }
                    }
                }
                if (num6 > 0)
                {
                    num6 = Main.rand.Next(num6);
                    Vector2 value2 = Main.npc[array[num6]].Center - projectile.Center;
                    float scaleFactor2 = projectile.velocity.Length();
                    value2.Normalize();
                    projectile.velocity = value2 * scaleFactor2;
                    projectile.netUpdate = true;
                    projectile.damage = (int)(projectile.damage * 0.5);
                    --smartbounces;
                    hasBounced = true;
                    for (int i = 0; i < 20; ++i)
                    {
                        Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, DustID.UndergroundHallowedEnemies, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f, 150, default, 1.5f);
                        dust.noGravity = true;
                    }                
					return false;

                }
            }
			return true;
        }
        void QuiverBounce(Projectile projectile)
        {
            Player player = Main.player[projectile.owner];
            int[] array = new int[10];
            int num6 = 0;
            int Range = 700;
            int num8 = 20;
            for (int j = 0; j < 200; j++)
            {
                if (Main.npc[j].CanBeChasedBy(this, false) && projectile.localNPCImmunity[j] != 1)
                {
                    float DistanceBetweenProjectileAndEnemy = (projectile.Center - Main.npc[j].Center).Length();
                    if (DistanceBetweenProjectileAndEnemy > num8 && DistanceBetweenProjectileAndEnemy < Range && Collision.CanHitLine(projectile.Center, 1, 1, Main.npc[j].Center, 1, 1))
                    {
                        array[num6] = j;
                        num6++;
                        if (num6 >= 9)
                        {
                            break;
                        }
                    }
                }
            }
            if (num6 > 0)
            {
                num6 = Main.rand.Next(num6);
                Vector2 value2 = Main.npc[array[num6]].Center - projectile.Center;
                float scaleFactor2 = projectile.velocity.Length();
                value2.Normalize();
                projectile.velocity = value2 * scaleFactor2;
                projectile.netUpdate = true;
                projectile.damage = (int)(projectile.damage * 0.5);
                --smartbounces;
                hasBounced = true;
                for (int i = 0; i < 30; ++i)
                {
                    Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, DustID.UndergroundHallowedEnemies, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f, 150, default, 1.5f);
                    dust.noGravity = true;
                }
            }
        }
    }
}
