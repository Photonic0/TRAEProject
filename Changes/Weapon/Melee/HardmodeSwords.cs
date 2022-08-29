using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TRAEProject.Changes.Items;
using Terraria;
using static Terraria.ModLoader.ModContent;
using TRAEProject.NewContent.Projectiles;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace TRAEProject.Changes.Weapon.Melee
{
    class HardmodeSwords : GlobalItem
    {
        public override bool InstancePerEntity => true;
        public bool FetidHeal = false;
        public override GlobalItem Clone(Item item, Item itemClone)
        {
            return base.Clone(item, itemClone);
        }
        public override void SetDefaults(Item item)
        {
            switch (item.type)
            {
                case ItemID.CobaltSword:
                    item.damage = 47; // up from 39
                    item.useTime = 16; // down from 22
                    item.useAnimation = 16;  // down from 22
                    item.scale = 1.59f;
                    item.useTurn = false;
                    item.crit = 24;
                    item.SetNameOverride("Cobalt Katana");
                    break;
                case ItemID.PalladiumSword:
                    item.damage = 61; // up from 45
                    item.useTime = 20;
                    item.useAnimation = 20;
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
                    item.damage = 50;
                    item.useTime = 25;
                    item.useAnimation = 25;
                    item.scale = 1.66f;
                    item.SetNameOverride("Orichalcum Flamberge");
                    break;
                case ItemID.AdamantiteSword:
                    item.damage = 60;
                    item.useTime = 17;
                    item.useAnimation = 17;
                    item.scale = 1.75f;
                    item.SetNameOverride("Adamantite Broadsword");
                    break;
                case ItemID.Frostbrand:
                    item.useTime = 40;
                    item.scale = 1.5f; // up from 1.15
                    return;
                case ItemID.TitaniumSword:
                    item.scale = 1.75f;
                    item.SetNameOverride("Titanium Falchion");
                    break;
                case ItemID.Excalibur:
                case ItemID.TrueExcalibur:
                    item.damage = 70;
                    item.useTime = 32;
                    item.useAnimation = 16;
                    item.scale = 1.8f;
                    break;
                case ItemID.ChlorophyteSaber:
                    item.damage = 50;
                    item.scale = 1.75f;
                    item.useTime = 16;
                    item.useAnimation = 16;
                    item.useTurn = false;
                    item.shoot = ProjectileID.None;
                    break;
                case ItemID.ChlorophyteClaymore:
                    item.damage = 120;
                    item.useTime = 50;
                    item.useAnimation = 40;
                    item.scale = 2.4f;
                    item.autoReuse = true;
                    item.useTurn = false;
                    break;
                case ItemID.BeamSword: // REVISIT
                    item.useTime = 45;
                    item.useAnimation = 15;
                    item.autoReuse = true;
                    item.useTurn = false;
                    return;
                case ItemID.TrueNightsEdge: // REVISIT
                    item.autoReuse = true;
                    item.damage = 100;
                    item.useTime = 30;
                    item.useAnimation = 30;
                    item.scale = 1.75f;
                    return;
                //phasesabars
                case ItemID.PurplePhasesaber:
                case ItemID.YellowPhasesaber:
                case ItemID.BluePhasesaber:
                case ItemID.GreenPhasesaber:
                case ItemID.RedPhasesaber:
                case ItemID.OrangePhasesaber:
                case ItemID.WhitePhasesaber:
                    item.damage = 60;
                    item.crit = 24;
                    item.knockBack = 1f;
                    item.useTime = 17;
                    item.useAnimation = 17;
                    item.autoReuse = true;
                    item.useTurn = false;
                    break;
                case ItemID.BreakerBlade:
                    item.scale = 1.5f; // up from 1.05f
                    item.damage = 80;
                    item.useTime = 60;
                    item.useAnimation = 60;
                    item.height = 90;
                    item.width = 80;
                    break;
                case ItemID.Cutlass:
                    //item.damage = 60;
                    //item.knockBack = 1f;
                    //item.useTime = 13;
                    //item.useAnimation = 13;
                    //item.autoReuse = true;
                    //item.useTurn = false;
                    break;
                case ItemID.Seedler:
                    item.useTime = 27;
                    item.useAnimation = 27;
                    break;
                case ItemID.Keybrand:
                    item.scale = 1.7f;
                    item.damage = 100;
                    break;
                case ItemID.TerraBlade: // REVISIT
                    item.damage = 100;
                    item.scale = 1.6f;
                    item.useTime = 16;
                    item.useAnimation = 16;
                    item.shootSpeed = 6f; //down from 12 (beam now has an extra update)
                    break;
                case ItemID.TheHorsemansBlade:
                    item.damage = 150;
                    item.scale = 1.75f;
                    break;
                case ItemID.DD2SquireDemonSword:
                    item.useTurn = false;
                    item.scale = 1.7f;
                    item.shoot = ProjectileType<Blank>();
                    break;
                case ItemID.FetidBaghnakhs:
                    FetidHeal = true;
                    item.useTurn = false;
                    item.shoot = ProjectileType<Blank>();
                    item.damage = 45;
                    item.useTime = 8;
                    item.useAnimation = 8;
                    break;
                case ItemID.PsychoKnife:
                    FetidHeal = true;
                    item.damage = 80; // down from 85
                    item.shoot = ProjectileType<Blank>();
                    item.useTime = 8;
                    item.useAnimation = 8;
                    break;
                case ItemID.ChristmasTreeSword: 
                    item.useTime = 29;
                    item.useAnimation = 29;
                    item.damage = 70;
                    item.shootSpeed = 9f; 
                    item.knockBack = 4f;
                    item.autoReuse = true;
                    break;
                case ItemID.DD2SquireBetsySword:
                    item.scale = 1.7f;
                    break;
                case 3063: // meowmere
                    item.scale = 1.95f; // up from 1.05
                    return;
                case 3065: // star wrath
                    item.damage = 110; // down from 110
                    item.scale = 1.7f; // up from 1.05
                    return;

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
        public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 mousePosition = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
            switch (item.type)
            {
                case ItemID.ChristmasTreeSword:
                    {
                        int number = 1 + Main.rand.Next(1, 2); // 1 to 3 shots
                        for (int i = 0; i < number; i++)
                        {
                            Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(24));
                            Projectile.NewProjectile(player.GetSource_ItemUse(item), position, perturbedSpeed * 0.95f, ProjectileType<LightsLong>(), damage, knockback, player.whoAmI);
                        }                        
						number = 2 + Main.rand.Next(1, 3); // 3 or 5 shots
                        for (int i = 0; i < number; i++)
                        {
                            Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(30));
                            perturbedSpeed.X *= Main.rand.NextFloat(0.5f, 1.5f);
                            Projectile.NewProjectile(player.GetSource_ItemUse(item), position, perturbedSpeed * 1.2f, ProjectileID.OrnamentFriendly, damage, knockback, player.whoAmI);
                        }
                        for (int i = 0; i < 10; i++)
                        {
                            Dust dust = Dust.NewDustDirect(player.position, player.width, player.height, 57, 0f, 0f, 255, default, Main.rand.Next(20, 26) * 0.1f);
                            dust.noLight = true;
                            dust.noGravity = true;
                            dust.velocity *= 0.5f;
                        }
                        Projectile.NewProjectile(player.GetSource_ItemUse(item), position, velocity * 1.8f, ProjectileType<Star1>(), damage, knockback, player.whoAmI);
                        Terraria.Audio.SoundEngine.PlaySound(SoundID.Item25);
                        return false;
                    }
            }
            return true;
        }
        public override void OnHitNPC(Item item, Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if (FetidHeal && player.GetModPlayer<OnHitItems>().BaghnakhHeal <= (int)(player.GetModPlayer<OnHitItems>().LastHitDamage * 0.5))
            {
                float healAmount = (float)(damage * 0.05f);
                player.GetModPlayer<OnHitItems>().BaghnakhHeal += (int)healAmount;
                player.HealEffect((int)healAmount, true);
                player.statLife += (int)healAmount;
            }
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
                    Projectile.NewProjectile(player.GetSource_FromThis(), k, y2, num2, num3, 221, 36, 0f, player.whoAmI);
                    return;
                case ItemID.ChlorophyteSaber:
                    Projectile.NewProjectile(player.GetSource_ItemUse(item), target.Center, TRAEMethods.PolarVector(Main.rand.NextFloat() * 2f, Main.rand.NextFloat(-(float)Math.PI, (float)Math.PI)), ProjectileID.SporeCloud, (int)(.8f * damage), 0, player.whoAmI);
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
