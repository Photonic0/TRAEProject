using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ID.ArmorIDs;
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent.Creative;
using TRAEProject.NewContent.Items.Materials;
namespace TRAEProject.NewContent.Items.Armor.Ronin
{
    [AutoloadEquip(EquipType.Head)]
    public class AshRoninHat : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Ash Ronin Mask");
            ////Tooltip.SetDefault("11% increased magic and summon damage\n7% increased magic critical strike chance\nIncreases maximum mana by 80");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1; 
            Head.Sets.DrawHatHair[Item.headSlot] = true;

        }
        public override void SetDefaults()
        {
            Item.value = Item.sellPrice(0, 3, 0, 0);
            Item.rare = ItemRarityID.Yellow;
            Item.width = 28;
            Item.height = 16;
            Item.defense = 10;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1)
                    .AddIngredient(ItemType<MagicalAsh>(), 2)
                    .AddIngredient(ItemType<DriedRose>(), 1)
                    .AddTile(TileID.MythrilAnvil)
                    .Register();
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage<SummonDamageClass>() += 0.11f;
            player.GetDamage<MagicDamageClass>() += 0.11f;
            player.GetCritChance<MagicDamageClass>() += 7;
            player.statManaMax2 += 80;
        }
    }
}

