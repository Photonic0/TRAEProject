using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace TRAEProject.NewContent.Buffs
{
    public class SBandAidFix : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            // DisplayName.SetDefault("Band Aid Fix");
            // Description.SetDefault("wait, don't band-aids actually help you HEAL your wounds?");
        }
    }
    public class BandAidFixEffect : GlobalNPC
    {
                public override bool InstancePerEntity => true;
		public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (npc.HasBuff(BuffType<SBandAidFix>()))
			{
                if (npc.lifeRegen < 0)
                {
                    npc.lifeRegen = (int)(npc.lifeRegen * 1.5);
                    damage *= 3;
                    damage /= 2;
                }
            }
        }
    }
    public class BandAid : ModPlayer
    {
        public bool Bandaid = false;

        public override void ResetEffects()
        {
            Bandaid = false;
        }
        public override void UpdateDead()
        {
            Bandaid = false;
        }

        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            if (Bandaid)
            {
                target.AddBuff(BuffType<SBandAidFix>(), 300);
            }
        }
        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if (Bandaid)
            {
                target.AddBuff(BuffType<SBandAidFix>(), 300);
            }
        }
    }
}