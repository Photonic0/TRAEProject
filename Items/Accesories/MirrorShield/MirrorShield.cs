using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TRAEProject.Items.Accesories.MirrorShield
{
    class MirrorShield : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mirror Shield");
            Tooltip.SetDefault("Increases max life by 60\nReduces damage taken from projectiles by 15%");
        }
        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.rare = ItemRarityID.Orange;
            Item.value = 75000;
            Item.defense = 2;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statLifeMax2 += 60;
            player.GetModPlayer<Defense>().pocketMirror = true;
        }

    }
}
