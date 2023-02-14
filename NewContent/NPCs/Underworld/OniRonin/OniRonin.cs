using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
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
using TRAEProject.NewContent.Items.Materials;
using TRAEProject.NewContent.NPCs.Banners;
using TRAEProject.NewContent.NPCs.Underworld.Lavamander;
using TRAEProject.NewContent.NPCs.Underworld.Phoenix;
using static System.Formats.Asn1.AsnWriter;
using static Terraria.ModLoader.ModContent;
using static Terraria.ModLoader.PlayerDrawLayer;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace TRAEProject.NewContent.NPCs.Underworld.OniRonin
{
    public class OniRoninNPC : ModNPC
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
            NPC.defense = 30;
            NPC.lifeMax = 5000;
            NPC.lavaImmune = true;
            NPC.HitSound = SoundID.NPCHit21;
            NPC.DeathSound = SoundID.NPCDeath24;
            NPC.knockBackResist = 0f;
            NPC.noGravity = true;
            //DrawOffsetY = -2;
            NPC.scale = 1f;
            Banner = NPC.type;
            NPC.GetGlobalNPC<UnderworldEnemies>().HellMinibossThatSpawnsInPairs = true;
            BannerItem = ItemType<FroggabombaBanner>();
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new List<IBestiaryInfoElement>
            {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheUnderworld,
                new FlavorTextBestiaryInfoElement("Mysterious Demon that brings out the magical powers of world's flowers to attack its enemies.")
            });
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ItemID.Sake, 1, 1, 2));
            npcLoot.Add(ItemDropRule.Common(ItemType<DriedRose>(), 2));
            npcLoot.Add(ItemDropRule.Common(ItemID.ObsidianRose, 15));
        }
        public override void AI()
        {
            NPC.TargetClosest();
            NPC.FaceTarget();
            NPC.velocity.X *= 0.93f;
            if ((double)NPC.velocity.X > -0.1 && (double)NPC.velocity.X < 0.1)
            {
                NPC.velocity.X = 0f;
            }
            if (NPC.ai[0] == 0f)
            {
                NPC.ai[0] = 200f;
            }
            int teleportCooldown = 200; 
            if (NPC.Distance(NPC.GetTargetData().Center) >= 800f)
            {
                teleportCooldown /= 10;
            }
            NPC.ai[0] += 1f;
            if (NPC.ai[0] > 1000)
                teleportCooldown = 20;
            if (NPC.ai[0] % teleportCooldown == 0 && Main.netMode != 1)
            {
                int targetTileX = (int)Main.player[NPC.target].Center.X / 16;
                int targetTileY = (int)Main.player[NPC.target].Center.Y / 16;

                Vector2 chosenTile = Vector2.Zero;

                if (AI_AttemptToFindTeleportSpot(ref chosenTile, targetTileX, targetTileY))
                {


                    NPC.ai[1] = 0f;
                    NPC.ai[2] = chosenTile.X;
                    NPC.ai[3] = chosenTile.Y;




                }
                NPC.netUpdate = true;
            }
            if (NPC.ai[2] != 0f && NPC.ai[3] != 0f)
            {


                NPC.position += NPC.netOffset;
                SoundEngine.PlaySound(SoundID.Item8, NPC.position);
                for (int num70 = 0; num70 < 50; num70++)
                {

                    int num78 = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, 6, 0f, 0f, 100, default, 2.5f);
                    Dust dust = Main.dust[num78];
                    dust.velocity *= 3f;
                    Main.dust[num78].noGravity = true;

                }
                NPC.position -= NPC.netOffset;
                NPC.position.X = NPC.ai[2] * 16f - (float)(NPC.width / 2) + 8f;
                NPC.position.Y = NPC.ai[3] * 16f - (float)NPC.height;
                NPC.netOffset *= 0f;
                NPC.velocity.X = 0f;
                NPC.velocity.Y = 0f;
                NPC.ai[2] = 0f;
                NPC.ai[3] = 0f;
                SoundEngine.PlaySound(SoundID.Item8, NPC.position);
                for (int num79 = 0; num79 < 50; num79++)
                {

                    int num87 = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, 6, 0f, 0f, 100, default, 2.5f);
                    Dust dust = Main.dust[num87];
                    dust.velocity *= 3f;
                    Main.dust[num87].noGravity = true;

                }
            }



            if (NPC.ai[0] > 200 && NPC.ai[0] < 800 && Main.netMode != 1)
            {
                NPC.ai[1] += 1f;
                if (NPC.ai[1] > 35f && NPC.ai[1] % 25f == 0)
                {


                    SoundEngine.PlaySound(SoundID.Item8, NPC.position);
                    int petal = ProjectileType<OniPetal>();
                    if (Main.rand.NextBool(5) && Main.expertMode)
                    {
                        petal = ProjectileType<OniFirePetal>();
                    }
                    Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, petal, 30, 0f);


                }
            }
            else if (NPC.ai[0] >= 800 && Main.netMode != 1)
            {
                NPC.ai[1] += 1f;
                if (NPC.ai[1] > 35f && NPC.ai[1] % 8f == 0)
                {
                    Player player = Main.player[NPC.target];
                    float posX = player.Center.X;
                    float posY = player.Center.Y;
                    SoundEngine.PlaySound(SoundID.Item13, NPC.position);

                    float speed = 7.5f;      
                    int petal = ProjectileType<OniPetal2>();
                    if (Main.rand.NextBool(5) && Main.expertMode)
                    {
                        petal = ProjectileType<OniFirePetal2>();
                        speed = 10f;
                    }
					float velX = posX - NPC.Center.X;
                    float velY = posY - NPC.Center.Y;
                    float sqrRoot = (float)Math.Sqrt(velX * velX + velY * velY);
                    sqrRoot = speed / sqrRoot;
                    velX *= sqrRoot;
                    velY *= sqrRoot;
                    Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center.X, NPC.Center.Y, velX, velY, petal, 30, 0f);
                }
            }
            if (NPC.ai[0] > 1200)
            {
                NPC.ai[0] = 0;
            }

            if (Main.rand.Next(2) == 0)
            {
                int num117 = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y + 2f), NPC.width, NPC.height, 6, NPC.velocity.X * 0.2f, NPC.velocity.Y * 0.2f, 100, default, 2f);
                Main.dust[num117].noGravity = true;
                Main.dust[num117].velocity.X *= 1f;
                Main.dust[num117].velocity.Y *= 1f;
            }
            NPC.position -= NPC.netOffset;




        }
        public bool AI_AttemptToFindTeleportSpot(ref Vector2 chosenTile, int targetTileX, int targetTileY, int rangeFromTargetTile = 20, int telefragPreventionDistanceInTiles = 5, int solidTileCheckFluff = 1, bool solidTileCheckCentered = false, bool teleportInAir = true)
        {
            int num = (int)NPC.Center.X / 16;
            int num2 = (int)NPC.Center.Y / 16;
            int num3 = 0;
            bool flag = false;
            float num4 = 20f;
            if (Math.Abs(num * 16 - targetTileX * 16) + Math.Abs(num2 * 16 - targetTileY * 16) > 2000)
            {
                num3 = 100;
                flag = false;
            }
            while (!flag && num3 < 100)
            {
                num3++;
                int num5 = Main.rand.Next(targetTileX - rangeFromTargetTile, targetTileX + rangeFromTargetTile + 1);
                for (int i = Main.rand.Next(targetTileY - rangeFromTargetTile, targetTileY + rangeFromTargetTile + 1); i < targetTileY + rangeFromTargetTile; i++)
                {
                    if ((i >= num2 - 1 && i <= num2 + 1 && num5 >= num - 1 && num5 <= num + 1) || (!teleportInAir && !Main.tile[num5, i].IsActuated))
                    {
                        continue;
                    }
                    bool flag2 = true;
                    if (Main.tile[num5, i - 1].LiquidType == 1)
                    {
                        flag2 = false;
                    }

                    if (!((!solidTileCheckCentered) ? (!Collision.SolidTiles(num5 - solidTileCheckFluff, num5 + solidTileCheckFluff, i - 3 - solidTileCheckFluff, i - 1)) : (!Collision.SolidTiles(num5 - solidTileCheckFluff, num5 + solidTileCheckFluff, i - solidTileCheckFluff, i + solidTileCheckFluff))))
                    {
                        continue;
                    }
                    Rectangle rectangle = new Rectangle(num5 * 16, i * 16, 16, 16);
                    rectangle.Inflate(telefragPreventionDistanceInTiles * 16, telefragPreventionDistanceInTiles * 16);
                    for (int j = 0; j < Main.player.Length; j++)
                    {
                        Player player = Main.player[j];
                        if (player != null && player.active && !player.DeadOrGhost)
                        {
                            Rectangle value = player.Hitbox;
                            Rectangle value2 = value.Modified((int)(player.velocity.X * num4), (int)(player.velocity.Y * num4), 0, 0);
                            Rectangle.Union(ref value2, ref value, out value2);
                            if (value2.Intersects(rectangle))
                            {
                                flag2 = false;
                                flag = false;
                                break;
                            }
                        }
                    }

                    if (flag2)
                    {

                        chosenTile = new Vector2(num5, i);

                        flag = true;

                    }
                    break;
                }

            }
            return flag;
        }
        public override bool PreKill()
        {

            Gore.NewGore(NPC.GetSource_Death(), NPC.Center, NPC.velocity, Mod.Find<ModGore>("OniRoninGore1").Type, 1f);
           
            Gore.NewGore(NPC.GetSource_Death(), NPC.Center, NPC.velocity, Mod.Find<ModGore>("OniRoninGore2").Type, 1f);
            Gore.NewGore(NPC.GetSource_Death(), NPC.Center, NPC.velocity, Mod.Find<ModGore>("OniRoninGore3").Type, 1f);
            Gore.NewGore(NPC.GetSource_Death(), NPC.Center, NPC.velocity, Mod.Find<ModGore>("OniRoninGore4").Type, 1f);
            return true;

        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return NPC.GetGlobalNPC<UnderworldEnemies>().MinibossSpawn();

        }
    
        public override void FindFrame(int frameHeight)
        {
            NPC.frame.Y = 0;
            if (NPC.ai[1] > 35f)
            {
                if (NPC.ai[0] > 200 && NPC.ai[0] < 800)
                {
                    NPC.frame.Y = frameHeight * 1;
                }
                if (NPC.ai[0] > 800 && NPC.ai[0] < 1000)
                {
                    NPC.frame.Y = frameHeight * 2;
                }
            }
        }
    }
    public class OniPetal : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 4;
            DisplayName.SetDefault("Oni Petal");     //The English name of the Projectile
        }
        public override void SetDefaults()
        {
            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 300;
            Projectile.tileCollide = false; 

        }
        int frame = Main.rand.Next(0, 3); 
        float maxSpin = Main.rand.NextFloat(2.25f, 2.75f);


        public override void AI()
        {
            Projectile.frame = frame;

            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);
            if (Projectile.ai[0] == 0 && Projectile.ai[1] == 0)
            {
                Projectile.ai[0] = Projectile.Center.X;
                Projectile.ai[1] = Projectile.Center.Y;
            }
            if (Projectile.ai[0] > 0 && Projectile.ai[1] > 0)
            {
                int radius = 75;
                Projectile.localAI[0] += 1f / 60;
                Projectile.Center = new Vector2(Projectile.ai[0], Projectile.ai[1]) + Vector2.One.RotatedBy(Projectile.localAI[0] * Math.PI) * radius;
                if (Projectile.localAI[0] >= maxSpin)
                {
                    Projectile.ai[0] = 0;
                    Projectile.ai[1] = 0;

                    for (int o = 0; o < 255; ++o)
                    {
                        Player player = Main.player[o];
                        if (o >= 0 && player.active && !player.dead)
                        {
                            float posX = player.Center.X;
                            float posY = player.Center.Y;
                            float Distance = Math.Abs(Projectile.Center.X - posX) + Math.Abs(Projectile.Center.Y - posY);

                            if (Distance > 1600f)
                            {
                                Projectile.Kill();
                            }
                            float speed = 5f;
                            float velX = posX - Projectile.Center.X;
                            float velY = posY - Projectile.Center.Y;
                            float sqrRoot = (float)Math.Sqrt(velX * velX + velY * velY);
                            sqrRoot = speed / sqrRoot;
                            velX *= sqrRoot;
                            velY *= sqrRoot;
                            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, velX, velY, ProjectileType<OniPetal2>(), 40, 0f);
                            Projectile.Kill();
                            return;
                        }

                    }
                }

            }
        }
    }
    public class OniPetal2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 4;
            DisplayName.SetDefault("Oni Petal");     //The English name of the Projectile
        }
        public override void SetDefaults()
        {
            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 300;
            Projectile.tileCollide = false; 

        }
        int frame = Main.rand.Next(0, 3);
        public override void AI()
        {
            Projectile.frame = frame;
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);
        }
    }
    public class OniFirePetal : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 4;
            DisplayName.SetDefault("Fire Petal");     //The English name of the Projectile
        }
        public override void SetDefaults()
        {
            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 300;
            Projectile.tileCollide = false; 

        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.OnFire, Main.rand.Next(300, 450));
        }
        int frame = Main.rand.Next(0, 3);
        float maxSpin = Main.rand.NextFloat(1.75f, 2.75f);
        public override void AI()
        {
            if (Main.rand.NextBool(8))
            {
                int num117 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y + 2f), Projectile.width, Projectile.height, 6, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100, default, 2f);
                Main.dust[num117].noGravity = true;
                Main.dust[num117].velocity.X *= 1f;
                Main.dust[num117].velocity.Y *= 1f;
            }    
            Projectile.frame = frame;

            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);
            if (Projectile.ai[0] == 0 && Projectile.ai[1] == 0)
            {
                Projectile.ai[0] = Projectile.Center.X;
                Projectile.ai[1] = Projectile.Center.Y;
            }
            if (Projectile.ai[0] > 0 && Projectile.ai[1] > 0)
            {
                int radius = 75;
                Projectile.localAI[0] += 1f / 60f;
                Projectile.Center = new Vector2(Projectile.ai[0], Projectile.ai[1]) + Vector2.One.RotatedBy(Projectile.localAI[0] * Math.PI) * radius;
                if (Projectile.localAI[0] >= maxSpin)
                {
                    Projectile.ai[0] = 0;
                    Projectile.ai[1] = 0;

                    for (int o = 0; o < 255; ++o)
                    {
                        Player player = Main.player[o];
                        if (o >= 0 && player.active && !player.dead)
                        {
                            float posX = player.Center.X;
                            float posY = player.Center.Y;
                            float Distance = Math.Abs(Projectile.Center.X - posX) + Math.Abs(Projectile.Center.Y - posY);

                            if (Distance > 1600f)
                            {
                                Projectile.Kill();
                            }
                            float speed = 7.5f;
                            float velX = posX - Projectile.Center.X;
                            float velY = posY - Projectile.Center.Y;
                            float sqrRoot = (float)Math.Sqrt(velX * velX + velY * velY);
                            sqrRoot = speed / sqrRoot; 
                            velX *= sqrRoot;
                            velY *= sqrRoot;
                            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, velX, velY, ProjectileType<OniFirePetal2>(), 40, 0f);
                            Projectile.Kill();
                            break;
                        }

                    }

                }

            }
        }
    }
    public class OniFirePetal2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 4;
            DisplayName.SetDefault("Fire Petal");     //The English name of the Projectile
        }
        public override void SetDefaults()
        {
            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 300;
            Projectile.tileCollide = false;
        }
        int frame = Main.rand.Next(0, 3);

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.OnFire, Main.rand.Next(300, 450));
        }
        public override void AI()
        {
            if (Main.rand.NextBool(8))
            {
                int num117 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y + 2f), Projectile.width, Projectile.height, 6, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100, default, 2f);
                Main.dust[num117].noGravity = true;
                Main.dust[num117].velocity.X *= 1f;
                Main.dust[num117].velocity.Y *= 1f;
            }
            Projectile.frame = frame;
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);
        }
    }
}