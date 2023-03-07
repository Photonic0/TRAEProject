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
    public class FantasyPack : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Fantasy Pack");
            ////DisplayName.SetDefault("Christmas Booster");
            ////Tooltip.SetDefault("Bame's note: I dont really like how this item feels... should I finish it?");
            ////Tooltip.SetDefault("Provides a booster jump, a levitation jump, and a fae jump");
        }
        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.rare = ItemRarityID.Yellow;
			Item.value = Item.buyPrice(0, 40);
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<TRAEJumps>().boosterFlightTimeMax += 40;
            player.GetModPlayer<TRAEJumps>().levitation = true;
            player.GetModPlayer<TRAEJumps>().faeJump = true;
        }
        public override void AddRecipes()
        {
            CreateRecipe().AddIngredient(ModContent.ItemType<FaeInABottle>(), 1)
                .AddIngredient(ModContent.ItemType<Booster>(), 1)
                .AddIngredient(ModContent.ItemType<LevitationJuice>(), 1)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}