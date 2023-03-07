using TRAEProject.NPCs;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
namespace TRAEProject.NewContent.Buffs
{
	public class NanoHealing : ModBuff
	{
		public override void SetStaticDefaults() 
		{
			//DisplayName.SetDefault("Nano Healing");
			//Description.SetDefault("Being repaired by nanites");
		}
		public override void Update(Player player, ref int buffIndex)
		{
			Dust dust = Dust.NewDustDirect(player.oldPosition, player.width, player.height, 135, 1, 1, 0, default, 1f);
			dust.noGravity = true;
		}
	}
}