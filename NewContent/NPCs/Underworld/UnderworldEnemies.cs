using Microsoft.Xna.Framework;
using Terraria;
using System;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;
using TRAEProject.NewContent.NPCs.Underworld.Boomxie;
using static Terraria.ModLoader.ModContent;
using TRAEProject.NewContent.NPCs.Underworld.Phoenix;
using TRAEProject.NewContent.NPCs.Underworld.Salalava;
using TRAEProject.NewContent.NPCs.Underworld.Lavamander;
using TRAEProject.NewContent.NPCs.Underworld.ObsidianBasilisk;
using TRAEProject.NewContent.NPCs.Underworld.OniRonin;
using Terraria.Audio;
using TRAEProject.NewContent.NPCs.Underworld.Beholder;
using TRAEProject.NewContent.NPCs.Banners;
using Terraria.ModLoader.Utilities;

namespace TRAEProject.NewContent.NPCs.Underworld
{
    public class UnderworldEnemies : GlobalNPC
    {

        public override bool InstancePerEntity => true;

        public int[] MinibossList = new int[] { NPCType<PhoenixNPC>(), NPCType<SalalavaNPC>(), NPCType<PhoenixAsh>(), NPCType<ObsidianBasiliskHead>(), NPCType<ObsidianBasiliskBody>(), NPCType<ObsidianBasiliskTail>(), NPCType<OniRoninNPC>() };
        // important to include the phoenix ash, else an NPC may spawn while the phoenix is in its Ash phase
        public bool HellMinibossThatSpawnsInPairs = false;

        public float MinibossSpawn()
        {
            if (Main.hardMode && NPC.downedPlantBoss)
            {
                for (int i = 0; i < 255; i++)
                {
                    Player player = Main.player[i];
                    if (player.killGuide)
                    {
                        return 0f;
                    }
                }
                for (int i = 0; i < MinibossList.Length; i++)
                {
                    if (NPC.AnyNPCs(MinibossList[i]))
                        return 0f;
                }
                return SpawnCondition.Underworld.Chance * 0.125f;
            }
            return 0f;
        }
        public override void SpawnNPC(int npc, int tileX, int tileY)
        {

            NPC npc1 = Main.npc[npc];
            if (npc1.type == NPCType<BeholderNPC>())
            {
                SoundEngine.PlaySound(SoundID.NPCDeath10, npc1.Center);
            }
            if (npc1.type == NPCType<Lavalarva>() && NPC.downedPlantBoss)
            {
                int amount = Main.rand.Next(2, 4);
                for (int i = 0; i < amount; i++)
                {
                    NPC npc2 = NPC.NewNPCDirect(npc1.GetSource_FromAI(), (int)npc1.Center.X, (int)npc1.Center.Y, NPCType<LavamanderNPC>());
                    npc2.velocity.X = Main.rand.Next(-2, 2);
                    npc2.velocity.Y = Main.rand.Next(-2, 2);
                }
            }
            if (npc1.type == NPCType<CheapWayToSpawnARedDevil>())
            {
                NPC.NewNPCDirect(npc1.GetSource_FromAI(), (int)npc1.Center.X, (int)npc1.Center.Y, NPCID.RedDevil);
            }
            if (npc1.GetGlobalNPC<UnderworldEnemies>().HellMinibossThatSpawnsInPairs)
            {
                int spawn = Main.rand.Next(MinibossList);
                while (spawn == npc1.type || spawn == NPCType<PhoenixAsh>() || spawn == NPCType<ObsidianBasiliskBody>() || spawn == NPCType<ObsidianBasiliskTail>()) // if it's about to spawn the phoenix ash or the same NPC, it rerolls until it doesnt
                {
                    spawn = Main.rand.Next(MinibossList);
                }
                NPC.NewNPCDirect(npc1.GetSource_FromAI(), (int)npc1.Center.X, (int)npc1.Center.Y, spawn);
            }
        }
    }
    public class CheapWayToSpawnARedDevil : ModNPC
    {
        public override void SetStaticDefaults()
        {
            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Hide = true // Hides this NPC from the Bestiary, useful for multi-part NPCs whom you only want one entry.
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);

            DisplayName.SetDefault("ThisIsARedDevilYouCantJustMakeVanillaNPCsMoreCommonSoIHaveToMakeAFakeNPC"); // Automatic from .lang files
        }
        public override void SetDefaults()
        {
            NPC.width = 1;
            NPC.height = 1;

            NPC.damage = 1337;
            NPC.defense = 420;
            NPC.lifeMax = 69;
        }
        public override void AI()
        {
            NPC.ai[0]++;
            if (NPC.ai[0] >= 1)
            {
                NPC.life = 0;
            }
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (NPC.downedPlantBoss)
            {
                return SpawnCondition.Underworld.Chance * 0.1f;
            }
            return SpawnCondition.Underworld.Chance * 0f;
        }
    }
}