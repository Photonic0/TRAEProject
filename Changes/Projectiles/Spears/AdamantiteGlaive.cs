using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using TRAEProject.Common;

namespace TRAEProject.Changes.Projectiles.Spears
{
    class AdamantiteGlaive : Spear
    {
        public override void SpearDefaults()
        {
            spearLength = 155.5f;
            stabStart = 123f;
            stabEnd = -10;
            swingAmount = (float)Math.PI / 16;
        }
    }
    public class AdamantiteGlaiveThrow : SpearThrow
    {
        public override void SpearDefaults()
        {
            spearLength = 155.5f;
            holdAt = 93f;
            Projectile.penetrate = -1;
            floatTime = 120;
        }
    }
}
