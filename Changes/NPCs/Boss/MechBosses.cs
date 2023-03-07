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
                case NPCID.TheDestroyer:
                   
                        npc.damage = 125;
				        npc.lifeMax = (int)(npc.lifeMax  * ((float)55000 / 80000));

                    
                    break;
                case NPCID.Probe:
                    {
                        npc.lifeMax = 300;
                    }
                    break;
                
            }
        }
        public override void ApplyDifficultyAndPlayerScaling(NPC npc, int numPlayers, float balance, float bossAdjustment)
        {
         
                switch (npc.type)
                {
                    case NPCID.TheDestroyer:
                        
                            npc.damage = 220;
                            npc.lifeMax = (int)(npc.lifeMax * 0.75);
                        
                        break;
                    case NPCID.Probe:
                        
                            npc.knockBackResist = 0f;
                            npc.scale *= 1.15f;
                            npc.height = (int)(npc.height * 1.25);
                            npc.width = (int)(npc.height * 1.25);
                            npc.knockBackResist = 0f;
                            npc.defense = 50;
                        
                        return;
                }
            
        }
        public override bool StrikeNPC(NPC npc, ref double damage, int defense, ref float knockback, int hitDirection, ref bool crit)
        {
            switch (npc.type)
            {
                case NPCID.TheDestroyerBody:
                    if (Main.expertMode)
                    {
                        int probecount = 0;
                        double probedr = damage * 0.05;
                        foreach (NPC enemy in Main.npc)
                        {
                            if (enemy.active && enemy.type == NPCID.Probe)
                            {
                                ++probecount;
                                damage *= 1 - 0.05 * probedr;
                            }
                        }
                        if (probecount > 5)
                        {
                            for (int i = 0; i < 2; i++)
                            {
                                int num = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 182, 0f, 0f, 100, default, 3.5f);
                                Main.dust[num].noGravity = true;
                                Main.dust[num].noLight = true;
                            }
                        }
                    }
                    return true;
                case NPCID.TheDestroyerTail:

                    
                        Terraria.Audio.SoundEngine.PlaySound(SoundID.Item92, npc.position);
                        for (int i = 0; i < 25; i++)
                        {
                            int num = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 182, 0f, 0f, 100, default, 2f);
                            Main.dust[num].noGravity = true;
                            Main.dust[num].noLight = true;
                        }
                    
                    return true;
            }
            return true;
        }
        public override void AI(NPC npc)
        {
            switch(npc.aiStyle)
            {
                case 37://Destroyer
           
                        if (npc.type == NPCID.TheDestroyerTail)
                        {
                            npc.takenDamageMultiplier = 2f;
                        }
                    
                    return;
            }
        }
    }  
}
