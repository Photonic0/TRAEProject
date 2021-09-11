using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace TRAEProject.Items.DreadItems.Brimstone
{
    class Brimstone : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Brimstone");
            Tooltip.SetDefault("Fires a blood beam");
        }
        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 30;
            Item.useStyle = 5;
            Item.damage = 90;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 150;
            Item.useTime = Item.useAnimation = 60;
            Item.reuseDelay = 30;
            Item.autoReuse = true;
            Item.shootSpeed = 4;
            Item.shoot = ProjectileType<BrimstoneBeam>();

            Item.UseSound = SoundID.NPCDeath13;
        }
    }
    class BrimstoneBeam : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = Projectile.height = 26;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.timeLeft = 2;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
            Projectile.penetrate = -1;
        }
        int beamLength = 2200;
        public const int chargeTime = 30;
        int timer = 0;
        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            if(player.itemTime > 1)
            {
                Projectile.timeLeft = 2;
                timer++;
                Projectile.velocity = Vector2.Zero;
                Projectile.Center = player.Center;
                if(Main.myPlayer == Projectile.owner)
                {
                    Projectile.rotation = (Main.MouseWorld - player.Center).ToRotation();
                }
                beamLength = 2200;
                for (int i =0; i < beamLength; i++)
                {
                    if(!Collision.CanHit(Projectile.Center, 1, 1, Projectile.Center + TRAEMethods.PolarVector(i, Projectile.rotation), 1, 1))
                    {
                        beamLength = i;
                        break;
                    }
                }
            }
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Draw(Projectile, beamLength, timer);
            return false;
        }
        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            float point = 0;
            if (timer > chargeTime)
            {
                return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), Projectile.Center, Projectile.Center + TRAEMethods.PolarVector(beamLength, Projectile.rotation), 26, ref point);
            }
            return false;
        }
        public static void Draw(Projectile Projectile, int beamLength, int timer)
        {
            if (Projectile.timeLeft < chargeTime)
            {
                Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
                int frame = (timer / 6) % 4;
                float scaleY = timer;
                if(timer > 30)
                {
                    scaleY = 30;
                }
                scaleY /= 30f;
                for (float k = beamLength; k > 0; k -= texture.Width)
                {
                    Main.EntitySpriteDraw(texture, Projectile.Center + TRAEMethods.PolarVector(k, Projectile.rotation) - Main.screenPosition, new Rectangle(0, frame * 26, 32, 26), Color.White, Projectile.rotation + (float)Math.PI, Vector2.UnitY * 13, new Vector2(1f, scaleY), SpriteEffects.None, 0);
                }
            }
        }
    }
}
