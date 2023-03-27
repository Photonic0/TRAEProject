
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent.Creative;
using TRAEProject.Common;
namespace TRAEProject.NewContent.Items.FlamethrowerAmmo
{
    public class LavaGel : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Lava Gel");
            // Tooltip.SetDefault("Ignite it to know what REAL fire is!");
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
            Item.maxStack = 9999;
        }
        public override void AddRecipes()
        {
            CreateRecipe(50).AddIngredient(ItemID.Hellstone)
                .AddIngredient(ItemID.Gel, 20)
                .AddTile(TileID.Hellforge)
                .Register();
        } 
    }
    public class LavaGelP : FlamethrowerProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("CursedFlamethrower");     //The English name of the Projectile

        }
        public override string Texture => "Terraria/Images/Item_0";
        public override void FlamethrowerDefaults()
        {
            color1 = new Color(255, 67, 67, 200);
            color2 = new Color(255, 127, 20, 200);
            color3 = Color.Lerp(color1, color2, 0.25f);
            color4 = new Color(80, 80, 80, 100);
            dustID = DustID.RedTorch;
            Projectile.GetGlobalProjectile<ProjectileStats>().homesIn = true;
            Projectile.GetGlobalProjectile<ProjectileStats>().AddsBuff = BuffID.OnFire3;
            Projectile.GetGlobalProjectile<ProjectileStats>().AddsBuffDuration = 240;
            Projectile.GetGlobalProjectile<ProjectileStats>().DamageFalloff = 0.1f;
        }
    }
}




