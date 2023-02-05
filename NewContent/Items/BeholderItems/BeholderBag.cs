using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using TRAEProject.NewContent.NPCs.Underworld.Beholder;
using TRAEProject.NewContent.Items.Armor.UnderworldWarrior;

namespace TRAEProject.NewContent.Items.BeholderItems
{
    class BeholderBag : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Treasure Bag");
            Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
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

        public override int BossBagNPC => NPCType<BeholderNPC>();

        public override bool CanRightClick()
        {
            return true;
        }

        public override void OpenBossBag(Player player)
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
                player.QuickSpawnItem(player.GetSource_OpenItem(Item.type), mainLoot);
                previousLoot = mainLoot;
            }
            if (Main.rand.NextBool(7))
                player.QuickSpawnItem(player.GetSource_OpenItem(Item.type), ItemType<BeholderMask>());
            int ring = Main.rand.NextFromList(ItemType<RingOfFuror>(), ItemType<RingOfMight>(), ItemType<RingOfTenacity>());
            player.QuickSpawnItem(player.GetSource_OpenItem(Item.type), ring);
            if (Main.rand.NextBool(4))
            {
                int item = Main.rand.NextFromList(ItemType<ScrollOfWipeout>(), ItemType<WandOfDisintegration>());
                player.QuickSpawnItem(player.GetSource_OpenItem(Item.type), item);
            }
            player.QuickSpawnItem(player.GetSource_OpenItem(Item.type),ItemType<MasterEmblem>());
        }
    }
}
