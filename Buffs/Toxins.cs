using TRAEProject.NPCs;
using Terraria;
using Terraria.ModLoader;
namespace TRAEProject.Buffs
{
	public class Toxins : ModBuff
	{
		public override string Texture => "TRAEProject/Buffs/TitaPenetrate";
		public override void SetStaticDefaults()
		{
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
			DisplayName.SetDefault("Toxins");
			Description.SetDefault("Toxic toxic toxic toxic");
		}
		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<ChangesNPCs>().Toxins = true;
		}
	}
}