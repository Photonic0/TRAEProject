using TRAEProject.NPCs;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
namespace TRAEProject.Buffs
{
	public class LavaShield : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Lava Shield");
			Description.SetDefault("Increases defense by 20");
		}
		public override string Texture => "TRAEProject/Buffs/LavaShield";

		public override void Update(Player player, ref int buffIndex)
		{
			player.statDefense += 20;
		}
	}
}