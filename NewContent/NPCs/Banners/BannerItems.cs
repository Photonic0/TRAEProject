using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using TRAEProject.NewContent.NPCs.Banners;
using static Terraria.ModLoader.ModContent;

namespace TRAEProject.NewContent.NPCs.Banners          //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
    public class BomberBonesBanner : ModItem
    {
        public override void SetStaticDefaults()
        {
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

            DisplayName.SetDefault("Bomber Bones Banner");
            Tooltip.SetDefault("Nearby players get a bonus against: Bomber Bones");
        }
        public override void SetDefaults()
        {

            Item.width = 12;
            Item.height = 28;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(0, 0, 2, 0);
            Item.createTile = TileType<BomberBonesBannerPlaced>();
            Item.placeStyle = 0;
        }
    }
    public class BoomxieBanner : ModItem
    {
        public override void SetStaticDefaults()
        {
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

            DisplayName.SetDefault("Boom Pixie Banner");
            Tooltip.SetDefault("Nearby players get a bonus against: Boom Pixie");
        }
        public override void SetDefaults()
        {

            Item.width = 12;
            Item.height = 28;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(0, 0, 2, 0);
            Item.createTile = TileType<BoomxieBannerPlaced>();
            Item.placeStyle = 0;
        }
    }
    public class FroggabombaBanner : ModItem
    {
        public override void SetStaticDefaults()
        {
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

            DisplayName.SetDefault("Froggabomba Banner");
            Tooltip.SetDefault("Nearby players get a bonus against: Froggabomba");
        }
        public override void SetDefaults()
        {

            Item.width = 12;
            Item.height = 28;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(0, 0, 2, 0);
            Item.createTile = TileType<FroggabombaBannerPlaced>();
            Item.placeStyle = 0;
        }
    }
    public class GraniteOvergrowthBanner : ModItem
    {
        public override void SetStaticDefaults()
        {
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

            DisplayName.SetDefault("GraniteOvergrowth Banner");
            Tooltip.SetDefault("Nearby players get a bonus against: GraniteOvergrowth");
        }
        public override void SetDefaults()
        {

            Item.width = 12;
            Item.height = 28;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(0, 0, 2, 0);
            Item.createTile = TileType<GraniteOvergrowthBannerPlaced>();
            Item.placeStyle = 0;
        }
    }
}

////then add this to the custom npc you want to drop the banner and in public override void SetDefaults()
/*  banner = npc.type;
  bannerItem = mod.ItemType("CustomBannerItem"); //this defines what banner this npc will drop       */