using Terraria.ID;
using Terraria.ModLoader;

namespace TRAEProject.NewContent.Projectiles
{
    public class NightsBeam : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("NightsBeam");     //The English name of the Projectile
        }
        public override void SetDefaults()
        {
            Projectile.width = 38;               //The width of Projectile hitbox
            Projectile.height = 42;              //The height of Projectile hitbox
            Projectile.aiStyle = 18;             //The ai style of the Projectile, please reference the source code of Terraria
            Projectile.friendly = true;         //Can the Projectile deal damage to enemies?
            Projectile.hostile = false;         //Can the Projectile deal damage to the player?
            Projectile.DamageType = DamageClass.Melee;           //Is the Projectile shoot by a Melee weapon?
            Projectile.penetrate = 2;           //How many monsters the Projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
            Projectile.timeLeft = 180;          //The live time for the Projectile (60 = 1 second, so 600 is 10 seconds)
            Projectile.light = 0.4f;            //How much light emit around the Projectile
            Projectile.ignoreWater = true;          //Does the Projectile's speed be influenced by water?
            Projectile.tileCollide = true;          //Can the Projectile collide with tiles?
            Projectile.extraUpdates = 0;
            AIType = ProjectileID.DeathSickle;
        }
    }
}

