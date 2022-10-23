using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TRAEProject.Changes.Weapon.Ranged.Rockets;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using TRAEProject.NewContent.Items.Weapons.Ammo;
using TRAEProject.Common;
using TRAEProject.NewContent.TRAEDebuffs;
using TRAEProject.Common.ModPlayers;
using static Terraria.ModLoader.ModContent;
namespace TRAEProject.Changes.Weapon
{
    public class StunningProjectile : GlobalProjectile
    {
        public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[projectile.owner];
            if (projectile.owner == player.whoAmI)
            {

                if (projectile.GetGlobalProjectile<NewRockets>().HeavyRocket)
                {
                    target.GetGlobalNPC<Stun>().StunMe(target, 30);
                }
                if (player.GetModPlayer<RangedStats>().AlphaScope > 0  
                    && projectile.CountsAsClass(DamageClass.Ranged) 
                    && crit 
                    && damage >= 20)
                {
                    int chance = 100 / ((damage / 10) * player.GetModPlayer<RangedStats>().AlphaScope);
                    if (Main.rand.NextBool(chance))
                    {
                        int duration = 60; 
                        if (projectile.GetGlobalProjectile<NewRockets>().HeavyRocket)
                        {
                            duration += 30;
                        }
                        target.GetGlobalNPC<Stun>().StunMe(target, duration);
                    }
                }
                if (player.GetModPlayer<RangedStats>().RocketsStun > 0 
                    && projectile.GetGlobalProjectile<NewRockets>().IsARocket 
                    && crit 
                    && damage >= 20)
                {
                    int chance = 100 / (damage / 10 * (player.GetModPlayer<RangedStats>().AlphaScope + player.GetModPlayer<RangedStats>().RocketsStun));
                    if (Main.rand.NextBool(chance))
                    {
                        int duration = 60;
                        if (projectile.GetGlobalProjectile<NewRockets>().HeavyRocket)
                        {
                            duration += 30;
                        }
                        target.GetGlobalNPC<Stun>().StunMe(target, duration);
                    }
                   
                }
            
                switch (projectile.type)
                {
                    case ProjectileID.TheDaoofPow:
                        if (Main.rand.NextBool(3))
                        {
                            int duration = Main.rand.Next(60, 80);
                            target.GetGlobalNPC<Stun>().StunMe(target, duration);
                        }
                        break;
                    case ProjectileID.SolarWhipSword:
                    case ProjectileID.SolarWhipSwordExplosion:
                        if (Main.rand.NextBool(8))
                        {
                            int duration = Main.rand.Next(75, 100);
                            target.GetGlobalNPC<Stun>().StunMe(target, duration);
                        }
                        break;
                }
            }
        }
    }
}
