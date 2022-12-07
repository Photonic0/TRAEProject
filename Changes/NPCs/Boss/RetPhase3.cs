using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace TRAEProject.Changes.NPCs.Boss 
{
    public static class RetPhase3
    {
        public static void Update(NPC npc)
        {
            npc.defense = npc.defDefense + 10;
			npc.HitSound = SoundID.NPCHit4;
            npc.velocity = Vector2.Zero;
            npc.ai[2]++;
            int tpTime = 30;
            int tpCount = 6;
            int shotTime = 10;
            int shotCount = 3;
            if(npc.ai[1] != -1 && npc.ai[3] != -1)
            {
                Teleport(npc);
            }
            if(npc.ai[2] < tpCount * tpTime && npc.ai[2] % tpTime == 0 )
            {
                SetupTeleport(npc);
            }
            if(npc.ai[2] > tpCount * tpTime + shotTime * shotCount)
            {
                if(npc.ai[2] > tpCount * tpTime + shotTime * shotCount + 60)
                {
                    npc.ai[2] = 0;
                }
            }
            else if(npc.ai[2] > tpCount * tpTime && npc.ai[2] % shotTime == 0)
            {
                Shoot(npc);
            }
            
        }
        static void Teleport(NPC npc)
        {

            TeleportDust(npc.Center);
            npc.Center = new Vector2(npc.ai[1], npc.ai[3]);
            TeleportDust(npc.Center);
            SoundEngine.PlaySound(SoundID.Item8);
            npc.TargetClosest(false);
            Player player = Main.player[npc.target];
            npc.rotation = (player.Center - npc.Center).ToRotation() - (float)Math.PI /2;

            npc.ai[1] = npc.ai[3] = -1;
        }
        static void SetupTeleport(NPC npc)
        {
            if(Main.netMode != NetmodeID.MultiplayerClient)
            {
                npc.TargetClosest(false);
                Player player = Main.player[npc.target];
                float r = Main.rand.NextFloat() * (float)Math.PI * 2;
                Vector2 offset = TRAEMethods.PolarVector(400, r);
                offset.X *= 1.4f;
                Vector2 teleToHere = player.Center + offset;
                npc.ai[1] = teleToHere.X;
                npc.ai[3] = teleToHere.Y;
                npc.netUpdate = true;
            }
        }
        static void TeleportDust(Vector2 center, bool pullIn = false)
        {
            for (int i = 0; i < 100; i++)
            {
                float theta = Main.rand.NextFloat(-(float)Math.PI, (float)Math.PI);
                float radius = 160;
                Dust dust = Dust.NewDustPerfect(center + (pullIn ? TRAEMethods.PolarVector(radius , theta): Vector2.Zero), DustID.SilverFlame, TRAEMethods.PolarVector( (pullIn ? -1 : 1) * radius / 10f, theta));
                dust.color = Color.Red;
                dust.noGravity = true;
            }
        }
        static void Shoot(NPC npc)
        {
            if (Main.netMode != 1)
            {
				float shootSpeed = 10f;
                int attackDamage_ForProjectiles3 = npc.GetAttackDamage_ForProjectiles(35f, 30f);
                int num413 = Projectile.NewProjectile(npc.GetSource_ReleaseEntity(), npc.Center + TRAEMethods.PolarVector(25 * 9, npc.rotation + (float)Math.PI /2), TRAEMethods.PolarVector(shootSpeed, npc.rotation + (float)Math.PI/2), ProjectileID.DeathLaser, attackDamage_ForProjectiles3, 0f, Main.myPlayer);
            }
        }
        public static void Start(NPC npc)
        {
            if (npc.ai[0] == 4f)
            {
                npc.ai[2] += 0.005f;
                if ((double)npc.ai[2] > 0.5)
                {
                    npc.ai[2] = 0.5f;
                }
            }
            else
            {
                npc.ai[2] -= 0.005f;
                if (npc.ai[2] < 0f)
                {
                    npc.ai[2] = 0f;
                }
            }
            npc.rotation += npc.ai[2];
            npc.ai[1] += 1f;
            if (npc.ai[1] >= 100f)
            {
                npc.ai[0] += 1f;
                npc.ai[1] = 0f;
                if (npc.ai[0] == 6f)
                {
                    npc.ai[2] = 0f;
                    npc.ai[1] = -1;
                    npc.ai[3] = -1;
                    npc.netUpdate = true;
                }
                else
                {
                    //SoundEngine.PlaySound(3, (int)npc.position.X, (int)npc.position.Y);
                    for (int num477 = 0; num477 < 20; num477++)
                    {
                        Dust.NewDust(npc.position, npc.width, npc.height, 5, (float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f);
                    }
                    //SoundEngine.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);

                    Terraria.Audio.SoundEngine.PlaySound(SoundID.ForceRoarPitched, npc.Center);
                }
            }
            Dust.NewDust(npc.position, npc.width, npc.height, 5, (float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f);
            npc.velocity.X *= 0.98f;
            npc.velocity.Y *= 0.98f;
            if ((double)npc.velocity.X > -0.1 && (double)npc.velocity.X < 0.1)
            {
                npc.velocity.X = 0f;
            }
            if ((double)npc.velocity.Y > -0.1 && (double)npc.velocity.Y < 0.1)
            {
                npc.velocity.Y = 0f;
            }
        }
    }
}