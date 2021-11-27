using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.GameContent.Creative;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ID.ArmorIDs;

namespace TRAEProject.Items.Armor.ChlorophyteHood
{

    [AutoloadEquip(EquipType.Head)]
    public class ChlorophyteHood : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chlorophyte Hood");

            Head.Sets.DrawHatHair[Item.headSlot] = true;
            Tooltip.SetDefault("Increases your maximum number of minions by 2");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.value = Item.sellPrice(0, 6, 0, 0);
            Item.rare = ItemRarityID.Lime;
            Item.width = 24;
            Item.height = 24;
            Item.defense = 3;
        }
        public override void UpdateEquip(Player player)
        {
            player.maxMinions += 2;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ItemID.ChlorophyteBar, 12)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.ChlorophytePlateMail && legs.type == ItemID.ChlorophyteGreaves;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Summons a powerful leaf crystal to shoot at nearby enemies\n30% increased summon damage";
            player.GetDamage(DamageClass.Summon) += 0.3f;
            player.AddBuff(BuffID.LeafCrystal, 2);
        }
    }
}
