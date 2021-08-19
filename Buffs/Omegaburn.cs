using TRAEProject.NPCs;
using Terraria;
using Terraria.ModLoader;
namespace TRAEProject.Buffs
{
	public class Omegaburn : ModBuff
	{
		public override string Texture => "TRAEProject/Buffs/Omegaburn";

		public override void SetStaticDefaults() {
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
			DisplayName.SetDefault("Omegaburn");
			Description.SetDefault("Melting extremely rapidly. If you manage to read this in-game without god mode cheats, you deserve a medal.");
		}

		public override void Update(NPC npc, ref int buffIndex) {
			npc.GetGlobalNPC<ChangesNPCs>().Omegaburn = true;
		}
	}
}