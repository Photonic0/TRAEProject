using TRAEProject.NPCs;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
namespace TRAEProject.Buffs
{
	public class LavaShield : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("LavaShield");
			Description.SetDefault("Reduces damage taken by 12% and increases defense by 10");
		}
		public override string Texture => "TRAEProject/Buffs/LavaShield";

		public override void Update(Player player, ref int buffIndex)
		{
			player.endurance += 0.12f;
			player.statDefense += 10;
		}
	}
}