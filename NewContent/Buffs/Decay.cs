using TRAEProject.NPCs;
using Terraria;
using Terraria.ModLoader;
using TRAEProject.Common;
namespace TRAEProject.NewContent.Buffs
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
		public override void Update(NPC npc, ref int buffIndex) {
			npc.GetGlobalNPC<TRAENPCDebuffEffects>().Decay = true;
		}
	}
}