using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using TRAEProject.NewContent.NPCs.Banners;

using static Terraria.ModLoader.ModContent;

namespace TRAEProject.NewContent.NPCs.Underworld.Phoenix

{
    public class Phoenix : ModNPC
    {
        public override void SetStaticDefaults()
		{
			NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData
			{
				SpecificallyImmuneTo = new int[] {
					BuffID.OnFire,
					BuffID.OnFire3,
					BuffID.Confused // Most NPCs have this
				}
			};
			NPCID.Sets.DebuffImmunitySets.Add(Type, debuffData);
			DisplayName.SetDefault("Undying Phoenix"); 
            Main.npcFrameCount[NPC.type] = 5; // make sure to set this for your modnpcs.
        }

        public override void SetDefaults()
        {
            NPC.width = 82;
            NPC.height = 68;
            NPC.aiStyle = 74;
            AIType = NPCID.SolarCorite;
			NPC.value = 0;
            NPC.damage = 50;
            NPC.defense = 28;
            NPC.lifeMax = 3000;
			NPC.scale = 1.1f;
            NPC.lavaImmune = true;
            NPC.HitSound = SoundID.DD2_WyvernHurt;
            NPC.DeathSound = SoundID.DD2_WyvernDeath;
            NPC.knockBackResist = 0f; 
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.buffImmune[BuffID.OnFire] = false;
			NPC.buffImmune[BuffID.OnFire3] = false;
			NPC.buffImmune[BuffID.Frostburn] = false;
			NPC.buffImmune[BuffID.Frostburn2] = false;
			Banner = NPC.type;
            BannerItem = ItemType<FroggabombaBanner>();
        }
		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new List<IBestiaryInfoElement>
			{
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheUnderworld,
				new FlavorTextBestiaryInfoElement("With the sheer amount souls released, it seems the Underworld itself has gained sentience. It creates a legendary bird out of ashes and flames that will continue its assault until every trace of its presence has been dealt with.")
			});
		}
		float dustTimer = 0;
        public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			npcLoot.Add(ItemDropRule.Common(ItemID.ChickenNugget, 5));
			npcLoot.Add(ItemDropRule.Common(ItemID.FireFeather, 10));
        }
        public override void AI()
        {
			
		
				NPC.rotation = 0;
            if (NPC.ai[0] != 0f)
            {
				if (dustTimer == 0f)
				{
					dustTimer += 1f;
					for (int num122 = 0; num122 < 15; num122++)
					{
						if (!Main.rand.NextBool(4))
						{
							Dust dust7 = Dust.NewDustDirect(NPC.Center - NPC.Size / 4f, NPC.width / 2, NPC.height / 2, Utils.SelectRandom<int>(Main.rand, 6, 31, 31));
							dust7.noGravity = true;
							dust7.velocity *= 2.3f;
							dust7.fadeIn = 1.5f;
							dust7.noLight = true;
						}
					}
					SoundEngine.PlaySound(SoundID.Item73, NPC.Center);
					dustTimer += 1f;
					for (int num122 = 0; num122 < 15; num122++)
					{
						if (!Main.rand.NextBool(4))
						{
							Dust dust7 = Dust.NewDustDirect(NPC.Center - NPC.Size / 4f, NPC.width / 2, NPC.height / 2, Utils.SelectRandom<int>(Main.rand, 6, 31, 31));
							dust7.noGravity = true;
							dust7.velocity *= 2.3f;
							dust7.fadeIn = 1.5f;
							dust7.noLight = true;
						}
					}
					for (int num731 = 0; num731 < 10; ++num731)
					{
						int num732 = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, 31, 0f, 0f, 100, default, 2f);
						Dust dust = Main.dust[num732];
						dust.velocity *= 2f;
						if (Main.rand.NextBool(2))
						{
							Main.dust[num732].scale = 0.5f;
							Main.dust[num732].fadeIn = 1f + Main.rand.Next(10) * 0.1f;
						}
					}
				}

				if (NPC.alpha <= 0)
				{
					for (int num123 = 0; num123 < 2; num123++)
					{
						if (!Main.rand.NextBool(4))
						{
							Dust dust8 = Dust.NewDustDirect(NPC.Center - NPC.Size / 4f, NPC.width / 2, NPC.height / 2, Utils.SelectRandom<int>(Main.rand, 6, 6, 31));
							dust8.noGravity = true;
							dust8.velocity *= 2.3f;
							dust8.fadeIn = 1.5f;
							dust8.noLight = true;
						}
					}
					Vector2 spinningpoint8 = new Vector2(0f, (float)Math.Cos((float)NPC.frameCounter * ((float)Math.PI * 2f) / 40f - (float)Math.PI / 2f)) * 16f;
					spinningpoint8 = spinningpoint8.RotatedBy(NPC.rotation);
					Vector2 vector23 = NPC.velocity.SafeNormalize(Vector2.Zero);
					for (int num124 = 0; num124 < 1; num124++)
					{
						Dust dust9 = Dust.NewDustDirect(NPC.Center - NPC.Size / 4f, NPC.width / 2, NPC.height / 2, 6);
						dust9.noGravity = true;
						dust9.position = NPC.Center + spinningpoint8;
						dust9.velocity *= 0f;
						dust9.fadeIn = 1.4f;
						dust9.scale = 1.15f;
						dust9.noLight = true;
						dust9.position += NPC.velocity * 1.2f;
						dust9.velocity += vector23 * 2f;
						Dust dust10 = Dust.NewDustDirect(NPC.Center - NPC.Size / 4f, NPC.width / 2, NPC.height / 2, 6);
						dust10.noGravity = true;
						dust10.position = NPC.Center + spinningpoint8;
						dust10.velocity *= 0f;
						dust10.fadeIn = 1.4f;
						dust10.scale = 1.15f;
						dust10.noLight = true;
						dust10.position += NPC.velocity * 0.5f;
						dust10.position += NPC.velocity * 1.2f;
						dust10.velocity += vector23 * 2f; 
						Dust dust11 = Dust.NewDustDirect(NPC.Center - NPC.Size / 4f, NPC.width / 2, NPC.height / 2, 6);
						dust11.noGravity = true;
						dust11.position = NPC.Center - spinningpoint8;
						dust11.velocity *= 0f;
						dust11.fadeIn = 1.4f;
						dust11.scale = 1.15f;
						dust11.noLight = true;
						dust11.position += NPC.velocity * 0.5f;
						dust11.position += NPC.velocity * 1.2f;
						dust11.velocity -= vector23 * 2f;
					}
				}

				if (NPC.alpha > 0)
				{
					NPC.alpha -= 55;
					if (NPC.alpha < 0)
					{
						NPC.alpha = 0;
						float num125 = 16f;
						for (int num126 = 0; (float)num126 < num125; num126++)
						{
							Vector2 spinningpoint9 = Vector2.UnitX * 0f;
							spinningpoint9 += -Vector2.UnitY.RotatedBy((float)num126 * ((float)Math.PI * 2f / num125)) * new Vector2(1f, 4f);
							spinningpoint9 = spinningpoint9.RotatedBy(NPC.velocity.ToRotation());
							int num127 = Dust.NewDust(NPC.Center, 0, 0, 6);
							Main.dust[num127].scale = 1.5f;
							Main.dust[num127].noLight = true;
							Main.dust[num127].noGravity = true;
							Main.dust[num127].position = NPC.Center + spinningpoint9;
							Main.dust[num127].velocity = Main.dust[num127].velocity * 4f + NPC.velocity * 0.3f;
						}
					}
				}
				DelegateMethods.v3_1 = new Vector3(1f, 0.6f, 0.2f);
				Utils.PlotTileLine(NPC.Center, NPC.Center + NPC.velocity * 4f, 40f, DelegateMethods.CastLightOpen);

				NPC.rotation = NPC.velocity.ToRotation();
				if (NPC.rotation < -(float)Math.PI / 2f)
                {
                    NPC.rotation += (float)Math.PI;
                }
                if (NPC.rotation > (float)Math.PI / 2f)
                {
                    NPC.rotation -= (float)Math.PI;
                }
            }
			else
            {
				dustTimer = 0;
				if (Main.rand.NextBool(500))
				{
					SoundEngine.PlaySound(SoundID.DD2_WyvernScream, NPC.Center);
				}
				if (Main.rand.NextBool(4))
				{
					Dust dust9 = Dust.NewDustDirect(NPC.Center - NPC.Size / 4f, NPC.width / 2, NPC.height / 2, 6, Scale: 1.15f);

				}
			}
            NPC.spriteDirection = -Math.Sign(NPC.velocity.X); 
		}
		public override bool PreKill()
		{
			NPCLoader.blockLoot.Add(ItemID.ChickenNugget);
			NPCLoader.blockLoot.Add(ItemID.FireFeather);

			for (int i = 0; i < 2; i++)
			{
				Gore.NewGore(NPC.GetSource_Death(), NPC.Center, NPC.velocity, Mod.Find<ModGore>("PhoenixGore1").Type, 1f);
			}
			Gore.NewGore(NPC.GetSource_Death(), NPC.Center, NPC.velocity, Mod.Find<ModGore>("PhoenixGore2").Type, 1f);
			Gore.NewGore(NPC.GetSource_Death(), NPC.Center, NPC.velocity, Mod.Find<ModGore>("PhoenixGore3").Type, 1f);
			Gore.NewGore(NPC.GetSource_Death(), NPC.Center, NPC.velocity, Mod.Find<ModGore>("PhoenixGore4").Type, 1f);
			NPC.NewNPC(NPC.GetSource_Death(), (int)(NPC.Center.X), (int)(NPC.Center.Y), NPCType<PhoenixAsh>());
			return false;

		}
		int frame = 0;


		public override void FindFrame(int frameHeight)
        {

	
			NPC.frameCounter++;
			if (NPC.frameCounter >= 6 && NPC.ai[0] == 0f)
			{
				frame++;
				if (frame > 3)
				{
					frame = 0;
				}
				NPC.frame.Y = frameHeight * frame;
				NPC.frameCounter = 0;
			}
			if (NPC.ai[0] != 0f)
			{
				NPC.frame.Y = frameHeight * 4;
			}
		
	}
        public override void HitEffect(int hitDirection, double damage)
        {
			Lighting.AddLight((int)(NPC.Center.X / 16f), (int)(NPC.Center.Y / 16f), 0.65f, 0.4f, 0.1f);
			float range = 60f;

			int dustsToMake = 5;
			for (int i = 0; i < dustsToMake; i++)
			{
				float radius = range / 50f;

				Vector2 speed = Main.rand.NextVector2CircularEdge(radius, radius);
				Dust d = Dust.NewDustPerfect(NPC.Center, DustID.Torch, speed * 5, Scale: 3f);
				if (Main.rand.NextBool(3))
				{
					d.scale *= Main.rand.NextFloat(1.25f, 1.5f);
					d.velocity *= Main.rand.NextFloat(1.10f, 1.20f);
				}
				d.noGravity = true;
			}
		}
    }

	public class PhoenixAsh : ModNPC
	{

		public override void SetStaticDefaults()
		{
			NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData
			{
				SpecificallyImmuneTo = new int[] {
					BuffID.OnFire,
					BuffID.OnFire3,
					BuffID.Confused // Most NPCs have this
				}
			};
			NPCID.Sets.DebuffImmunitySets.Add(Type, debuffData);
			DisplayName.SetDefault("Phoenix Ash"); // Automatic from .lang files
			Main.npcFrameCount[NPC.type] = 6; // make sure to set this for your modnpcs.
		}

		public override void SetDefaults()
		{
			NPC.width = 30;
			NPC.height = 18;
			NPC.value = 50000;
			NPC.damage = 10;
			NPC.defense = 0;
			NPC.lifeMax = 1250;
			NPC.scale = 1f;
			NPC.lavaImmune = true;
			NPC.knockBackResist = 0f;
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			for (int i = 0; i < 200; i++)
			{
				if (Main.npc[i].type == NPC.type && Main.npc[i].type == NPCType<Phoenix>())
					return 0f;
			}
			if (Main.hardMode && NPC.downedPlantBoss)
			{
				return SpawnCondition.Underworld.Chance * 0.16f;
			}
			return 0f;
		}
		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new List<IBestiaryInfoElement>
			{
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheUnderworld,
				new FlavorTextBestiaryInfoElement("The ashes of a dying phoenix. The fires of the Underworld will very quickly reignite its spirit.")
			});
		}
		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			npcLoot.Add(ItemDropRule.Common(ItemID.ChickenNugget, 5));
			npcLoot.Add(ItemDropRule.Common(ItemID.FireFeather, 10));
		}
		public override void HitEffect(int hitDirection, double damage)
		{
			for (int i = 0; i < 5; i++)
			{
				Dust.NewDustDirect(NPC.Center - NPC.Size / 4f, NPC.width / 2, NPC.height / 2, 6, Scale: 1.15f);
			}
			for (int i = 0; i < 8; i++)
			{
				Dust d = Dust.NewDustDirect(NPC.Center - NPC.Size / 4f, NPC.width / 2, NPC.height / 2, DustID.Ash);
				d.noGravity = true;
			}
		}
		int timeTillRevive = 300;
		public override void AI()
		{
			NPC.ai[0]++;
			if (NPC.wet)
			{
				if (NPC.collideY)
				{
					NPC.velocity.Y = -2f;
				}
				if (NPC.velocity.Y < 0f && NPC.ai[3] == NPC.position.X)
				{
					NPC.direction *= -1;
					NPC.ai[2] = 200f;
				}
				if (NPC.velocity.Y > 0f)
				{
					NPC.ai[3] = NPC.position.X;
				}

				if (NPC.velocity.Y > 2f)
				{
					NPC.velocity.Y *= 0.9f;
				}
				else if (NPC.directionY < 0)
				{
					NPC.velocity.Y -= 0.8f;
				}
				NPC.velocity.Y -= 0.5f;
				if (NPC.velocity.Y < -1f)
				{
					NPC.velocity.Y = -1f;
				}

			}

			if (NPC.ai[0] % (timeTillRevive / 6) == 0)
            {
				SoundEngine.PlaySound(SoundID.Item34, NPC.Center);
				for (int i = 0; i < 25; i++)
				{
					Vector2 speed = Main.rand.NextVector2CircularEdge(3f, 3f);
					Dust d = Dust.NewDustPerfect(NPC.Center, 6, speed * 2, Scale: 2.5f);
					d.noGravity = true;
				}
			}
			if (NPC.ai[0] == timeTillRevive)
            {
				NPC.life = 0;
				SoundEngine.PlaySound(SoundID.DD2_WyvernScream, NPC.Center);
				NPC.NewNPC(NPC.GetSource_Death(), (int)NPC.Center.X, (int)NPC.Center.Y, NPCType<Phoenix>());
				for (int i = 0; i < 100; i++)
				{
					Vector2 speed = Main.rand.NextVector2CircularEdge(3.6f, 3.6f);
					Dust d = Dust.NewDustPerfect(NPC.Center, DustID.Torch, speed * 5, Scale: 3f);
					d.noGravity = true;
				}
				for (int i = 0; i < 30; i++)
				{
					Dust dust7 = Dust.NewDustDirect(NPC.Center - NPC.Size / 4f, NPC.width / 2, NPC.height / 2, 31);
					dust7.noGravity = true;
					dust7.velocity *= 2.3f;
					dust7.fadeIn = 1.5f;
					dust7.noLight = true;
				}
			}
			if (Main.rand.NextBool((timeTillRevive - (int)NPC.ai[0]) / 4 + 1) ) // Divide by 4 to make it 4 times more likely, add 1 else it can become 0 and break
			{
				Dust dust7 = Dust.NewDustDirect(NPC.Center - NPC.Size / 4f, NPC.width / 2, NPC.height / 2, Utils.SelectRandom<int>(Main.rand, 6, 31, 31));
				dust7.noGravity = true;
				dust7.velocity *= 2.3f;
				dust7.fadeIn = 1.5f;
				dust7.noLight = true;
			}
		}
		int frame = 0;
		public override void FindFrame(int frameHeight)
		{
			if (NPC.ai[0] != 0)
			{
				frame = (int)(NPC.ai[0] / (timeTillRevive / 6));
				NPC.frame.Y = frameHeight * frame;
			}

		}
	}
}