﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TRAEProject.NewContent.Items.Accesories.SandstormBoots
{
	[AutoloadEquip(EquipType.Shoes)]
    class SandstormBoots : ModItem
    {
        public override void SetStaticDefaults()
        {
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

            // DisplayName.SetDefault("Sandstorm Boots");
            // Tooltip.SetDefault("20% increased movement speed\nThe wearer can perform an improved double jump\n20% increased movement speed on sand");
        }
        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.sellPrice(gold: 3);
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.accRunSpeed = 4.8f;
            player.moveSpeed += 0.20f;
            player.desertBoots = false;
            player.sailDash = false;
            player.coldDash = false;
            player.desertDash = true;
            player.GetModPlayer<AccesoryEffects>().sandRunning = true;
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
