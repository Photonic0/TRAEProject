﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TRAEProject.NewContent.Items.Accesories.TheBlackCross
{    [AutoloadEquip(EquipType.Neck)]
    class TheBlackCross : ModItem
    {
        public override void SetStaticDefaults()
        {
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

            // DisplayName.SetDefault("The Black Cross");
            // Tooltip.SetDefault("Increases length of invincibility after taking damage.\nGrants the wearer a chance to dodge an attack");
        }
        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.rare = ItemRarityID.Yellow;
            Item.value = 75000;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.longInvince = true;
            player.GetModPlayer<BlackCrossDodge>().BlackCrossBelt = true;
        }
        public override void AddRecipes()
        {
            CreateRecipe().AddIngredient(ItemID.CrossNecklace, 1)
                .AddIngredient(ItemID.BlackBelt, 1)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
    public class BlackCrossDodge : ModPlayer
    {
        public bool BlackCrossBelt = false;
		
		public override void ResetEffects()
        {
            BlackCrossBelt = false;
        }
        public override void UpdateDead()
        {
            BlackCrossBelt = false;
        }
        public override bool FreeDodge(Player.HurtInfo info)
        {

            if (BlackCrossBelt && Main.rand.NextBool(10))
            {
                Player.NinjaDodge();
                Player.SetImmuneTimeForAllTypes(120);
                return true;
            }
            return false;
        }
    }
}
