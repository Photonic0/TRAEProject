
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent.Creative;
using TRAEProject.Items.Materials;
namespace TRAEProject.Items.FlamethrowerAmmo
{
    public class FrozenGel : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Glacial Gel");
            Tooltip.SetDefault("Create the coldest flames");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.damage = 20;
            Item.DamageType = DamageClass.Ranged;
            Item.knockBack = 0.5f;
            Item.value = Item.sellPrice(0, 0, 10, 0);
            Item.rare = ItemRarityID.Pink;
            Item.width = 24;
            Item.height = 24;
            Item.shootSpeed = 1;
            Item.consumable = true;
            Item.shoot = ProjectileType<FrozenGelP>();
            Item.ammo = AmmoID.Gel;
            Item.maxStack = 3000;
        }

        public override void AddRecipes()
        {
            CreateRecipe(200).AddIngredient(ItemType<IceQueenJewel>())
                .AddIngredient(ItemID.Gel, 10)
                .AddTile(TileID.Solidifier)
                .Register();
        }
    }

    public class FrozenGelP : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("GlacialFlamethrower");     //The English name of the Projectile

        }
        public override string Texture => "Terraria/Images/Item_0";
        public override void SetDefaults()
        {
            Projectile.timeLeft = 60;
            Projectile.width = 6;
            Projectile.height = 6;
            Projectile.alpha = 255;
            Projectile.penetrate = 3;
            Projectile.extraUpdates = 2;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.hostile = false;
            Projectile.friendly = true;
			Projectile.tileCollide = false;
            Projectile.GetGlobalProjectile<TRAEGlobalProjectile>().DamageFalloff = 0.2f;
        }
        public override void AI()
        {
            Projectile.position.X += Projectile.width / 2;
            Projectile.position.Y += Projectile.height / 2;
            Projectile.width = Projectile.height += 2;
            Projectile.position.X -= Projectile.width / 2;
            Projectile.position.Y -= Projectile.height / 2;
            Projectile.position.X += Projectile.width / 2;
            Projectile.position.Y += Projectile.height / 2;
            Projectile.width = Projectile.height += 2;
            Projectile.position.X -= (Projectile.width / 2);
            Projectile.position.Y -= (Projectile.height / 2);
            float dustScale = 1f;
            if (Projectile.ai[0] == 0f)
                dustScale = 0.25f;
            else if (Projectile.ai[0] == 1f)
                dustScale = 0.5f;
            else if (Projectile.ai[0] == 2f)
                dustScale = 0.75f;

            if (Main.rand.Next(4) == 0)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.IceTorch, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100);
                // Some dust will be large, the others small and with gravity, to give visual variety.
                if (Main.rand.NextBool(3))
                {
					dust.noGravity = true;
                    dust.scale *= 2.5f;
                    dust.velocity.X *= 2f;
                    dust.velocity.Y *= 2f;
                }
                dust.scale *= 1.5f;
                dust.velocity *= 1.2f;
                dust.scale *= dustScale;
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



