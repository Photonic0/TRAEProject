using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using TRAEProject.Common.ModPlayers;

namespace TRAEProject.NewContent.Items.Accesories.MechanicalEye
{
    [AutoloadEquip(EquipType.Face)]

    public class MechanicalEyeItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1; 
            DisplayName.SetDefault("Cyber Eye");
            Tooltip.SetDefault("Rocket critical strikes stun enemies for 1 second");
        }
        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.rare = ItemRarityID.Yellow;
            Item.value = 20000;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<RangedStats>().RocketsStun += 1;
        }
    }
}
