using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent.Creative;
using TRAEProject.NewContent.Items.Materials;
namespace TRAEProject.NewContent.Items.Armor.Phoenix
{
    [AutoloadEquip(EquipType.Legs)]
    public class PhoenixLeggings : ModItem
    {
      
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Phoenix Leggings");
            Tooltip.SetDefault("11% increased ranged and summon damage\n11% increased movement speed");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.value = Item.sellPrice(0, 5, 0, 0);
            Item.rare = ItemRarityID.Yellow;
            Item.width = 18;
            Item.height = 12;
            Item.defense = 12;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1)
                    .AddIngredient(ItemType<MagicalAsh>(), 4)
                    .AddIngredient(ItemType<ObsidianScale>(), 1)

                    .AddTile(TileID.MythrilAnvil)
                    .Register();
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage<SummonDamageClass>() += 0.11f;
            player.GetDamage<RangedDamageClass>() += 0.11f;
            player.moveSpeed += 0.11f;
        }
    }
}
