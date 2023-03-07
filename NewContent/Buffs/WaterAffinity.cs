using TRAEProject.NPCs;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
namespace TRAEProject.NewContent.Buffs
{
	public class WaterAffinity : ModBuff
	{


		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("Water Affinity");
			// Description.SetDefault("Running Speed increased");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.moveSpeed += 0.33f;
		}
	}
}