using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TRAEProject.Common;
using TRAEProject.NewContent.Projectiles;
using TRAEProject.NewContent.TRAEDebuffs;
using static Terraria.ModLoader.ModContent;

namespace TRAEProject.Changes.Weapon.Melee
{
    public class PreHardmodeSwords : GlobalItem
    {
        public override bool InstancePerEntity => true;
        public override GlobalItem Clone(Item item, Item itemClone)
        {
            return base.Clone(item, itemClone);
        }
        public override void SetDefaults(Item item)
        {
            switch (item.type)
            {
                // WOODEN 
                case ItemID.WoodenSword:
                    item.damage = 9; // up from 7
                    item.scale = 1.15f; // up from 1
                    item.useTime = 22; // down from 25
                    item.useAnimation = 22;
                    break;
                case ItemID.BorealWoodSword:
                case ItemID.PalmWoodSword:
                    item.damage = 10; // up from 8
                    item.scale = 1.15f; // up from 1
                    item.useTime = 22; // down from 23
                    item.useAnimation = 22;
                    break;
                case ItemID.RichMahoganySword:
                case ItemID.EbonwoodSword:
                case ItemID.ShadewoodSword:
                    item.damage = 12; // up from 10
                    item.scale = 1.15f; // up from 1
                    break;
                case ItemID.PearlwoodSword:
                    item.scale = 1.15f; // up from 1
                    break;
                case ItemID.CactusSword:
                    item.damage = 9; // up from 8
                    item.useTime = 25; // down from 32
                    item.useAnimation = 25;
                    break;
                // ORES
                case ItemID.CopperBroadsword:
                    item.damage = 13;
                    item.scale = 1.25f;
                    item.useTime = 20;
                    item.useAnimation = 20;
                    break;
                case ItemID.TinBroadsword:
                    item.damage = 14;
                    item.scale = 1.25f;
                    item.useTime = 20;
                    item.useAnimation = 20;
                    break;
                case ItemID.IronBroadsword:
                    item.damage = 15;
                    item.scale = 1.25f;
                    item.useTime = 20;
                    item.useAnimation = 20;
                    break;
                case ItemID.LeadBroadsword:
                    item.damage = 16;
                    item.scale = 1.25f;
                    item.useAnimation = 20;
                    item.useTime = 20;
                    break;
                case ItemID.SilverBroadsword:
                    item.damage = 17;
                    item.scale = 1.25f;
                    item.useTime = 20;
                    item.useAnimation = 20;
                    break;
                case ItemID.TungstenBroadsword:
                    item.damage = 18;
                    item.scale = 1.25f;
                    item.useTime = 20;
                    item.useAnimation = 20;
                    break;
                case ItemID.GoldBroadsword:
                    item.damage = 19;
                    item.scale = 1.25f;
                    item.useTime = 18;
                    item.useAnimation = 18;
                    break;
                case ItemID.PlatinumBroadsword:
                    item.damage = 20;
                    item.scale = 1.25f;
                    item.useTime = 18;
                    item.useAnimation = 18;
                    break;
                
                    
                    // SHORTSWORDS
                
                
                case ItemID.CopperShortsword:
                case ItemID.TinShortsword:
                case ItemID.IronShortsword:
                case ItemID.LeadShortsword:
                case ItemID.SilverShortsword:
                case ItemID.TungstenShortsword:
                case ItemID.GoldShortsword:
                case ItemID.PlatinumShortsword:
                    item.autoReuse = true;
                    break;
                case ItemID.Gladius:
                    item.autoReuse = true;
                    item.knockBack = 5f; // up from 0.5
                    break;
                
                    
                    // OTHER
               
                
                
                case ItemID.AntlionClaw:
                    item.useTime = 11;
                    item.useAnimation = 11;
                    break;
                case ItemID.ZombieArm:
                    item.damage = 15; // up from 12
                    item.useTime = 20;
                    item.useAnimation = 20;
                    item.knockBack = 8.25f;
                    item.autoReuse = true;
                    break;
                case ItemID.BoneSword:
                    item.damage = 24;
                    item.scale = 1.33f;
                    item.value = Item.buyPrice(gold: 5);
                    break;
                //phaseblades
                case ItemID.PurplePhaseblade:
                    item.damage = 29;
                    item.crit = 8;
                    item.knockBack = 0.1f;
                    item.useTime = 25;
                    item.useAnimation = 25;
                    item.shoot = ProjectileType<Blank>();
                    item.autoReuse = true;
                    item.useTurn = false;
                    break;
                case ItemID.YellowPhaseblade:
                    item.damage = 29;
                    item.crit = 10;
                    item.knockBack = 0.1f;
                    item.useTime = 25;
                    item.useAnimation = 25;
                    item.shoot = ProjectileType<Blank>();
                    item.autoReuse = true;
                    item.useTurn = false;
                    break;
                case ItemID.BluePhaseblade:
                    item.damage = 29;
                    item.crit = 12;
                    item.knockBack = 0.1f;
                    item.useTime = 25;
                    item.useAnimation = 25;
                    item.shoot = ProjectileType<Blank>();
                    item.autoReuse = true;
                    item.useTurn = false;
                    break;
                case ItemID.GreenPhaseblade:
                    item.damage = 29;
                    item.crit = 14;
                    item.knockBack = 0.1f;
                    item.useTime = 25;
                    item.useAnimation = 25;
                    item.autoReuse = true;
                    item.useTurn = false;
                    break;
                case ItemID.RedPhaseblade:
                    item.damage = 29;
                    item.crit = 16;
                    item.knockBack = 0.1f;
                    item.useTime = 25;
                    item.useAnimation = 25;
                    item.autoReuse = true;
                    item.useTurn = false;
                    break;
                case ItemID.OrangePhaseblade:
                    item.damage = 29;
                    item.crit = 17;
                    item.knockBack = 0.1f;
                    item.useTime = 25;
                    item.useAnimation = 25;
                    item.autoReuse = true;
                    item.useTurn = false;
                    break;
                case ItemID.WhitePhaseblade:
                    item.damage = 29;
                    item.crit = 18;
                    item.knockBack = 0.1f;
                    item.useTime = 25;
                    item.useAnimation = 25;
                    item.autoReuse = true;
                    item.useTurn = false;
                    break;


                // NIGHT'S EDGE & COMPONENTS
                
                
                case ItemID.LightsBane:
                    item.damage = 21;
                    item.useTime = 17;
                    item.useAnimation = 17;
                    item.autoReuse = true;
                    item.shoot = ProjectileType<Blank>();
                    break;
                case ItemID.BloodButcherer:
                    item.damage = 24;
                    item.useTime = 25;
                    item.useAnimation = 25;
                    item.shoot = ProjectileType<Blank>();
                    break;
                case ItemID.Katana:
                case ItemID.Muramasa:
                    item.crit = 20;
                    item.useTime = 16;
                        item.useAnimation = 16;
                    item.shoot = ProjectileType<Blank>();
                    item.useTurn = false;
                    break;
                case ItemID.BladeofGrass:
                    item.damage = 36; // up from 28
                    item.useTime = 30;
                    item.useAnimation = 30;
                    item.shoot = ProjectileType<Blank>();
                    break;
                case ItemID.FieryGreatsword:
                    item.useTime = 42;
                    item.useAnimation = 42;
                    item.autoReuse = true;
                    break;
                case ItemID.NightsEdge:
                    item.shoot = ProjectileType<NightsBeam>();
                    item.damage = 38;
                    item.useTime = 60;
                    item.useAnimation = 30;
                    item.autoReuse = true;
                    item.shootSpeed = 7f;
                    break;
                case ItemID.PurpleClubberfish:
                    item.scale = 1.4f;
                    item.damage = 34;
                    item.autoReuse = true;
                    break;
                case ItemID.LucyTheAxe:
                    item.damage = 42; // up from 26
                    item.useTime = 24; // up from 17, slows down axe speed tho
                    item.useAnimation = 24;
                    item.shoot = 0;
                    item.useTurn = false;
 item.shootSpeed = 11f;
                    break;
                   

            }
        }
        
