using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;


namespace TRAEProject.Changes.NPCs.Boss.Dreadnautilus
{
    public class BloodSquid : GlobalNPC
    {
        public override void SetDefaults(NPC npc)
        {
            if(npc.type == NPCID.BloodSquid)
            {
                npc.lifeMax = 333;
                npc.damage = 100;
            }
        }
        public override void AI(NPC npc)
        {
            if (npc.type == NPCID.BloodSquid)
            {
                Lighting.AddLight(npc.Center, 0.8f, 0.6f, 0.6f);

            }
        }

    }
}
