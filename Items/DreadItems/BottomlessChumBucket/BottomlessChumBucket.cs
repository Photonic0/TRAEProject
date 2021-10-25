using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
namespace TRAEProject.Items.DreadItems.BottomlessChumBucket
{
    public class BottomlessChumBucket : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bottomless Chum Bucket");
			Tooltip.SetDefault("Toss in water up to 3 times to increase fishing power\nThis can't possibly fail!");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
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
			Item.SetShopValues(ItemRarityColor.Yellow8, Item.sellPrice(0, 5));
		}
    }
}
