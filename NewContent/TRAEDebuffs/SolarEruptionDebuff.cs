using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using TRAEProject.Common;

namespace TRAEProject.NewContent.TRAEDebuffs
{
    public class SolarEruptionDebuff : TRAEDebuff
    {
        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (npc.HasBuff(BuffID.Daybreak))
            if (npc.lifeRegen > 0)
            {
                npc.lifeRegen = 0;
            }
            npc.lifeRegen -= 600;
            if (damage < 100)
            {
                damage = 100;
            }
            npc.netUpdate = true;
        }
        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            if (Main.rand.Next(2) < 1)
            {
                int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 127, npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f, 100, default, 3f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 2.4f;
                Main.dust[dust].velocity.Y -= 0.4f;
                if (Main.rand.NextBool(4))
                {
                    Main.dust[dust].noGravity = false;
                    Main.dust[dust].scale *= 0.9f;
                }
            }
            Lighting.AddLight(npc.position, 0.1f, 0.2f, 0.7f);
        }
    }
}
