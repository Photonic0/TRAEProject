using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using TRAEProject.Common;

namespace TRAEProject.Changes.Projectiles.Spears
{
    public class BoneSpear : Spear
    {
        public override void SpearDefaults()
        {
            spearLength = 59f;
            stabStart = 34f;
            stabEnd = -10;
            swingAmount = (float)Math.PI / 32;
        }
    }
    public class BoneSpearThrow : SpearThrow
    {
        public override void SpearDefaults()
        {
            spearLength = 59f;
            holdAt = 17f;
            maxSticks = 6;
            stickingDps = 3;
        }
    }
}
