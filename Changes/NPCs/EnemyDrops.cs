using Terraria;
using TRAEProject.NewContent.Items.Weapons.Summoner.AbsoluteZero;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent.ItemDropRules;
using TRAEProject.NewContent.Items.Weapons.Jungla;
using TRAEProject.NewContent.Items.Materials;
using TRAEProject.NewContent.Items.Accesories.ShadowflameCharm;
using TRAEProject.NewContent.Items.Accesories.MechanicalEye;
using TRAEProject.NewContent.Items.Accesories.SpaceBalloon;
using TRAEProject.NewContent.Items.Weapons.Ammo;
using TRAEProject.NewContent.Items.Weapons.HeadHarvester;
using TRAEProject.NewContent.Items.Weapons.SharpLament;

namespace TRAEProject.Changes.NPCs
{
    public class EnemyDrops: GlobalNPC
    {
        public static readonly int[] MimicDrops = new int[] { ItemID.CrossNecklace, ItemID.PhilosophersStone, ItemID.TitanGlove, ItemID.StarCloak, ItemID.DualHook};
       
        public static readonly int[] PirateDrops = new int[] { ItemID.LuckyCoin, ItemID.GoldRing, ItemID.DiscountCard, ItemID.PirateStaff };
      
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            switch (npc.type)
            {
                case NPCID.IcyMerman:
                case NPCID.IceElemental:
                    npcLoot.RemoveWhere(rule =>
                    {
                        if (rule is not CommonDrop drop) // Type of drop you expect here
                            return false;
                        return drop.itemId == ItemID.FrostStaff; // compare more fields if needed
                    });
                    return;
                case NPCID.GreekSkeleton:
                    npcLoot.RemoveWhere(rule =>
                    {
                        if (rule is not CommonDrop drop) // Type of drop you expect here
                            return false;
                        return drop.itemId == ItemID.Javelin; // compare more fields if needed
                    });
                    npcLoot.Add(ItemDropRule.Common(ItemID.Javelin, 25));
                    return;
                case NPCID.IceQueen:
                    {
                        npcLoot.Add(ItemDropRule.OneFromOptionsNotScalingWithLuck(1, ItemType<IceQueenJewel>()));
                        return;
                    }
                case NPCID.Clown:
                    {
                        npcLoot.Add(ItemDropRule.OneFromOptionsNotScalingWithLuck(4, ItemID.WhoopieCushion));
                        npcLoot.Add(ItemDropRule.Common(ItemID.Bananarang, 1));
                        return;
                    }
                case NPCID.SkeletonCommando:
                    {
                        npcLoot.Add(ItemDropRule.Common(ItemType<MechanicalEyeItem>(), 33));
                        return;
                    }
                case NPCID.MartianDrone:
                    {
                        npcLoot.Add(ItemDropRule.Common(ItemType<SpaceBalloonItem>(), 25));
                        return;
                    }
                case NPCID.DesertLamiaDark:
                case NPCID.DesertLamiaLight:
                    npcLoot.Add(ItemDropRule.Common(ItemID.AncientCloth, 8));
                    return;
                case NPCID.Tim:
                    npcLoot.Add(ItemDropRule.Common(ItemID.BookofSkulls, 2));
                    return;
                case NPCID.JungleCreeper:
                case NPCID.JungleCreeperWall:
                    npcLoot.Add(ItemDropRule.Common(ItemID.PoisonStaff, 50));
                    return;
                case NPCID.BlackRecluse:
                case NPCID.BlackRecluseWall:
                    npcLoot.RemoveWhere(rule =>
                    {
                        if (rule is not CommonDrop drop) // Type of drop you expect here
                            return false;
                        return drop.itemId == ItemID.PoisonStaff; // compare more fields if needed
                    });
                    npcLoot.Remove(ItemDropRule.Common(ItemID.PoisonStaff));
                    return;
                case NPCID.ScutlixRider:
                    npcLoot.RemoveWhere(rule =>
                    {
                        if (rule is not CommonDrop drop) // Type of drop you expect here
                            return false;
                        return drop.itemId == ItemID.BrainScrambler; // compare more fields if needed
                    });
                    npcLoot.Add(ItemDropRule.Common(ItemID.BrainScrambler, 30));
                    return;
                case NPCID.BrainScrambler:
                    npcLoot.Add(ItemDropRule.Common(ItemID.BrainScrambler, 30));
                    return;
                case NPCID.IceMimic:
                    npcLoot.Add(ItemDropRule.OneFromOptionsNotScalingWithLuck(1, MimicDrops));
                    return;
                case NPCID.PirateShip:
                    npcLoot.Add(ItemDropRule.OneFromOptionsNotScalingWithLuck(1, PirateDrops));
                    return;
                case NPCID.ArmoredViking:
                    npcLoot.RemoveWhere(rule =>
                    {
                        if (rule is not CommonDrop drop) // Type of drop you expect here
                            return false;
                        return drop.itemId == ItemID.IceSickle; // compare more fields if needed
                    });
                    return;
                case NPCID.IceTortoise:
                    npcLoot.RemoveWhere(rule =>
                    {
                        if (rule is not CommonDrop drop) // Type of drop you expect here
                            return false;
                        return drop.itemId == ItemID.IceSickle; // compare more fields if needed
                    });
                    npcLoot.RemoveWhere(rule =>
                    {
                        if (rule is not CommonDrop drop) // Type of drop you expect here
                            return false;
                        return drop.itemId == ItemID.FrozenTurtleShell; // compare more fields if needed
                    });
                    npcLoot.Add(ItemDropRule.Common(ItemID.FrozenTurtleShell, 50));
                    return;
                case NPCID.GoblinSummoner:
                    npcLoot.Add(ItemDropRule.Common(ItemType<ShadowflameCharmItem>(), 5));
                    return;
                case NPCID.DesertBeast:
                    npcLoot.RemoveWhere(rule =>
                    {
                        if (rule is not CommonDrop drop) // Type of drop you expect here
                            return false;
                        return drop.itemId == ItemID.AncientHorn; // compare more fields if needed
                    });
                    npcLoot.Add(ItemDropRule.Common(ItemID.AncientHorn, 25));
                    return;
                case NPCID.AngryTrapper:
                    npcLoot.RemoveWhere(rule =>
                    {
                        if (rule is not CommonDrop drop) // Type of drop you expect here
                            return false;
                        return drop.itemId == ItemID.Uzi; // compare more fields if needed
                    });                  
                    return;
                case NPCID.CultistBoss:
                    npcLoot.Add(ItemDropRule.BossBag(ItemID.CultistBossBag));
                    return;
                case NPCID.HeadlessHorseman:
                    npcLoot.Add(ItemDropRule.Common(ItemID.TheHorsemansBlade, 8));
                    return;
            }
        }
        public override bool PreKill(NPC npc)
        {
            NPCLoader.blockLoot.Add(ItemID.TrifoldMap);
            NPCLoader.blockLoot.Add(ItemID.FastClock);
            switch (npc.type)
            {
                case NPCID.EyeofCthulhu:
                    if (WorldGen.crimson)
                    {
                        Item.NewItem(npc.GetSource_Loot(), npc.getRect(), ItemType<BloodyArrow>(), Main.rand.Next(20, 50));
                    }
                    return true;
                case NPCID.CultistBoss:
                    if (Main.expertMode)
                    {
                        NPCLoader.blockLoot.Add(ItemID.LunarCraftingStation);
                    }
                    return true;
                case NPCID.SkeletronHead:
                    NPCLoader.blockLoot.Add(ItemID.BookofSkulls);
                    return true;
                case NPCID.Medusa:
                    if (Main.rand.Next(20) == 0)
                    {
                        Item.NewItem(npc.GetSource_Loot(), npc.getRect(), ItemID.PocketMirror, 1);
                    }
                    NPCLoader.blockLoot.Add(ItemID.PocketMirror);
                    return true;
                case NPCID.Plantera:
                    int[] PDrops = new int[] { ItemID.FlowerPow, ItemID.Seedler, ItemID.LeafBlower, ItemID.NettleBurst, ItemID.GrenadeLauncher, ItemID.VenusMagnum };
                    int Drop1 = Main.rand.Next(4);
                    // there is 100% a cleaner way of doing this
                    if (!Main.expertMode && !Main.masterMode)
                    {
                        if (Drop1 == 0)
                        {
                            Item.NewItem(npc.GetSource_Loot(), npc.getRect(), ItemID.FlowerPow, 1);
                            Item.NewItem(npc.GetSource_Loot(), npc.getRect(), ItemID.Seedler, 1);
                        }
                        if (Drop1 == 1)
                        {
                            Item.NewItem(npc.GetSource_Loot(), npc.getRect(), ItemID.LeafBlower, 1);
                            Item.NewItem(npc.GetSource_Loot(), npc.getRect(), ItemID.NettleBurst, 1);
                        }
                        if (Drop1 == 2)
                        {
                            Item.NewItem(npc.GetSource_Loot(), npc.getRect(), ItemType<Jungla>(), 1);
                            Item.NewItem(npc.GetSource_Loot(), npc.getRect(), ItemID.VenusMagnum, 1);
                        }
                        if (Drop1 == 3)
                        {
                            Item.NewItem(npc.GetSource_Loot(), npc.getRect(), ItemID.PygmyStaff, 1);
                            Item.NewItem(npc.GetSource_Loot(), npc.getRect(), Main.rand.Next(PDrops), 1);
                        }
                    }
                    NPCLoader.blockLoot.Add(ItemID.FlowerPow);
                    NPCLoader.blockLoot.Add(ItemID.Seedler);
                    NPCLoader.blockLoot.Add(ItemID.LeafBlower);
                    NPCLoader.blockLoot.Add(ItemID.WaspGun);
                    NPCLoader.blockLoot.Add(ItemID.NettleBurst);
                    NPCLoader.blockLoot.Add(ItemID.GrenadeLauncher);
                    NPCLoader.blockLoot.Add(ItemID.RocketI);
                    NPCLoader.blockLoot.Add(ItemID.VenusMagnum);
                    NPCLoader.blockLoot.Add(ItemID.PygmyStaff);
                    return true;
                case NPCID.MoonLordCore:
                    int[] MLDrops = new int[] { ItemID.Meowmere, ItemID.Terrarian, ItemID.SDMG, ItemID.Celeb2, ItemID.LunarFlareBook, ItemID.LastPrism, ItemID.RainbowWhip, ItemID.StardustDragonStaff };
                    if (!Main.expertMode && !Main.masterMode)
                    {
                        Item.NewItem(npc.GetSource_Loot(), npc.getRect(), Main.rand.Next(MLDrops), 1);
                    }
                    NPCLoader.blockLoot.Add(ItemID.Meowmere);
                    NPCLoader.blockLoot.Add(ItemID.StarWrath);
                    NPCLoader.blockLoot.Add(ItemID.Terrarian);
                    NPCLoader.blockLoot.Add(ItemID.SDMG);
                    NPCLoader.blockLoot.Add(ItemID.Celeb2);
                    NPCLoader.blockLoot.Add(ItemID.LunarFlareBook);
                    NPCLoader.blockLoot.Add(ItemID.LastPrism);
                    NPCLoader.blockLoot.Add(ItemID.RainbowCrystalStaff);
                    NPCLoader.blockLoot.Add(ItemID.MoonlordTurretStaff);
                    return true;
                case NPCID.HallowBoss:
                    int[] HallowDrops = new int[] { ItemID.PiercingStarlight, ItemID.FairyQueenMagicItem, ItemID.FairyQueenRangedItem, ItemID.RainbowCrystalStaff };
                    if (!Main.expertMode && !Main.masterMode)
                    {
                        Item.NewItem(npc.GetSource_Loot(), npc.getRect(), Main.rand.Next(HallowDrops), 1);
                    }
                    NPCLoader.blockLoot.Add(ItemID.PiercingStarlight);
                    NPCLoader.blockLoot.Add(ItemID.FairyQueenMagicItem);
                    NPCLoader.blockLoot.Add(ItemID.FairyQueenRangedItem);
                    NPCLoader.blockLoot.Add(ItemID.RainbowWhip);
                    return true;
                case NPCID.MourningWood:
                    int[] WoodDrops = new int[] { ItemID.SpookyHook, ItemID.SpookyTwig, ItemID.NecromanticScroll, ItemType<SharpLament>(), ItemID.StakeLauncher};
                    int todrop = Main.rand.Next(WoodDrops);
                    if (todrop == ItemID.StakeLauncher)
                        Item.NewItem(npc.GetSource_Loot(), npc.getRect(), ItemID.Stake, Main.rand.Next(25, 50));
                    Item.NewItem(npc.GetSource_Loot(), npc.getRect(), todrop, 1);
                    NPCLoader.blockLoot.Add(ItemID.SpookyHook);
                    NPCLoader.blockLoot.Add(ItemID.SpookyTwig);
                    NPCLoader.blockLoot.Add(ItemID.NecromanticScroll);
                    NPCLoader.blockLoot.Add(ItemID.StakeLauncher);
                    NPCLoader.blockLoot.Add(ItemID.Stake);
                    return true;
                case NPCID.Pumpking:
                    int[] PumpDrops = new int[] { ItemID.CandyCornRifle, ItemID.JackOLanternLauncher, ItemID.RavenStaff, ItemType<HeadHarvester>(), ItemID.BatScepter, ItemID.ScytheWhip, ItemID.BlackFairyDust, ItemID.SpiderEgg };
                    int todrop2 = Main.rand.Next(PumpDrops);
                    if (todrop2 == ItemID.CandyCornRifle)
                        Item.NewItem(npc.GetSource_Loot(), npc.getRect(), ItemID.CandyCorn, Main.rand.Next(25, 50));
                    if (todrop2 == ItemID.JackOLanternLauncher)
                        Item.NewItem(npc.GetSource_Loot(), npc.getRect(), ItemID.JackOLantern, Main.rand.Next(25, 50));
                    Item.NewItem(npc.GetSource_Loot(), npc.getRect(), todrop2, 1);
                    NPCLoader.blockLoot.Add(ItemID.TheHorsemansBlade);
                    NPCLoader.blockLoot.Add(ItemID.CandyCornRifle);
                    NPCLoader.blockLoot.Add(ItemID.JackOLanternLauncher);
                    NPCLoader.blockLoot.Add(ItemID.RavenStaff);
                    NPCLoader.blockLoot.Add(ItemID.BatScepter);
                    NPCLoader.blockLoot.Add(ItemID.BlackFairyDust);
                    NPCLoader.blockLoot.Add(ItemID.ScytheWhip);
                    NPCLoader.blockLoot.Add(ItemID.SpiderEgg);
                    NPCLoader.blockLoot.Add(ItemID.CandyCorn);
                    NPCLoader.blockLoot.Add(ItemID.JackOLantern);
                    return true;
                case NPCID.IceQueen:
                    int[] IceQueenDrops = new int[] { ItemID.SnowmanCannon, ItemID.BlizzardStaff, ItemID.NorthPole, ItemType<AbsoluteZero>() };
                    Item.NewItem(npc.GetSource_Loot(), npc.getRect(), Main.rand.Next(IceQueenDrops), 1);
                    NPCLoader.blockLoot.Add(ItemID.SnowmanCannon);
                    NPCLoader.blockLoot.Add(ItemID.NorthPole);
                    NPCLoader.blockLoot.Add(ItemID.BlizzardStaff);
                    return true;
                case 657: // queen slime
                    NPCLoader.blockLoot.Add(ItemID.Smolstar);
                    return true;
                case NPCID.Mimic:
                    Item.NewItem(npc.GetSource_Loot(), npc.getRect(), Main.rand.Next(MimicDrops), 1);
                    NPCLoader.blockLoot.Add(ItemID.PhilosophersStone);
                    NPCLoader.blockLoot.Add(ItemID.CrossNecklace);
                    NPCLoader.blockLoot.Add(ItemID.StarCloak);
                    NPCLoader.blockLoot.Add(ItemID.DualHook);
                    NPCLoader.blockLoot.Add(ItemID.TitanGlove);
                    return true;
                case NPCID.BigMimicHallow:
                    int[] HDrops = new int[] { ItemID.FlyingKnife, ItemID.DaedalusStormbow, ItemID.CrystalVileShard, ItemID.Smolstar };
                    int Ihook = Main.rand.Next(4); 
                    if (Ihook == 0)
                    {
                        Item.NewItem(npc.GetSource_Loot(), npc.getRect(), ItemID.IlluminantHook, 1);
                    }
                    Item.NewItem(npc.GetSource_Loot(), npc.getRect(), Main.rand.Next(HDrops), 1);
                    NPCLoader.blockLoot.Add(ItemID.FlyingKnife);
                    NPCLoader.blockLoot.Add(ItemID.CrystalVileShard);
                    NPCLoader.blockLoot.Add(ItemID.DaedalusStormbow);
                    NPCLoader.blockLoot.Add(ItemID.IlluminantHook);
                    return true;
					
                case NPCID.BigMimicCrimson:
                    int[] CRDrops = new int[] { ItemID.FetidBaghnakhs, ItemID.SoulDrain, ItemID.DartPistol, ItemID.FleshKnuckles };
                    int Thook = Main.rand.Next(4);
                    if (Thook == 0)
                    {
                        Item.NewItem(npc.GetSource_Loot(), npc.getRect(), ItemID.TendonHook, 1);
                    }
                    Item.NewItem(npc.GetSource_Loot(), npc.getRect(), Main.rand.Next(CRDrops), 1);
                    NPCLoader.blockLoot.Add(ItemID.FetidBaghnakhs);
                    NPCLoader.blockLoot.Add(ItemID.SoulDrain);
                    NPCLoader.blockLoot.Add(ItemID.DartPistol);
                    NPCLoader.blockLoot.Add(ItemID.FleshKnuckles);
                    NPCLoader.blockLoot.Add(ItemID.TendonHook);
                    return true;
                case NPCID.BigMimicCorruption:
                    int[] CDrops = new int[] { ItemID.ChainGuillotines, ItemID.DartRifle, ItemID.ClingerStaff, ItemID.PutridScent };
                    int Whook = Main.rand.Next(4); 
                    if (Whook == 0)
                    {
                        Item.NewItem(npc.GetSource_Loot(), npc.getRect(), ItemID.WormHook, 1);
                    }
                    Item.NewItem(npc.GetSource_Loot(), npc.getRect(), Main.rand.Next(CDrops), 1);
                    NPCLoader.blockLoot.Add(ItemID.ChainGuillotines);
                    NPCLoader.blockLoot.Add(ItemID.ClingerStaff);
                    NPCLoader.blockLoot.Add(ItemID.DartRifle);
                    NPCLoader.blockLoot.Add(ItemID.PutridScent);
                    NPCLoader.blockLoot.Add(ItemID.WormHook);
                    return true;
            }


            return true;
        }
    }
}