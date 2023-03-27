using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;

namespace TRAEProject.NewContent.Items.Materials
{
    public class MagicalAsh : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Magical Ash");
            // Tooltip.SetDefault("Let's hope a Phoenix isnt born from these");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 5;
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
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
