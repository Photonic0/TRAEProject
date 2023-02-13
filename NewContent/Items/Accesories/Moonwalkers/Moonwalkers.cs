using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;
using TRAEProject.NewContent.Items.Accesories.SpaceBalloon;

namespace TRAEProject.NewContent.Items.Accesories.Moonwalkers
{
    [AutoloadEquip(EquipType.Shoes)]
    public class Moonwalkers : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            DisplayName.SetDefault("Moonwalkers");
            Tooltip.SetDefault("Increases jump height, prevents fall damage and grants extended flight\nPress DOWN to fall faster\nAllows reducing gravity by hodling up");
        }
        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.rare = ItemRarityID.Yellow;
            Item.value = 750000;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<SpaceBalloonPlayer>().SpaceBalloon += 1;
            player.rocketBoots = 2;
            player.rocketTimeMax += 10;
            player.GetModPlayer<AccesoryEffects>().FastFall = true;
            player.noFallDmg = true;
        }
        public override void AddRecipes()
        {
            CreateRecipe().AddIngredient(ItemID.ObsidianWaterWalkingBoots)
               .AddIngredient(ItemType<SpaceBalloonItem>())
               .AddTile(TileID.TinkerersWorkbench)
               .Register();
        }
    }
}