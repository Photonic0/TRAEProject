using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TRAEProject.Common;
using Terraria.Audio;
using static Terraria.ModLoader.ModContent;

namespace TRAEProject.NewContent.Items.Weapons.BAM
{
    class BAM : ModItem
    {
        public override void SetStaticDefaults()
        {
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

            DisplayName.SetDefault("B.A.M.");
            Tooltip.SetDefault("'Bombardment Alien Multitool'\nShoots rockets, gel and darts");
        }
        public override void SetDefaults()
        {
            Item.width = 68;
            Item.height = 22;
            Item.damage = 40;
            Item.useAnimation = 40;
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.rare = ItemRarityID.Red;
            Item.value = Item.sellPrice(gold: 5);
            Item.DamageType = DamageClass.Ranged;
            Item.knockBack = 2f;
            Item.shootSpeed = 8f;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Gel;
            Item.shoot = ProjectileType<BAMP>();
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item5;
            Item.noUseGraphic = true;
            Item.channel = true;
        }
    }
    public class ShootSpecialGel : GlobalItem
    {
        public override bool InstancePerEntity => true;

        public override GlobalItem Clone(Item item, Item itemClone)
        {
            return base.Clone(item, itemClone);
        }
        public override void PickAmmo(Item weapon, Item ammo, Player player, ref int type, ref float speed, ref int damage, ref float knockback)
        {
            if (weapon.type == ItemType<BAM>())
            {
                switch (ammo.type)
                {
                    case ItemID.Gel:
                        type = ProjectileType<BAMGel>();
                        break;
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

            if (Main.rand.Next(2) == 0)
            {
                for (int i = 0; i < 2; ++i)
                {
                    Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.UltraBrightTorch, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100);

                    // Some dust will be large, the others small and with gravity, to give visual variety.
                    if (Main.rand.NextBool(4))
                    {
                        dust.noGravity = true;
                        dust.scale *= 3f;
                        dust.velocity.X *= 2f;
                        dust.velocity.Y *= 2f;
                    }

                    dust.scale *= 1.5f;
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

    public class BAMP : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("BAM");     //The English name of the Projectile

        }
        public override void SetDefaults()
        {
            Projectile.width = 22;
            Projectile.height = 22;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.hide = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.ignoreWater = true;
        }
        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            float num = (float)Math.PI / 2f;
            Vector2 vector = player.RotatedRelativePoint(player.MountedCenter);
            int num2 = 2;
            float num3 = 0f;
            num = 0f;
            if (Projectile.spriteDirection == -1)
            {
                num = (float)Math.PI;
            }
            Projectile.ai[0] += 1f;

            int UseTime = 40;
            Projectile.ai[1] -= 1f;
            bool flag13 = false;
            if (Projectile.ai[1] <= 0f)
            {
                Projectile.ai[1] = UseTime;
                flag13 = true;
                _ = (int)Projectile.ai[0] / (UseTime);
            }
            bool canShoot3 = player.channel && player.HasAmmo(player.inventory[player.selectedItem], canUse: true) && !player.noItems && !player.CCed;
            if (Projectile.localAI[0] > 0f)
            {
                Projectile.localAI[0] -= 1f;
            }
            if (Projectile.soundDelay <= 0 && canShoot3)
            {
                Projectile.soundDelay = UseTime;
                if (Projectile.ai[0] != 1f)
                {
                    SoundEngine.PlaySound(SoundID.Item5, Projectile.position);
                }
                Projectile.localAI[0] = 12f;
            }
            player.phantasmTime = 2;
            if (flag13 && Main.myPlayer == Projectile.owner)
            {
                int projToShoot3 = 14;
                float speed3 = 14f;
                int Damage3 = player.GetWeaponDamage(player.inventory[player.selectedItem]);
                float KnockBack3 = player.inventory[player.selectedItem].knockBack;
                if (canShoot3)
                {
                    player.PickAmmo(player.inventory[player.selectedItem], ref projToShoot3, ref speed3, ref canShoot3, ref Damage3, ref KnockBack3, out var usedAmmoItemId3);
                    IEntitySource projectileSource_Item_WithPotentialAmmo3 = player.GetSource_ItemUse_WithPotentialAmmo(player.HeldItem, usedAmmoItemId3);
                    KnockBack3 = player.GetWeaponKnockback(player.inventory[player.selectedItem], KnockBack3);
                    float num70 = player.inventory[player.selectedItem].shootSpeed * Projectile.scale;
                    Vector2 vector30 = vector;
                    Vector2 value11 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY) - vector30;
                    if (player.gravDir == -1f)
                    {
                        value11.Y = (float)(Main.screenHeight - Main.mouseY) + Main.screenPosition.Y - vector30.Y;
                    }
                    Vector2 vector31 = Vector2.Normalize(value11);
                    if (float.IsNaN(vector31.X) || float.IsNaN(vector31.Y))
                    {
                        vector31 = -Vector2.UnitY;
                    }
                    vector31 *= num70;
                    if (vector31.X != Projectile.velocity.X || vector31.Y != Projectile.velocity.Y)
                    {
                        Projectile.netUpdate = true;
                    }
                    Projectile.velocity = vector31 * 0.55f;
                    for (int num71 = 0; num71 < 4; num71++)
                    {
                        Vector2 vector32 = Vector2.Normalize(Projectile.velocity) * speed3 * (0.6f + Main.rand.NextFloat() * 0.8f);
                        if (float.IsNaN(vector32.X) || float.IsNaN(vector32.Y))
                        {
                            vector32 = -Vector2.UnitY;
                        }
                        Vector2 vector33 = vector30 + Utils.RandomVector2(Main.rand, -15f, 15f);
                        int num72 = Projectile.NewProjectile(projectileSource_Item_WithPotentialAmmo3, vector33.X, vector33.Y, vector32.X, vector32.Y, projToShoot3, Damage3, KnockBack3, Projectile.owner);
                        Main.projectile[num72].noDropItem = true;
                    }
                }
                else
                {
                    Projectile.Kill();
                }
            }
            Projectile.position = player.RotatedRelativePoint(player.MountedCenter, reverseRotation: false, addGfxOffY: false) - Projectile.Size / 2f;
            Projectile.rotation = Projectile.velocity.ToRotation() + num;
            Projectile.spriteDirection = Projectile.direction;
            Projectile.timeLeft = 2;
            player.ChangeDir(Projectile.direction);
            player.heldProj = Projectile.whoAmI;
            player.SetDummyItemTime(num2);
            player.itemRotation = MathHelper.WrapAngle((float)Math.Atan2(Projectile.velocity.Y * (float)Projectile.direction, Projectile.velocity.X * (float)Projectile.direction) + num3);
        }
    }
}