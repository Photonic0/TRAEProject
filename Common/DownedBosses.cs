using System.IO;
using Terraria.ModLoader.IO;
using Terraria.ModLoader;

using static Terraria.ModLoader.ModContent;
using Terraria;
using TRAEProject.Common;
using Terraria.ID;
using TRAEProject.NewContent.NPCs.GraniteOvergrowth;

namespace TRAEProject.Common
{
    public class TRAEWorld : ModSystem
    {
        public static bool downedOvergrowth = false;
        public static bool downedOgre = false;
        public static bool downedBetsy = false;
        public static bool downedAMech = false;

        // public static bool downedOtherBoss = false;


        public override void OnWorldLoad()
        {
            downedOvergrowth = false;
            downedOgre = false;
            downedBetsy = false; 
            downedAMech = false;
        }

        public override void OnWorldUnload()
        {
            downedOvergrowth = false;
            downedOgre = false;
            downedBetsy = false; 
            downedAMech = false;
        }

        // We save our data sets using TagCompounds.
        // NOTE: The tag instance provided here is always empty by default.
        public override void SaveWorldData(TagCompound tag)
        {
            if (downedOvergrowth)
            {
                tag["downedOvergrowth"] = true;
            }
            if (downedOgre)
            {
                tag["downedOgre"] = true;
            }
            if (downedBetsy)
            {
                tag["downedBetsy"] = true;
            }
            if (downedAMech)
            {
                tag["downedAMech"] = true;
            }
        }

        public override void LoadWorldData(TagCompound tag)
        {
            downedOvergrowth = tag.ContainsKey("downedOvergrowth");
            downedOgre = tag.ContainsKey("downedOgre");
            downedBetsy = tag.ContainsKey("downedBetsy");
            downedAMech = tag.ContainsKey("downedAMech");
        }

        public override void NetSend(BinaryWriter writer)
        {
            // Order of operations is important and has to match that of NetReceive
            var flags = new BitsByte();
            flags[0] = downedOvergrowth;
            flags[1] = downedOgre;
            flags[2] = downedBetsy;
            flags[3] = downedAMech;
            writer.Write(flags);
        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            downedOvergrowth = flags[0];
            downedOgre = flags[2];
            downedBetsy = flags[2];
            downedAMech = flags[3];
        }
    }
}
public class DownedVanillaNPCs : GlobalNPC
{
    public override bool InstancePerEntity => true;
    public override void OnKill(NPC npc)
    {
        if ((npc.type == NPCID.DD2OgreT2 || npc.type == NPCID.DD2OgreT3))
        {
            NPC.SetEventFlagCleared(ref TRAEWorld.downedOgre, -1);
        }
        if (npc.type == NPCID.DD2Betsy)
        {
            NPC.SetEventFlagCleared(ref TRAEWorld.downedBetsy, -1);
        }
        if (npc.type == NPCType<GraniteOvergrowth>())
        {
            NPC.SetEventFlagCleared(ref TRAEWorld.downedOvergrowth, -1);
        }
        if ((npc.type == NPCID.TheDestroyer || npc.type == NPCID.SkeletronPrime || npc.type == NPCID.Spazmatism || npc.type == NPCID.Retinazer))
        {
            NPC.SetEventFlagCleared(ref TRAEWorld.downedAMech, -1);
        }
    }
}