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
          
                        npc.lifeMax = 24000;
                        npc.defense = 20;
                   
                    break;
                case NPCID.PrimeVice:
                   
                        npc.lifeMax = 12000;
                    
                    break;
                case NPCID.PrimeLaser:
                    
                        npc.lifeMax = 6000;
                        npc.damage = 90;
                    
                    break;
                case NPCID.PrimeSaw:
                 
                        npc.lifeMax = 6000;
                        npc.damage = 90;
                    
                    break;
                case NPCID.TheDestroyer:
                   
                        npc.damage = 125;
                        npc.lifeMax = 70000;
                    
                    break;
                case NPCID.Probe:
                    {
                        npc.lifeMax = 300;
                    }
                    break;
                
            }
        }
        public override void ScaleExpertStats(NPC npc, int numPlayers, float bossLifeScale)
        {
         
                switch (npc.type)
                {
                    case NPCID.Retinazer:
                       
                            npc.lifeMax -= (int)(npc.lifeMax * 0.04);
                        return;
                    case NPCID.Spazmatism:
                        
                            npc.lifeMax -= (int)(npc.lifeMax * 0.05);
                        
                        return;
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
                case 31://Spazmatism
                    if (Main.expertMode)
                    {
                        if (npc.ai[1] == 0f && npc.ai[0] != 1f && npc.ai[0] != 2f && npc.ai[0] != 0f)
                        {
                            if (npc.ai[1] == 0f)
                            {
                                float speed = 2.7f;
                                float tenpercent = 0.2f;
                                int num425 = 1;
                                if (npc.position.X + (float)(npc.width / 2) < Main.player[npc.target].position.X + (float)Main.player[npc.target].width)
                                {
                                    num425 = -1;
                                }
                                Vector2 spazposition = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                                float playerpositionX = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) + (float)(num425 * 180) - spazposition.X;
                                float playerpositionY = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - spazposition.Y;
                                float playerpositiontospaz = (float)Math.Sqrt((double)(playerpositionX * playerpositionX + playerpositionY * playerpositionY));
                                if (Main.expertMode)
                                {
                                    if (playerpositiontospaz > 300f)
                                    {
                                        speed += 0.5f;
                                    }
                                    if (playerpositiontospaz > 400f)
                                    {
                                        speed += 0.5f;
                                    }
                                    if (playerpositiontospaz > 500f)
                                    {
                                        speed += 0.75f;
                                    }
                                    if (playerpositiontospaz > 600f)
                                    {
                                        speed += 0.75f;
                                    }
                                    if (playerpositiontospaz > 700f)
                                    {
                                        speed += 0.9f;
                                    }
                                    if (playerpositiontospaz > 800f)
                                    {
                                        speed += 0.9f;
                                    }
                                }
                                playerpositiontospaz /= speed;
                                playerpositionX *= playerpositiontospaz;
                                playerpositionY *= playerpositiontospaz;
                                if (npc.velocity.X < playerpositionX)
                                {
                                    ref float x1 = ref npc.velocity.X; // could maybe be simplified to npc.velocity.X += tenpercent 
                                    x1 += tenpercent;
                                    if (npc.velocity.X < 0f && playerpositionX > 0f)
                                    {
                                        ref float x2 = ref npc.velocity.X;
                                        x2 += tenpercent;
                                    }
                                }
                                else if (npc.velocity.X > playerpositionX)
                                {
                                    ref float x3 = ref npc.velocity.X;
                                    x3 -= tenpercent;
                                    if (npc.velocity.X > 0f && playerpositionX < 0f)
                                    {
                                        ref float x4 = ref npc.velocity.X;
                                        x4 -= tenpercent;
                                    }
                                }
                                if (npc.velocity.Y < playerpositionY)
                                {
                                    ref float x5 = ref npc.velocity.Y;
                                    x5 += tenpercent;
                                    if (npc.velocity.Y < 0f && playerpositionY > 0f)
                                    {
                                        ref float x6 = ref npc.velocity.Y;
                                        x6 += tenpercent;
                                    }
                                }
                                else if (npc.velocity.Y > playerpositionY)
                                {
                                    ref float x7 = ref npc.velocity.Y;
                                    x7 -= tenpercent;
                                    if (npc.velocity.Y > 0f && playerpositionY < 0f)
                                    {
                                        ref float x8 = ref npc.velocity.Y;
                                        x8 -= tenpercent;
                                    }
                                }
                                ref float x = ref npc.ai[2];
                                x += 1f;
                                if (npc.ai[2] >= 400f)
                                {
                                    npc.ai[1] = 1f;
                                    npc.ai[2] = 0f;
                                    npc.ai[3] = 0f;
                                    npc.target = 255;
                                    npc.netUpdate = true;
                                }
                                if (Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))
                                {
                                    ref float y = ref npc.localAI[2];
                                    y += 2f;

                                    if (npc.localAI[2] > 22f)
                                    {
                                        npc.localAI[2] = 0f;
                                        Terraria.Audio.SoundEngine.PlaySound(SoundID.Item34, npc.position);
                                    }
                                    if (Main.netMode != NetmodeID.MultiplayerClient)
                                    {
                                        ref float x9 = ref npc.localAI[1];
                                        x9 += 2f;
                                        if ((double)npc.life < (double)npc.lifeMax * 0.75)
                                        {
                                            ref float x10 = ref npc.localAI[1];
                                            x10 += 1f;
                                        }
                                        if ((double)npc.life < (double)npc.lifeMax * 0.5)
                                        {
                                            ref float y1 = ref npc.localAI[1];
                                            y1 += 1f;
                                        }
                                        if ((double)npc.life < (double)npc.lifeMax * 0.25)
                                        {
                                            ref float y2 = ref npc.localAI[1];
                                            y2 += 1f;
                                        }
                                        if ((double)npc.life < (double)npc.lifeMax * 0.1)
                                        {
                                            ref float y3 = ref npc.localAI[1];
                                            y3 += 2f;
                                        }
                                        if (npc.soundDelay <= 0)
                                        {
                                            Terraria.Audio.SoundEngine.PlaySound(SoundID.ForceRoar, npc.Center);
                                            npc.soundDelay = 240;
                                        }
                                        if (npc.localAI[1] > 8f)
                                        {

                                            

                                        }
                                    }
                                }
                            }
                        }
                    }
                    return;
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
