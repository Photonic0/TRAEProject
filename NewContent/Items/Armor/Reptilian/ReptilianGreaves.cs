using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent.Creative;
using TRAEProject.NewContent.Items.Materials;
namespace TRAEProject.NewContent.Items.Armor.Reptilian
{
    [AutoloadEquip(EquipType.Legs)]
    public class ReptilianGreaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Reptilian Treads");
            ////Tooltip.SetDefault("11% increased melee and summon damage\n11% increased movement speed");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.value = Item.sellPrice(0, 4, 0, 0);
            Item.rare = ItemRarityID.Yellow;
            Item.width = 22;
            Item.height = 18;
            Item.defense = 14;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1)
                    .AddIngredient(ItemType<SalamanderTail>(), 2)
                    .AddIngredient(ItemType<ObsidianScale>(), 2)
                    .AddTile(TileID.MythrilAnvil)
                    .Register();
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage<SummonDamageClass>() += 0.11f; 
            player.GetDamage<MeleeDamageClass>() += 0.11f;
            player.moveSpeed += 0.11f;
        }
    }
}
