using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace TRAEProject.Buffs
{
	public class CoolWhipTag: ModBuff
	{
		public override void SetStaticDefaults() 
		{
			Main.debuff[Type] = true;
			BuffID.Sets.IsAnNPCWhipDebuff[Type] = true;
			Main.buffNoSave[Type] = true;
			DisplayName.SetDefault("CoolWhipDebuff");
			Description.SetDefault("Okay, how in the hell did you get this debuff on you");
		}
		public override string Texture => "TRAEProject/Buffs/CoolWhipTag";
		public override void Update(NPC npc, ref int buffIndex) 
		{
			npc.GetGlobalNPC<ChangesNPCs>().TagDamage += 8;
		}
	}
}