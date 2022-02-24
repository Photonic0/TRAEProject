using Microsoft.Xna.Framework;
using System;
using Terraria.Audio;
using Terraria.ID;
using TRAEProject.NewContent.Buffs;
using TRAEProject.NewContent.Projectiles;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using TRAEProject.Changes;
using System.Collections.Generic;

namespace TRAEProject
{
    public class Progression : GlobalNPC
    {
        public override bool PreKill(NPC npc)
        {
            if (npc.type == NPCID.WallofFlesh)
            {
                NPC.downedMechBoss1 = true;
                NPC.downedMechBoss2 = true;
                NPC.downedMechBoss3 = true;
            }
            if (npc.type == NPCID.Plantera)
            {
                NPC.downedGolemBoss = true;
            }
            return true;
        }
    }
}
    




