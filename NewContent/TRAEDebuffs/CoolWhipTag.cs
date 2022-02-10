using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using TRAEProject.Changes.Weapon.Summon.Minions;
using TRAEProject.Common;

namespace TRAEProject.NewContent.TRAEDebuffs
{
    public class CoolWhipTag : TRAEDebuff
    {
        public override void Update(NPC npc)
        {
            npc.GetGlobalNPC<Tag>().Damage += 8;
        }
    }
}
