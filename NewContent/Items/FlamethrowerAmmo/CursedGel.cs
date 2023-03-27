
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent.Creative;
using TRAEProject.Common;
using static Terraria.ModLoader.PlayerDrawLayer;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.GameContent;

namespace TRAEProject.NewContent.Items.FlamethrowerAmmo
{
    public class CursedGel : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Cursed Gel");
            // Tooltip.SetDefault("Flames seek out their targets");
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
    public class CursedGelP : FlamethrowerProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("CursedFlamethrower");     //The English name of the Projectile

        }
        public override string Texture => "Terraria/Images/Item_0";
        public override void FlamethrowerDefaults()
        {
            color1 = new Color(80, 255, 20, 200);
            color2 = new Color(150, 255, 20, 200);
            color3 = Color.Lerp(color1, color2, 0.25f);
            color4 = new Color(80, 80, 80, 100);
            dustID = DustID.CursedTorch;
            Projectile.GetGlobalProjectile<ProjectileStats>().homesIn = true;
            Projectile.GetGlobalProjectile<ProjectileStats>().dontHitTheSameEnemyMultipleTimes = true;
            Projectile.GetGlobalProjectile<ProjectileStats>().AddsBuff = BuffID.CursedInferno;
            Projectile.GetGlobalProjectile<ProjectileStats>().AddsBuffDuration = 240;
            Projectile.GetGlobalProjectile<ProjectileStats>().DamageFalloff = 0.1f;
        }
    }
}



