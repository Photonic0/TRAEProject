using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent.Creative;
using TRAEProject.NewContent.Items.Materials;
namespace TRAEProject.NewContent.Items.Armor.Ronin
{
    [AutoloadEquip(EquipType.Legs)]
    public class AshRoninPants : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ash Ronin Pants");
            Tooltip.SetDefault("11% increased magic and summon damage\n11% increased movement speed");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.value = Item.sellPrice(0, 4, 0, 0);
            Item.rare = ItemRarityID.Yellow;
            Item.width = 22;
            Item.height = 18;
            Item.defense = 10;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1)
                        .AddIngredient(ItemType<MagicalAsh>(), 3)
                        .AddIngredient(ItemType<DriedRose>(), 1)
                        .AddTile(TileID.MythrilAnvil)
                        .Register();
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage<MagicDamageClass>() += 0.11f; 
            player.GetDamage<SummonDamageClass>() += 0.11f;
            player.moveSpeed += 0.11f;
        }
    }
}
