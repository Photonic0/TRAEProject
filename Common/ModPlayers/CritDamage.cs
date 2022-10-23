using Microsoft.Xna.Framework;
using System;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using TRAEProject.NewContent.Buffs;
using TRAEProject.NewContent.Projectiles;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using TRAEProject.Changes;

namespace TRAEProject.Common.ModPlayers
{
    public class CritDamage : ModPlayer
    {
        public float critDamage = 0f;
        public float meleeCritDamage = 0f;
        public float arrowCritDamage = 0f; 
        public override void ResetEffects()
        {
            critDamage = 0f;
            meleeCritDamage = 0f;
            arrowCritDamage = 0f;
        }
        public override void UpdateDead()
        {
            critDamage = 0f;
            meleeCritDamage = 0f;
            arrowCritDamage = 0f;
        }
        public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
        {
            
            if (crit)
            {
                float multiplier = critDamage + meleeCritDamage;
                damage += (int)(damage * multiplier);
            }
                
        }
        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (crit)
            {
                if (proj.CountsAsClass(DamageClass.Melee))
                {
                    float multiplier = critDamage + meleeCritDamage;
                    if (proj.arrow && proj.CountsAsClass(DamageClass.Ranged))
                    {
                        multiplier += arrowCritDamage;
                    }
                    damage += (int)(damage * multiplier);
                }
            }
            
        }
    }
}
