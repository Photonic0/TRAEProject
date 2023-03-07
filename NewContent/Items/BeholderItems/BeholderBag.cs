using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using TRAEProject.NewContent.NPCs.Underworld.Beholder;
using TRAEProject.NewContent.Items.Armor.UnderworldWarrior;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader.Core;

namespace TRAEProject.NewContent.Items.BeholderItems
{
    class BeholderBag : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Treasure Bag");
            ////Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
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
        }

        public override bool CanRightClick()
        {
            return true;
        }
        public override void ModifyItemLoot(ItemLoot itemLoot)
        {
            int previousLoot = 0;
            int[] lootList = new int[] { ItemType<UnderworldWarriorHelmet>(), ItemType<UnderworldWarriorChestplate>(), ItemType<UnderworldWarriorGreaves>() };

            for (int i = 0; i < 2; i++)
            {
                int mainLoot = Main.rand.Next(lootList);
                while (mainLoot == previousLoot) // dont drop the same piece twice
                {
                    mainLoot = Main.rand.Next(lootList); 
                }
                itemLoot.Add(ItemDropRule.Common(mainLoot));
                previousLoot = mainLoot;
            }
            itemLoot.Add(ItemDropRule.Common(ItemType<BeholderMask>(), 7));
            int[] rings = new int[] { ItemType<RingOfFuror>(), ItemType<RingOfMight>(), ItemType<RingOfTenacity>() };
            itemLoot.Add(ItemDropRule.OneFromOptions(1, rings));
            int[] otherloot = new int[] { ItemType<ScrollOfWipeout>(), ItemType<WandOfDisintegration>() };
            itemLoot.Add(ItemDropRule.OneFromOptions(4, otherloot));
            itemLoot.Add(ItemDropRule.Common(ItemType<MasterEmblem>(), 1));

        }
    }
}
