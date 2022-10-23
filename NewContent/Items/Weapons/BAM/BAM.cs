
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TRAEProject.Common;
using Terraria.Audio;
using TRAEProject.Changes.Weapon.Ranged.Rockets;
using static Terraria.ModLoader.ModContent;
using TRAEProject.NewContent.Items.Weapons.Ammo;

namespace TRAEProject.NewContent.Items.Weapons.BAM
{
    public class BAM : ModItem
    {
        public override void SetStaticDefaults()
        {
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

            DisplayName.SetDefault("B.A.M.");
            Tooltip.SetDefault("'Bombardment Assault Multitool'\nShoots gel, rockets and darts");
        }
        public override void SetDefaults()
        {
            Item.width = 68;
            Item.height = 22;
            Item.damage = 40;
            Item.useAnimation = 72;
            Item.useTime = 9;
            Item.autoReuse = true;
            Item.rare = ItemRarityID.Red;
            Item.value = Item.sellPrice(gold: 5);
            Item.DamageType = DamageClass.Ranged;
            Item.knockBack = 2f;
            Item.shootSpeed = 6f;
            Item.scale = 1.15f;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Gel;
            Item.shoot = ProjectileType<BAMGel>();
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item34;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ItemID.FragmentVortex, 18)
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-5f, 0f);
        }
        int shotCount = 0;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            shotCount++;
            if (shotCount == 4)
            {
                player.GetModPlayer<BAMAttacks>().ammoToUse = 2;
                SoundEngine.PlaySound(SoundID.Item61, player.Center);
            }
            else if (shotCount == 7)
            {
                player.GetModPlayer<BAMAttacks>().ammoToUse = 3;
                SoundEngine.PlaySound(SoundID.Item11, player.Center);
            }
            else
            {
                player.GetModPlayer<BAMAttacks>().ammoToUse = 1;
            }
            if (Item.useAmmo == AmmoID.Rocket)
            {
                Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, type, (int)(damage * 2f), knockback, player.whoAmI);
                return false;

            }
            if (Item.useAmmo == AmmoID.Dart)
            {
                float numberProjectiles = 3;
                float rotation = MathHelper.ToRadians(10);
                position += Vector2.Normalize(new Vector2(velocity.X, velocity.Y)) * 10f;
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 2f; // Watch out for dividing by 0 if there is only 1 projectile.
                    Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI);
                }
                return false;
            }
            return true;
        }
        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            if (shotCount != 1 && shotCount != 4 && shotCount != 7)
                return false;
            if (shotCount == 7)
            {
                shotCount = 0; 
            }
            return true;
        }
    }
    public class ShootSpecialGel : GlobalItem
    {
        public override bool InstancePerEntity => true;

        public override GlobalItem Clone(Item item, Item itemClone)
        {
            return base.Clone(item, itemClone);
        }
        public override void PickAmmo(Item weapon, Item ammo, Player player, ref int type, ref float speed, ref StatModifier damage, ref float knockback)
        {
            if (weapon.type == ItemType<BAM>())
            {
                switch (ammo.type)
                {
                    case ItemID.Gel:
                        type = ProjectileType<BAMGel>();
                        break;
                    case ItemID.RocketI:
                        type = ProjectileType<BAMRocket>();
                        break;
                    case ItemID.RocketII:
                        type = ProjectileType<BAMRocketDestructive>();
                        break;
                    case ItemID.RocketIII:
                        type = ProjectileType<BAMRocketSuper>();
                        break;
                    case ItemID.RocketIV:
                        type = ProjectileType<BAMRocketDirect>();
                        break;
                    case ItemID.MiniNukeI:
                        type = ProjectileType<BAMRocketMiniNuke>();
                        break;
                    case ItemID.MiniNukeII:
                        type = ProjectileType<BAMRocketDMiniNuke>();
                        break;
                    case ItemID.ClusterRocketI:
                        type = ProjectileType<BAMRocketCluster>();
                        break;
                    case ItemID.ClusterRocketII:
                        type = ProjectileType<BAMRocketHeavy>();
                        break;
                    case ItemID.DryRocket:
                        type = ProjectileType<BAMRocketDry>();
                        break;
                    case ItemID.WetRocket:
                        type = ProjectileType<BAMRocketWet>();
                        break;
                    case ItemID.LavaRocket:
                        type = ProjectileType<BAMRocketLava>();
                        break;
                    case ItemID.HoneyRocket:
                        type = ProjectileType<BAMRocketHoney>();
                        break;

                }
                if (ammo.type == ItemType<LuminiteRocket>())
                {
                    type = ProjectileType<BAMRocketLuminite>();
                }
            }
        }
    }
    public class BAMGel : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("BAMGel");     //The English name of the Projectile

        }
        public override string Texture => "Terraria/Images/Item_0";
        public override void SetDefaults()
        {

            Projectile.width = 6;
            Projectile.height = 6;
            Projectile.alpha = 255;
            Projectile.penetrate = 3;
            Projectile.extraUpdates = 2;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.hostile = false;
            Projectile.friendly = true;
            Projectile.timeLeft = 60;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.GetGlobalProjectile<ProjectileStats>().dontHitTheSameEnemyMultipleTimes = true;
            Projectile.GetGlobalProjectile<ProjectileStats>().AddsBuffDuration = 240;
            Projectile.GetGlobalProjectile<ProjectileStats>().DamageFalloff = 0.1f;
        }
        public override void AI()
        {
            float dustScale = 1f;
            if (Projectile.ai[0] == 0f)
                dustScale = 0.25f;
            else if (Projectile.ai[0] == 1f)
                dustScale = 0.5f;
            else if (Projectile.ai[0] == 2f)
                dustScale = 0.75f;

            if (Main.rand.NextBool(3))
            {
                for (int i = 0; i < 2; ++i)
                {
                    Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, 229, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100, Scale: 0.8f);
                    dust.noGravity = true;
                    if (Main.rand.NextBool(4))
                    {
                        dust.scale *= 2f;
                        dust.velocity.X *= 2f;
                        dust.velocity.Y *= 2f;
                    }

                    dust.scale *= 1.25f;
                    dust.velocity *= 1.2f;
                    dust.scale *= dustScale;
                }
            }
            Projectile.ai[0] += 1f;
        }
        public override void ModifyDamageHitbox(ref Rectangle hitbox)
        {
            int size = 30;
            hitbox.X -= size;
            hitbox.Y -= size;
            hitbox.Width += size * 2;
            hitbox.Height += size * 2;
        }
    }
    public class BAMAttacks : ModPlayer
    {
        public int ammoToUse = 1;
        public override void PostItemCheck()
        {
            if (Player.HeldItem.type == ItemType<BAM>())
            {
                if (ammoToUse == 1)
                {
                    Player.HeldItem.useAmmo = AmmoID.Gel;
                    Player.HeldItem.shoot = ProjectileType<BAMGel>();
                }
                if (ammoToUse == 2)
                {
                    Player.HeldItem.useAmmo = AmmoID.Rocket;
                    Player.HeldItem.shoot = ProjectileID.RocketI;
               
                }
                if (ammoToUse == 3)
                {
                    Player.HeldItem.useAmmo = AmmoID.Dart;
                    Player.HeldItem.shoot = ProjectileID.PoisonDart;
                 

                }

                return;
            }
        }
    }
}