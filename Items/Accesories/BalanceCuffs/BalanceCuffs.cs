using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TRAEProject.Items.Accesories.LifeCuffs;
using static Terraria.ModLoader.ModContent;

namespace TRAEProject.Items.Accesories.BalanceCuffs
{    
[AutoloadEquip(EquipType.HandsOn, EquipType.HandsOff)]
    class BalanceCuffs : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Balance Cuffs");
            Tooltip.SetDefault("Temporarily increases damage by 20% and restore mana when damaged");
        }
        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.rare = ItemRarityID.Orange;
            Item.value = 50000;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<LifeCuffsEffect>().cuffs += 1;
            player.GetModPlayer<TRAEPlayer>().magicCuffsCount += 1;
        }

        public override void AddRecipes()
        {
            CreateRecipe().AddIngredient(ItemType<LifeCuffs.LifeCuffs>(), 1)
                .AddIngredient(ItemID.MagicCuffs, 1)
                .AddIngredient(ItemID.DarkShard, 1)
                .AddIngredient(ItemID.LightShard, 1)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
            CreateRecipe().AddIngredient(ItemID.ManaRegenerationBand, 1)
            .AddIngredient(ItemID.Shackle, 1)
            .AddIngredient(ItemID.DarkShard, 1)
            .AddIngredient(ItemID.LightShard, 1)
            .AddTile(TileID.TinkerersWorkbench)
            .Register();
        }
    }
}
