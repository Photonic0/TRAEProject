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
    public class Toxins : TRAEDebuff
    {
        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            npc.lifeRegen -= 80;
            npc.netUpdate = true;
            if (damage < 25)
            {
                damage = 25;
            }
        }
        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            drawColor.R = (byte)(drawColor.R * 0.80);
            drawColor.G = (byte)(drawColor.G * 0.90);
            drawColor.B = (byte)(drawColor.G * 0.40);
        }
    }
}
