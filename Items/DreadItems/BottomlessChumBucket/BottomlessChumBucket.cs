using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;

namespace TRAEProject.Items.DreadItems.BottomlessChumBucket
{
    public class BottomlessChumBucket : ModItem
    {
        public override void SetDefaults()
        {
			Item.useStyle = 1;
			Item.shootSpeed = 7f;
			Item.shoot = 820;
			Item.width = 30;
			Item.height = 32;
			Item.maxStack = 1;
			Item.UseSound = SoundID.Item1;
			Item.useAnimation = 19;
			Item.useTime = 19;
			Item.noMelee = true;
			Item.SetShopValues(ItemRarityColor.Blue1, Item.sellPrice(0, 5));
		}
    }
}
