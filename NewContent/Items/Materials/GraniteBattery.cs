using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;

namespace TRAEProject.NewContent.Items.Materials
{
    public class GraniteBattery : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Granite Battery");
            Tooltip.SetDefault("Holds more power than it looks");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 5;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 26;
            Item.maxStack = 99;
            Item.rare = ItemRarityID.Lime;
            Item.value = Item.sellPrice(0, 1, 0, 0);
        }
    }  
}
