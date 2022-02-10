using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace TRAEProject.Common.ModPlayers
{
    public class SummonStats : ModPlayer
    {
        public int minionCritChance = 0;

        public override void ResetEffects()
        {
            minionCritChance = 0;
        }
        public override void UpdateDead()
        {
            minionCritChance = 0;
        }
    }
}
