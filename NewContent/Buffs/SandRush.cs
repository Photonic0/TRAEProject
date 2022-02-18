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
			DisplayName.SetDefault("Sand Rush");
			Description.SetDefault("Running and jumping speed increased by 25%");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.moveSpeed += 0.25f;
			player.jumpSpeedBoost += 1.5f;
		}
	}
}