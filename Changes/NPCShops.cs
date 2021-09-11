using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TRAEProject.Changes
{
    class NPCShops : GlobalNPC
    {
        public override void SetupTravelShop(int[] shop, ref int nextSlot)
        {
            for (int i = 0; i < shop.Length; i++)
            {
                if (shop[i] == ItemID.CelestialMagnet)
                {
                    for (int j = i + 1; j < shop.Length; j++)
                    {
                        shop[j - 1] = shop[j];
                    }
                    shop[shop.Length - 1] = 0;
                    nextSlot--;
                }
            }
        }
        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            switch (type)
            {
                case NPCID.ArmsDealer:
                    if (!NPC.downedBoss1) // when will this code run?
                    {
                        for (int i = 0; i < shop.item.Length; i++) // loop through the
                        {
                            if (shop.item[i] != null && shop.item[i].type == ItemID.Minishark) // check if the shop slot it is at has an item, and if that item is Minishark
                            {
                                shop.item[i].SetDefaults(ItemID.None); // if so, set that slot to none
                                for (int j = i + 1; j < shop.item.Length; j++)
                                {
                                    shop.item[j - 1] = shop.item[j];
                                }
                                --nextSlot;
                                break;
                            }
                        }
                    }
                    break;
                case NPCID.SkeletonMerchant:
                    if (Main.moonPhase == 2 || Main.moonPhase == 8)
                    {
                        shop.item[nextSlot].SetDefaults(ItemID.Rally);
                        nextSlot++;
                    }
                    if (Main.moonPhase == 4 || Main.moonPhase == 6)
                    {
                        shop.item[nextSlot].SetDefaults(ItemID.ChainKnife);
                        nextSlot++;
                    }
                    if (Main.moonPhase == 3 || Main.moonPhase == 7)
                    {
                        shop.item[nextSlot].SetDefaults(ItemID.BoneSword);
                        nextSlot++;
                    }
                    if (Main.moonPhase == 1 || Main.moonPhase == 5)
                    {
                        shop.item[nextSlot].SetDefaults(ItemID.BookofSkulls);
                        nextSlot++;
                    }
                    break;
                case NPCID.Truffle:
                    if (!NPC.downedPlantBoss)
                    {
                        for (int i = 0; i < shop.item.Length; i++)
                        {
                            if (shop.item[i].type == ItemID.MushroomSpear)
                            {
                                for (int j = i + 1; j < shop.item.Length; j++)
                                {
                                    shop.item[j - 1] = shop.item[j];
                                }
                                shop.item[shop.item.Length - 1].type = ItemID.None;
                                nextSlot--;
                            }
                        }
                    }
                    break;
            }
        }
    }
}
