using Terraria;
using Terraria.ModLoader;
namespace TRAEProject.Buffs
{
	public class Celled: ModBuff
	{
		public override void SetStaticDefaults() {
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
			DisplayName.SetDefault("Celled");
			Description.SetDefault("Being eaten by cells");
		}
		public override string Texture => "TRAEProject/Buffs/Celled";
		public override void Update(Player player, ref int buffIndex) {
			player.GetModPlayer<TRAEPlayer>().Celled = true;
		}
	}
}