using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ID.ArmorIDs;
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent.Creative;
using TRAEProject.NewContent.Items.Materials;
namespace TRAEProject.NewContent.Items.Armor.Phoenix
{
    [AutoloadEquip(EquipType.Head)]
    public class PhoenixHeadgear : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Phoenix Headgear");
            // Tooltip.SetDefault("11% increased ranged and summon damage\n7% increased ranged critical strike chance\n10% increased jump speed");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.value = Item.sellPrice(0, 5, 0, 0);
            Item.rare = ItemRarityID.Yellow;
            Item.width = 28;
            Item.height = 18;
            Item.defense = 12;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1)
                    .AddIngredient(ItemType<MagicalAsh>(), 3)
                    .AddIngredient(ItemType<ObsidianScale>(), 2)
                    .AddTile(TileID.MythrilAnvil)
                    .Register();
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage<SummonDamageClass>() += 0.11f;
            player.GetDamage<RangedDamageClass>() += 0.11f;
            player.GetCritChance<RangedDamageClass>() += 7;
            player.jumpSpeedBoost += 0.5f; // 10% 
        }
    }
}

