using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TRAEProject.Changes.Weapon
{
    class HardmodeSwords : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            switch(item.type)
            {
                case ItemID.CobaltSword:
                    item.damage = 50; // up from 39
                    item.useTime = 16; // down from 22
                    item.useAnimation = 16;  // down from 22
                    item.scale = 1.59f;
                    item.useTurn = false;
                    item.crit = 40;
                    item.SetNameOverride("Cobalt Katana");
                    break;
                case ItemID.PalladiumSword:
                    item.damage = 61; // up from 45
                    item.useTime = 17;
                    item.useAnimation = 17;
                    item.scale = 1.67f;
                    item.useTurn = false;
                    item.SetNameOverride("Palladium Falcata");
                    break;
                case ItemID.MythrilSword:
                    item.damage = 140;
                    item.useTime = 40;
                    item.useAnimation = 40;
                    item.scale = 2.4f;
                    item.SetNameOverride("Mythril Zweihänder");
                    break;
                case ItemID.OrichalcumSword:
                    item.damage = 65;
                    item.useTime = 20;
                    item.useAnimation = 20;
                    item.scale = 1.66f;
                    item.SetNameOverride("Orichalcum Flamberge");
                    break;
                case ItemID.AdamantiteSword:
                    item.damage = 76;
                    item.useTime = 16;
                    item.useAnimation = 16;
                    item.scale = 1.75f;
                    item.SetNameOverride("Adamantite Broadsword");
                    break;
                case ItemID.TitaniumSword:
                    item.damage = 70;
                    item.useTime = 16;
                    item.useAnimation = 16;
                    item.scale = 1.75f;
                    item.SetNameOverride("Titanium Falchion");
                    break;
                case ItemID.Excalibur:
                case ItemID.TrueExcalibur:
                    item.damage = 90;
                    item.scale = 1.75f;
                    item.useTime = 16;
                    item.useAnimation = 16;
                    item.scale = 1.75f;
                    break;
                case ItemID.ChlorophyteSaber:
                    item.damage = 60;
                    item.scale = 1.75f;
                    item.useTime = 12;
                    item.useAnimation = 12;
                    item.useTurn = false;
                    item.shoot = ProjectileID.None;
                    break;
                case ItemID.ChlorophyteClaymore:
                    item.damage = 180;
                    item.useTime = 40;
                    item.useAnimation = 40;
                    item.scale = 2.4f;
                    item.useTime = 50;
                    item.autoReuse = true;
                    item.useTurn = false;
                    break;

                //phasesabars
                case ItemID.PurplePhasesaber:
                case ItemID.YellowPhasesaber:
                case ItemID.BluePhasesaber:
                case ItemID.GreenPhasesaber:
                case ItemID.RedPhasesaber:
                case ItemID.WhitePhasesaber:
                    item.damage = 60;
                    item.crit = 20;
                    item.knockBack = 1f;
                    item.useTime = 13;
                    item.useAnimation = 13;
                    item.autoReuse = true;
                    item.useTurn = false;
                    break;


                case ItemID.BreakerBlade:
                    item.scale = 1.5f; // up from 1.05f
                    item.damage = 160;
                    item.useTime = 60;
                    item.useAnimation = 60;
                    item.height = 90;
                    item.width = 80;
                    break;
                case ItemID.Cutlass:
                    item.damage = 60;
                    item.knockBack = 1f;
                    item.useTime = 13;
                    item.useAnimation = 13;
                    item.autoReuse = true;
                    item.useTurn = false;
                    break;
                case ItemID.Keybrand:
                    item.scale = 1.7f;
                    item.damage = 125;
                    break;
                case ItemID.TerraBlade: // REVISIT
                    item.damage = 100;
                    item.scale = 1.6f;
                    item.useTime = 16;
                    item.useAnimation = 16;
                    break;
                case ItemID.TheHorsemansBlade:
                    item.useTime = 16;
                    item.useAnimation = 16;
                    item.damage = 142;
                    item.scale = 1.25f;
                    break;
            }
        }
        public override bool? CanHitNPC(Item item, Player player, NPC target)
        {
            if(item.type == ItemID.TheHorsemansBlade)
            {
                if(target.SpawnedFromStatue)
                {
                    return false;
                }
            }
            return base.CanHitNPC(item, player, target);
        }

        public override void OnHitNPC(Item item, Player player, NPC target, int damage, float knockBack, bool crit)
        {
            switch (item.type)
            {
                case ItemID.PalladiumSword:
                    player.AddBuff(BuffID.RapidHealing, 300);
                    return;
                case ItemID.OrichalcumSword:
                    int direction = player.direction;
                    float k = Main.screenPosition.X;
                    if (direction < 0)
                    {
                        k += (float)Main.screenWidth;
                    }
                    float y2 = Main.screenPosition.Y;
                    y2 += (float)Main.rand.Next(Main.screenHeight);
                    Vector2 vector = new Vector2(k, y2);
                    float num2 = target.Center.X - vector.X;
                    float num3 = target.Center.Y - vector.Y;
                    num2 += (float)Main.rand.Next(-50, 51) * 0.1f;
                    num3 += (float)Main.rand.Next(-50, 51) * 0.1f;
                    float num4 = (float)Math.Sqrt(num2 * num2 + num3 * num3);
                    num4 = 24f / num4;
                    num2 *= num4;
                    num3 *= num4;
                    Projectile.NewProjectile(player.GetProjectileSource_SetBonus(5), k, y2, num2, num3, 221, 36, 0f, player.whoAmI);
                    return;
                case ItemID.ChlorophyteSaber:
                    Projectile.NewProjectile(player.GetProjectileSource_Item(item), target.Center, TRAEMethods.PolarVector(Main.rand.NextFloat() * 2f, Main.rand.NextFloat(-(float)Math.PI, (float)Math.PI)), ProjectileID.SporeCloud, (int)(.8f * damage), 0, player.whoAmI);
                    break;
            }
        }
        public override void HoldItem(Item item, Player player)
        {
            switch (item.type)
            {
                case ItemID.TitaniumSword:
                    player.onHitTitaniumStorm = true;
                    return;
            }
        }
    }
}
