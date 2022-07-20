using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TRAEProject.NewContent.Items.Materials;
using TRAEProject.NewContent.Items.Weapons.Jungla;
using TRAEProject.NewContent.Items.Weapons.Ammo;
using static Terraria.ModLoader.ModContent;

namespace TRAEProject.Changes.Items
{
    public class Bags : GlobalItem
    {
		public static readonly int[] ShadowChestLoot = new int[] { ItemID.HellwingBow, ItemID.Flamelash, ItemID.FlowerofFire, ItemID.Sunfury };
		
		public override bool PreOpenVanillaBag(string context, Player player, int arg)
		{
			if (context == "bossBag" && arg == ItemID.EyeOfCthulhuBossBag)
			{
				if (Main.tenthAnniversaryWorld && !Main.getGoodWorld)
				{
					player.TryGettingDevArmor(player.GetSource_OpenItem(arg));
				}
				if (Main.rand.Next(7) == 0)
				{
					player.QuickSpawnItem(player.GetSource_OpenItem(arg), 2112);
				}
				if (Main.rand.Next(30) == 0)
				{
					player.QuickSpawnItem(player.GetSource_OpenItem(arg), 1299);
				}
				if (WorldGen.crimson)
				{
					int num9 = Main.rand.Next(20) + 10;
					num9 += Main.rand.Next(20) + 10;
					num9 += Main.rand.Next(20) + 10;
					player.QuickSpawnItem(player.GetSource_OpenItem(arg), 880, num9);
					num9 = Main.rand.Next(3) + 1;
					player.QuickSpawnItem(player.GetSource_OpenItem(arg), 2171, num9);
					num9 = Main.rand.Next(30) + 20;
					player.QuickSpawnItem(player.GetSource_OpenItem(arg), ItemType<BloodyArrow>(), num9);
				}
				else
				{
					int num10 = Main.rand.Next(20) + 10;
					num10 += Main.rand.Next(20) + 10;
					num10 += Main.rand.Next(20) + 10;
					player.QuickSpawnItem(player.GetSource_OpenItem(arg), 56, num10);
					num10 = Main.rand.Next(3) + 1;
					player.QuickSpawnItem(player.GetSource_OpenItem(arg), 59, num10);
					num10 = Main.rand.Next(30) + 20;
					player.QuickSpawnItem(player.GetSource_OpenItem(arg), 47, num10);
				}
				player.QuickSpawnItem(player.GetSource_OpenItem(arg), 3097);
				return false;
			}
			if (context == "bossBag" && arg == ItemID.SkeletronBossBag)
			{
			player.QuickSpawnItem(player.GetSource_OpenItem(arg), ItemID.BoneGlove, 1);
				if (Main.rand.Next(3) == 0)
				player.QuickSpawnItem(player.GetSource_OpenItem(arg),ItemID.SkeletronHand, 1);
				if (Main.rand.Next(3) == 0)
				player.QuickSpawnItem(player.GetSource_OpenItem(arg),ItemID.SkeletronMask, 1);
				return false;
			}
			if (context == "bossBag" && arg == ItemID.PlanteraBossBag)
			{
				player.TryGettingDevArmor(player.GetSource_OpenItem(arg));
				if (Main.rand.Next(7) == 0)
				{
				player.QuickSpawnItem(player.GetSource_OpenItem(arg),ItemID.PlanteraMask);
				}
			player.QuickSpawnItem(player.GetSource_OpenItem(arg),ItemID.TempleKey);
			player.QuickSpawnItem(player.GetSource_OpenItem(arg),ItemID.SporeSac);
				if (Main.rand.Next(15) == 0)
				{
				player.QuickSpawnItem(player.GetSource_OpenItem(arg),ItemID.Seedling);
				}
				if (Main.rand.Next(20) == 0)
				{
				player.QuickSpawnItem(player.GetSource_OpenItem(arg),ItemID.TheAxe);
				}
				if (Main.rand.Next(2) == 0)
				{
				player.QuickSpawnItem(player.GetSource_OpenItem(arg),ItemID.PygmyStaff);
				}
				if (Main.rand.Next(10) == 0)
				{
				player.QuickSpawnItem(player.GetSource_OpenItem(arg),ItemID.ThornHook);
				}
				switch (Main.rand.Next(3))
				{
					case 0:
					player.QuickSpawnItem(player.GetSource_OpenItem(arg),ItemType<Jungla>());
					player.QuickSpawnItem(player.GetSource_OpenItem(arg),ItemID.VenusMagnum);
						break;
					case 1:
					player.QuickSpawnItem(player.GetSource_OpenItem(arg),ItemID.Seedler);
					player.QuickSpawnItem(player.GetSource_OpenItem(arg),ItemID.FlowerPow);
						break;
					case 2:
					player.QuickSpawnItem(player.GetSource_OpenItem(arg),ItemID.LeafBlower);
					player.QuickSpawnItem(player.GetSource_OpenItem(arg),ItemID.NettleBurst);
						break;
				}
				return false;
			}
			if (context == "bossBag" && arg == ItemID.CultistBossBag) // TO DO
			{
				player.QuickSpawnItem(player.GetSource_OpenItem(arg), ItemID.LunarCraftingStation);
				player.QuickSpawnItem(player.GetSource_OpenItem(arg), ItemType<LuminiteFeather>());
			}
				if (context == "bossBag" && arg == ItemID.FairyQueenBossBag) 
			{
				player.TryGettingDevArmor(player.GetSource_OpenItem(arg));
			player.QuickSpawnItem(player.GetSource_OpenItem(arg),ItemID.EmpressFlightBooster);
				if (Main.rand.Next(7) == 0)
				{
				player.QuickSpawnItem(player.GetSource_OpenItem(arg),ItemID.FairyQueenMask);
				}
				if (Main.rand.Next(10) == 0)
				{
				player.QuickSpawnItem(player.GetSource_OpenItem(arg),ItemID.RainbowWings);
				}
				if (Main.rand.Next(20) == 0)
				{
				player.QuickSpawnItem(player.GetSource_OpenItem(arg),ItemID.SparkleGuitar);
				}
				if (Main.rand.Next(4) == 0)
				{
				player.QuickSpawnItem(player.GetSource_OpenItem(arg),ItemID.HallowBossDye);
				}
				if (Main.rand.Next(20) == 0)
				{
				player.QuickSpawnItem(player.GetSource_OpenItem(arg),ItemID.RainbowCursor);
				}
				switch (Main.rand.Next(4))
				{
					case 0:
					player.QuickSpawnItem(player.GetSource_OpenItem(arg),ItemID.PiercingStarlight);
						break;
					case 1:
					player.QuickSpawnItem(player.GetSource_OpenItem(arg),ItemID.FairyQueenMagicItem);
						break;
					case 2:
					player.QuickSpawnItem(player.GetSource_OpenItem(arg),ItemID.FairyQueenRangedItem);
						break;
					case 3:
					player.QuickSpawnItem(player.GetSource_OpenItem(arg),ItemID.RainbowCrystalStaff);
						break;
				}
				return false;
			}
			if (context == "bossBag" && arg == ItemID.MoonLordBossBag) // TO DO
			{
				player.TryGettingDevArmor(player.GetSource_OpenItem(arg));
				if (Main.rand.Next(7) == 0)
				{
				player.QuickSpawnItem(player.GetSource_OpenItem(arg),ItemID.BossMaskMoonlord);
				}
				if (Main.rand.Next(10) == 0)
				{
				player.QuickSpawnItem(player.GetSource_OpenItem(arg),ItemID.MeowmereMinecart);
				}
				if (!player.HasItem(ItemID.PortalGun))
				{
				player.QuickSpawnItem(player.GetSource_OpenItem(arg),3384);
				}
			player.QuickSpawnItem(player.GetSource_OpenItem(arg),ItemID.LunarOre, Main.rand.Next(90, 111));
			player.QuickSpawnItem(player.GetSource_OpenItem(arg),ItemID.GravityGlobe);
			player.QuickSpawnItem(player.GetSource_OpenItem(arg),ItemID.SuspiciousLookingTentacle);
			player.QuickSpawnItem(player.GetSource_OpenItem(arg),4954); // celestial starboard
				int item = Utils.SelectRandom<int>(Main.rand, 3063, 3389, 1553, 3930, 3541, 3570, ItemID.RainbowWhip, ItemID.StardustDragonStaff);
			player.QuickSpawnItem(player.GetSource_OpenItem(arg),item); 
				return false;
			}

			if (context == "crate" && (arg == ItemID.OasisCrate || arg == ItemID.OasisCrateHard))
			{
				int index = Main.rand.Next(ChestLoot.PyramidItems.Length);
				int itemWhoAmI = Item.NewItem(player.GetSource_OpenItem(arg), (int)player.position.X, (int)player.position.Y, player.width, player.height, ChestLoot.PyramidItems[index], 1, noBroadcast: false, -1);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, null, itemWhoAmI, 1f);
				}

