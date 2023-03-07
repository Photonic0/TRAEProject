using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using TRAEProject.NewContent.Items.Weapons.Summoner.Whip;
using TRAEProject.Changes.Weapon;

namespace TRAEProject.NewContent.Items.Materials
{
    public class IceQueenJewel : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Glacial Diamond");
            ////Tooltip.SetDefault("Holds the power of the Ice Queen");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 5;
        }

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 28;
            Item.maxStack = 99;
            Item.rare = ItemRarityID.Yellow;
            Item.value = Item.sellPrice(0, 25, 0, 0);
        }
    }  
}
