using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;

namespace TRAEProject.NewContent.Items.Materials
{
    public class ObsidianScale : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Obsidian Scales");
            Tooltip.SetDefault("Very Tough");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 5;
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 26;
            Item.maxStack = 99;
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
