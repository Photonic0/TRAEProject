using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace TRAEProject.NewContent.Buffs
{
	public class NeoFeralBite : ModBuff
	{

		public override void SetStaticDefaults() {
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
			DisplayName.SetDefault("Feral Bite");
			Description.SetDefault("Causes confusion");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			if (Main.rand.Next(600) == 0)
			{
				float duration = Main.rand.Next(15, 20);
				player.AddBuff(BuffID.Confused, (int)duration);
			}
		}
	}
}