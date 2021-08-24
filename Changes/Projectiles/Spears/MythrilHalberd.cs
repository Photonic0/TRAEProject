using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using TRAEProject.Common;
using TRAEProject.Common.ModPlayers;

namespace TRAEProject.Changes.Projectiles.Spears
{
    class MythrilHalberd : Spear
    {
        public override void SpearDefaults()
        {
            spearLength = 141f;
            stabStart = 119f;
            stabEnd = -10;
            swingAmount = (float)Math.PI / 24;
        }
        float origonalAim = 0;
        public override void OnStart()
        {
            origonalAim = aimDirection;
        }
        int maxInterupting = 0;
        bool soundPlayed = false;
        public override void Channeling()
        {
            Player player = Main.player[Projectile.owner];
            Projectile.friendly = false;
            if (interupting < player.itemAnimationMax)
            {
                interupting++;
                maxInterupting = interupting;
            }
            else
            {
                if (player.autoReuseGlove)
                {
                    player.channel = false;
                }
                else
                {
                    if(!soundPlayed)
                    {

                        SoundEngine.PlaySound(25, player.Center, 0);
                        soundPlayed = true;
                    }
                }
            }
            for(int i =0; i < 200; i++)
            {
                hitCount[i] = 0;
            }
            SetAimDirecition();
        }
        public override void InteruptedAnimation()
        {
            Projectile.friendly = true;
            interupting -= 3;
            SetAimDirecition();
        }
        void SetAimDirecition()
        {
            Player player = Main.player[Projectile.owner];
            aimDirection = origonalAim + (float)Math.PI * player.direction * -1f * ((float)interupting / (float)player.itemAnimationMax);
        }
        public override void SpearModfiyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if(maxInterupting > 0)
            {
                Player player = Main.player[Projectile.owner];
                damage += (int)(damage * (2 * (float)maxInterupting / (float)player.itemAnimationMax));
            }
        }
    }
    public class MythrilHalberdThrow : SpearThrow
    {
        public override void SpearDefaults()
        {
            spearLength = 141f;
            holdAt = 85f;
            maxSticks = 1;
            stickingDps = 0;
            floatTime = 10;
        }
    }
}
