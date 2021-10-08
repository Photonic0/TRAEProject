using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using static Terraria.ModLoader.ModContent;

namespace TRAEProject.Items.Accesories.MagicalCarpet
{
	[AutoloadEquip(EquipType.Wings)]
	class MagicalCarpet : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magical Carpet");
			Tooltip.SetDefault("Allows flight and slow fall\nPress DOWN to toggle hover");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

			ArmorIDs.Wing.Sets.Stats[Item.wingSlot] = new WingStats(90, 5f, 3f, true, -1f, 2f);
		}

		public override void SetDefaults()
		{
			Item.width = 66;
			Item.height = 24;
			Item.value = Item.sellPrice(gold: 10);
			Item.rare = ItemRarityID.LightPurple;
			Item.accessory = true;
		}
		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(ItemID.FlyingCarpet)
				.AddIngredient(ItemID.AncientBattleArmorMaterial, 1)
				.AddIngredient(ItemID.SoulofFlight, 20)
				.AddTile(TileID.TinkerersWorkbench)
				.Register();
		}
	}
}
