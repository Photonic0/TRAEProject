using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TRAEProject.Items.Accesories.SandstormBoots
{
	[AutoloadEquip(EquipType.Shoes)]
    class SandstormBoots : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sandstorm Boots");
            Tooltip.SetDefault("25% increased movement speed\nThe wearer can perform an improved double jump\nRun even faster in sand");
        }
        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.rare = ItemRarityID.Orange;
            Item.sellPrice(gold: 3);
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.accRunSpeed = 4.8f;
			player.moveSpeed += 0.25f; 
            player.desertBoots = true;
            player.hasJumpOption_Sandstorm = true;
        }
        public override void AddRecipes()
        {
            CreateRecipe().AddIngredient(ItemID.SandBoots, 1)
                .AddIngredient(ItemID.SandstorminaBottle, 1)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}
