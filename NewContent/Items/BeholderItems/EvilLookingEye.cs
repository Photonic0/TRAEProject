using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace TRAEProject.NewContent.Items.BeholderItems
{
	public class EvilLookingEye : ModItem
	{
		public override void SetStaticDefaults()
		{
			Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

			//DisplayName.SetDefault("Evil Looking Eye");
			//Tooltip.SetDefault("Summons a baby Beholder");
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.DukeFishronPetItem);
			Item.shoot = ProjectileType<EvilLookingEyePet>();
			Item.buffType = BuffType<EvilLookingEyeBuff>();
		}

		public override void UseStyle(Player player, Rectangle heldItemFrame)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(Item.buffType, 3600, true);
			}
		}
	}
	public class EvilLookingEyePet : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Baby Beholder");
			Main.projFrames[Projectile.type] = 12;
			Main.projPet[Projectile.type] = true;
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.ZephyrFish);
			AIType = ProjectileID.ZephyrFish;
		}

		public override bool PreAI()
		{
			Player player = Main.player[Projectile.owner];
			player.zephyrfish = false; // Relic from aiType
			return true;
		}
		public override void AI()
		{
			Player player = Main.player[Projectile.owner];
			Projectile.frameCounter++;
			if (Projectile.frameCounter >= 9)
			{
				Projectile.frameCounter = 0;
				Projectile.frame = (Projectile.frame + 1) % 12;
			}
			if (player.dead)
			{
				player.GetModPlayer<EvilLookingEyePlayer>().EvilLookingEyePet = false;
			}
			if (player.GetModPlayer<EvilLookingEyePlayer>().EvilLookingEyePet)
			{
				Projectile.timeLeft = 2;
			}
		}
	}
	public class EvilLookingEyePlayer : ModPlayer
	{
		public bool EvilLookingEyePet;
		public override void ResetEffects()
		{
            EvilLookingEyePet = false;
		}
	}
	public class EvilLookingEyeBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			// //DisplayName and Description are automatically set from the .lang files, but below is how it is done normally.
			//DisplayName.SetDefault("Baby Beholder");
			//Description.SetDefault("It can't shoot lasers yet. I think.");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}
		public override void Update(Player player, ref int buffIndex)
		{
			player.buffTime[buffIndex] = 18000;
			player.GetModPlayer<EvilLookingEyePlayer>().EvilLookingEyePet = true;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[ProjectileType<EvilLookingEyePet>()] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.GetSource_FromThis(), player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ProjectileType<EvilLookingEyePet>(), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}
