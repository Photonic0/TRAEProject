﻿using Microsoft.Xna.Framework;
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

namespace TRAEProject.Changes.Weapon.Melee.SpearProjectiles
{
    class PalladiumPike : Spear
    {
        public override void SpearDefaults()
        {
            spearLength = 141f;
            stabStart = 116f;
            stabEnd = 40;
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
                    if (!soundPlayed)
                    {

                        SoundEngine.PlaySound(SoundID.MaxMana, player.Center);
                        soundPlayed = true;
                    }
                }
            }
            for (int i = 0; i < 200; i++)
            {
                hitCount[i] = 0;
            }

            SetAimDirecition(out float amt);
            outAmount = 1f + amt / 2f;
        }
        public override void InteruptedAnimation()
        {
            Projectile.friendly = true;
            interupting -= 1;
            SetAimDirecition(out _);
            outAmount = 1.5f;
        }
        public override void SpearActive()
        {
            Player player = Main.player[Projectile.owner];
            if (!player.channel && interupting > 0)
            {
                Projectile.extraUpdates = 2;
            }
            else
            {
                Projectile.extraUpdates = 0;
            }
        }
        void SetAimDirecition(out float amt)
        {
            Player player = Main.player[Projectile.owner];
            amt = ((float)interupting / (float)player.itemAnimationMax);
            amt *= amt;
            aimDirection = origonalAim + 5f * ((float)Math.PI / 6f) * player.direction * -1f * amt;
        }
        public override void SpearModfiyHitNPCMelee(NPC target, ref NPC.HitModifiers modifiers)
        {
            if (maxInterupting > 0)
            {
                Player player = Main.player[Projectile.owner];
                modifiers.FinalDamage.Base *= 3 * (float)maxInterupting / (float)player.itemAnimationMax;
            }
        }
        public override void SpearHitNPCMelee(NPC target, NPC.HitInfo hit)
        {
            Player player = Main.player[Projectile.owner];

                player.AddBuff(BuffID.RapidHealing, 300);
        }
    }
    public class PalladiumPikeThrow : SpearThrow
    {
        public override void SpearDefaults()
        {
            spearLength = 141f;
            holdAt = 85f;
            maxSticks = 1;
            stickingDps = 0;
            floatTime = 10;
            DustOnDeath = DustID.Palladium;
            DustOnDeathCount = 30;


        }
        public override void SpearHitNPC(bool atMaxCharge, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (atMaxCharge)
            {
                Player player = Main.player[Projectile.owner];

                    player.AddBuff(BuffID.RapidHealing, 300);
            }
        }
    }
}
