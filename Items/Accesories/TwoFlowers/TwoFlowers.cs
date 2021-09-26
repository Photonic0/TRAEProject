using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TRAEProject.Items.Accesories.TwoFlowers
{
    class TwoFlowers : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Two Flowers");
            Tooltip.SetDefault("Critical hits may spawn mana stars\nAutomaticly uses mana potions\nMagic attacks inflict binding flames");
        }
        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.rare = ItemRarityID.Orange;
            Item.value = 75000;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.lavaRose = true;
            player.manaFlower = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe().AddIngredient(ItemID.ObsidianRose, 1)
                .AddIngredient(ItemID.ManaFlower, 1)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}
