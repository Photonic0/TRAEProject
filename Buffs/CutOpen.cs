using TRAEProject.NPCs;
using Terraria;
using Terraria.ModLoader;
namespace TRAEProject.Buffs
{
	public class CutOpen : ModBuff
	{
		public override void SetStaticDefaults() 
		{
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
			DisplayName.SetDefault("CutOpen");
			Description.SetDefault("Losing life, and lowered Defenese. Except not, because you are a player and therefore you shouldn't even have this.");
		}
		public override string Texture => "TRAEProject/Buffs/CutOpen";
		public override void Update(NPC npc, ref int buffIndex) {
			npc.defense -= 20;
		}
	}
}