using Mono.Cecil.Cil;
using MonoMod.Cil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using TRAEProject.Buffs;
using static Terraria.ModLoader.ModContent;

namespace TRAEProject.Common.ModPlayers
{
    class RangedStats : ModPlayer
    {

        public int Magicquiver = 0; 
        public int Magicandgunquiver = 0;
        public float rangedVelocity = 1f; 
        public float gunVelocity = 1f;
        public override void ResetEffects()
        {
            Magicquiver = 0; 
            Magicandgunquiver = 0;
            rangedVelocity = 1f; 
            gunVelocity = 1f;
        }
    }
}
