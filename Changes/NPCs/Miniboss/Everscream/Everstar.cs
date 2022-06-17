using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TRAEProject.Changes.NPCs.Miniboss.Everscream
{
    public class Everstar : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.OrnamentStar);
            AIType = ProjectileID.OrnamentStar;
            Projectile.hostile = true;
            Projectile.friendly = false;
        }
        public override void AI()
        {
            if(Projectile.ai[0] < 0)
            {
                Projectile.velocity = Projectile.velocity.SafeNormalize(-Vector2.UnitY) * 6;
            }
            if (Projectile.ai[0] < 50 && Projectile.ai[0] % 10f == 0f)
            {
                float num248 = (float)Math.PI / 2f * (float)((Projectile.ai[0] % 20f != 0f) ? 1 : (-1));
                num248 *= (float)((Projectile.whoAmI % 2 != 0) ? 1 : (-1));
                num248 += (float)Main.rand.Next(-5, 5) * MathHelper.Lerp(0.2f, 0.03f, Projectile.ai[0] / 50f);
                Vector2 v = Projectile.velocity.RotatedBy(num248);
                v = v.SafeNormalize(Vector2.Zero);
                v *= Math.Max(2.5f, (50f - Projectile.ai[0]) / 50f * (7f + (-2f + (float)Main.rand.Next(2) * 2f)));
                int num249 = Projectile.NewProjectile(Projectile.GetSource_FromAI(), Projectile.Center, v, ModContent.ProjectileType<Ornament>(), Projectile.damage, Projectile.knockBack * 0.25f, Projectile.owner, 0f, Main.rand.Next(4));
            }

        }
    }
    public class Ornament : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 4;
        }
        public override void SetDefaults()
        {
                Projectile.CloneDefaults(ProjectileID.OrnamentFriendly);
                AIType = ProjectileID.OrnamentFriendly;
                Projectile.hostile = true;
                Projectile.friendly = false;
        }
    }
}
