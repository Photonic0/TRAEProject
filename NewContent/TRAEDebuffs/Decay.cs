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
    public class Decay : TRAEDebuff
    {
        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {

            if (npc.lifeRegen > 0)
            {
                npc.lifeRegen = 0;
            }
            npc.lifeRegen -= 16;
            if (damage < 2)
            {
                damage = 2;
            }
            npc.netUpdate = true;
        }
        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            drawColor.R = (byte)(drawColor.R * 0.85);
            drawColor.G = (byte)(drawColor.G * 0.99);
            drawColor.B = (byte)(drawColor.G * 0.47);
        }
    }
}
