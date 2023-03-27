using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TRAEProject.Changes.NPCs.Boss
{
    public class MechBosses : GlobalNPC
    {
        public override void SetDefaults(NPC npc)
        {
            switch (npc.type)
            {
                
                case NPCID.SkeletronPrime:
          

				        npc.lifeMax = (int)(npc.lifeMax  * ((float)24000 / 28000));
                        npc.defense = 20;
                   
                    break;
                case NPCID.PrimeVice:
                   
				        npc.lifeMax = (int)(npc.lifeMax  * (float)(12000 / 9000));
                    
                    break;
                case NPCID.PrimeLaser:
                    
                        npc.lifeMax = 6000;
				        npc.lifeMax = (int)(npc.lifeMax  * ((float)6000 / 6000));
                        npc.damage = 90;
                    
                    break;
                case NPCID.PrimeSaw:
				        npc.lifeMax = (int)(npc.lifeMax  * ((float)6000 / 9000));
                        npc.damage = 90;
                    
                    break;
                
            }
        }


    }  
}
