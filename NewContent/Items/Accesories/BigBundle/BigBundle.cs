using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;
using TRAEProject.NewContent.Items.Accesories.SpaceBalloon;
using TRAEProject.NewContent.Items.Accesories.WeirdBundle;
namespace TRAEProject.NewContent.Items.Accesories.BigBundle
{
    [AutoloadEquip(EquipType.Balloon)]
    public class BigBundle : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            DisplayName.SetDefault("The Big Bundle");
            Tooltip.SetDefault("Allows the player to sextuple jump!\nIncreases jump height, health regeneration and prevents fall damage\nResets all jumps and flight time every 10 seconds of being in the air\nReleases Bees and covers you in honey when damaged");
        }
        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.rare = ItemRarityID.Cyan;
            Item.value = 100000;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.hasJumpOption_Sandstorm = true;
            player.hasJumpOption_Blizzard = true;
            player.hasJumpOption_Cloud = true;
            player.hasJumpOption_Fart = true;
            player.hasJumpOption_Sail = true;
            player.honeyCombItem = Item;
            player.jumpBoost = true;
            player.lifeRegen += 2;
            player.noFallDmg = true;
            player.GetModPlayer<SpaceBalloonPlayer>().SpaceBalloon += 1;
        }
        public override void AddRecipes()
        {
            CreateRecipe().AddIngredient(ItemID.BundleofBalloons)
               .AddIngredient(ItemType<BundleOfWeirdBalloons>())
               .AddIngredient(ItemType<SpaceBalloonItem>())
               .AddTile(TileID.TinkerersWorkbench)
               .Register();
        }
    }
}