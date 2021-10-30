using TRAEProject.NPCs;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
namespace TRAEProject.Buffs
{
	public class WaterAffinity : ModBuff
	{
		public override string Texture => "TRAEProject/Buffs/WaterAffinity";


		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Water Affinity");
			Description.SetDefault("Running Speed increased");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.moveSpeed += 0.5f;
		}
	}
}