using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TRAEProject.NewContent.Items.Accesories.ExtraJumps
{
    public class FlightForecast : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flight Forecast");
            Tooltip.SetDefault("Rocket boots and wings are activated by pushing UP instead of jump\nProvides a double jump");
        }
        public override void SetDefaults()
        {
            Item.rare = 5;
            Item.value = 300000;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<TRAEJumps>().advFlight = true;
            player.hasJumpOption_Cloud = true;
        }
        public override void AddRecipes()
        {
            CreateRecipe().AddIngredient(ModContent.ItemType<AdvFlightSystem>(), 1)
                .AddIngredient(ItemID.CloudinaBottle, 1)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}