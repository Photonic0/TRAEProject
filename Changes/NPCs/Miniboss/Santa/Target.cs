using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace TRAEProject.Changes.NPCs.Miniboss.Santa
{
    public class Target :ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = Projectile.height = 42;
            Projectile.tileCollide = false;
            Projectile.extraUpdates = 0;
            Projectile.penetrate = -1;
            Projectile.friendly = false;
            Projectile.hostile = false;
            Projectile.timeLeft = 120;
            
        }
        public override bool ShouldUpdatePosition()
        {
            return false;
        }
        public override void AI()
        {
            Projectile.frameCounter++;
            if(Projectile.frameCounter >= 30)
            {
                Projectile.frameCounter = 0;
                Projectile.frame++;
                if(Projectile.frame > 1)
                {
                    Projectile.frame = 0;
                }
            }
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
            Main.EntitySpriteDraw(texture, Projectile.position - Main.screenPosition, new Rectangle(0, 42 * Projectile.frame, 42, 42), Color.White, 0, Vector2.Zero, Vector2.One, SpriteEffects.None, 0);

            Texture2D arrow = ModContent.Request<Texture2D>("TRAEProject/Changes/NPCs/Miniboss/Santa/Target_Arrow").Value;
            Main.EntitySpriteDraw(arrow, Projectile.Center + Projectile.velocity * (30 + 2 * Projectile.frame) - Main.screenPosition, null, Color.White, Projectile.velocity.ToRotation(), Vector2.UnitY * 7, 1f, SpriteEffects.None, 0);
            return false;
        }
    }
}
