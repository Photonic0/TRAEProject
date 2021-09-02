using TRAEProject.Buffs;
using Microsoft.Xna.Framework;
using Terraria;
using System;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace TRAEProject
{
    public class ChangesNPCs : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        public bool titaPenetrate;
        public bool Heavyburn;
        public bool Decay;
        public bool Toxins;
        public bool Corrupted;
        public bool Omegaburn;
        private readonly bool[] PrimeBonus = new bool[] {NPC.downedMechBoss1, NPC.downedMechBoss2};
        private readonly bool[] TwinsBonus = new bool[] {NPC.downedMechBoss1, NPC.downedMechBoss3};
        private readonly bool[] DestroyerBonus = new bool[] {NPC.downedMechBoss2, NPC.downedMechBoss3};
        public override void ResetEffects(NPC npc)
        {
            Decay = false;
            Toxins = false;
            titaPenetrate = false;
            Heavyburn = false;
            Omegaburn = false;
            Corrupted = false;
        }
        public override void SetDefaults(NPC npc)
        {
            npc.buffImmune[BuffType<TitaPenetrate>()] = npc.buffImmune[BuffID.BoneJavelin];
            npc.buffImmune[BuffType<Decay>()] = npc.buffImmune[BuffID.Frostburn];
            npc.buffImmune[BuffID.Daybreak] = false;
            npc.buffImmune[BuffType<Omegaburn>()] = false;
            switch (npc.type)
            {
                case NPCID.PirateCaptain:
                    npc.lifeMax = 1000;
                    return;
                case NPCID.SkeletronPrime:
                    if (ServerConfig.Instance.MechChanges)
                    {
                        npc.lifeMax = 24000;
                    npc.defense = 20;
                    }
                    return;
                case NPCID.PrimeVice:
                    if (ServerConfig.Instance.MechChanges)
                    {
                        npc.lifeMax = 12000;
                    }
                    return;
                case NPCID.PrimeLaser:
                    if (ServerConfig.Instance.MechChanges)
                    {
                        npc.lifeMax = 6000;
                        npc.damage = 90;
                    }                     
                    return;
                case NPCID.PrimeSaw:
                    if (ServerConfig.Instance.MechChanges)
                    {
                        npc.lifeMax = 6000;
                        npc.damage = 90;
                    }                  
                    return;
                case NPCID.TheDestroyer:
                    if (ServerConfig.Instance.MechChanges)
                    {
                        npc.damage = 125;
                        npc.lifeMax = 80000;
                    }                     
                    return;
				case NPCID.JungleCreeper:
                case NPCID.JungleCreeperWall:
				    {
                        npc.lifeMax = 120;
						npc.damage = 50;
                    npc.defense = 14;
					}
                    return;
                case NPCID.Probe:
                    {
                        npc.lifeMax = 300;
                    }
                    return;
                case NPCID.GigaZapper:
                    npc.knockBackResist = 0f;
                    return;
                case NPCID.VortexSoldier:
                    npc.damage = 110; // up from 90
                    npc.lifeMax = 550; // down from 700
                    npc.knockBackResist = 0.15f; // buffed from 0.6
                    return;
                case NPCID.VortexRifleman:
                    npc.lifeMax = 800; // unchanged
                    return;
                case NPCID.SolarDrakomire:
                    npc.lifeMax = 1250; // up from 800;
                    npc.defense = 48;
                    npc.knockBackResist = 0.4f; // nerfed from 0.2
                    return;
                case NPCID.SolarCorite:
                    npc.lifeMax = 600; // down from 600 
                    /*npc.knockBackResist = 0.7f;*/ // nerfed from 0.2
                    return;
                case NPCID.SolarSolenian:
                    npc.lifeMax = 800; // unchanged from 800 
                    npc.damage = 90; // unchanged from 90
                    npc.knockBackResist = 0.8f; // nerfed from 0.4
                    return;
                case NPCID.SolarSroller:
                    npc.damage = 60; // down from 80
                    npc.knockBackResist = 0.2f; // nerfed from 1
                    return;
                case NPCID.SolarCrawltipedeHead:
                    npc.lifeMax = 25000; // unchanged
                    npc.damage = 70; // down from 150
                    return;
                case NPCID.SolarCrawltipedeBody:
                    npc.damage = 50; // down from 100
                    return;
                case NPCID.SolarCrawltipedeTail:
                    npc.damage = 50; // unchanged
                    return;
                case NPCID.NebulaHeadcrab:
                    npc.damage = 60; // down from 70
                    npc.lifeMax = 480; // up from 330
                    npc.defense = 34; // unchanged from 34
                    npc.knockBackResist = 0.85f;
                    return;
                case NPCID.StardustCellSmall:
                    npc.lifeMax = 300; // unchanged from 300
                    npc.damage = 40;
                    return;
                case NPCID.StardustCellBig:
                    npc.lifeMax = 400; // up from 300
                    npc.damage = 40;
                    return;
                case NPCID.StardustJellyfishBig:
                    npc.lifeMax = 2000; // up from 1500
                    return;
                case NPCID.StardustSpiderBig:
                    npc.scale = 1.5f;
                    npc.width = 63;
                    npc.height = 54;
                    //npc.lifeMax = 3200;
                    npc.knockBackResist = 0.05f;
                    return;
                case NPCID.StardustWormHead:
                    npc.lifeMax = 3300;
                    npc.defense = 50;
                    return;
                case NPCID.MoonLordHead:
                    npc.width = 51;
                    npc.height = 81;
                    return;
            }
        }
        public override void OnHitPlayer(NPC npc, Player target, int damage, bool crit)
        {
            switch (npc.type)
            {
                case NPCID.StardustCellBig:
                    {
                        int length = Main.rand.Next(90, 180);
                        target.AddBuff(BuffType<Celled>(), length, false);
                    }
                    return;
                case NPCID.SolarSroller:
                    if (Main.expertMode && npc.ai[0] == 6.0 /*&& npc.ai[3] > 0 && npc.ai[3] < 4.0*/)
                    {
                        int length = Main.rand.Next(300, 480);
                        target.AddBuff(BuffID.Dazed, length, false);
                    }
                    return;
            }
        }
        public override void ScaleExpertStats(NPC npc, int numPlayers, float bossLifeScale)
        {
            if (ServerConfig.Instance.MechChanges)
            {
                switch (npc.type)
                {
                    //case NPCID.SkeletronPrime:
                    //case NPCID.PrimeVice:
                    //case NPCID.PrimeSaw:
                    //case NPCID.PrimeLaser:
                    //case NPCID.PrimeCannon:
                    //    for (int i = 0; i < PrimeBonus.Length; ++i) // repeats it three times for each mech
                    //    {
                    //        if (PrimeBonus[i]) // checks if that mech boss has been defeated
                    //        {
                    //            npc.lifeMax += (int)(npc.lifeMax * 0.05); // increases health by 5% for each one
                    //            double toround = npc.lifeMax / 100; // divides it by 100
                    //            npc.lifeMax = (int)(Math.Round(toround, 0) * 100); // rounds that decimal to the nearest whole number and then multiplies by 100 again 
                    //            npc.damage += (int)(npc.damage * 0.1);
                    //        }
                    //    }
                    //    return;
                    case NPCID.Retinazer:
                        if (ServerConfig.Instance.MechChanges)
                            npc.lifeMax -= (int)(npc.lifeMax * 0.04);
                        //for (int i = 0; i < TwinsBonus.Length; ++i) // repeats it three times for each mech
                        //{
                        //    if (TwinsBonus[i]) // checks if that mech boss has been defeated
                        //    {
                        //        npc.lifeMax += (int)(npc.lifeMax * 0.05); // increases health by 5% for each one
                        //        double toround = npc.lifeMax / 100; // divides it by 100
                        //        npc.lifeMax = (int)(Math.Round(toround, 0) * 100); // rounds that decimal to the nearest whole number and then multiplies by 100 again 
                        //        npc.damage += (int)(npc.damage * 0.1);
                        //    }
                        //}
                        return;
                    case NPCID.Spazmatism:
                        if (ServerConfig.Instance.MechChanges)
                        { 
                            npc.lifeMax -= (int)(npc.lifeMax * 0.05); 
                        }                       
                        //for (int i = 0; i < TwinsBonus.Length; ++i) // repeats it three times for each mech
                        //{
                        //    if (TwinsBonus[i]) // checks if that mech boss has been defeated
                        //    {
                        //        npc.lifeMax += (int)(npc.lifeMax * 0.05); // increases health by 5% for each one
                        //        double toround = npc.lifeMax / 100; // divides it by 100
                        //        npc.lifeMax = (int)(Math.Round(toround, 0) * 100); // rounds that decimal to the nearest whole number and then multiplies by 100 again 
                        //        npc.damage += (int)(npc.damage * 0.1);
                        //    }
                        //}
                        return;
                    case NPCID.TheDestroyer:
                        if (ServerConfig.Instance.MechChanges)
                        {
                            npc.damage = 220;
                            npc.lifeMax = (int)(npc.lifeMax * 0.95);
                        }                      
                        //npc.damage = (int)(npc.damage * 0.85);
                        //for (int i = 0; i < DestroyerBonus.Length; ++i) // repeats it three times for each mech
                        //{
                        //    if (DestroyerBonus[i]) // checks if that mech boss has been defeated
                        //    {
                        //        npc.lifeMax += (int)(npc.lifeMax * 0.05); // increases health by 5% for each one
                        //        double toround = npc.lifeMax / 100; // divides it by 100
                        //        npc.lifeMax = (int)(Math.Round(toround, 0) * 100); // rounds that decimal to the nearest whole number and then multiplies by 100 again 
                        //        npc.defDamage += (int)(npc.damage * 0.1);
                        //    }
                        //}
                        return;
                    case NPCID.TheDestroyerBody:
                        if (ServerConfig.Instance.MechChanges)
                        npc.damage = (int)(npc.damage * 1.20);
                        //npc.defense = 20;  
                        //for (int i = 0; i < DestroyerBonus.Length; ++i) // repeats it three times for each mech
                        //{
                        //    if (DestroyerBonus[i]) // checks if that mech boss has been defeated
                        //    {
                        //        npc.defDamage += (int)(npc.damage * 0.1);
                        //    }
                        //}
                        return;
                    case NPCID.Probe:
                        if (ServerConfig.Instance.MechChanges)
                        { 
                        npc.knockBackResist = 0f;
                        npc.scale *= 1.15f;
                        npc.height = (int)(npc.height * 1.25);
                        npc.width = (int)(npc.height * 1.25);
                        npc.knockBackResist = 0f;
                        npc.defense = 50;
                        }
                        //for (int i = 0; i < DestroyerBonus.Length; ++i) // repeats it three times for each mech
                        //{
                        //    if (DestroyerBonus[i]) // checks if that mech boss has been defeated
                        //    {
                        //        npc.lifeMax += (int)(npc.lifeMax * 0.05); // increases health by 5% for each one
                        //        double toround = npc.lifeMax / 10; // divides it by 100
                        //        npc.lifeMax = (int)(Math.Round(toround, 0) * 10); // rounds that decimal to the nearest whole number and then multiplies by 100 again 
                        //        npc.defDamage += (int)(npc.damage * 0.1);
                        //    }
                        //}
                        return;
                }
            }
            switch (npc.type)
            {
                case NPCID.SolarFlare:
                    npc.lifeMax = 200;
                    return;
                case NPCID.SolarSpearman:
                    npc.knockBackResist = 0f;
                    return;
                case NPCID.StardustSpiderSmall:
                    npc.knockBackResist = 0f;
                    return;
            }
        }
        public int moths = 0;
        public float braintimer = 0;
        public override bool PreAI(NPC npc)
        {
            if (npc.HasBuff(BuffID.Frozen))
            {
                npc.velocity = Vector2.Zero;
                return false;
            }
            return base.PreAI(npc);
        }
        public override void AI(NPC npc)
        {
            if (npc.HasBuff(BuffID.Weak))
            {
                npc.damage = (int)(npc.defDamage * 0.85f);   
            }
            switch (npc.type)
            {
                
                //case NPCID.Mothron:    
                //    if (!NPC.downedPlantBoss)
                //    {
                //        npc.life = 0;
                //    }
                //    if (Main.expertMode)
                //    {
                //        if (moths < 3)
                //        {
                //            int moth = NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.MothronSpawn);
                //            ++moths;
                //        }
                //    }
                //    return;
                case NPCID.SolarCorite:
                    npc.knockBackResist = 0.2f;
                    return;
                case NPCID.SolarSolenian:
                    npc.reflectsProjectiles = false;
                    npc.takenDamageMultiplier = 1f;
                    return;
                case NPCID.StardustSpiderSmall:
                    int spidres = Main.rand.Next(1, 2);
                    if (npc.ai[2] < spidres && Main.expertMode)
                    {
                        int spider = NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.StardustSpiderSmall);
                        Main.npc[spider].velocity = npc.velocity;
                        Main.npc[spider].ai[2] = spidres;
                        npc.ai[2] += 1f;
                    }
                    return;
                case NPCID.SolarCrawltipedeHead:
                    if (npc.ai[2] < 2f)
                    {
                        int worms = NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.SolarCrawltipedeHead);
                        Main.npc[worms].ai[2] = 2f;
                        npc.ai[2] += 1f;
                    }
                    return;
                case NPCID.LunarTowerNebula:
                    if (Main.expertMode)
                    {
                        braintimer += 1f;
                        if (braintimer == 1200f && npc.HasPlayerTarget)
                        {
                            for (int i = 0; i < Main.rand.Next(5, 7); i++)
                            {
                                NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.NebulaHeadcrab);
                                for (int x = 0; x < Main.rand.Next(10, 15); x++)
                                {
                                    Dust dust = Dust.NewDustDirect(npc.position, npc.width, npc.height, 243, 0f, 0f, 0, default, 1);
                                    dust.noLight = true;
                                    dust.velocity *= 0.5f;
                                }
                            }
                            braintimer = 0f;
                        }
                    }
                    return;
            }
            switch (npc.aiStyle)
            {
                case 85: // Stardust Cell AND Brain Suckler
                    if (npc.type == NPCID.StardustCellBig && Main.expertMode) //only for the Cell, on Expert
                    {
                        npc.noTileCollide = false;
                        if (npc.ai[0] == 0f)
                        {
                            npc.TargetClosest(true);
                            if (Collision.CanHit(npc.Center, 1, 1, Main.player[npc.target].Center, 1, 1))
                            {
                                npc.ai[0] = 1f;
                            }
                            else
                            {
                                Vector2 value31 = Main.player[npc.target].Center - npc.Center;
                                ref float x = ref value31.Y;
                                x -= (Main.player[npc.target].height / 4);
                                float num1256 = value31.Length();
                                if (num1256 > 800f)
                                {
                                    npc.ai[0] = 2f;
                                }
                                else
                                {
                                    Vector2 center33 = npc.Center;
                                    center33.X = Main.player[npc.target].Center.X;
                                    Vector2 vector216 = center33 - npc.Center;
                                    if (vector216.Length() > 8f && Collision.CanHit(npc.Center, 1, 1, center33, 1, 1))
                                    {
                                        npc.ai[0] = 3f;
                                        npc.ai[1] = center33.X;
                                        npc.ai[2] = center33.Y;
                                        Vector2 center34 = npc.Center;
                                        center34.Y = Main.player[npc.target].Center.Y;
                                        if (vector216.Length() > 8f && Collision.CanHit(npc.Center, 1, 1, center34, 1, 1) && Collision.CanHit(center34, 1, 1, Main.player[npc.target].position, 1, 1))
                                        {
                                            npc.ai[0] = 3f;
                                            npc.ai[1] = center34.X;
                                            npc.ai[2] = center34.Y;
                                        }
                                    }
                                    else
                                    {
                                        center33 = npc.Center;
                                        center33.Y = Main.player[npc.target].Center.Y;
                                        vector216 = center33 - npc.Center;
                                        if (vector216.Length() > 8f && Collision.CanHit(npc.Center, 1, 1, center33, 1, 1))
                                        {
                                            npc.ai[0] = 3f;
                                            npc.ai[1] = center33.X;
                                            npc.ai[2] = center33.Y;
                                        }
                                    }
                                    if (npc.ai[0] == 0f)
                                    {
                                        npc.localAI[0] = 0f;
                                        value31.Normalize();
                                        value31 *= 0.5f;
                                        npc.velocity += value31;
                                        npc.ai[0] = 4f;
                                        npc.ai[1] = 0f;
                                    }
                                }
                            }
                        }
                        if (npc.ai[0] == 1f)  // MAY BE THE ONLY PART THAT SHOULD BE HERE
                        {
                            npc.rotation += npc.direction * 0.3f;
                            Vector2 value32 = Main.player[npc.target].Center - npc.Center;
                            float num1257 = value32.Length();
                            float num1258 = 14f; //changed from 5.5f
                            num1258 += num1257 / 100f;
                            int num1259 = 50;
                            value32.Normalize();
                            value32 *= num1258;
                            npc.velocity = (npc.velocity * (num1259 - 1) + value32) / num1259;
                            if (!Collision.CanHit(npc.Center, 1, 1, Main.player[npc.target].Center, 1, 1))
                            {
                                npc.ai[0] = 0f;
                                npc.ai[1] = 0f;
                            }
                        }
                        else if (npc.ai[0] == 2f)
                        {
                            npc.rotation = npc.velocity.X * 0.1f;
                            npc.noTileCollide = true;
                            Vector2 value33 = Main.player[npc.target].Center - npc.Center;
                            float num1261 = value33.Length();
                            float scaleFactor11 = 3f; // MAYBE THIS ONE OR THE ONE BELOW AFFECTS SPEED TOO
                            int num1262 = 3;
                            value33.Normalize();
                            value33 *= scaleFactor11;
                            npc.velocity = (npc.velocity * (float)(num1262 - 1) + value33) / (float)num1262;
                            if (num1261 < 600f && !Collision.SolidCollision(npc.position, npc.width, npc.height))
                            {
                                npc.ai[0] = 0f;
                            }
                        }
                        else if (npc.ai[0] == 3f)
                        {
                            npc.rotation = npc.velocity.X * 0.1f;
                            Vector2 value34 = new Vector2(npc.ai[1], npc.ai[2]);
                            Vector2 value35 = value34 - npc.Center;
                            float num1263 = value35.Length();
                            float num1264 = 2f; // MAY AFFECT SPEED
                            float num1265 = 3f; // MAY AFFECT SPEED
                            value35.Normalize();
                            value35 *= num1264;
                            npc.velocity = (npc.velocity * (num1265 - 1f) + value35) / num1265;
                            if (npc.collideX || npc.collideY)
                            {
                                npc.ai[0] = 4f;
                                npc.ai[1] = 0f;
                            }
                            if (num1263 < num1264 || num1263 > 800f || Collision.CanHit(npc.Center, 1, 1, Main.player[npc.target].Center, 1, 1))
                            {
                                npc.ai[0] = 0f;
                            }
                        }
                        else if (npc.ai[0] == 4f)
                        {
                            npc.rotation = npc.velocity.X * 0.1f;
                            if (npc.collideX)
                            {
                                ref float x1 = ref npc.velocity.X;
                                x1 *= -0.8f;
                            }
                            if (npc.collideY)
                            {
                                ref float x2 = ref npc.velocity.Y;
                                x2 *= -0.8f;
                            }
                            Vector2 value36;
                            if (npc.velocity.X == 0f && npc.velocity.Y == 0f)
                            {
                                value36 = Main.player[npc.target].Center - npc.Center;
                                ref float x3 = ref value36.Y;
                                x3 -= Main.player[npc.target].height / 4;
                                value36.Normalize();
                                npc.velocity = value36 * 0.1f;
                            }
                            float scaleFactor12 = 2f; // MAY AFFECT SPEED
                            float num1266 = 20f;  // MAY AFFECT SPEED
                            value36 = npc.velocity;
                            value36.Normalize();
                            value36 *= scaleFactor12;
                            npc.velocity = (npc.velocity * (num1266 - 1f) + value36) / num1266;
                            ref float x = ref npc.ai[1];
                            x += 1f;
                            if (npc.ai[1] > 180f)
                            {
                                npc.ai[0] = 0f;
                                npc.ai[1] = 0f;
                            }
                            if (Collision.CanHit(npc.Center, 1, 1, Main.player[npc.target].Center, 1, 1))
                            {
                                npc.ai[0] = 0f;
                            }
                            ref float x4 = ref npc.localAI[0];
                            x4 += 1f;
                            if (npc.localAI[0] >= 5f && !Collision.SolidCollision(npc.position - new Vector2(10f, 10f), npc.width + 20, npc.height + 20))
                            {
                                npc.localAI[0] = 0f;
                                Vector2 center35 = npc.Center;
                                center35.X = Main.player[npc.target].Center.X;
                                if (Collision.CanHit(npc.Center, 1, 1, center35, 1, 1) && Collision.CanHit(npc.Center, 1, 1, center35, 1, 1) && Collision.CanHit(Main.player[npc.target].Center, 1, 1, center35, 1, 1))
                                {
                                    npc.ai[0] = 3f;
                                    npc.ai[1] = center35.X;
                                    npc.ai[2] = center35.Y;
                                }
                                else
                                {
                                    center35 = npc.Center;
                                    center35.Y = Main.player[npc.target].Center.Y;
                                    if (Collision.CanHit(npc.Center, 1, 1, center35, 1, 1) && Collision.CanHit(Main.player[npc.target].Center, 1, 1, center35, 1, 1))
                                    {
                                        npc.ai[0] = 3f;
                                        npc.ai[1] = center35.X;
                                        npc.ai[2] = center35.Y;
                                    }
                                }
                            }
                        }
                        else if (npc.ai[0] == 5f)
                        {
                            Player player7 = Main.player[npc.target];
                            if (!player7.active || player7.dead)
                            {
                                npc.ai[0] = 0f;
                                npc.ai[1] = 0f;
                                npc.netUpdate = true;
                            }
                            else
                            {
                                npc.Center = ((player7.gravDir == 1f) ? player7.Top : player7.Bottom) + new Vector2((float)(player7.direction * 4), 0f);
                                npc.gfxOffY = player7.gfxOffY;
                                npc.velocity = Vector2.Zero;
                                player7.AddBuff(163, 59, false);
                            }
                        }
                        if (npc.type == NPCID.StardustCellBig)
                        {
                            npc.rotation = 0f;
                            int num2;
                            for (int num1267 = 0; num1267 < 200; num1267 = num2 + 1)
                            {
                                if (num1267 != npc.whoAmI && Main.npc[num1267].active && Main.npc[num1267].type == npc.type && Math.Abs(npc.position.X - Main.npc[num1267].position.X) + Math.Abs(npc.position.Y - Main.npc[num1267].position.Y) < (float)npc.width)
                                {
                                    if (npc.position.X < Main.npc[num1267].position.X)
                                    {
                                        ref float x = ref npc.velocity.X;
                                        x -= 0.05f;
                                    }
                                    else
                                    {
                                        ref float x = ref npc.velocity.X;
                                        x += 0.05f;
                                    }
                                    if (npc.position.Y < Main.npc[num1267].position.Y)
                                    {
                                        ref float x = ref npc.velocity.Y;
                                        x -= 0.05f;
                                    }
                                    else
                                    {
                                        ref float x = ref npc.velocity.Y;
                                        x += 0.05f;
                                    }
                                }
                                num2 = num1267;
                            }
                        }
                    }
                    return;
                case 31://Spazmatism
                    if (Main.expertMode && ServerConfig.Instance.MechChanges)
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
                                            Terraria.Audio.SoundEngine.PlaySound(SoundID.ForceRoar, (int)npc.position.X, (int)npc.position.Y, -1, 1.5f);
                                            npc.soundDelay = 240;
                                        }
                                        if (npc.localAI[1] > 8f)
                                        {

                                            //npc.localAI[1] = 0f;
                                            //float sixF = 6f;
                                            //int basedamage = 30;
                                            //if (Main.expertMode)
                                            //{
                                            //    basedamage = 27;
                                            //}
                                            //int type = 101;
                                            //spazposition = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                                            //playerpositionX = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - spazposition.X;
                                            //playerpositionY = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - spazposition.Y;
                                            //playerpositiontospaz = (float)Math.Sqrt((double)(playerpositionX * playerpositionX + playerpositionY * playerpositionY));
                                            //playerpositiontospaz = sixF / playerpositiontospaz;
                                            //playerpositionX *= playerpositiontospaz;
                                            //playerpositionY *= playerpositiontospaz;
                                            //playerpositionY += (float)Main.rand.Next(-40, 41) * 0.01f;
                                            //playerpositionX += (float)Main.rand.Next(-40, 41) * 0.01f;
                                            //playerpositionY += npc.velocity.Y * 0.5f;
                                            //playerpositionX += npc.velocity.X * 0.5f;
                                            //ref float posx = ref spazposition.X;
                                            //posx -= playerpositionX * 2f;
                                            //ref float posy = ref spazposition.Y;
                                            //posy -= playerpositionY * 2f;
                                            //int flamethrower = Projectile.NewProjectile(spazposition.X, spazposition.Y, playerpositionX, playerpositionY, type, npcdamage, 0f, Main.myPlayer, 0f, 0f);

                                        }
                                    }
                                }
                            }
                        }
                    }                
                    return;    
                case 37://Destroyer
                    if (ServerConfig.Instance.MechChanges)
                    {
                        if (npc.type == NPCID.TheDestroyerTail)
                        {
                            npc.takenDamageMultiplier = 4f;
                        }
                        for (int i = 0; i < Main.player.Length; i++)
                        {
                            Player player = Main.player[i];
                            if (npc.Distance(player.Center) < 100 * 16)
                            {  //50 tiles or closer
                                player.AddBuff(BuffID.Heartreach, 1, false);
                            }
                        }
                    }
                    return;
            }
        }
        public override bool StrikeNPC(NPC npc, ref double damage, int defense, ref float knockback, int hitDirection, ref bool crit)
        {
            switch (npc.type)
            {
                case NPCID.TheDestroyerBody:
                    if (Main.expertMode && ServerConfig.Instance.MechChanges)
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
                                int num = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 182, 0f, 0f, 100, default(Color), 3.5f);
                                Main.dust[num].noGravity = true;
                                Main.dust[num].noLight = true;
                            }
                        }
                    }
                    return true;
                case NPCID.TheDestroyerTail:
                    if (ServerConfig.Instance.MechChanges)
                    {
                        Terraria.Audio.SoundEngine.PlaySound(SoundID.Item92, npc.position);
                        for (int i = 0; i < 25; i++)
                        {
                            int num = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 182, 0f, 0f, 100, default(Color), 2f);
                            Main.dust[num].noGravity = true;
                            Main.dust[num].noLight = true;
                        }
                    }
                    return true;
                case NPCID.SolarSpearman:
                    for (int i = 0; i < 5; i++)
                    {
                        int num = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 174, 0f, 0f, 100, default(Color), 2f);
                        Main.dust[num].noGravity = true;
                        Main.dust[num].noLight = true;
                    }
                    return true;
            }
            return true;
        }

        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.player.ZoneJungle)
                pool.Add(NPCID.JungleCreeper, 0.2f);
        }
        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (Decay)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 16;
                if (damage < 2)
                {
                    damage = 2;
                }
                npc.netUpdate = true;
            }
			if (npc.HasBuff(BuffID.CursedInferno))
            {
                npc.lifeRegen -= 48;
                npc.netUpdate = true;
            }
			if (npc.HasBuff(BuffID.ShadowFlame))
            {
                npc.lifeRegen -= 90;
                npc.netUpdate = true;
            }
			if (npc.HasBuff(BuffID.Venom))
            {
                npc.lifeRegen -= 140;
                npc.netUpdate = true;
            }
            if (Toxins)
            {
                npc.lifeRegen -= 80;
                npc.netUpdate = true;
                if (damage < 25)
                {
                    damage = 25;
                }
            }
            if (Heavyburn)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 120;
                if (damage < 10)
                {
                    damage = 10;
                }
                npc.netUpdate = true;
            }
            if (Omegaburn)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 4000;
                if (damage < 1000)
                {
                    damage = 1000;
                }
                npc.netUpdate = true;
            }
            if (titaPenetrate)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                int TridentCount = 0;
                for (int i = 0; i < 1000; i++)
                {
                    Projectile p = Main.projectile[i];
                    if (p.active && p.type == ProjectileType<Projectiles.TitaTridentThrown>() && p.ai[0] == 1f && p.ai[1] == npc.whoAmI)
                    {
                        TridentCount++;
                    }
                }
                npc.lifeRegen -= TridentCount * 2 * 10;
                if (damage < TridentCount * 5)
                {
                    damage = TridentCount * 5;
                }
                npc.netUpdate = true;

            }
        }
        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            if (npc.HasBuff(BuffID.Weak))
            {
                drawColor.R = 118;
                drawColor.G = 57;
                drawColor.B = 49;
            }
            if (Decay)
            {
                drawColor.R = (byte)(drawColor.R * 0.85);
                drawColor.G = (byte)(drawColor.G * 0.99);
                drawColor.B = (byte)(drawColor.G * 0.47);
            }
            if (Corrupted)
            {
                drawColor.R = 172;
                drawColor.G = 145;
                drawColor.B = 153;
                if (Main.rand.Next(4) < 1)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width, npc.height, 184, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 2.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 0.8f;
                    Main.dust[dust].velocity.Y -= 0.3f;
                    if (Main.rand.NextBool(4))
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.3f;
                    }
                }
            }
            if (Toxins)
            {
                drawColor.R = (byte)(drawColor.R * 0.80);
                drawColor.G = (byte)(drawColor.G * 0.90);
                drawColor.B = (byte)(drawColor.G * 0.40);
            }
            if (Heavyburn)
            {
                if (Main.rand.Next(3) < 2)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 127, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 2.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.NextBool(4))
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }
                Lighting.AddLight(npc.position, 0.1f, 0.2f, 0.7f);
            }
            if (Omegaburn)
            {
                if (Main.rand.Next(2) < 1)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 127, npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f, 100, default(Color), 3f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 2.4f;
                    Main.dust[dust].velocity.Y -= 0.4f;
                    if (Main.rand.NextBool(4))
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.9f;
                    }
                }
                Lighting.AddLight(npc.position, 0.1f, 0.2f, 0.7f);
            }
        }

        public override void SetupTravelShop(int[] shop, ref int nextSlot)
        {
            for (int i = 0; i < shop.Length; i++)
            {
                //if (shop[i] == ItemID.CelestialMagnet)
                //{
                //    for (int j = i + 1; j < shop.Length; j++)
                //    {
                //        shop[j - 1] = shop[j];
                //    }
                //    shop[shop.Length - 1] = 0;
                //    nextSlot--;
                //}
            }
        }
        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            switch (type)
            {
                case NPCID.ArmsDealer:
                    if (!NPC.downedBoss1) // when will this code run?
                    {
                        for (int i = 0; i < shop.item.Length; i++) // loop through the
                        {
                            if (shop.item[i] != null && shop.item[i].type == ItemID.Minishark) // check if the shop slot it is at has an item, and if that item is Minishark
                            {
                                shop.item[i].SetDefaults(ItemID.None); // if so, set that slot to none
                                for (int j = i + 1; j < shop.item.Length; j++)
                                {
                                    shop.item[j - 1] = shop.item[j];
                                }
                                --nextSlot;
                                break;                          
                            }
                        }
                    }
                    break;
                case NPCID.SkeletonMerchant:
                    if (Main.moonPhase == 2 || Main.moonPhase == 8)
                    {
                        shop.item[nextSlot].SetDefaults(ItemID.Rally);
                        nextSlot++;
                    }
                    if (Main.moonPhase == 4 || Main.moonPhase == 6)
                    {
                        shop.item[nextSlot].SetDefaults(ItemID.ChainKnife);
                        nextSlot++;
                    }
                    if (Main.moonPhase == 3 || Main.moonPhase == 7)
                    {
                        shop.item[nextSlot].SetDefaults(ItemID.BoneSword);
                        nextSlot++;
                    }
                    if (Main.moonPhase == 1 || Main.moonPhase == 5) 
                    {
                        shop.item[nextSlot].SetDefaults(ItemID.BookofSkulls);
                        nextSlot++;
                    }
                    break;
                case NPCID.Wizard:
                    if (!Main.dayTime)
                    {
                        shop.item[nextSlot].SetDefaults(ItemID.CelestialMagnet);
                        nextSlot++;
                    }
                    break;
                case NPCID.WitchDoctor:
                    if (!Main.dayTime)
                    {
                        shop.item[nextSlot].SetDefaults(ItemID.PygmyNecklace);
                        nextSlot++;
                    }
                    break;
            }
        }
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
        public override bool CheckDead(NPC npc) // makes something happen when NPC dies
        {
            if (Corrupted)
            {
                for (int i = 0; i < 3; ++i)
                {
                    float velX = Main.rand.Next(-35, 36) * 0.2f;
                    float velY = Main.rand.Next(-35, 36) * 0.2f;
                    Projectile.NewProjectile(npc.GetProjectileSpawnSource(),npc.position.X, npc.position.Y, velX, velY, ProjectileID.TinyEater, 52, 0f, Main.myPlayer, 0f, 0f);
                }
            }
            //switch (npc.type)
            //{
            //    case NPCID.Plantera:
            //        if (Main.expertMode && !NPC.downedPlantBoss)
            //        {
            //            if (Main.netMode == NetmodeID.SinglePlayer)
            //            {
            //                Main.NewText("You feel your armor harden...", 50, 255, 130, false);
            //            }
            //            else if (Main.netMode == NetmodeID.Server)
            //            {
            //                NetMessage.BroadcastChatMessage(NetworkText.FromKey("You feel your armor harden..."), new Color(50, 255, 130), -1);
            //            }
            //        }
            //        return true;
            //}
            return true;
        }
    }
}