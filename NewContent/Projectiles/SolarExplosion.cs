using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
namespace TRAEProject.NewContent.Projectiles
{
    public class SolarExplosion: ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 5;
            //DisplayName.SetDefault("Solar Explosion");     //The English name of the Projectile
        }
        public override void SetDefaults()
        {
            Projectile.width = 50;               //The width of Projectile hitbox
            Projectile.height = 50;              //The height of Projectile hitbox
            Projectile.scale = 1f;
            Projectile.friendly = true;         //Can the Projectile deal damage to enemies?
            Projectile.DamageType = DamageClass.Melee;           //Is the Projectile shoot by a Melee weapon?
            Projectile.penetrate = 3;           //How many monsters the Projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
            Projectile.timeLeft = 1200;          //The live time for the Projectile (60 = 1 second, so 600 is 10 seconds)
            Projectile.light = 1f;            //How much light emit around the Projectile
            Projectile.tileCollide = false;          //Can the Projectile collide with tiles?
            Projectile.extraUpdates = 0;            //Set to above 0 if you want the Projectile to update multiple time in a frame
        }

		public override void AI()
		{
			Projectile.ai[1] += 0.01f;
			Projectile.scale = Projectile.ai[1];
			Projectile.ai[0]++;
			if (Projectile.ai[0] >= (float)(3 * Main.projFrames[Projectile.type]))
			{
				Projectile.Kill();
				return;
			}
			if (++Projectile.frameCounter >= 3)
			{
				Projectile.frameCounter = 0;
				if (++Projectile.frame >= Main.projFrames[Projectile.type])
				{
					Projectile.hide = true;
				}
			}
			Projectile.alpha -= 63;
			if (Projectile.alpha < 0)
			{
				Projectile.alpha = 0;
			}

			Lighting.AddLight(Projectile.Center, 0.9f, 0.8f, 0.6f);

			if (Projectile.ai[0] != 1f)
			{
				return;
			}
			Projectile.position.X += Projectile.width / 2;
			Projectile.position.Y += Projectile.height / 2;
			Projectile.width = Projectile.height = (int)(50 * Projectile.scale);
			Projectile.position.X -= Projectile.width / 2;
			Projectile.position.Y -= Projectile.height / 2;
			Projectile.position.X += Projectile.width / 2;
			Projectile.position.Y += Projectile.height / 2;
			Projectile.width = Projectile.height = (int)(50 * Projectile.scale);
			Projectile.position.X -= (Projectile.width / 2);
			Projectile.position.Y -= (Projectile.height / 2);
			Projectile.Damage();

			for (int num899 = 0; num899 < 4; num899++)
			{
				int num900 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 31, 0f, 0f, 100, default, 1.5f);
				Main.dust[num900].position = Projectile.Center + Vector2.UnitY.RotatedByRandom(3.1415927410125732) * (float)Main.rand.NextDouble() * Projectile.width / 2f;
			}
			for (int num901 = 0; num901 < 10; num901++)
			{
				int num902 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 6, 0f, 0f, 200, default, 2.7f);
				Main.dust[num902].position = Projectile.Center + Vector2.UnitY.RotatedByRandom(3.1415927410125732) * (float)Main.rand.NextDouble() * Projectile.width / 2f;
				Main.dust[num902].noGravity = true;
				Dust dust2 = Main.dust[num902];
				dust2.velocity *= 3f;
				num902 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 6, 0f, 0f, 100, default, 1.5f);
				Main.dust[num902].position = Projectile.Center + Vector2.UnitY.RotatedByRandom(3.1415927410125732) * (float)Main.rand.NextDouble() * Projectile.width / 2f;
				dust2 = Main.dust[num902];
				dust2.velocity *= 2f;
				Main.dust[num902].noGravity = true;
				Main.dust[num902].fadeIn = 2.5f;
			}
			for (int num903 = 0; num903 < 5; num903++)
			{
				int num904 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 6, 0f, 0f, 0, default, 2.7f);
				Main.dust[num904].position = Projectile.Center + Vector2.UnitX.RotatedByRandom(3.1415927410125732).RotatedBy(Projectile.velocity.ToRotation()) * Projectile.width / 2f;
				Main.dust[num904].noGravity = true;
				Dust dust2 = Main.dust[num904];
				dust2.velocity *= 3f;
			}
			for (int num905 = 0; num905 < 10; num905++)
			{
				int num906 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 31, 0f, 0f, 0, default, 1.5f);
				Main.dust[num906].position = Projectile.Center + Vector2.UnitX.RotatedByRandom(3.1415927410125732).RotatedBy(Projectile.velocity.ToRotation()) * Projectile.width / 2f;
				Main.dust[num906].noGravity = true;
				Dust dust2 = Main.dust[num906];
				dust2.velocity *= 3f;
			}

		}
    }
}

