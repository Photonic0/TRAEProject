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
    public class AdvFlightSystem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Adv. Flight System");
            Tooltip.SetDefault("Rocket boots and wings are activated by pushing UP instead of jump");
        }
        public override void SetDefaults()
        {
            Item.rare = 5;
            Item.value = 300000;
            Item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<TRAEJumps>().advFlight = true;
        }
    }
}