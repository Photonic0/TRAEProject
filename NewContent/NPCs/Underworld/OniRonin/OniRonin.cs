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
	public class OniRonin : ModNPC
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
			DisplayName.SetDefault("Oni Ronin");
			Main.npcFrameCount[NPC.type] = 3;
		}

		public override void SetDefaults()
		{
			NPC.width = 38;
			NPC.height = 52;
			//NPC.aiStyle = 3;
			//AIType = NPCID.DesertBeast;
			//AnimationType = NPCID.WalkingAntlion;
			NPC.value = 5000;
			NPC.damage = 70;
			NPC.defense = 33;
			NPC.lifeMax = 5000;
			NPC.lavaImmune = true;
			NPC.HitSound = SoundID.NPCHit22;
			NPC.DeathSound = SoundID.NPCDeath24;
			NPC.knockBackResist = 0f;
			//DrawOffsetY = -2;
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
		public override void AI()
		{
                TargetClosest();
                velocity.X *= 0.93f;
                if ((double)velocity.X > -0.1 && (double)velocity.X < 0.1)
                {
                    velocity.X = 0f;
                }
                if (this.ai[0] == 0f)
                {
                    this.ai[0] = 500f;
                }
                if (this.ai[2] != 0f && this.ai[3] != 0f)
                {
                    position += netOffset;
                    if (type == 172)
                    {
                        alpha = 255;
                    }
                    SoundEngine.PlaySound(SoundID.Item8, position);
                    for (int num70 = 0; num70 < 50; num70++)
                    {
                        if (type == 29 || type == 45)
                        {
                            int num71 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 27, 0f, 0f, 100, default(Color), Main.rand.Next(1, 3));
                            Dust dust = Main.dust[num71];
                            dust.velocity *= 3f;
                            if (Main.dust[num71].scale > 1f)
                            {
                                Main.dust[num71].noGravity = true;
                            }
                        }
                        else if (type == 32)
                        {
                            int num72 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 172, 0f, 0f, 100, default(Color), 1.5f);
                            Dust dust = Main.dust[num72];
                            dust.velocity *= 3f;
                            Main.dust[num72].noGravity = true;
                        }
                        else if (type == 283 || type == 284)
                        {
                            int num73 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 173);
                            Dust dust = Main.dust[num73];
                            dust.velocity *= 2f;
                            Main.dust[num73].scale = 1.4f;
                        }
                        else if (type == 285 || type == 286)
                        {
                            int num74 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 174, 0f, 0f, 100, default(Color), 1.5f);
                            Dust dust = Main.dust[num74];
                            dust.velocity *= 3f;
                            Main.dust[num74].noGravity = true;
                        }
                        else if (type == 281 || type == 282)
                        {
                            int num75 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 175, 0f, 0f, 100, default(Color), 1.5f);
                            Dust dust = Main.dust[num75];
                            dust.velocity *= 3f;
                            Main.dust[num75].noGravity = true;
                        }
                        else if (type == 172)
                        {
                            int num76 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 106, 0f, 0f, 100, default(Color), 2.5f);
                            Dust dust = Main.dust[num76];
                            dust.velocity *= 3f;
                            Main.dust[num76].noGravity = true;
                        }
                        else if (type == 533)
                        {
                            int num77 = Dust.NewDust(position, width, height, 27, 0f, 0f, 100, default(Color), 2.5f);
                            Dust dust = Main.dust[num77];
                            dust.velocity *= 3f;
                            Main.dust[num77].noGravity = true;
                        }
                        else
                        {
                            int num78 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 6, 0f, 0f, 100, default(Color), 2.5f);
                            Dust dust = Main.dust[num78];
                            dust.velocity *= 3f;
                            Main.dust[num78].noGravity = true;
                        }
                    }
                    position -= netOffset;
                    position.X = this.ai[2] * 16f - (float)(width / 2) + 8f;
                    position.Y = this.ai[3] * 16f - (float)height;
                    netOffset *= 0f;
                    velocity.X = 0f;
                    velocity.Y = 0f;
                    this.ai[2] = 0f;
                    this.ai[3] = 0f;
                    SoundEngine.PlaySound(SoundID.Item8, position);
                    for (int num79 = 0; num79 < 50; num79++)
                    {
                        if (type == 29 || type == 45)
                        {
                            int num80 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 27, 0f, 0f, 100, default(Color), Main.rand.Next(1, 3));
                            Dust dust = Main.dust[num80];
                            dust.velocity *= 3f;
                            if (Main.dust[num80].scale > 1f)
                            {
                                Main.dust[num80].noGravity = true;
                            }
                        }
                        else if (type == 32)
                        {
                            int num81 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 172, 0f, 0f, 100, default(Color), 1.5f);
                            Dust dust = Main.dust[num81];
                            dust.velocity *= 3f;
                            Main.dust[num81].noGravity = true;
                        }
                        else if (type == 172)
                        {
                            int num82 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 106, 0f, 0f, 100, default(Color), 2.5f);
                            Dust dust = Main.dust[num82];
                            dust.velocity *= 3f;
                            Main.dust[num82].noGravity = true;
                        }
                        else if (type == 283 || type == 284)
                        {
                            int num83 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 173);
                            Dust dust = Main.dust[num83];
                            dust.velocity *= 2f;
                            Main.dust[num83].scale = 1.4f;
                        }
                        else if (type == 285 || type == 286)
                        {
                            int num84 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 174, 0f, 0f, 100, default(Color), 1.5f);
                            Dust dust = Main.dust[num84];
                            dust.velocity *= 3f;
                            Main.dust[num84].noGravity = true;
                        }
                        else if (type == 281 || type == 282)
                        {
                            int num85 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 175, 0f, 0f, 100, default(Color), 1.5f);
                            Dust dust = Main.dust[num85];
                            dust.velocity *= 3f;
                            Main.dust[num85].noGravity = true;
                        }
                        else if (type == 533)
                        {
                            int num86 = Dust.NewDust(position, width, height, 27, 0f, 0f, 100, default(Color), 2.5f);
                            Dust dust = Main.dust[num86];
                            dust.velocity *= 3f;
                            Main.dust[num86].noGravity = true;
                        }
                        else
                        {
                            int num87 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 6, 0f, 0f, 100, default(Color), 2.5f);
                            Dust dust = Main.dust[num87];
                            dust.velocity *= 3f;
                            Main.dust[num87].noGravity = true;
                        }
                    }
                }
                this.ai[0] += 1f;

                    if (this.ai[0] == 100f || this.ai[0] == 200f || this.ai[0] == 300f)
                    {
                        this.ai[1] = 30f;
                        netUpdate = true;
                    }
                
                if (this.ai[0] >= 650f && Main.netMode != 1)
                {
                    this.ai[0] = 1f;
                    int targetTileX = (int)Main.player[target].Center.X / 16;
                    int targetTileY = (int)Main.player[target].Center.Y / 16;
                    Vector2 chosenTile = Vector2.Zero;
                    if (AI_AttemptToFindTeleportSpot(ref chosenTile, targetTileX, targetTileY))
                    {
                        this.ai[1] = 20f;
                        this.ai[2] = chosenTile.X;
                        this.ai[3] = chosenTile.Y;
                    }
                    netUpdate = true;
                }
                if (this.ai[1] > 0f)
                {
                    this.ai[1] -= 1f;
                    if (this.ai[1] == 25f)
                    {

                            if (type != 172)
                            {
                                SoundEngine.PlaySound(SoundID.Item8, position);
                            }
                            if (Main.netMode != 1)
                            {
                                if (type == 29)
                                {
                                    NewNPC(GetSpawnSourceForProjectileNPC(), (int)position.X + width / 2, (int)position.Y - 8, 30);
                                }
                                else if (type == 45)
                                {
                                    NewNPC(GetSpawnSourceForProjectileNPC(), (int)position.X + width / 2, (int)position.Y - 8, 665);
                                }
                                else if (type == 32)
                                {
                                    NewNPC(GetSpawnSourceForProjectileNPC(), (int)position.X + width / 2, (int)position.Y - 8, 33);
                                }
                                else if (type == 172)
                                {
                                    float num102 = 10f;
                                    Vector2 vector14 = new Vector2(position.X + (float)width * 0.5f, position.Y + (float)height * 0.5f);
                                    float num103 = Main.player[target].position.X + (float)Main.player[target].width * 0.5f - vector14.X + (float)Main.rand.Next(-10, 11);
                                    float num104 = Main.player[target].position.Y + (float)Main.player[target].height * 0.5f - vector14.Y + (float)Main.rand.Next(-10, 11);
                                    float num105 = (float)Math.Sqrt(num103 * num103 + num104 * num104);
                                    num105 = num102 / num105;
                                    num103 *= num105;
                                    num104 *= num105;
                                    int num106 = 40;
                                    int num107 = 129;
                                    int num108 = Projectile.NewProjectile(GetSpawnSource_ForProjectile(), vector14.X, vector14.Y, num103, num104, num107, num106, 0f, Main.myPlayer);
                                    Main.projectile[num108].timeLeft = 300;
                                    localAI[0] = 0f;
                                }
                                else
                                {
                                    NewNPC(GetSpawnSourceForProjectileNPC(), (int)position.X + width / 2 + direction * 8, (int)position.Y + 20, 25);
                                }
                            }
                        
                    }
                }
                position += netOffset;

                else if (Main.rand.Next(2) == 0)
                {
                    int num117 = Dust.NewDust(new Vector2(position.X, position.Y + 2f), width, height, 6, velocity.X * 0.2f, velocity.Y * 0.2f, 100, default(Color), 2f);
                    Main.dust[num117].noGravity = true;
                    Main.dust[num117].velocity.X *= 1f;
                    Main.dust[num117].velocity.Y *= 1f;
                }
                position -= netOffset;
            



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

			
		}
	}
}