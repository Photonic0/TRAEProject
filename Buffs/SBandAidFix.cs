using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace TRAEProject.Buffs
{
    public class BandAidFix : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            DisplayName.SetDefault("Band Aid Fix");
            Description.SetDefault("wait, don't band-aids actually help you HEAL your wounds?");
        }
        public override string Texture => "TRAEProject/Buffs/SBandAidFix";
    }
    public class BandAidFixEffect : GlobalNPC
    {
                public override bool InstancePerEntity => true;
		public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (npc.HasBuff(BuffType<BandAidFix>()))
			{
			if (npc.lifeRegen < 0)
            npc.lifeRegen = (int)(npc.lifeRegen * 1.5);
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
                target.AddBuff(BuffType<BandAidFix>(), 300);
            }
        }
        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if (Bandaid)
            {
                target.AddBuff(BuffType<BandAidFix>(), 300);
            }
        }
    }
}