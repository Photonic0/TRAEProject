using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace TRAEProject.Changes
{
    public class BladeImmunePlayer : ModPlayer
    {
        NPC justHit = null;
        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            justHit = target;
        }
        public override bool? CanHitNPC(Item item, NPC target)
        {
            if(target.GetGlobalNPC<BladeImmune>().immune[Player.whoAmI] != 0)
            {
                return false;
            }
            return base.CanHitNPC(item, target);
        }
        public override void PostItemCheck()
        {
            if (justHit != null)
            {
                justHit.GetGlobalNPC<BladeImmune>().immune[Player.whoAmI] = justHit.immune[Player.whoAmI];
                justHit.immune[Player.whoAmI] = 0;
                justHit = null;
            }
        }
    }
    public class BladeImmune : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        public int[] immune = new int[256];
        public override bool PreAI(NPC npc)
        {
            for (int j = 0; j < 256; j++)
            {
                if (immune[j] > 0)
                {
                    immune[j]--;
                }
            }
            return base.PreAI(npc);
        }
    }
}
