using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using TRAEProject.Common;

namespace TRAEProject.NewContent.TRAEDebuffs
{
    public class BindingFlames : TRAEDebuff
    {
        public override void Update(NPC npc)
        {
            Dust d = Main.dust[Dust.NewDust(npc.position, npc.width, npc.height, 6)];
            d.velocity = (npc.Center - d.position).SafeNormalize(-Vector2.UnitY) * 2f;
        }
    }

	public class BindingFlameEffect : GlobalNPC
	{
		public override void ModifyHitPlayer(NPC npc, Player target, ref int damage, ref bool crit)
		{
			if (npc.GetGlobalNPC<ProcessTRAEDebuffs>().HasDebuff<BindingFlames>())
			{
				damage = (int)(damage * 0.85f);
			}
		}
	}
}
