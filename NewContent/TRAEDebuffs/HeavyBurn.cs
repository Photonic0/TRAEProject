using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using TRAEProject.Common;

namespace TRAEProject.NewContent.TRAEDebuffs
{
    public class HeavyBurn : TRAEDebuff
    {

        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (npc.lifeRegen > 0)
            {
                npc.lifeRegen = 0;
            }
            npc.lifeRegen -= 120;
            if (damage < 10)
            {
                damage = 10;
            }
            npc.netUpdate = true;
        }
        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            if (Main.rand.Next(3) < 2)
            {
                int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 127, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default, 2.5f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 1.8f;
                Main.dust[dust].velocity.Y -= 0.5f;
                if (Main.rand.NextBool(4))
                {
                    Main.dust[dust].noGravity = false;
                    Main.dust[dust].scale *= 0.5f;
                }
            }
            Lighting.AddLight(npc.position, 0.1f, 0.2f, 0.7f);
            if (Main.rand.Next(3) < 2)
            {
                int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 127, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default, 2.5f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 1.8f;
                Main.dust[dust].velocity.Y -= 0.5f;
                if (Main.rand.NextBool(4))
                {
                    Main.dust[dust].noGravity = false;
                    Main.dust[dust].scale *= 0.5f;
                }
            }
            Lighting.AddLight(npc.position, 0.1f, 0.2f, 0.7f);
        }
    }
}
