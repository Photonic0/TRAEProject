using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TRAEProject.NewContent.Items.Accesories.SpaceBalloon;

namespace TRAEProject.NewContent.Items.Accesories.ExtraJumps
{
    public class FaeInABalloon : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Fae Balloon");
            // Tooltip.SetDefault("A weak double jump that grant immunity frames\nIncreases jump height\nAllows reducing gravity by hodling up");
        }
        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.rare = ItemRarityID.Yellow;
			Item.value = Item.buyPrice(0, 40);
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<TRAEJumps>().faeJump = true;
            player.jumpBoost = true;
            player.GetModPlayer<SpaceBalloonPlayer>().SpaceBalloon += 1;
        }
        public override void AddRecipes()
        {
            CreateRecipe().AddIngredient(ModContent.ItemType<FaeInABottle>(), 1)
                .AddIngredient(ModContent.ItemType<SpaceBalloonItem>(), 1)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}