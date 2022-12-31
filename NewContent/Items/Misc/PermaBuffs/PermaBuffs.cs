using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace TRAEProject.NewContent.Items.Misc.PermaBuffs
{
	public class PermaBuffs : ModPlayer
	{
		public bool speedWish;
		public override void PostUpdateBuffs()
		{
			if(speedWish)
			{
				Player.moveSpeed += 0.15f;
			}
		}

		public override void SyncPlayer(int toWho, int fromWho, bool newPlayer) 
		{
			ModPacket packet = Mod.GetPacket();
			packet.Write((byte)Player.whoAmI);
			packet.Write((bool)speedWish);
			packet.Send(toWho, fromWho);
		}

		// Called in ExampleMod.Networking.cs
		public void ReceivePlayerSync(BinaryReader reader)
		{
			speedWish = reader.ReadBoolean();
		}

		public override void clientClone(ModPlayer clientClone) {
			PermaBuffs clone = clientClone as PermaBuffs;
			clone.speedWish = speedWish;
		}

		public override void SendClientChanges(ModPlayer clientPlayer) 
		{
			PermaBuffs clone = clientPlayer as PermaBuffs;

			if (speedWish != clone.speedWish)
			{
				SyncPlayer(toWho: -1, fromWho: Main.myPlayer, newPlayer: false);
			}
		}

		// NOTE: The tag instance provided here is always empty by default.
		// Read https://github.com/tModLoader/tModLoader/wiki/Saving-and-loading-using-TagCompound to better understand Saving and Loading data.
		public override void SaveData(TagCompound tag) 
		{
			tag["speedWish"] = speedWish;
		}

		public override void LoadData(TagCompound tag) 
		{
			speedWish = tag.GetBool("speedWish");
		}
	}
}