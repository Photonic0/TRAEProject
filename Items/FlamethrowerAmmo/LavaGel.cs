
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent.Creative;
namespace TRAEProject.Items.FlamethrowerAmmo
{
    public class LavaGel : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lava Gel");
            Tooltip.SetDefault("Ignite it to know what real fire is!");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.damage = 18;
            Item.DamageType = DamageClass.Ranged;
            Item.knockBack = 4f;
            Item.value = Item.sellPrice(0, 0, 0, 5);
            Item.rare = ItemRarityID.Orange;
            Item.width = 22;
            Item.height = 18;
            Item.shootSpeed = 6;
            Item.consumable = true;
            Item.shoot = ProjectileType<LavaGelP>();
            Item.ammo = AmmoID.Gel;
            Item.maxStack = 3000;
        }
        public override void AddRecipes()
        {
            CreateRecipe(50).AddIngredient(ItemID.Hellstone)
                .AddIngredient(ItemID.Gel, 20)
                .AddTile(TileID.Hellforge)
                .Register();
        } 
    }
        public class LavaGelP : ModProjectile
        {
            public override void SetStaticDefaults()
            {
                DisplayName.SetDefault("Lavaflamethrower");     //The English name of the Projectile

            }
            public override string Texture => "Terraria/Images/Item_0";
            public override void SetDefaults()
            {
            Projectile.width = 6;
            Projectile.height = 6;
            Projectile.alpha = 255;
            Projectile.timeLeft = 60;
            Projectile.penetrate = 3;
            Projectile.DamageType = DamageClass.Ranged;            Projectile.usesLocalNPCImmunity = true;
Projectile.GetGlobalProjectile<TRAEGlobalProjectile>().dontHitTheSameEnemyMultipleTimes = true;
                Projectile.hostile = false;
                Projectile.friendly = true;
                Projectile.extraUpdates = 3;
                Projectile.GetGlobalProjectile<TRAEGlobalProjectile>().AddsBuff = BuffID.OnFire3;
                Projectile.GetGlobalProjectile<TRAEGlobalProjectile>().AddsBuffDuration = 90;
                Projectile.GetGlobalProjectile<TRAEGlobalProjectile>().DamageFalloff = 0.15f;
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

            if (Main.rand.Next(2) == 0)
            {
                for (int i = 0; i < 2; ++i)
                {
                    Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100);

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
    }
}




