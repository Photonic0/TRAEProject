using TRAEProject.NPCs;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;

namespace TRAEProject.NewContent.Buffs
{
	public class BindingFlames : ModBuff
	{
		public override void SetStaticDefaults()
		{
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
			DisplayName.SetDefault("Binding Flames");
			Description.SetDefault("You deal 15% less contact damage. Except not, because you are a player and therefore you shouldn't even have this.");
		}
        public override void Update(NPC npc, ref int buffIndex)
        {
			Dust d = Main.dust[Dust.NewDust(npc.position, npc.width, npc.height, 6)];
			d.velocity = (npc.Center - d.position).SafeNormalize(-Vector2.UnitY) * 2f;
        }
    }
	public class BindingFlameEffect : GlobalNPC
	{
		public override void ModifyHitPlayer(NPC npc, Player target, ref int damage, ref bool crit)
		{
			if (npc.HasBuff(BuffType<BindingFlames>()))
			{
				damage = (int)(damage * 0.85f);
			}
		}
	}
}