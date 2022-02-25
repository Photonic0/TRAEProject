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
		int timer = 0;
		public override void Update(Player player, ref int buffIndex)
		{
			timer++;
			if (timer > 240)
            {
				player.AddBuff(BuffID.Obstructed, 1);
			}
			if (timer == 300)
			{
				float duration = Main.rand.Next(30, 45);
				player.AddBuff(BuffID.Confused, (int)duration);
				timer = 0;
			}
		
		}
	}
}