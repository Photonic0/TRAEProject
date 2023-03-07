using TRAEProject.NPCs;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
namespace TRAEProject.NewContent.Buffs
{
	public class SandRush : ModBuff
	{
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("Sand Rush");
			// Description.SetDefault("Movement speed increased by 20%");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.moveSpeed += 0.20f;
			player.jumpSpeedBoost += Mobility.JSV(0.20f);

		}
	}
}