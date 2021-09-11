using Terraria;
using TRAEProject.Items.Summoner.AbsoluteZero;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace TRAEProject
{
    public class EnemyDrops: GlobalNPC
    {
        public static readonly int[] IceQueenDrops = new int[] { ItemID.SnowmanCannon, ItemID.BlizzardStaff, ItemID.NorthPole, ItemType<AbsoluteZero>()};
        public override bool PreKill(NPC npc)
        {
            NPCLoader.blockLoot.Add(ItemID.FrostStaff);
            if (npc.aiStyle == 18)
            {
                if (Main.rand.Next(33) == 0)
                {
                    Item.NewItem(npc.getRect(), ItemID.JellyfishNecklace, 1);
                    NPCLoader.blockLoot.Add(ItemID.JellyfishNecklace);
                }
                return true;
            }
            switch (npc.type)
            {
                case NPCID.IceQueen:
                    {
                        NPCLoader.blockLoot.Add(IceQueenDrops.Length);
                        Item.NewItem(npc.getRect(), Main.rand.Next(IceQueenDrops.Length), 1);
						Item.NewItem(npc.getRect(), ItemType<IceQueenJewel>(), 1);
                    }
                    return true;
                case NPCID.SkeletronHead:
                    {
                        NPCLoader.blockLoot.Add(ItemID.BookofSkulls);
                    }
                    return true;
                case NPCID.DesertGhoul:
                case NPCID.DesertGhoulHallow:
                case NPCID.DesertGhoulCorruption:
                case NPCID.DesertGhoulCrimson:
                case NPCID.DesertLamiaDark:
                case NPCID.DesertLamiaLight:
                    if (Main.rand.Next(9) == 0)
                    {
                        Item.NewItem(npc.getRect(), ItemID.AncientCloth, 1);
                    }
                    NPCLoader.blockLoot.Add(ItemID.AncientCloth);
                    return true;
                case NPCID.Tim:
                    int chance = 4;
                    chance = Main.expertMode ? chance : 2;
                    if (Main.rand.Next(chance) == 0)
                    {
                        Item.NewItem(npc.getRect(), ItemID.BookofSkulls, 1);
                    }
                    return true;
                case NPCID.JungleCreeper:
                case NPCID.JungleCreeperWall:
                    {
                        if (Main.rand.Next(50) == 0)
                        {
                            Item.NewItem(npc.getRect(), ItemID.PoisonStaff, 1);
                        }
                    }
                    return true;
                case NPCID.BlackRecluse:
                case NPCID.BlackRecluseWall:
                    NPCLoader.blockLoot.Add(ItemID.PoisonStaff);
                    return true;
                case NPCID.ScutlixRider:
                case NPCID.BrainScrambler:
                    if (Main.rand.Next(50) == 0)
                    {
                        Item.NewItem(npc.getRect(), ItemID.BrainScrambler, 1);
                    }
                    return true;
                case NPCID.ArmoredSkeleton:
                    if (Main.rand.Next(100) == 0)
                    {
                        Item.NewItem(npc.getRect(), ItemID.DualHook, 1);
                    }
                    return true;
                case NPCID.SkeletonArcher:
                    {
                        if (Main.rand.Next(100) == 0)
                        {
                            Item.NewItem(npc.getRect(), ItemID.DualHook, 1);
                        }
                        if (Main.rand.Next(50) == 0)
                        {
                            Item.NewItem(npc.getRect(), ItemID.MagicQuiver, 1);
                            NPCLoader.blockLoot.Add(ItemID.MagicQuiver);
                        }
                    }
                    return true;
                case NPCID.Mimic:
                case NPCID.IceMimic:
                    {
                        int drop = Main.rand.Next(5);
                        if (drop == 0)
                        {
                            Item.NewItem(npc.getRect(), ItemID.PhilosophersStone, 1);
                        }
                        if (drop == 1)
                        {
                            Item.NewItem(npc.getRect(), ItemID.StarCloak, 1);
                        }
                        if (drop == 2)
                        {
                            Item.NewItem(npc.getRect(), ItemID.TitanGlove, 1);
                        }
                        if (drop == 3)
                        {
                            Item.NewItem(npc.getRect(), ItemID.CrossNecklace, 1);
                        }
                        if (drop == 4)
                        {
                            Item.NewItem(npc.getRect(), ItemID.MagicDagger, 1);
                        }
                        NPCLoader.blockLoot.Add(ItemID.StarCloak);
                        NPCLoader.blockLoot.Add(ItemID.PhilosophersStone);
                        NPCLoader.blockLoot.Add(ItemID.TitanGlove);
                        NPCLoader.blockLoot.Add(ItemID.CrossNecklace);
                        NPCLoader.blockLoot.Add(ItemID.DualHook);
                    }
                    return true;
                case NPCID.BigMimicHallow:
                    {
                        int drop = Main.rand.Next(3);
                        int hook = Main.rand.Next(4);
                        if (drop == 0)
                        {
                            Item.NewItem(npc.getRect(), ItemID.DaedalusStormbow, 1);
                        }
                        if (drop == 1)
                        {
                            Item.NewItem(npc.getRect(), ItemID.CrystalVileShard, 1);
                        }
                        if (drop == 2)
                        {
                            Item.NewItem(npc.getRect(), ItemID.FlyingKnife, 1);
                        }
                        if (hook == 0)
                        {
                            Item.NewItem(npc.getRect(), ItemID.IlluminantHook, 1);
                        }
                        NPCLoader.blockLoot.Add(ItemID.DaedalusStormbow);
                        NPCLoader.blockLoot.Add(ItemID.CrystalVileShard);
                        NPCLoader.blockLoot.Add(ItemID.FlyingKnife);
                        NPCLoader.blockLoot.Add(ItemID.IlluminantHook);
                    }
                    return true;
                case NPCID.BigMimicCrimson:
                    {
                        int drop = Main.rand.Next(4);
                        int hook = Main.rand.Next(4);
                        if (drop == 0)
                        {
                            Item.NewItem(npc.getRect(), ItemID.DartPistol, 1);
                        }
                        if (drop == 1)
                        {
                            Item.NewItem(npc.getRect(), ItemID.SoulDrain, 1);
                        }
                        if (drop == 2)
                        {
                            Item.NewItem(npc.getRect(), ItemID.FetidBaghnakhs, 1);
                        }
                        if (drop == 3)
                        {
                            Item.NewItem(npc.getRect(), ItemID.FleshKnuckles, 1);
                        }
                        if (hook == 0)
                        {
                            Item.NewItem(npc.getRect(), ItemID.TendonHook, 1);
                        }
                        NPCLoader.blockLoot.Add(ItemID.DartPistol);
                        NPCLoader.blockLoot.Add(ItemID.SoulDrain);
                        NPCLoader.blockLoot.Add(ItemID.FetidBaghnakhs);
                        NPCLoader.blockLoot.Add(ItemID.FleshKnuckles);
                        NPCLoader.blockLoot.Add(ItemID.TendonHook);
                    }
                    return true;
                case NPCID.BigMimicCorruption:
                    {
                        int drop = Main.rand.Next(4);
                        int hook = Main.rand.Next(4);
                        if (drop == 0)
                        {
                            Item.NewItem(npc.getRect(), ItemID.DartRifle, 1);
                        }
                        if (drop == 1)
                        {
                            Item.NewItem(npc.getRect(), ItemID.PutridScent, 1);
                        }
                        if (drop == 2)
                        {
                            Item.NewItem(npc.getRect(), ItemID.ClingerStaff, 1);
                        }
                        if (drop == 3)
                        {
                            Item.NewItem(npc.getRect(), ItemID.ChainGuillotines, 1);
                        }
                        if (hook == 0)
                        {
                            Item.NewItem(npc.getRect(), ItemID.WormHook, 1);
                        }
                        NPCLoader.blockLoot.Add(ItemID.DartRifle);
                        NPCLoader.blockLoot.Add(ItemID.ClingerStaff);
                        NPCLoader.blockLoot.Add(ItemID.ChainGuillotines);
                        NPCLoader.blockLoot.Add(ItemID.PutridScent);
                        NPCLoader.blockLoot.Add(ItemID.WormHook);
                    }
                    return true;
                case NPCID.PirateShip:
                    {
                        int drop = Main.rand.Next(5);
                        if (drop == 0)
                        {
                            Item.NewItem(npc.getRect(), ItemID.PirateStaff, 1);
                        }
                        if (drop == 1)
                        {
                            Item.NewItem(npc.getRect(), ItemID.LuckyCoin, 1);
                        }
                        if (drop == 2)
                        {
                            Item.NewItem(npc.getRect(), ItemID.CoinGun, 1);
                        }
                        if (drop == 3)
                        {
                            Item.NewItem(npc.getRect(), ItemID.GoldRing, 1);
                        }
                        if (drop == 4)
                        {
                            Item.NewItem(npc.getRect(), ItemID.DiscountCard, 1);
                        }
                        NPCLoader.blockLoot.Add(ItemID.LuckyCoin);
                        NPCLoader.blockLoot.Add(ItemID.CoinGun);
                        NPCLoader.blockLoot.Add(ItemID.PirateStaff);
                        NPCLoader.blockLoot.Add(ItemID.GoldRing);
                        NPCLoader.blockLoot.Add(ItemID.DiscountCard);
                    }
                    return true;
                case NPCID.Wolf:
                    if (Main.rand.Next(66) == 0)
                    {
                        Item.NewItem(npc.getRect(), ItemID.MoonCharm, 1);
                    }
                    return true;
                case NPCID.NebulaHeadcrab:
                    if (Main.rand.Next(4) == 0)
                    {
                        Item.NewItem(npc.getRect(), ItemID.Heart, 1);
                        NPCLoader.blockLoot.Add(ItemID.Heart);
                    }
                    return true;
                case NPCID.VortexLarva:
                    if (Main.rand.Next(3) == 0)
                    {
                        Item.NewItem(npc.getRect(), ItemID.Heart, 1);
                        NPCLoader.blockLoot.Add(ItemID.Heart);
                    }
                    return true;
                case NPCID.Probe:
                    if (Main.expertMode)
                    {
                        Item.NewItem(npc.getRect(), ItemID.Heart, 1);
                        NPCLoader.blockLoot.Add(ItemID.Heart);
                    }
                    return true;
                case NPCID.Medusa:
                    if (Main.rand.Next(20) == 0)
                    {
                        Item.NewItem(npc.getRect(), ItemID.PocketMirror, 1);
                    }
                    NPCLoader.blockLoot.Add(ItemID.PocketMirror);
                    return true;
                case NPCID.IceTortoise:
                    if (Main.rand.Next(50) == 0)
                    {
                        Item.NewItem(npc.getRect(), ItemID.FrozenTurtleShell, 1);
                    }
                    NPCLoader.blockLoot.Add(ItemID.FrozenTurtleShell);
                    return true;
                case NPCID.DesertBeast:
                    if (Main.rand.Next(25) == 0)
                    {
                        Item.NewItem(npc.getRect(), ItemID.AncientHorn, 1);
                    }
                    NPCLoader.blockLoot.Add(ItemID.AncientHorn);
                    return true;
                case NPCID.LavaSlime:
                    if (Main.rand.Next(50) == 0)
                    {
                        Item.NewItem(npc.getRect(), ItemID.LavaCharm, 1);
                    }
                    return true;
                case NPCID.Shark:
                    if (Main.rand.Next(33) == 0)
                    {
                        Item.NewItem(npc.getRect(), ItemID.DivingHelmet, 1);
                        NPCLoader.blockLoot.Add(ItemID.DivingHelmet);
                    }
                    return true;
            }
            return true;
        }
	}
}