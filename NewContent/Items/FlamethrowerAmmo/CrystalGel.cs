
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;
using Terraria.GameContent.Creative;
using TRAEProject.Common;
using Terraria.DataStructures;

namespace TRAEProject.NewContent.Items.FlamethrowerAmmo
{        
    public class CrystalGel : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Crystal Gel");
            // Tooltip.SetDefault("Splits and ignores 25 defense");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99; AmmoID.Sets.IsSpecialist[Item.type] = true;

        }
        public override void SetDefaults()
        {
            Item.damage = 0;
            Item.DamageType = DamageClass.Ranged;
            Item.knockBack = 2;
            Item.value = Item.sellPrice(0, 0, 10, 0);
            Item.rare = ItemRarityID.Pink;
            Item.width = 24;
            Item.height = 22;
            Item.shootSpeed = 0f;
            Item.consumable = true;
            Item.shoot = ProjectileType<CrystalGelP>();
            Item.ammo = AmmoID.Gel;
            Item.maxStack = 9999;
        }

        public override void AddRecipes()
        {
            CreateRecipe(50).AddIngredient(4986)
                .AddIngredient(ItemID.Gel, 10)
                .AddTile(TileID.Solidifier)
                .Register();
        }
    }
    public class CrystalGelP : FlamethrowerProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("CursedFlamethrower");     //The English name of the Projectile

        }
        public override string Texture => "Terraria/Images/Item_0";
        public override void FlamethrowerDefaults()
        {
            dustID = Main.rand.NextFromList(DustID.BlueTorch, DustID.PinkTorch, DustID.PurpleTorch);
            if (dustID == DustID.BlueTorch)
            {
                color1 = new Color(20, 80, 255, 200);
                color2 = new Color(20, 255, 255, 200);
                color3 = Color.Lerp(color1, color2, 0.25f);
                color4 = new Color(80, 80, 80, 100);
            }
            if (dustID == DustID.PinkTorch)
            {
                color1 = new Color(255, 20, 230, 200);
                color2 = new Color(254, 50, 239, 200);
                color3 = Color.Lerp(color1, color2, 0.25f);
                color4 = new Color(80, 80, 80, 100);
            }
            if (dustID == DustID.PurpleTorch)
            {
                color1 = new Color(187, 20, 255, 200);
                color2 = new Color(194, 89, 255, 200);
                color3 = Color.Lerp(color1, color2, 0.25f);
                color4 = new Color(80, 80, 80, 100);
            }
            Projectile.ArmorPenetration = 25;
            Projectile.GetGlobalProjectile<ProjectileStats>().homesIn = true;
            Projectile.GetGlobalProjectile<ProjectileStats>().dontHitTheSameEnemyMultipleTimes = true;
            Projectile.GetGlobalProjectile<ProjectileStats>().DamageFalloff = 0.15f;
        }
        public override void OnSpawn(IEntitySource source)
        {
            float rotation = MathHelper.ToRadians(100);
            for (int i = 0; i < 2; ++i)
            {
                Vector2 perturbedSpeed = new Vector2(Projectile.velocity.X, Projectile.velocity.Y).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (2 - 1))) * 0.2f; // Watch out for dividing by 0 if there is only 1 projectile.
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, Projectile.velocity.X + perturbedSpeed.X, Projectile.velocity.Y + perturbedSpeed.Y, ProjectileType<CrystalGelSplitP>(), Projectile.damage, Projectile.knockBack, Projectile.owner, 0f, ai2: 1f);
            }
        }
        public class CrystalGelSplitP : FlamethrowerProjectile
        {
            public override void SetStaticDefaults()
            {
                // DisplayName.SetDefault("CursedFlamethrower");     //The English name of the Projectile

            }
            public override string Texture => "Terraria/Images/Item_0";
            public override void FlamethrowerDefaults()
            {
                dustID = Main.rand.NextFromList(DustID.BlueTorch, DustID.PinkTorch, DustID.PurpleTorch);
                if (dustID == DustID.BlueTorch)
                {
                    color1 = new Color(20, 80, 255, 100);
                    color2 = new Color(20, 255, 255, 100);
                    color3 = Color.Lerp(color1, color2, 0.25f);
                    color4 = new Color(80, 80, 80, 100);
                }
                if (dustID == DustID.PinkTorch)
                {
                    color1 = new Color(255, 20, 230, 100);
                    color2 = new Color(254, 50, 239, 100);
                    color3 = Color.Lerp(color1, color2, 0.25f);
                    color4 = new Color(80, 80, 80, 100);
                }
                if (dustID == DustID.PurpleTorch)
                {
                    color1 = new Color(187, 20, 255, 100);
                    color2 = new Color(194, 89, 255, 100);
                    color3 = Color.Lerp(color1, color2, 0.25f);
                    color4 = new Color(80, 80, 80, 100);
                }
                Projectile.ArmorPenetration = 25;
                Projectile.GetGlobalProjectile<ProjectileStats>().homesIn = true;
                Projectile.GetGlobalProjectile<ProjectileStats>().dontHitTheSameEnemyMultipleTimes = true;
                Projectile.GetGlobalProjectile<ProjectileStats>().DamageFalloff = 0.15f;
            }
        }
    }
}


