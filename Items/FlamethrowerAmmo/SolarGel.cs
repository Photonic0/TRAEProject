
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TRAEProject.Buffs;
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent.Creative;
namespace TRAEProject.Items.FlamethrowerAmmo
{
    public class SolarGel : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Solar Gel");
            Tooltip.SetDefault("Shoots a concentrated Solar Flare");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.damage = 40;
            Item.DamageType = DamageClass.Ranged;
            Item.knockBack = 2;
            Item.value = Item.sellPrice(0, 0, 10, 0);
            Item.rare = ItemRarityID.Pink;
            Item.width = 20;
            Item.height = 18;
            Item.shootSpeed = 6;
            Item.consumable = true;
            Item.shoot = ProjectileType<SolarGelP>();
            Item.ammo = AmmoID.Gel;
            Item.maxStack = 3000;
        }

        public override void AddRecipes()
        {
            CreateRecipe(100).AddIngredient(ItemID.LunarTabletFragment)
                .AddIngredient(ItemID.Gel, 10)
                .AddTile(TileID.Solidifier)
                .Register();
        }
	}
    public class SolarGelP : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Solar Flamethrower");     //The English name of the Projectile
        
            }
            public override string Texture => "Terraria/Images/Item_0";
        public override void SetDefaults()
        {
            Projectile.width = 8;
            Projectile.height = 8;
            Projectile.aiStyle = 48;
            Projectile.friendly = true;
            Projectile.extraUpdates = 100;
            Projectile.timeLeft = 120;
            Projectile.penetrate = 1;
            Projectile.CloneDefaults(ProjectileID.HeatRay);
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.hostile = false;
            Projectile.GetGlobalProjectile<TRAEGlobalProjectile>().AddsBuff = BuffType<Heavyburn>();
            Projectile.GetGlobalProjectile<TRAEGlobalProjectile>().AddsBuffDuration = 60;
        }
        public override void Kill(int timeLeft)
        {
            // Please note the usage of MathHelper, please use this!
            // We subtract 90 degrees as radians to the rotation vector to offset the sprite as its default rotation in the sprite isn't aligned properly.            usePos += rotVector * 16f; 
            for (int i = 0; i < 30; i++)
            {
                // Create a new dust
                Dust dust = Dust.NewDustDirect(Projectile.Center, Projectile.width, Projectile.height, DustID.HeatRay, 0f, 0f);
                dust.position = (dust.position + Projectile.Center) / 2f;
                dust.velocity *= 2f;
                dust.noGravity = true;
            }
        }
    }
}


