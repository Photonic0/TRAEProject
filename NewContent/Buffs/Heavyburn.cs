using TRAEProject.NPCs;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using TRAEProject.Common;
namespace TRAEProject.NewContent.Buffs
{
	public class Heavyburn: ModBuff
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Heavyburn");
			Description.SetDefault("Losing life");
		}
		public override void Update(NPC npc, ref int buffIndex) {
			npc.GetGlobalNPC<TRAENPCDebuffEffects>().Heavyburn = true;
		}
	}
}