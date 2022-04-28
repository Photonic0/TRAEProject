using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using TRAEProject.Common;
using Terraria.Audio;
using Terraria.ModLoader;

namespace TRAEProject.NewContent.TRAEDebuffs
{
    public class ChargedArrowStacks : TRAEDebuff
    {
        Projectile projectile = null;
        Player player = null;
        public void SetProjectileAndPlayer(Projectile pRojectile, Player pLayer)
        {
            projectile = pRojectile;
            player = pLayer;
        }
        public override void Update(NPC npc)
        {
            npc.GetGlobalNPC<EnemyRing>().damage = projectile.damage;
            npc.GetGlobalNPC<EnemyRing>().player = player;
            npc.GetGlobalNPC<EnemyRing>().howManyStacks += 1;
        }
    }
    public class EnemyRing : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        public int damage = 0;
        public int howManyStacks = 0;
        public int attackDelay = 0;
       public Player player = null;
        public override void ResetEffects(NPC npc)
        {
            howManyStacks = 0;
        }
        public override void AI(NPC npc)
        {
            if (howManyStacks > 0)
            {
                int dusts = 3 + 1 * howManyStacks;
                int NPCLimit = 0;
                int Range = 75 + 25 * howManyStacks;
                
                float dustScale = 0.9f;

                attackDelay++;
                if (attackDelay >= 15)
                {
                    attackDelay = 0;

                    for (int k = 0; k < 200; k++)
                    {
                        NPC nPC = Main.npc[k];
                        if (nPC.whoAmI != npc.whoAmI && nPC.active && !nPC.friendly && nPC.damage > 0 && !nPC.dontTakeDamage && Vector2.Distance(npc.Center, nPC.Center) <= Range)
                        {
                            ++NPCLimit;
                            if (NPCLimit < 3)
                            {

                                int finalDefense = nPC.defense - (int)player.GetArmorPenetration(DamageClass.Generic);
                                nPC.ichor = false;
                                nPC.betsysCurse = false;
                                if (finalDefense < 0)
                                {
                                    finalDefense = 0;
                                }
                                if (finalDefense > 100)
                                {
                                    finalDefense = 100;
                                }
                                damage += finalDefense / 2;
      
                                player.ApplyDamageToNPC(nPC, damage, 0f, 0, crit: false);
                                SoundEngine.PlaySound(SoundID.Item93, nPC.position);
                            }
                        }
                    }

                }
                for (int i = 0; i < dusts; i++)
                {
                    Vector2 spawnPos = npc.Center + Main.rand.NextVector2CircularEdge(Range, Range);
                    Vector2 offset = spawnPos - npc.Center;
                    if (Math.Abs(offset.X) > Main.screenWidth * 0.6f || Math.Abs(offset.Y) > Main.screenHeight * 0.6f) //dont spawn dust if its pointless
                        continue;
                    Dust dust = Main.dust[Dust.NewDust(spawnPos, 0, 0, DustID.Electric, 0, 0, 100, default, dustScale)];
                    dust.velocity = npc.velocity;
                    //if (Main.rand.NextBool(3))
                    //{
                    //    dust.velocity += Vector2.Normalize(npc.Center - dust.position) * Main.rand.NextFloat(5f);
                    //    dust.position += dust.velocity * 5f;
                    //}
                    dust.noGravity = true;
                }
            }
        }
    }
}
