using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TRAEProject.Common;

namespace TRAEProject.Common
{
    public  class TRAENPCDebuffEffects : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        public bool titaPenetrate;
        public bool BoilingBlood = false;
        public int BoilingBloodDMG = 0;
        public bool Heavyburn;
        public bool Decay;
        public bool Toxins;
        public bool Corrupted;
        public int TagDamage = 0;
        public int TagCritChance = 0;
        public bool Omegaburn;
        public override void ResetEffects(NPC npc)
        {
            Decay = false;
            Toxins = false;
            BoilingBlood = false;
            titaPenetrate = false;
            Heavyburn = false;
            Omegaburn = false;
            Corrupted = false;
            TagDamage = 0;
            TagCritChance = 0;
        }
        
        public int moths = 0;
        public float braintimer = 0;
        public override void AI(NPC npc)
        {
            if (npc.HasBuff(BuffID.Weak))
            {
                npc.damage = (int)(npc.defDamage * 0.85f);
            }
        }
        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (BoilingBlood)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= BoilingBloodDMG * 6;
                if (damage < BoilingBloodDMG)
                {
                    damage = BoilingBloodDMG;
                }
            }
            npc.netUpdate = true;
            if (Decay)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 16;
                if (damage < 2)
                {
                    damage = 2;
                }
                npc.netUpdate = true;
            }
            if (npc.HasBuff(BuffID.CursedInferno))
            {
                npc.lifeRegen -= 48;
                npc.netUpdate = true;
            }
            if (npc.HasBuff(BuffID.ShadowFlame))
            {
                npc.lifeRegen -= 90;
                npc.netUpdate = true;
            }
            if (npc.HasBuff(BuffID.Venom))
            {
                npc.lifeRegen -= 140;
                npc.netUpdate = true;
            }
            if (Toxins)
            {
                npc.lifeRegen -= 80;
                npc.netUpdate = true;
                if (damage < 25)
                {
                    damage = 25;
                }
            }
            if (Heavyburn)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 120;
                if (damage < 10)
                {
                    damage = 10;
                }
                npc.netUpdate = true;
            }
            if (Omegaburn)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 4000;
                if (damage < 1000)
                {
                    damage = 1000;
                }
                npc.netUpdate = true;
            }
        }
        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            if (npc.HasBuff(BuffID.Weak))
            {
                drawColor.R = 118;
                drawColor.G = 57;
                drawColor.B = 49;
            }
            if (npc.HasBuff(BuffID.WitheredWeapon))
            {
                if (Main.rand.Next(4) < 1)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width, npc.height, 179, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 0.8f;
                    Main.dust[dust].velocity.Y -= 0.3f;
                    if (Main.rand.NextBool(4))
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }
            }
            if (npc.HasBuff(BuffID.WitheredArmor))
            {
                if (Main.rand.Next(5) < 1)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width, npc.height, 21, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 2f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 0.8f;
                    Main.dust[dust].velocity.Y -= 0.3f;
                    if (Main.rand.NextBool(4))
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }
            }
            if (Decay)
            {
                drawColor.R = (byte)(drawColor.R * 0.85);
                drawColor.G = (byte)(drawColor.G * 0.99);
                drawColor.B = (byte)(drawColor.G * 0.47);
            }
            if (BoilingBlood)
            {
                if (Main.rand.Next(3) < 1)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width, npc.height, DustID.Smoke, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 2f);
                    Main.dust[dust].velocity *= 0.8f;
                    Main.dust[dust].velocity.Y -= 0.3f;
                }
            }
            if (Corrupted)
            {
                drawColor.R = 172;
                drawColor.G = 145;
                drawColor.B = 153;
                if (Main.rand.Next(4) < 1)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width, npc.height, 184, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 1.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 0.8f;
                    Main.dust[dust].velocity.Y -= 0.3f;
                    if (Main.rand.NextBool(4))
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.3f;
                    }
                }
            }
            if (Toxins)
            {
                drawColor.R = (byte)(drawColor.R * 0.80);
                drawColor.G = (byte)(drawColor.G * 0.90);
                drawColor.B = (byte)(drawColor.G * 0.40);
            }
            if (Heavyburn)
            {
                if (Main.rand.Next(3) < 2)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 127, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 2.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.NextBool(4))
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }
                Lighting.AddLight(npc.position, 0.1f, 0.2f, 0.7f);
            }
            if (BoilingBlood)
            {
                if (Main.rand.Next(3) < 3)
                {
                    Dust dust = Dust.NewDustDirect(npc.position, npc.width, npc.height, 115, 0f, 0f, 0, default, Main.rand.Next(8, 12) * 0.1f);
                    dust.noLight = true;
                    dust.velocity *= 0.5f;
                }
            }
            if (Heavyburn)
            {
                if (Main.rand.Next(3) < 2)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 127, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 2.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.NextBool(4))
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }
                Lighting.AddLight(npc.position, 0.1f, 0.2f, 0.7f);
            }
            if (Omegaburn)
            {
                if (Main.rand.Next(2) < 1)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 127, npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f, 100, default(Color), 3f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 2.4f;
                    Main.dust[dust].velocity.Y -= 0.4f;
                    if (Main.rand.NextBool(4))
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.9f;
                    }
                }
                Lighting.AddLight(npc.position, 0.1f, 0.2f, 0.7f);
            }
        }
        public override bool CheckDead(NPC npc) // makes something happen when NPC dies
        {
            if (Corrupted)
            {
                for (int i = 0; i < 3; ++i)
                {
                    float velX = Main.rand.Next(-35, 36) * 0.2f;
                    float velY = Main.rand.Next(-35, 36) * 0.2f;
                    Projectile.NewProjectile(npc.GetProjectileSpawnSource(), npc.position.X, npc.position.Y, velX, velY, ProjectileID.TinyEater, 52, 0f, Main.myPlayer, 0f, 0f);
                }
            }
            return true;
        }
    }
}
