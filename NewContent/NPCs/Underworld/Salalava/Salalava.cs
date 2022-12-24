using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using TRAEProject.Changes.NPCs.Miniboss.Santa;
using TRAEProject.NewContent.NPCs.Banners;
using TRAEProject.NewContent.NPCs.Underworld.Lavamander;
using TRAEProject.NewContent.NPCs.Underworld.Phoenix;
using static System.Formats.Asn1.AsnWriter;
using static Terraria.ModLoader.ModContent;
using static Terraria.ModLoader.PlayerDrawLayer;

namespace TRAEProject.NewContent.NPCs.Underworld.Salalava
{
	public class SalalavaNPC : ModNPC
	{
		public override void SetStaticDefaults()
		{
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
			DisplayName.SetDefault("Salalava");
			Main.npcFrameCount[NPC.type] = 6;
		}

		public override void SetDefaults()
		{
			NPC.width = 184;
			NPC.height = 34;
			NPC.aiStyle = 3;
			AIType = NPCID.DesertBeast;
			//AnimationType = NPCID.WalkingAntlion;
			NPC.value = 5000;
			NPC.damage = 70;
			NPC.defense = 40;
			NPC.lifeMax = 6000;
			NPC.lavaImmune = true;
			NPC.HitSound = SoundID.DD2_DrakinHurt;
			NPC.DeathSound = SoundID.DD2_DrakinDeath;
			NPC.knockBackResist = 0f;
			DrawOffsetY = -2;
			NPC.scale = 1f;
			Banner = NPC.type;
			NPC.GetGlobalNPC<HellMinibosses>().HellMinibossThatSpawnsInPairs = true;
			BannerItem = ItemType<FroggabombaBanner>();
		}
		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new List<IBestiaryInfoElement>
			{
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheUnderworld,
				new FlavorTextBestiaryInfoElement("")
			});
		}
		float dustTimer = 0;
		//      public override void ModifyNPCLoot(NPCLoot npcLoot)
		//{
		//	npcLoot.Add(ItemDropRule.Common(ItemID.ChickenNugget, 5));
		//	npcLoot.Add(ItemDropRule.Common(ItemID.FireFeather, 10));
		//      }

		float jump = 0;
		float attackTimer = 0;
		public override void AI()
		{

			NPC.noGravity = false;
			int num = 1;
			int num2 = 1;
			int num3 = (int)((NPC.position.X + (NPC.width / 2)) / 16f);
			int num4 = (int)(NPC.Bottom.Y / 16f);
			for (int j = num3 - num; j <= num3 + num; j++)
			{
				for (int k = num4 - num2; k < num4 + num2; k++)
				{
					if (Main.tile[j, k].LiquidAmount > 200 && Main.tile[j, k].LiquidType == 0 ||
						Main.tile[j, k].LiquidAmount > 200 && Main.tile[j, k].LiquidType == 2 ||
						Main.tile[j, k].LiquidAmount > 200 && Main.tile[j, k].LiquidType == 1
						)
					{
						if (NPC.velocity.Y > 0)
							NPC.velocity.Y = 0;
						NPC.noGravity = true;
						jump++;
						if (NPC.Distance(NPC.GetTargetData().Center) <= 300f)
							jump += 3; // jumps way more often if it can reach you
						if (jump >= 900f) // We have to force it to jump, its normal AI won't let it jump while "water walking"
						{
							jump = 0;
							NPC.velocity.Y = -8f;
							NPC.velocity.X *= 1.25f;
						}
					}
				}
			}



			if (NPC.Distance(NPC.GetTargetData().Center) <= 600f)
			{

				attackTimer++;
				int lavamandies = 0;
				if (attackTimer >= 240f)
				{
					NPC.FaceTarget();
					if (attackTimer == 240f)
					{
						SoundEngine.PlaySound(SoundID.DD2_DrakinBreathIn, NPC.Center);
					}
					NPC.velocity.X = 0;
					for (int i = 0; i < 200; i++)
					{
						if (Main.npc[i].type == NPCType<LavamanderNPC>())
						{
							lavamandies++;
						}
					}
					if (lavamandies < 7)
					{
						if (attackTimer % 10 == 0)
						{
							SoundEngine.PlaySound(SoundID.DD2_OgreRoar, NPC.Center);
							NPC npc = NPC.NewNPCDirect(NPC.GetSource_FromAI(), (int)NPC.Center.X, (int)NPC.Center.Y, NPCType<Lavalarva>());
							npc.velocity.X = Main.rand.NextFloat(-3f, 3f);
							npc.velocity.Y = Main.rand.NextFloat(-5f, -7f);

						}
					}
					else
					{
						if (attackTimer % 10 == 0)
						{
							SoundEngine.PlaySound(SoundID.DD2_DrakinShot, NPC.Center);
							if (Main.netMode != NetmodeID.MultiplayerClient)
							{
								Vector2 vector3 = Vector2.Normalize(Main.player[NPC.target].Center - NPC.Center) * (NPC.width/* + 20*/) / 2f + NPC.Center;
								NPC.NewNPC(NPC.GetBossSpawnSource(NPC.target), (int)vector3.X, (int)vector3.Y + 17, NPCType<LavaBubble>());

							}
						}
						NPC.TargetClosest(true);
					}
					if (attackTimer > 300f)
						attackTimer = 0f;
				}
			}
		}
		public override bool PreKill()
		{
			for (int i = 0; i < 4; i++)
			{
				Gore.NewGore(NPC.GetSource_Death(), NPC.Center, NPC.velocity, Mod.Find<ModGore>("SalalavaGore1").Type, 1f);
			}
			Gore.NewGore(NPC.GetSource_Death(), NPC.Center, NPC.velocity, Mod.Find<ModGore>("SalalavaGore2").Type, 1f);
			Gore.NewGore(NPC.GetSource_Death(), NPC.Center, NPC.velocity, Mod.Find<ModGore>("SalalavaGore3").Type, 1f);
			Gore.NewGore(NPC.GetSource_Death(), NPC.Center, NPC.velocity, Mod.Find<ModGore>("SalalavaGore4").Type, 1f);
			return false;

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
		int frame = 0;
		public override void FindFrame(int frameHeight)
		{
			if (attackTimer >= 240f)
				NPC.frame.Y = 5 * frameHeight;
			else
			{
				if (NPC.velocity.X == 0f)
				{
					NPC.frame.Y = 0;
				}
				if (NPC.direction < 0 && NPC.velocity.X < 0f)
				{
					NPC.spriteDirection = -1;
				}
				if (NPC.direction > 0 && NPC.velocity.X > 0f)
				{
					NPC.spriteDirection = 1;
				}
				//if (NPC.frame.Y / frameHeight < 2)
				//{
				//	NPC.frame.Y = frameHeight * 2;
				//}
				NPC.frameCounter += 1f + Math.Abs(NPC.velocity.X) / 2f;
				if (NPC.frameCounter > 12.0)
				{
					NPC.frame.Y += frameHeight;
					NPC.frameCounter = 0.0;
				}
				if (NPC.frame.Y / frameHeight > 4)
				{
					NPC.frame.Y = 0;
				}
				if (NPC.velocity.Y != 0f)
				{
					NPC.frame.Y = 0;
				}
			}
		}
	}
	public class LavaBubble : ModNPC
	{
		public override void SetStaticDefaults()
		{
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
			DisplayName.SetDefault("Lava Bubble");
			Main.npcFrameCount[NPC.type] = 1;
			NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
			{
				Hide = true // Hides this NPC from the Bestiary, useful for multi-part NPCs whom you only want one entry.
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);
		}

		public override void SetDefaults()
		{
			NPC.width = 38;
			NPC.height = 38;
			NPC.aiStyle = 70;
			AIType = NPCID.DetonatingBubble;
			//AnimationType = NPCID.WalkingAntlion;
			NPC.value = 0;
			NPC.damage = 70;
			NPC.lifeMax = 1;
			NPC.lavaImmune = true;
			NPC.scale = 1f;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
		}
		public override void OnKill()
		{
			SoundEngine.PlaySound(SoundID.Item10, NPC.Center);
			if (NPC.life <= 0)
			{
				Vector2 center = NPC.Center;
				for (int num267 = 0; num267 < 60; num267++)
				{
					int num268 = 25;
					Vector2 vector24 = ((float)Main.rand.NextDouble() * ((float)Math.PI * 2f)).ToRotationVector2() * Main.rand.Next(24, 41) / 8f;
					int num269 = Dust.NewDust(NPC.Center - Vector2.One * num268, num268 * 2, num268 * 2, DustID.Lava);
					Dust dust61 = Main.dust[num269];
					Vector2 vector25 = Vector2.Normalize(dust61.position - NPC.Center);
					dust61.position = NPC.Center + vector25 * 25f * NPC.scale;
					if (num267 < 30)
					{
						dust61.velocity = vector25 * dust61.velocity.Length();
					}
					else
					{
						dust61.velocity = vector25 * Main.rand.Next(45, 91) / 10f;
					}
					dust61.color = Main.hslToRgb((float)(0.40000000596046448 + Main.rand.NextDouble() * 0.20000000298023224), 0.9f, 0.5f);
					dust61.color = Color.Lerp(dust61.color, Color.White, 0.3f);
					dust61.noGravity = true;
					dust61.scale = 0.7f;
				}
			}
		}
		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			NPC.life = 0;
			NPC.active = false;
		}
		//     public override void AI()
		//     {
		//if (NPC.Distance(NPC.GetTargetData().Center) <= 10f)
		//{
		//	NPC.alpha = 255;
		//}
		//         if (NPC.target == 255)
		//         {
		//             NPC.TargetClosest();
		//             NPC.ai[3] = Main.rand.Next(80, 121) / 100f;
		//             float scaleFactor = Main.rand.Next(165, 265) / 15f;
		//             NPC.velocity = Vector2.Normalize(Main.player[NPC.target].Center - NPC.Center + new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101))) * scaleFactor;
		//             NPC.netUpdate = true;
		//         }
		//         Vector2 vector122 = Vector2.Normalize(Main.player[NPC.target].Center - NPC.Center);
		//         NPC.velocity = (NPC.velocity * 40f + vector122 * 24f /*up from 20*/) / 41f;
		//         NPC.scale = NPC.ai[3];
		//         NPC.alpha -= 30;
		//         if (NPC.alpha < 50)
		//         {
		//             NPC.alpha = 50;
		//         }
		//         NPC.alpha = 50;
		//         NPC.velocity.X = (NPC.velocity.X * 20f + Main.rand.Next(-100, 110) * 0.1f) / 21f;// up from 50, for some reason there isn't a noticeable difference unless the numbers are this big
		//         NPC.velocity.Y = (NPC.velocity.Y * 20f + -0.25f + Main.rand.Next(-100, 110) * 0.2f) / 21f; // up from 50;
		//         if (NPC.velocity.Y > 0f)
		//         {
		//             NPC.velocity.Y -= 0.04f;
		//         }
		//         if (NPC.ai[0] == 0f)
		//         {
		//             NPC.ai[1]++;
		//             if (NPC.ai[1] >= 400f)
		//             {
		//                 NPC.ai[0] = 1f;
		//                 NPC.ai[1] = 4f;
		//             }
		//         }

		//         return;
		//     }
	}
	public class Lavalarva : ModNPC
	{
		public override void SetStaticDefaults()
		{
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
			DisplayName.SetDefault("Lavalarva");
			Main.npcFrameCount[NPC.type] = 5;
			NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
			{
				Hide = true // Hides this NPC from the Bestiary, useful for multi-part NPCs whom you only want one entry.
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);
		}

		public override void SetDefaults()
		{
			NPC.width = 122;
			NPC.height = 22;
			NPC.aiStyle = 3;
			AIType = NPCID.DesertBeast;
			//AnimationType = NPCID.WalkingAntlion;
			NPC.value = 0;
			NPC.damage = 70;
			NPC.defense = 20;
			NPC.lifeMax = 500;
			NPC.lavaImmune = true;
			NPC.HitSound = SoundID.DD2_DrakinHurt;
			NPC.DeathSound = SoundID.DD2_DrakinDeath;
			NPC.knockBackResist = 0.1f;
			DrawOffsetY = -2;
			NPC.scale = 1f;
        }
        public override bool PreKill()
        {

            Gore.NewGore(NPC.GetSource_Death(), NPC.Center, NPC.velocity, Mod.Find<ModGore>("LavalarvaGore1").Type, 1f);
            Gore.NewGore(NPC.GetSource_Death(), NPC.Center, NPC.velocity, Mod.Find<ModGore>("LavalarvaGore2").Type, 1f);
            Gore.NewGore(NPC.GetSource_Death(), NPC.Center, NPC.velocity, Mod.Find<ModGore>("LavalarvaGore3").Type, 1f);
            return false;

        }
        float jump = 0;

        public override void AI()
        {

            NPC.noGravity = false;
            int num = 1;
            int num2 = 1;
            int num3 = (int)((NPC.position.X + (NPC.width / 2)) / 16f);
            int num4 = (int)(NPC.Bottom.Y / 16f);
            for (int j = num3 - num; j <= num3 + num; j++)
            {
                for (int k = num4 - num2; k < num4 + num2; k++)
                {
                    if (Main.tile[j, k].LiquidAmount > 200 && Main.tile[j, k].LiquidType == 0 ||
                        Main.tile[j, k].LiquidAmount > 200 && Main.tile[j, k].LiquidType == 2 ||
                        Main.tile[j, k].LiquidAmount > 200 && Main.tile[j, k].LiquidType == 1
                        )
                    {
                        if (NPC.velocity.Y > 0)
                            NPC.velocity.Y = 0;
                        NPC.noGravity = true;
                        jump++;
                        if (NPC.Distance(NPC.GetTargetData().Center) <= 300f)
                            jump += 3; // jumps way more often if it can reach you
                        if (jump >= 750f) // We have to force it to jump, its normal AI won't let it jump while "water walking"
                        {
                            jump = 0;
                            NPC.velocity.Y = -8f;
                            NPC.velocity.X *= 2f;

                        }
                    }
                }
            }
        }
        public override void FindFrame(int frameHeight)
        {

            if (NPC.velocity.X == 0f)
            {
                NPC.frame.Y = 0;
            }
            if (NPC.direction < 0 && NPC.velocity.X < 0f)
            {
                NPC.spriteDirection = -1;
            }
            if (NPC.direction > 0 && NPC.velocity.X > 0f)
            {
                NPC.spriteDirection = 1;
            }
            if (NPC.frame.Y / frameHeight < 2)
            {
                NPC.frame.Y = frameHeight * 2;
            }
            NPC.frameCounter += 1f + Math.Abs(NPC.velocity.X) / 2f;
            if (NPC.frameCounter > 12.0)
            {
                NPC.frame.Y += frameHeight;
                NPC.frameCounter = 0.0;
            }
            if (NPC.frame.Y / frameHeight >= Main.npcFrameCount[NPC.type])
            {
                NPC.frame.Y = frameHeight * 2;
            }
            if (NPC.velocity.Y != 0f)
            {
                NPC.frame.Y = 0;
            }
        }
    }
}