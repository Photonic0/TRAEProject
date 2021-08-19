using Terraria;
using Terraria.ModLoader;
namespace TRAEProject.Buffs
{
	public class MagicBoost : ModBuff
	{

		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Magic Boost");
			Description.SetDefault("Magic damage increased by 20%");
		}
		public override string Texture => "TRAEProject/Buffs/MagicBoost";

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetDamage<MagicDamageClass>() += 0.2f;
		}
	}
}