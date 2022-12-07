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

namespace TRAEProject.NewContent.NPCs.Underworld.Lavamander
{
    public class Lavamander : ModNPC
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
			DisplayName.SetDefault("Lavamander"); 
            Main.npcFrameCount[NPC.type] = 5; // make sure to set this for your modnpcs.
        }

		public override void SetDefaults()
		{
			NPC.width = 84;
			NPC.height = 20;
            NPC.aiStyle = 3;
            AIType = NPCID.WalkingAntlion;
			//AnimationType = NPCID.WalkingAntlion;
			NPC.value = 5000;
			NPC.damage = 35;
			NPC.defense = 8;
			NPC.lifeMax = 120;
			NPC.lavaImmune = true;
			NPC.HitSound = SoundID.NPCHit26;
			NPC.DeathSound = SoundID.NPCDeath29;
			NPC.knockBackResist = 0.25f;
			NPC.scale = 1.15f;
			Banner = NPC.type; 
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
        public override void AI()
        {
			NPC.noGravity = false;
			int num = 2;
			int num2 = 2;
			int num3 = (int)((NPC.position.X + (NPC.width / 2)) / 16f);
			int num4 = (int)((NPC.position.Y + NPC.height) / 16f);
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
							jump += 4; // jumps way more often if it can reach you
						if (jump >= 750f) // We have to force it to jump, its normal AI won't let it jump while "water walking"
						{
							jump = 0;
							NPC.velocity.Y = -8f;
							NPC.velocity.X *= 1.5f;

						}
					}
				}
			}
		}
		public override bool PreKill()
		{

			Gore.NewGore(NPC.GetSource_Death(), NPC.Center, NPC.velocity, Mod.Find<ModGore>("PhoenixGore2").Type, 1f);
			Gore.NewGore(NPC.GetSource_Death(), NPC.Center, NPC.velocity, Mod.Find<ModGore>("PhoenixGore3").Type, 1f);
			Gore.NewGore(NPC.GetSource_Death(), NPC.Center, NPC.velocity, Mod.Find<ModGore>("PhoenixGore4").Type, 1f);
			return false;

		}

		int frame = 0;
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