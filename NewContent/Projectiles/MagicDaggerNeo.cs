using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TRAEProject.NewContent.Projectiles
{
    public class MagicDaggerNeo: ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("MagicDaggerNeo");     //The English name of the Projectile
        }

        public override void SetDefaults()
        {
            Projectile.width = 10;
            Projectile.height = 24;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.scale = 0.8f;
            Projectile.timeLeft = 720;
            Projectile.light = 0.2f;
            Projectile.tileCollide = false;
            Projectile.extraUpdates = 2;
        }
        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            Player player = Main.player[Projectile.owner];
            int finalDefense = target.defense - player.armorPenetration;
            target.ichor = false;
            target.betsysCurse = false;
            if (finalDefense < 0)
            {
                finalDefense = 0;
            }
            damage += finalDefense / 2;
            return;
        }
        float radius = Main.rand.Next(100, 125);
        float spinSpeed = Main.rand.NextFloat(0.02f, 0.03f);
        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            if (Projectile.scale > 2f)
                Projectile.scale = 2f;
            bool flag4 = false;
            Projectile.ai[1] = 1;
            if (Projectile.ai[1] == 1)
            {
                Vector2 origin = player.Center;
                //Get 30 locations in a circle around 'origin'
                int numLocations = 360; // 360 degree angle, a circle. See CH
                Projectile.localAI[1] += Projectile.direction;
                Projectile.rotation += Projectile.direction * spinSpeed;
                Vector2 position = origin + Vector2.UnitX.RotatedBy(MathHelper.ToRadians(360f / numLocations * Projectile.localAI[1])) * radius;
                Projectile.position = position;
            }
            if (Projectile.timeLeft == 1)
            {
                flag4 = true;
            }
            if (flag4)
            {
                Projectile.ai[1] = 0;
                float speed = 20f;
                Vector2 direction = (Main.MouseWorld - Projectile.Center).SafeNormalize(-Vector2.UnitY);
                int dagger = Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(),Projectile.Center, direction * speed, ProjectileID.MagicDagger, Projectile.damage, Projectile.knockBack, Projectile.owner);
                float size = 0.75f + 2 * Projectile.damage * 0.002f;
                if (size > 2f)
                    size = 2f;
                Main.projectile[dagger].scale = size;
                Projectile.Kill();
            }
        }
        public override void Kill(int timeLeft)
        {
            --Main.player[Projectile.owner].GetModPlayer<TRAEPlayer>().magicdaggercount;
        }   
    }    
}

