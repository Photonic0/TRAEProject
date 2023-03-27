using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TRAEProject.Common;

namespace TRAEProject.Changes.Weapon.Summon
{
    public class Sentries : GlobalItem
    {
        public override bool InstancePerEntity => true;
        public override void SetDefaults(Item item)
        {
            switch (item.type)
            {
                case ItemID.QueenSpiderStaff:
                    item.damage = 19; // down from 26
                    break;
                case ItemID.DD2LightningAuraT1Popper:
                    item.damage = 7; // up from 4
                    break;
                case ItemID.DD2LightningAuraT2Popper:
                    item.damage = 15; // up from 11
                    break;
                case ItemID.DD2LightningAuraT3Popper:
                    item.damage = 44; // up from 34
                    break;
                case ItemID.DD2FlameburstTowerT1Popper:
                    item.damage = 25; // up from 17
                    break;
                case ItemID.DD2FlameburstTowerT2Popper:
                    item.damage = 58; // up from 42
                    break;
                case ItemID.DD2FlameburstTowerT3Popper:
                    item.damage = 123; // up from 88
                    break;

                case ItemID.RainbowCrystalStaff:
                    item.damage = 30; // down from 150
                    break;
                case ItemID.MoonlordTurretStaff:
                    item.damage = 33; // down from 100

                    item.SetNameOverride("Stardust Portal Staff");
                    break;
                
            }
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            switch (item.type)
            {
                case ItemID.MoonlordTurretStaff:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.Text = "Summons a stardust portal to shoot lasers at your enemies";
                        }
                    }
                    break;
            }
        }
    }
    public class SentryChanges : GlobalProjectile
    {
        public override bool InstancePerEntity => true;
        public override void SetDefaults(Projectile projectile)
        {
            switch(projectile.type)
            {

                case ProjectileID.FrostBlastFriendly:
                    projectile.usesLocalNPCImmunity = true;
                    projectile.localNPCHitCooldown = 30;
                    break;
            }
        }
        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
        {
            switch (projectile.type)
            {
                case ProjectileID.SpiderEgg:
                case ProjectileID.BabySpider:
                {
                    int findbuffIndex = target.FindBuffIndex(BuffID.Venom);
                    if (findbuffIndex != -1)
                    {
                        target.DelBuff(findbuffIndex);
                    };
                    return;
                }
            }
        }
    }
}
