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
    public class Scanline : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = Projectile.height = 4;
            Projectile.tileCollide = false;
            Projectile.extraUpdates = 20;
            Projectile.penetrate = -1;
            Projectile.friendly = false;
            Projectile.hostile = false;
            Projectile.timeLeft = 180;
        }
        Vector2 start = Vector2.Zero;
        public override void AI()
        {
            if(start == Vector2.Zero)
            {
                start = Projectile.Center;
            }
        }
        public override bool PreDraw(ref Color lightColor)
        {
            if(start != Vector2.Zero)
            {
                float distance = 10000;
                Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
                Main.EntitySpriteDraw(texture, start - Main.screenPosition, null, Color.White, (Projectile.Center - start).ToRotation(), new Vector2(0, 2), new Vector2(distance / 4f, 0.5f), SpriteEffects.None, 0);
            }
            return false;
        }
    }
}
