using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TRAEProject.Common;
namespace TRAEProject.NewContent.Buffs
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
		public override void Update(NPC npc, ref int buffIndex) 
		{
			npc.GetGlobalNPC<TRAENPCDebuffEffects>().TagDamage += 8;
		}
	}
}