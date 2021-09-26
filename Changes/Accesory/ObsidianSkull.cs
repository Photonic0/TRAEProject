using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace TRAEProject.Changes.Accesory
{

    public class ObsidianSkullEffect : ModPlayer
    {
        bool skull = false;
        public override void ResetEffects()
        {
            skull = false;
        }
        public override void PostUpdateEquips()
        {
            if (Player.fireWalk)
            {
                Player.fireWalk = false;
                skull = true;
            }
        }
        public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
        {
            if ((target.Center - Player.Center).Length() < 300f)
            {
                damage = (int)(damage * 1.1f);
            }
        }
        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if ((target.Center - Player.Center).Length() < 300f)
            {
                damage = (int)(damage * 1.1f);
            }
        }
    }
}
