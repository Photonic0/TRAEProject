using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TRAEProject.Changes.Accesory;

namespace TRAEProject.NewContent.Items.Accesories.GravityTabi
{
    public class GravityTabi : ModItem
    {
        public override void SetStaticDefaults()
        {
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

            // DisplayName.SetDefault("Gravity Tabi");
            // Tooltip.SetDefault("Allows control of gravity, fast fall and dashing\nPrevents fall damage");
        }
        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.rare = ItemRarityID.Pink;
            Item.value = 37500;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<AccesoryEffects>().FastFall = true;
            player.gravControl2 = true;
            player.noFallDmg = true;
            player.GetModPlayer<GravitationPlayer>().noFlipGravity = true;
            player.dashType = 1;
        }
        public override void AddRecipes()
        {
            CreateRecipe().AddIngredient(ItemID.Tabi, 1)
                .AddIngredient(ItemID.ObsidianHorseshoe, 1)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}