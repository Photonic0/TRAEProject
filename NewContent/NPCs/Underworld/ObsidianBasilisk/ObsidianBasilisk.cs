using TRAEProject.NewContent.NPCs;
using Microsoft.Xna.Framework;
using System.IO;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.ModLoader.Utilities;
using TRAEProject.Common;
using TRAEProject.NewContent.NPCs.Underworld.Phoenix;

namespace TRAEProject.NewContent.NPCs.Underworld.ObsidianBasilisk
{
	// These three class showcase usage of the WormHead, WormBody and WormTail classes from Worm.cs
	internal class ObsidianBasiliskHead : WormHead
	{
		public override int BodyType => ModContent.NPCType<ObsidianBasiliskBody>();

		public override int TailType => ModContent.NPCType<ObsidianBasiliskTail>();

		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Obsidian Basilisk");
			NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData
			{
				SpecificallyImmuneTo = new int[] {
					BuffID.OnFire,
					BuffID.OnFire3,
					BuffID.Daybreak,
                    BuffID.Confused // Most NPCs have this
				}
            };
            NPCID.Sets.DebuffImmunitySets.Add(Type, debuffData);
            //var drawModifier = new NPCID.Sets.NPCBestiaryDrawModifiers(0) { // Influences how the NPC looks in the Bestiary
            //	//CustomTexturePath = "ExampleMod/Content/NPCs/ExampleWorm_Bestiary", // If the NPC is multiple parts like a worm, a custom texture for the Bestiary is encouraged.
            //	Position = new Vector2(40f, 24f),
            //	PortraitPositionXOverride = 0f,
            //	PortraitPositionYOverride = 12f
            //};
            //NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, drawModifier);
        }

		public override void SetDefaults() {
            // Head is 10 defence, body 20, tail 30.
            NPC.CloneDefaults(NPCID.DiggerHead);
            NPC.width = 50;
            NPC.height = 86;
			NPC.knockBackResist = 0f;
            //NPC.aiStyle = 3;
            //AIType = NPCID.WalkingAntlion;
            //AnimationType = NPCID.WalkingAntlion;
            NPC.value = 10000;
            NPC.damage = 100;
            NPC.defense = 33;
            NPC.lifeMax = 15000; NPC.scale = 1.1f;
            NPC.lavaImmune = true;
			NPC.GetGlobalNPC<Freeze>().freezeImmune = true;
			NPC.GetGlobalNPC<HellMinibosses>().HellMinibossThatSpawnsInPairs = true;
            NPC.HitSound = SoundID.NPCHit41;
            NPC.DeathSound = SoundID.NPCDeath24;
            //NPC.aiStyle = -1;
		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			// We can use AddRange instead of calling Add multiple times in order to add multiple items at once
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the spawning conditions of this NPC that is listed in the bestiary.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Underground,
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns,

				// Sets the description of this NPC that is listed in the bestiary.
				new FlavorTextBestiaryInfoElement("")
			});
		}
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 8; i++)
            {
                Vector2 vel = new Vector2(Main.rand.NextFloat(-4, -8), Main.rand.NextFloat(4, 8));
                var dust = Dust.NewDustDirect(new Vector2(NPC.Center.X - 10, NPC.Center.Y - 10), 20, 20, DustID.Torch, Scale: 1.2f); ;
                dust.noGravity = true;
            }
        }
        public override void Init() {
			// Set the segment variance
			// If you want the segment length to be constant, set these two properties to the same value
			MinSegmentLength = 66;
			MaxSegmentLength = 66;

			CommonWormInit(this);
		}

		// This method is invoked from ExampleWormHead, ExampleWormBody and ExampleWormTail
		internal static void CommonWormInit(Worm worm) {
			// These two properties handle the movement of the worm
			worm.MoveSpeed = 18f;
			worm.Acceleration = 0.15f;
		}
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {

                for (int i = 0; i < NPC.GetGlobalNPC<HellMinibosses>().MinibossList.Length; i++)
                {
                    if (NPC.AnyNPCs(NPC.GetGlobalNPC<HellMinibosses>().MinibossList[i]))
                        return 0f;
                }
                if (Main.hardMode && NPC.downedPlantBoss)
                {
                    return SpawnCondition.Underworld.Chance * 0.2f;
                }
            
			return 0f;
        }
        public override bool PreKill()
        {

            Gore.NewGore(NPC.GetSource_Death(), NPC.Center, NPC.velocity, Mod.Find<ModGore>("ObsidianBasiliskHead_Gore").Type, 1f);
            return false;
        }
    }

    internal class ObsidianBasiliskBody : WormBody
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Obsidian Basilisk");
            NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData
            {
                SpecificallyImmuneTo = new int[] {
                    BuffID.OnFire,
                    BuffID.OnFire3,
                    BuffID.Daybreak,
                    BuffID.Confused // Most NPCs have this
				}
            };
            NPCID.Sets.DebuffImmunitySets.Add(Type, debuffData);

            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Hide = true // Hides this NPC from the Bestiary, useful for multi-part NPCs whom you only want one entry.
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);
        }

        public override void SetDefaults()
        {
            NPC.CloneDefaults(NPCID.DiggerBody);
            NPC.damage = 90;
            NPC.defense = 120; NPC.HitSound = SoundID.NPCHit4;

            NPC.aiStyle = -1; NPC.scale = 1.2f;
        }

        public override void Init()
        {
            ObsidianBasiliskHead.CommonWormInit(this);
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (NPC.life <= 0)
            {

                Gore.NewGore(NPC.GetSource_Death(), NPC.Center, NPC.velocity, Mod.Find<ModGore>("ObsidianBasiliskBody_Gore").Type, 1f);
            }
        }
    }

	internal class ObsidianBasiliskTail : WormTail
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Obsidian Basilisk");
            NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData
            {
                SpecificallyImmuneTo = new int[] {
                    BuffID.OnFire,
                    BuffID.OnFire3,
                    BuffID.Daybreak,
                    BuffID.Confused // Most NPCs have this
				}
            }; NPCID.Sets.DebuffImmunitySets.Add(Type, debuffData);

            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0) {
				Hide = true // Hides this NPC from the Bestiary, useful for multi-part NPCs whom you only want one entry.
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);
		}

		public override void SetDefaults()
		{
			NPC.CloneDefaults(NPCID.DiggerTail); NPC.damage = 80;
			NPC.defense = 50;
			NPC.aiStyle = -1;
			NPC.scale = 1.2f; NPC.HitSound = SoundID.NPCHit41;

        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (NPC.life <= 0)
            {

                Gore.NewGore(NPC.GetSource_Death(), NPC.Center, NPC.velocity, Mod.Find<ModGore>("ObsidianBasiliskBody_Gore").Type, 1f);
            }
        }
        public override bool PreKill()
        {

            Gore.NewGore(NPC.GetSource_Death(), NPC.Center, NPC.velocity, Mod.Find<ModGore>("ObsidianBasiliskTail_Gore").Type, 1f);
            return false;
        }

        public override void Init() {
			ObsidianBasiliskHead.CommonWormInit(this);
		}
	}
}