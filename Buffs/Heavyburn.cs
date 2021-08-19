using TRAEProject.NPCs;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
namespace TRAEProject.Buffs
{
	public class Heavyburn: ModBuff
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Heavyburn");
			Description.SetDefault("Losing life");
		}
		public override string Texture => "TRAEProject/Buffs/TitaPenetrate";
		public override void Update(NPC npc, ref int buffIndex) {
			npc.GetGlobalNPC<ChangesNPCs>().Heavyburn = true;
		}
	}
}