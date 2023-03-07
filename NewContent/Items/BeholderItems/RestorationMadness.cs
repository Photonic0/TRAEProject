using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TRAEProject;
using TRAEProject.Changes.Prefixes;
using static Terraria.ModLoader.ModContent;

namespace TRAEProject.NewContent.Items.BeholderItems
{
    class GreaterRestorationPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;

            // DisplayName.SetDefault("Greater Restoration Potion");
        }
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 28;
            Item.consumable = true;
            Item.maxStack = 30;
            Item.DefaultToHealingPotion(20, 28, 3);
            Item.rare = ItemRarityID.LightPurple;
            Item.value = Item.buyPrice(silver: 50);
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.HasBuff(BuffID.PotionSickness))
            {
                return false;
            }
            return true;
        }
        public override void OnConsumeItem(Player player)
        {
            player.ClearBuff(BuffID.PotionSickness);

            int potionSickness = 2700;
            if (player.pStone == true)
            {
                potionSickness = 2025;
            }
            player.AddBuff(BuffID.PotionSickness, potionSickness);

            player.AddBuff(BuffType<Restoring2>(), 1764);
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            foreach (TooltipLine line in tooltips)
            {
                if (line.Mod == "Terraria" && line.Name == "HealLife")
                {
                    line.Text = "Restores 150 HP over 30 seconds\nReduced Potion Cooldown";
                }
            }
        }
    }

    class Restoring1 : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            // DisplayName.SetDefault("Restoring");
            // Description.SetDefault("Restoring health");
        }

    }
    class Restoring2 : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            // DisplayName.SetDefault("Restoring");
            // Description.SetDefault("Restoring health");
        }
    }
    public class RestorationEffect: ModPlayer
    {

        int timer = 0;
        public override void PostUpdateBuffs()
        {
            if (Player.HasBuff<Restoring1>() || Player.HasBuff<Restoring2>())
            {
                timer += 1;
                if (timer == 36 && Player.HasBuff<Restoring2>())
                {
                    timer = 0;
                    Player.HealEffect(3, true);
                    Player.statLife += 3;
                }
                if (timer == 36 && Player.HasBuff<Restoring1>())
                {
                    timer = 0;
                    Player.HealEffect(2, true);
                    Player.statLife += 2;
                }
            
            }
        }
    }
    public class RestorationPotRework : GlobalItem
    {
        public override bool InstancePerEntity => true;
        public override GlobalItem Clone(Item item, Item itemClone)
        {
            return base.Clone(item, itemClone);
        }
        public override void SetDefaults(Item item)
        {
            if (item.type == ItemID.RestorationPotion)
            {

                item.width = 20;
                item.height = 28;
                item.consumable = true;
                item.maxStack = 30;
                item.useTime = item.useAnimation = 17;
                item.healLife = 2;
                item.noMelee = true;
                item.noUseGraphic = true;
                item.useStyle = ItemUseStyleID.DrinkLiquid;
            }
        }
        public override bool CanUseItem(Item item, Player player)
        {
            if (player.HasBuff(BuffID.PotionSickness) && item.type == ItemID.RestorationPotion)
            {
                return false;
            }
            return true;
        }
        public override void OnConsumeItem(Item item, Player player)
        {
            if (item.type == ItemID.RestorationPotion)
            {
                player.AddBuff(BuffType<Restoring1>(), 1764);
            }
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            switch (item.type)
            {
                case ItemID.RestorationPotion:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "HealLife")
                        {
                            line.Text = "Heals 100 HP over 30 seconds";
                        }
                    }
                    break;

            }
        }
    }        
}