using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;

namespace TRAEProject.NewContent.Items.Materials
{
    public class SalamanderTail : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Salamander Tail");
            // Tooltip.SetDefault("It's still moving");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 5;
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 18;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Lime;
            Item.value = Item.sellPrice(0, 1, 0, 0);
        }
        public override void Update(ref float gravity, ref float maxFallSpeed)
        {
            if (Item.lavaWet)
                gravity *= -1;
        }
    }  
}
