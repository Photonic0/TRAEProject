using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace TRAEProject.NewContent.Buffs
{
	public class StrongerPoisoned : ModBuff
	{
		public override void SetStaticDefaults()
		{
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
			DisplayName.SetDefault("Stronger Poisoned");
			Description.SetDefault("Yes, I'm fully aware that this is the exact opposite of what a Bezoar is for.");
		}
        public override void Update(NPC npc, ref int buffIndex)
        {
            int findbuffIndex = npc.FindBuffIndex(BuffID.Poisoned);
            if (findbuffIndex != -1)
            {
                npc.DelBuff(findbuffIndex);
            };
        }
    }
	public class StrongerPoisonedEffect : GlobalNPC
	{
                public override bool InstancePerEntity => true;
				public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
			if (npc.HasBuff(BuffType<StrongerPoisoned>()))
			{
			npc.lifeRegen -= 24;
            if (damage < 6)
            {
                damage = 6;
            }
			}
        }
        float R1 = 1f;
        float G1 = 1f;
        float B = 1f;
        float A = 1f;

        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            if (npc.HasBuff(BuffType<StrongerPoisoned>()))
			{
                if (Main.rand.Next(30) == 0)
                {
                    int index = Dust.NewDust(npc.position, npc.width, npc.height, 46, 0.0f, 0.0f, 120, default, 0.2f);
                    Main.dust[index].noGravity = true;
                    Main.dust[index].fadeIn = 1.9f;
                }
                R1 *= 0.65f;
                B *= 0.75f;
                drawColor = Main.buffColor(drawColor, R1, G1, B, A);
                return;
            }
        }
    }
    public class Bezoar : ModPlayer
    {
        public bool bezoar = false;

        public override void ResetEffects()
        {
            bezoar = false;
        }
        public override void UpdateDead()
        {
            bezoar = false;
        }
        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            if (bezoar && target.HasBuff(BuffID.Poisoned))
            {
                target.RequestBuffRemoval(BuffID.Poisoned);
                target.AddBuff(BuffType<StrongerPoisoned>(), 300);
            }
        }
        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if (bezoar && target.HasBuff(BuffID.Poisoned))
            {
                target.RequestBuffRemoval(BuffID.Poisoned);
                target.AddBuff(BuffType<StrongerPoisoned>(), 300);
            }
        }
    }
}