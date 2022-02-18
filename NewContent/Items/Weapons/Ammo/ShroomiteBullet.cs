using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent.Creative;
using TRAEProject.Common;
using TRAEProject.NewContent.TRAEDebuffs;

namespace TRAEProject.NewContent.Items.Weapons.Ammo
{
    public class ShroomiteBullet: ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shroomite Bullet");
            Tooltip.SetDefault("Critical hits very briefly make enemies 5% more vulnerable to all damage\nStacks up to +35%, with the duration of the stack being 0.03 seconds for every 1 damage");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }
        public override void SetDefaults()
        {
            Item.damage = 15;
            Item.DamageType = DamageClass.Ranged;
            Item.knockBack = 3;
            Item.value = Item.sellPrice(0, 0, 0, 20);
            Item.rare = ItemRarityID.Yellow;
            Item.width = 12;
            Item.height = 15;
            Item.shootSpeed = 6;
            Item.consumable = true;
            Item.shoot = ProjectileType<ShroomiteShot>();
            Item.ammo = AmmoID.Bullet;
            Item.maxStack = 9999;
        }

        public override void AddRecipes()
        {
            CreateRecipe(100).AddIngredient(ItemID.MusketBall, 100)
                .AddIngredient(ItemID.ShroomiteBar, 1)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }

    public class ShroomiteShot: ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("ShroomitSHot");     //The English name of the Projectile

        }
        public override void SetDefaults()
        {
            AIType = ProjectileID.Bullet;
            Projectile.CloneDefaults(ProjectileID.Bullet);
            Projectile.timeLeft = 1200;
            Projectile.penetrate = 1;
            Projectile.extraUpdates = 2;
            Projectile.ignoreWater = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.hostile = false;
            Projectile.friendly = true;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (crit)
            { 
                 TRAEDebuff.Apply<ShroomBonus>(target, damage * 2, 6);
            }
        }
        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);
            Lighting.AddLight(Projectile.Center, 0f, 0f, 0.4f);
        }
        public override void Kill(int timeLeft)
        {
            Terraria.Audio.SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
        }
    }
}


