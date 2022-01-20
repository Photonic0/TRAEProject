using TRAEProject.NPCs;
using Terraria;
using Terraria.ModLoader;
using TRAEProject.Common;
namespace TRAEProject.NewContent.Buffs
{
	public class Omegaburn : ModBuff
	{

		public override void SetStaticDefaults() {
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
			DisplayName.SetDefault("Omegaburn");
			Description.SetDefault("Melting extremely rapidly. If you manage to read this in-game without god mode cheats, you deserve a medal.");
		}

		public override void Update(NPC npc, ref int buffIndex) {
			npc.GetGlobalNPC<TRAENPCDebuffEffects>().Omegaburn = true;
		}
	}
}