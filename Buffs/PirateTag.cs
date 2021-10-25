using Terraria;
using Terraria.ModLoader;
namespace TRAEProject.Buffs
{
	public class PirateTag: ModBuff
	{
		public override void SetStaticDefaults() 
		{
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
			DisplayName.SetDefault("PirateSetDebuff");
			Description.SetDefault("Yarr! Ye a bad cheating ladd! Cheatin' in all these debuffs in your system ain't ya?");
		}
		public override string Texture => "TRAEProject/Buffs/PirateTag";
		public override void Update(NPC npc, ref int buffIndex) 
		{
		}
	}
}