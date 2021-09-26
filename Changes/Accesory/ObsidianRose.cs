using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace TRAEProject.Changes.Accesory
{
    public class ObsidianRose : ModPlayer
    {
        bool rose = false;
        public override void ResetEffects()
        {
            rose = false;
        }
        public override void PostUpdateEquips()
        {
            if(Player.lavaRose)
            {
                Player.lavaRose = false;
                rose = true;
            }
        }
        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if(proj.CountsAsClass(DamageClass.Magic) && rose)
            {

            }
        }
    }
}