				if (Main.rand.Next(4) == 0)
				{
					int bombAmount = Main.rand.Next(4, 7);
					int itemWhoAmI2 = Item.NewItem(player.GetSource_OpenItem(arg),(int)player.position.X, (int)player.position.Y, player.width, player.height, ItemID.ScarabBomb, bombAmount);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, null, itemWhoAmI2, 1f);
					}
				}
				if (Main.rand.Next(2) == 0)
				{
					int fossilAmount = Main.rand.Next(10, 17);
					int itemWhoAmI3 = Item.NewItem(player.GetSource_OpenItem(arg),(int)player.position.X, (int)player.position.Y, player.width, player.height, ItemID.FossilOre, fossilAmount);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, null, itemWhoAmI3, 1f);
					}
				}
				FishingCrateLoot(player, arg);
				return false;
			}
			if (context == "obsidianLockBox")
			{
				int index = Main.rand.Next(ChestLoot.ShadowItems.Length);
				int number = Item.NewItem(player.GetSource_OpenItem(arg),(int)player.position.X, (int)player.position.Y, player.width, player.height, ChestLoot.ShadowItems[index], 1, noBroadcast: false, -1);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, null, number, 1f);
				}
				return false;
			}
			return true;
		}
		void FishingCrateLoot(Player player, int crateItemID)
        {
			if (Main.rand.Next(4) == 0)
			{
				int num28 = Main.rand.Next(6);
				switch (num28)
				{
					case 0:
						num28 = 288;
						break;
					case 1:
						num28 = 296;
						break;
					case 2:
						num28 = 304;
						break;
					case 3:
						num28 = 305;
						break;
					case 4:
						num28 = 2322;
						break;
					case 5:
						num28 = 2323;
						break;
				}
				int stack35 = Main.rand.Next(2, 5);
				int number55 = Item.NewItem(player.GetSource_OpenItem(num28),(int)player.position.X, (int)player.position.Y, player.width, player.height, num28, stack35);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, null, number55, 1f);
				}
			}
			if (Main.rand.Next(2) == 0)
			{
				int type28 = Main.rand.Next(188, 190);
				int stack36 = Main.rand.Next(5, 18);
				int number56 = Item.NewItem(player.GetSource_OpenItem(type28),(int)player.position.X, (int)player.position.Y, player.width, player.height, type28, stack36);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, null, number56, 1f);
				}
			}
			if (Main.rand.Next(2) == 0)
			{
				int type29 = ((Main.rand.Next(2) != 0) ? 2675 : 2676);
				int stack37 = Main.rand.Next(2, 7);
				int number57 = Item.NewItem(player.GetSource_OpenItem(type29),(int)player.position.X, (int)player.position.Y, player.width, player.height, type29, stack37);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, null, number57, 1f);
				}
			}
			bool hardmode = ItemID.Sets.IsFishingCrateHardmode[crateItemID];
			if (!hardmode)
			{
				return;
			}
			if (Main.rand.Next(2) == 0)
			{
				int type37 = 521;
				if (crateItemID == 3986)
				{
					type37 = 520;
				}
				int stack40 = Main.rand.Next(2, 6);
				int number65 = Item.NewItem(player.GetSource_OpenItem(type37),(int)player.position.X, (int)player.position.Y, player.width, player.height, type37, stack40);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, null, number65, 1f);
				}
			}
			if (Main.rand.Next(2) == 0)
			{
				int type38 = 522;
				int stack41 = Main.rand.Next(2, 6);
				switch (crateItemID)
				{
					case 3983:
						type38 = 1332;
						break;
					case 3986:
						type38 = 502;
						stack41 = Main.rand.Next(4, 11);
						break;
				}
				int number66 = Item.NewItem(player.GetSource_OpenItem(type38),(int)player.position.X, (int)player.position.Y, player.width, player.height, type38, stack41);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, null, number66, 1f);
				}
			}
		}
    }
}
