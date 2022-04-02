using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;

namespace TRAEProject.NewContent.Items.Materials
{
    public class LuminiteFeather : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Luminite Feather");
            Tooltip.SetDefault("Used to make the ultimate wings");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
        }

        public override void SetDefaults()
        {
            Item.width = 14;
            Item.height = 34;
            Item.maxStack = 99;
            Item.rare = ItemRarityID.Expert;
            Item.value = Item.sellPrice(0, 50, 0, 0);
        }
    }  
}
