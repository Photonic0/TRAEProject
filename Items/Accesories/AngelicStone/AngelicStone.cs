using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TRAEProject.Items.Accesories.AngelicStone
{
    public class AngelicStone : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Angelic Stone");
            Tooltip.SetDefault("10% increased mana regeneration\nCuts the duration of mana sickness in half");
        }
        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.rare = ItemRarityID.Orange;
            Item.value = 75000;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<AngelicStoneEffects>().stones += 1;
            player.GetModPlayer<TRAEPlayer>().manaRegenBoost += 0.1f;
        }

        public override void AddRecipes()
        {
            CreateRecipe().AddIngredient(ItemID.PhilosophersStone, 1)
                .AddIngredient(ItemID.BandofStarpower, 1)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
        class AngelicStoneEffects : ModPlayer
        {
            public int stones = 0;
            public override void ResetEffects()
            {
                stones = 0;
            }
            public override void PostUpdateEquips()
            {
                int maxTime = 60 / (1 + stones);
                if (Player.HasBuff(BuffID.ManaSickness))
                {
                    if (Player.buffTime[Player.FindBuffIndex(BuffID.ManaSickness)] > maxTime)
                    {
                        Player.buffTime[Player.FindBuffIndex(BuffID.ManaSickness)] = maxTime;
                    }
                }
            }
        }
    }
}
