using Terraria;
using Terraria.ModLoader;
using TRAEProject.Common;
using static Terraria.ModLoader.ModContent;
namespace TRAEProject.Buffs
{
    public class Impaled : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Impaled");
            Description.SetDefault("Ouch!");
            Main.debuff[Type] = true;

        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            if (npc.lifeRegen > 0)
            {
                npc.lifeRegen = 0;
            }
            int JavelinCount = 0;
            int impaleDamage = 0;
            for (int i = 0; i < 1000; i++)
            {
                if (Main.projectile[i].active && Main.projectile[i].ModProjectile != null && (Main.projectile[i].ModProjectile is SpearThrow) && Main.projectile[i].ai[0] == 1f && Main.projectile[i].ai[1] == (float)npc.whoAmI)
                {
                    SpearThrow spear = (SpearThrow)Main.projectile[i].ModProjectile;
                    impaleDamage += spear.stickingDps;
                    JavelinCount++;
                }
            }
            npc.lifeRegen -= impaleDamage * 2;
            npc.lifeRegenExpectedLossPerSecond = impaleDamage;
        }
    }
}