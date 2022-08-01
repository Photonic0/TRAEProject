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
    public class Booster : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Booster");
            //DisplayName.SetDefault("Christmas Booster");
            Tooltip.SetDefault("Bame's note: I dont really like how this item feels... should I finish it?");
            //Tooltip.SetDefault("This is how santa gets down the chimmney so quickly");
        }
        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.rare = ItemRarityID.Pink;
            Item.value = 37500;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<TRAEJumps>().boosterFlightTimeMax += 120;
        }
    }
}
