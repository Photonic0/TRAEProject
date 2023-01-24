using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ID.ArmorIDs;
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent.Creative;
using TRAEProject.NewContent.Items.Materials;
using TRAEProject.Common.ModPlayers;

namespace TRAEProject.NewContent.Items.Armor.Reptilian
{
    [AutoloadEquip(EquipType.Head)]
    public class ReptilianMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Reptilian Mask");
            Tooltip.SetDefault("11% increased melee and summon damage\n7% increased melee critical strike chance\n15% increased whip range");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.value = Item.sellPrice(0, 4, 0, 0);
            Item.rare = ItemRarityID.Yellow;
            Item.width = 30;
            Item.height = 22;
            Item.defense = 14;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1)
                    .AddIngredient(ItemType<SalamanderTail>(), 2)
                    .AddIngredient(ItemType<ObsidianScale>(), 3)
                    .AddTile(TileID.MythrilAnvil)
                    .Register();
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage<SummonDamageClass>() += 0.11f;
            player.GetDamage<MeleeDamageClass>() += 0.11f;
            player.whipRangeMultiplier *= 1.15f;
            player.GetCritChance(DamageClass.Melee) += 7;
        }
    }
}

