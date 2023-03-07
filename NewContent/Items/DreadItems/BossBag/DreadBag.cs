using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using TRAEProject.NewContent.Items.FlamethrowerAmmo;
using static Terraria.ModLoader.ModContent;
using TRAEProject.NewContent.Items.Armor.UnderworldWarrior;
using Terraria.GameContent.ItemDropRules;

namespace TRAEProject.NewContent.Items.DreadItems.BossBag
{
    class DreadBag : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Treasure Bag");
            // Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.maxStack = 999;
            Item.consumable = true;
            Item.width = 60;
            Item.height = 34;
            Item.rare = 9;
            Item.expert = true;
            //bossBagNPC = mod.NPCType("WeakPoint");
        }


        public override bool CanRightClick()
        {
            return true;
        }

        public override void ModifyItemLoot(ItemLoot itemLoot)
        {
            int loot = Main.rand.NextFromList(new int[] { ItemType<ShellSpinner.ShellSpinner>(), ItemType<BloodBoiler.BloodBoiler>(), ItemType<Brimstone.Brimstone>(), ItemID.SanguineStaff });
            if (loot == ItemType<BloodBoiler.BloodBoiler>())
                itemLoot.Add(ItemDropRule.Common(ItemType<BloodyGel>(), 1, 80, 120));
            itemLoot.Add(ItemDropRule.Common(loot, 1));
            itemLoot.Add(ItemDropRule.Common(ItemID.BloodHamaxe, 8));
            itemLoot.Add(ItemDropRule.Common(ItemType<BloodWings.BloodWings>(), 6));
            itemLoot.Add(ItemDropRule.Common(ItemID.BloodMoonMonolith, 9));
            itemLoot.Add(ItemDropRule.Common(ItemType<DreadMask.DreadMask>(), 7));
            itemLoot.Add(ItemDropRule.Common(ItemType<BottomlessChumBucket.BottomlessChumBucket>(), 9));
            itemLoot.Add(ItemDropRule.Common(ItemID.BloodMoonStarter, 1));
            itemLoot.Add(ItemDropRule.Common(ItemType<RedPearl.RedPearl>(), 1));
        }
    }
}
