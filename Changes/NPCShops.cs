using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using TRAEProject.NewContent.Items.Misc.Potions;
using System.IO;
using Terraria.ModLoader.IO;
using TRAEProject.Common;
using TRAEProject.NewContent.NPCs.Underworld.ObsidianBasilisk;
using TRAEProject.NewContent.NPCs.Underworld.Phoenix;
using TRAEProject.NewContent.NPCs.Underworld.Salalava;

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
				if (shop[i] == ItemID.PulseBow)
                {
                    for (int j = i + 1; j < shop.Length; j++)
                    {
                        shop[j - 1] = shop[j];
                    }
                    shop[shop.Length - 1] = 0;
                    nextSlot--;
                }
                if (shop[i] == ItemID.Gatligator)
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
                    if (NPC.downedBoss3)
                    {
                        bool foundBeetle = false;
                        for (int i = 0; i < shop.item.Length; i++)
                        {
                            if (shop.item[i].type == ItemID.EmptyBullet)
                            {
                                foundBeetle = true;
                            }
                        }
                        if (!foundBeetle)
                        {
                            shop.item[nextSlot].SetDefaults(ItemID.EmptyBullet);
                            nextSlot++;
                        }
                    }
                    if (Main.hardMode) // when will this code run?
                        {
                            shop.item[nextSlot].SetDefaults(ItemID.Gatligator);
                            nextSlot++;
                        }
                        if (NPC.downedPlantBoss) // when will this code run?
                        {
                            shop.item[nextSlot].SetDefaults(ItemID.Uzi);
                            nextSlot++;
                        }
                    
                    break;
                case NPCID.Wizard:
                    shop.item[nextSlot].SetDefaults(ItemID.FastClock);
                    nextSlot++;
                    break;
                case NPCID.SkeletonMerchant:
                    if (Main.hardMode)
                    {
                        shop.item[nextSlot].SetDefaults(ItemType<PowerBrew>());
                        nextSlot++;
                        break;
                    }
                    if (Main.moonPhase == 2 || Main.moonPhase == 8)
                    {
                        shop.item[nextSlot].SetDefaults(ItemID.Rally);
                        nextSlot++; 
                        break;
                    }
                    if (Main.moonPhase == 4 || Main.moonPhase == 6)
                    {
                        shop.item[nextSlot].SetDefaults(ItemID.ChainKnife);
                        nextSlot++; 
                        break;
                    }
                    if (Main.moonPhase == 3 || Main.moonPhase == 7)
                    {
                        shop.item[nextSlot].SetDefaults(ItemID.BoneSword);
                        nextSlot++; 
                        break;
                    }
                    if (Main.moonPhase == 1 || Main.moonPhase == 5)
                    {
                        shop.item[nextSlot].SetDefaults(ItemID.BookofSkulls);
                        nextSlot++;
                        break;
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
                case NPCID.WitchDoctor:
                    if (Main.dayTime)
                    {
                        bool foundBeetle = false;
                        for (int i = 0; i < shop.item.Length; i++)
                        {
                            if (shop.item[i].type == ItemID.HerculesBeetle)
                            {
                                foundBeetle = true;
                            }
                        }
                        if (!foundBeetle)
                        {
                            shop.item[nextSlot].SetDefaults(ItemID.HerculesBeetle);
                            nextSlot++;
                        }    
                    }
                    break;
                case NPCID.Pirate:
                    shop.item[nextSlot].SetDefaults(ItemID.ThePlan);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.TrifoldMap);
                    nextSlot++;
                    break;
                case NPCID.DD2Bartender:
                    if (!TRAEWorld.downedOgre)
                    {        
                        int[] ArmorList = new int[] { ItemID.HuntressWig, ItemID.HuntressPants, ItemID.HuntressJerkin,
                                                      ItemID.SquireGreatHelm, ItemID.SquirePlating, ItemID.SquireGreaves,
                                                      ItemID.MonkBrows, ItemID.MonkPants, ItemID.MonkShirt ,
                                                      ItemID.ApprenticeHat, ItemID.ApprenticeRobe, ItemID.ApprenticeTrousers,
                        
   
                        };

                        for (int i = 0; i < shop.item.Length; i++)
                        {
                            for (int k = 0; k < ArmorList.Length; k++)
                            {
                                if (shop.item[i].type == ArmorList[k])
                                {
                                    shop.item[i].type = ItemID.None;
                                }
                            }
                        }
                    }
                    if (!TRAEWorld.downedBetsy)
                    {
                        int[] ArmorList = new int[] { ItemID.HuntressAltHead, ItemID.HuntressAltPants, ItemID.HuntressAltShirt,
                                                      ItemID.SquireAltHead, ItemID.SquireAltShirt, ItemID.SquireAltPants,
                                                      ItemID.MonkAltHead, ItemID.MonkAltShirt, ItemID.MonkAltPants ,
                                                      ItemID.ApprenticeAltHead, ItemID.ApprenticeAltShirt, ItemID.ApprenticeAltPants,


                        };

                        for (int i = 0; i < shop.item.Length; i++)
                        {
                            for (int k = 0; k < ArmorList.Length; k++)
                            {
                                if (shop.item[i].type == ArmorList[k])
                                {
                                    shop.item[i].type = ItemID.None;

                                }
                            }
                        }
                    }
                    break;
            }
        
        }
    }
}
