using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent.Creative;
using TRAEProject.NewContent.Items.Materials;
using System;

namespace TRAEProject.NewContent.Items.Weapons.Ammo
{
    public class ChargedBullet: ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Charged Bullet");
            Tooltip.SetDefault("Shocks enemies around it, dealing 33% damage");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }
        public override void SetDefaults()
        {
            Item.damage = 11;
            Item.DamageType = DamageClass.Ranged;
            Item.knockBack = 2;
            Item.value = Item.sellPrice(0, 0, 0, 20);
            Item.rare = ItemRarityID.Yellow;
            Item.width = 12;
            Item.height = 15;
            Item.shootSpeed = 4;
            Item.consumable = true;
            Item.shoot = ProjectileType<ChargedBulletShot>();
            Item.ammo = AmmoID.Bullet;
            Item.maxStack = 9999;
        }

        public override void AddRecipes()
        {
            CreateRecipe(500).AddIngredient(ItemID.EmptyBullet, 500)
                .AddIngredient(ItemType<GraniteBattery>(), 1)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }

    public class ChargedBulletShot: ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("ChargedSHot");     //The English name of the Projectile

        }
        public override void SetDefaults()
        {
            AIType = ProjectileID.Bullet;
            Projectile.CloneDefaults(ProjectileID.Bullet);
            Projectile.timeLeft = 600;
            Projectile.extraUpdates = 2;
            Projectile.ignoreWater = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.hostile = false;
            Projectile.friendly = true;
        }
        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);;
            int Range = 125;
            Projectile.localAI[1]++;
            if (Projectile.localAI[1] > 4 && Projectile.localAI[1] % 2 == 0)
            {
                int dust = Dust.NewDust(Projectile.position, 1, 1, DustID.Electric, Projectile.velocity.X, Projectile.velocity.Y, 0, default, 1f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 0.2f;
                Projectile.localAI[1] = 4;
            }
            if (Projectile.localAI[0] < 15)
            {
                Projectile.localAI[0]++;
            }
            if (Projectile.localAI[0] >= 15)
            {
                for (int k = 0; k < 200; k++)
                {
                    NPC nPC = Main.npc[k];
                    if (nPC.active && !nPC.friendly && nPC.damage > 0 && !nPC.dontTakeDamage && Vector2.Distance(Projectile.Center, nPC.Center) <= Range)
                    {
                        Projectile.localAI[0] = 0;
                        float shootToX = nPC.position.X + nPC.width * 0.5f - Projectile.Center.X;
                        float shootToY = nPC.position.Y + nPC.height * 0.5f - Projectile.Center.Y;
                        float distance2 = (float)Math.Sqrt((shootToX * shootToX + shootToY * shootToY));//Dividing the factor of 2f which is the desired velocity by distance2
                        distance2 = 1f / distance2;

                        //Multiplying the shoot trajectory with distance2 times a multiplier if you so choose to
                        shootToX *= distance2 * 10f;
                        shootToY *= distance2 * 10f;
                        Vector2 perturbedSpeed = new Vector2(shootToX, shootToY).RotatedByRandom(MathHelper.ToRadians(0));
                        Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileType<ChargedBulletBolt>(), Projectile.damage / 3, Projectile.knockBack, Projectile.owner);
                        
                        break;
                    }
                }

            }

        }
        public override void Kill(int timeLeft)
        {
            Terraria.Audio.SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
            for (int i = 0; i < 5; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.oldPosition, Projectile.width, Projectile.height, DustID.Electric, 1f);
                dust.noGravity = true;
            }
        }
    }

    public class ChargedBulletBolt : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Charged Bullet Bolt");
        }
        public override void SetDefaults()
        {
            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.friendly = true;
            Projectile.extraUpdates = 100;
            Projectile.timeLeft = 50;
            Projectile.penetrate = 1;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.alpha = 255;
        }
        public override void AI()
        {
            Projectile.tileCollide = true;

                Vector2 ProjectilePosition = Projectile.position;
                Projectile.alpha = 255;
                int dust = Dust.NewDust(ProjectilePosition, 1, 1, DustID.Electric, 0f, 0f, 0, default, 1f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].position = ProjectilePosition;
                Main.dust[dust].velocity *= 0.2f;
            

        }
    }

}


