using Terraria.ModLoader;

namespace TRAEProject.NewContent.Items.BeholderItems
{
    [AutoloadEquip(EquipType.Head)]
    public class BeholderMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

            //DisplayName.SetDefault("Beholder Mask");
            ////Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            Item.value = 0;
            Item.rare = 1;

            Item.vanity = true;
            Item.width = 30;
            Item.height = 30;
        }
    }
}