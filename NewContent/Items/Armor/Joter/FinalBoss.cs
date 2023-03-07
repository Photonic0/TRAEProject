using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ID.ArmorIDs;
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent.Creative;
using TRAEProject.NewContent.Items.Materials;
namespace TRAEProject.NewContent.Items.Armor.Joter
{
    [AutoloadEquip(EquipType.Head)]
    public class FinalBoss : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Final Boss");
            // Tooltip.SetDefault("!srepoleved gnitanosrepmi snoitanimoba gnitanosrepmi rof taerG");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.value = Item.sellPrice(0, 0, 0, 0);
            Item.rare = ItemRarityID.Red;
            Item.width = 32; 
            Item.vanity = true;
            Item.height = 32;
        }
    }
}