        public override void OnHitNPC(Item item, Player player, NPC target, int damage, float knockBack, bool crit)
        {          
            if (item.type == ItemID.BloodButcherer)
            {
                if (Main.rand.Next(2) == 0) // 50% chance
                {
                    player.HealEffect(1, true);
                    player.statLife += 1;
                }
            }
         
            if (item.type == ItemID.FieryGreatsword)
            {
                TRAEDebuff.Apply<HeavyBurn>(target, 120, 1);
            }
        }
        /// SHOOT STUFF
        public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 mousePosition = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
            switch (item.type)
            {
                case ItemID.NightsEdge:
                        Terraria.Audio.SoundEngine.PlaySound(SoundID.Item8);
                        return true;
  
            }
            return true;       
        }
        public override void HoldItem(Item item, Player player)
        {
            if (item.type == ItemID.NightsEdge)
            {
                if (player.itemTime == 1 && player.whoAmI == Main.myPlayer)
                {
                    Terraria.Audio.SoundEngine.PlaySound(SoundID.MaxMana);
                    for (int i = 0; i < 5; i++)
                    {
                        Dust dust = Dust.NewDustDirect(player.position, player.width, player.height, 173, 0f, 0f, 255, default, Main.rand.Next(20, 26) * 0.1f);
                        dust.noLight = true;
                        dust.noGravity = true;
                        dust.velocity *= 0.5f;
                    }
                    return;
                }
            }
            return;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            switch (item.type)
            {
                case ItemID.BloodButcherer:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Material")
                        {
                            line.Text += "\nChance to heal the user on contact";
                        }
                    }
                    break;
                case ItemID.LucyTheAxe:
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.Mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.Text += "\nRight click to throw her as a boomerang";
                        }
                    }
                    break;
            }
        }
        public override bool AltFunctionUse(Item item, Player player)
        {
            if (item.type == ItemID.LucyTheAxe)
            {
                return true;
            }
            return base.AltFunctionUse(item, player);
        }
        bool swung = false;
        public override void UseAnimation(Item item, Player player)
        {
            if (item.type == ItemID.LucyTheAxe && swung == false && player.altFunctionUse != 2)
            {
                swung = true;
            }
        }
        public override bool CanUseItem(Item item, Player player)
        {
            if (item.type == ItemID.LucyTheAxe)
            {
                if (player.ownedProjectileCounts[ProjectileType<ThrownLucy>()] > 0)
                {
                    return false;
                }
                if (player.altFunctionUse == 2)
                {
                    item.shoot = ProjectileType<ThrownLucy>();
                    item.noMelee = true;
                    item.DamageType = DamageClass.MeleeNoSpeed;
                    item.noUseGraphic = true;
                    swung = false;
                }
                if (player.altFunctionUse != 2)
                {
                    item.shoot = ProjectileType<Blank>(); 
                    item.DamageType = DamageClass.Melee;
                    item.noMelee = false;
                    item.noUseGraphic = false; 
                    if (swung)
                    {
                        item.shoot = ProjectileID.None;
                    }
                }

            }
            return base.CanUseItem(item, player);
        }
      
    }
    
}
