using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace TRAEProject.NewContent.Buffs
{
	public class NeoFeralBite : ModBuff
	{
		public override string Texture => "TRAEProject/NewContent/Buffs/NeoFeralBite";

		public override void SetStaticDefaults() {
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
			DisplayName.SetDefault("Feral Bite");
			Description.SetDefault("Causes confusion");
		}
		int timer = 0;

		public override void Update(Player player, ref int buffIndex)
		{

			timer++;
			if (timer > 540)
            {
				player.AddBuff(BuffID.Obstructed, 1);
timer = 0;
			}
			if (timer == 600)
			{
				float duration = Main.rand.Next(10, 25);
				player.AddBuff(BuffID.Confused, (int)duration);
			}
		}
	}
}