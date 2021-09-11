using TRAEProject.Buffs;
using TRAEProject.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TRAEProject.Items.Summoner.Whip;
using static Terraria.ModLoader.ModContent;

namespace TRAEProject.Changes.Projectiles
{
    public class MinionChanges : GlobalProjectile
    {
        public override bool InstancePerEntity => true;
        public override void SetDefaults(Projectile projectile)
        {
            switch (projectile.type)
            {
                case ProjectileID.MiniSharkron:
                    projectile.extraUpdates = 1;
                    projectile.usesLocalNPCImmunity = true;
                    projectile.localNPCHitCooldown = 10;
                    projectile.penetrate = 4;
                    projectile.GetGlobalProjectile<TRAEGlobalProjectile>().homesIn = true;
                    projectile.GetGlobalProjectile<TRAEGlobalProjectile>().homingRange = 100f;
                    projectile.GetGlobalProjectile<TRAEGlobalProjectile>().dontHitTheSameEnemyMultipleTimes = true;
                    return;
                case ProjectileID.Tempest:
                    projectile.minionSlots = 3;
                    return;
                case ProjectileID.Retanimini:
                case ProjectileID.Spazmamini:
                    projectile.tileCollide = false;
                    projectile.usesIDStaticNPCImmunity = false;
                    projectile.usesLocalNPCImmunity = true; ;
                    return;
                case ProjectileID.MiniRetinaLaser:
                    projectile.GetGlobalProjectile<TRAEGlobalProjectile>().homesIn = true;
                    projectile.GetGlobalProjectile<TRAEGlobalProjectile>().dontHitTheSameEnemyMultipleTimes = true;
                    projectile.usesIDStaticNPCImmunity = false;
                    projectile.usesLocalNPCImmunity = true;
                    projectile.localNPCHitCooldown = 10;
                    return;
                case ProjectileID.CoolWhip:
                    projectile.GetGlobalProjectile<TRAEGlobalProjectile>().AddsBuff = BuffType<CoolWhipTag>();
                    projectile.GetGlobalProjectile<TRAEGlobalProjectile>().AddsBuffDuration = 240;
                    return;
                case ProjectileID.DeadlySphere:
                    projectile.extraUpdates = 5;
                    projectile.usesIDStaticNPCImmunity = false;
                    projectile.usesLocalNPCImmunity = true;
                    projectile.localNPCHitCooldown = 10;
                    return;
                case ProjectileID.DangerousSpider:
                case ProjectileID.VenomSpider:
                case ProjectileID.JumperSpider:
                    projectile.usesIDStaticNPCImmunity = false;
                    projectile.usesLocalNPCImmunity = true;
                    projectile.localNPCHitCooldown = 26;
                    return;
                case ProjectileID.HornetStinger:
                    projectile.extraUpdates = 2;
                    projectile.GetGlobalProjectile<TRAEGlobalProjectile>().homesIn = true;
                    projectile.GetGlobalProjectile<TRAEGlobalProjectile>().homingRange = 150f;
                    return;
                case ProjectileID.Smolstar:
                    projectile.usesLocalNPCImmunity = true;
                    projectile.localNPCHitCooldown = 48; // up from 40
                    return;
                case ProjectileID.ImpFireball:
                    projectile.usesIDStaticNPCImmunity = false;
                    projectile.usesLocalNPCImmunity = true;
                    projectile.localNPCHitCooldown = 10;
                    return;
                case ProjectileID.VampireFrog:
                    projectile.usesIDStaticNPCImmunity = false;
                    projectile.usesLocalNPCImmunity = true;
                    projectile.localNPCHitCooldown = 15; // up from 10, static 
                    return;
                case ProjectileID.PygmySpear: // revisit
                    projectile.penetrate = 2;
                    projectile.usesLocalNPCImmunity = true;
                    projectile.localNPCHitCooldown = 10;
                    return;
            }

        }
        public override void AI(Projectile projectile)
        {
            switch (projectile.type)
            {
                case ProjectileID.BatOfLight:
                    projectile.localNPCHitCooldown = (int)projectile.ai[0];
                    return;
                case ProjectileID.FlyingImp:
                    {
                        if (projectile.ai[1] < 0f)
                        {
                            projectile.ai[1] -= 0.2f; // Needs to reach 90f to shoot
                        }
                    }
                    return;
                case ProjectileID.Smolstar: // could probably move this to AI
                    {
                        if (projectile.ai[0] == -1f)
                        {
                            projectile.ai[1] -= 0.2f; // when it reaches 9f, attack.                 
                        }
                        return;
                    }
                case ProjectileID.DeadlySphere: // could probably move this to AI
                    {
                            projectile.ai[1] += 1f; // when it reaches 9f, attack.                 
                        return;
                    }
                case ProjectileID.Tempest:
                    {
                        projectile.ai[1] += 3; // fires faster
                    }
                    return;
            }    
        }
        public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
        {
            if (projectile.minionSlots > 0 && target.HasBuff(BuffID.RainbowWhipNPCDebuff) && crit == true)
            {
                float VelocityX = Main.rand.Next(-35, 36) * 0.02f;
                float VelocityY = Main.rand.Next(-35, 36) * 0.02f;
                VelocityX *= 10f;
                VelocityY *= 10f;
                Projectile.NewProjectile(projectile.GetProjectileSource_FromThis(), target.Center.X, target.Center.Y, VelocityX, VelocityY, ProjectileType<KaleidoscopeProjectile>(), (int)(projectile.damage * 0.5), 0, projectile.owner, 0, 0f);
            }
            switch (projectile.type)
            {
                case ProjectileID.JumperSpider:
                case ProjectileID.VenomSpider:
                case ProjectileID.DangerousSpider:
                    {
                        projectile.localAI[1] = 26f;
                        return;
                    }
            }
        }
        public override void ModifyHitNPC(Projectile projectile, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (projectile.minion)
            {
                damage += target.GetGlobalNPC<ChangesNPCs>().TagDamage;
                if (Main.rand.Next(100) < target.GetGlobalNPC<ChangesNPCs>().TagCritChance)
                {
                    crit = true;
                }
            }
        }
        public override void ModifyDamageHitbox(Projectile projectile, ref Rectangle hitbox)
        {
            switch (projectile.type)
            {
                case ProjectileID.Tempest:
                    hitbox.Width = 56;
                    hitbox.Height = 80;
                    projectile.scale = 2f;
                    return;
                case ProjectileID.MiniSharkron:
                    hitbox.Width = 14;
                    hitbox.Height = 14;
                    projectile.scale = 1.4f;
                    return;
            }
        }
    }
    public class SummonTags : GlobalBuff
    {
        
        public override void Update(int type, NPC npc, ref int buffIndex)
        {
            switch (type)
            {
                case BuffID.MaceWhipNPCDebuff:
                    npc.GetGlobalNPC<ChangesNPCs>().TagCritChance += 15;
                    return;
                case BuffID.RainbowWhipNPCDebuff:
                    npc.GetGlobalNPC<ChangesNPCs>().TagCritChance += 10;
                    return;
            }
        }
    }
}