using TRAEProject.NPCs;
using Terraria;
using Terraria.ModLoader;
namespace TRAEProject.Buffs
{
	public class Decay : ModBuff
	{
		public override void SetStaticDefaults() 
		{
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
			DisplayName.SetDefault("Decay");
			Description.SetDefault("Losing life");
		}
		public override string Texture => "TRAEProject/Buffs/TitaPenetrate";
		public override void Update(NPC npc, ref int buffIndex) {
			npc.GetGlobalNPC<ChangesNPCs>().Decay = true;
		}
	}
}