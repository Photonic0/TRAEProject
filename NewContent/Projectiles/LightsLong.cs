using Terraria;

using Terraria.ModLoader;
namespace TRAEProject.NewContent.Projectiles
{
    public class LightsLong: ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 4;
            DisplayName.SetDefault("LightsLong");     //The English name of the Projectile
        }
        public override void SetDefaults()
        {
            Projectile.width = 94;               //The width of Projectile hitbox
            Projectile.height = 12;              //The height of Projectile hitbox
            Projectile.scale = 1f;
            Projectile.friendly = true;         //Can the Projectile deal damage to enemies?
            Projectile.DamageType = DamageClass.Melee;           //Is the Projectile shoot by a Melee weapon?
            Projectile.penetrate = 1;           //How many monsters the Projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
            Projectile.timeLeft = 1200;          //The live time for the Projectile (60 = 1 second, so 600 is 10 seconds)
            Projectile.light = 1f;            //How much light emit around the Projectile
            Projectile.tileCollide = true;          //Can the Projectile collide with tiles?
            Projectile.extraUpdates = 0;            //Set to above 0 if you want the Projectile to update multiple time in a frame
        }
       public int TargetWhoAmI
        {
            get => (int)Projectile.ai[1];
            set => Projectile.ai[1] = value;
        }
        private const int MAX_TICKS = 25;
        public override void AI()
        {
            TargetWhoAmI++;
            // For a little while, the javelin will travel with the same speed, but after this, the javelin drops velocity very quickly.
            TargetWhoAmI++;
            // For a little while, the javelin will travel with the same speed, but after this, the javelin drops velocity very quickly.
            if (TargetWhoAmI >= MAX_TICKS)
            {
                // Change these multiplication factors to alter the javelin's movement change after reaching maxTicks
                const float velXmult = 0.999f; // x velocity factor, every AI update the x velocity will be 98% of the original speed
                const float velYmult = 0.27f; // y velocity factor, every AI update the y velocity will be be 0.35f bigger of the original speed, causing the javelin to drop to the ground
                TargetWhoAmI = MAX_TICKS; // set ai1 to maxTicks continuously
                Projectile.velocity.X *= velXmult;
                Projectile.velocity.Y += velYmult;
            }

            // Make sure to set the rotation accordingly to the velocity, and add some to work around the sprite's rotation
            // Please notice the MathHelper usage, offset the rotation by 90 degrees (to radians because rotation uses radians) because the sprite's rotation is not aligned!
            Projectile.rotation = Projectile.velocity.ToRotation();
            // Make sure to set the rotation accordingly to the velocity, and add some to work around the sprite's rotation
            // Please notice the MathHelper usage, offset the rotation by 90 degrees (to radians because rotation uses radians) because the sprite's rotation is not aligne
            Projectile.frameCounter++;
            if (Projectile.frameCounter >= 8)
            {
                Projectile.frameCounter = 0;
                Projectile.frame = (Projectile.frame + 1) % 4;
            }
        }
    }
}

