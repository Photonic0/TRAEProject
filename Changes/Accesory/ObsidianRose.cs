using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using TRAEProject.NewContent.Buffs;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using TRAEProject.Common;
using TRAEProject.NewContent.TRAEDebuffs;

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
                TRAEDebuff.Apply<BindingFlames>(target, Main.rand.Next(240, 360), 1);
            }
        }
    }
}
