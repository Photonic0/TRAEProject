
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent.Creative;
using TRAEProject.Common;
namespace TRAEProject.NewContent.Items.FlamethrowerAmmo
{
    public class CursedGel : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Cursed Gel");
            ////Tooltip.SetDefault("Flames seek out their targets");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.damage = 20;
            Item.DamageType = DamageClass.Ranged;
            Item.knockBack = 2;
            Item.value = Item.sellPrice(0, 0, 0, 10);
            Item.rare = ItemRarityID.Pink;
            Item.width = 22;
            Item.height = 18;
            Item.shootSpeed = 1;
            Item.consumable = true;
            Item.shoot = ProjectileType<CursedGelP>();
            Item.ammo = AmmoID.Gel;
            Item.maxStack = 9999;
        }

        public override void AddRecipes()
        {
            CreateRecipe(100).AddIngredient(ItemID.CursedFlame)
                .AddIngredient(ItemID.Gel, 20)
                .AddTile(TileID.Solidifier)
                .Register();
        }
    }
    public class CursedGelP : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("CursedFlamethrower");     //The English name of the Projectile

        }
        public override string Texture => "Terraria/Images/Item_0";
        public override void SetDefaults()
        {

            Projectile.width = 6;
            Projectile.height = 6;
            Projectile.alpha = 255;
            Projectile.penetrate = 3;
            Projectile.extraUpdates = 2;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.hostile = false;
            Projectile.friendly = true; 
            Projectile.timeLeft = 60;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.GetGlobalProjectile<ProjectileStats>().homesIn = true;
            Projectile.GetGlobalProjectile<ProjectileStats>().dontHitTheSameEnemyMultipleTimes = true;
            Projectile.GetGlobalProjectile<ProjectileStats>().AddsBuff = BuffID.CursedInferno;
            Projectile.GetGlobalProjectile<ProjectileStats>().AddsBuffDuration = 240;
            Projectile.GetGlobalProjectile<ProjectileStats>().DamageFalloff = 0.1f;
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
                    Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.CursedTorch, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100);

                    // Some dust will be large, the others small and with gravity, to give visual variety.
                    if (Main.rand.NextBool(4))
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



