using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace TRAEProject.Changes.Plantera
{
    class HostileCloud : ModProjectile
    {
        public override void SetStaticDefaults()
        {

            Main.projFrames[Projectile.type] = 5;
        }
        public override void SetDefaults()
        {
			Projectile.tileCollide = false;
			Projectile.width = 60;
			Projectile.height = 60;
			Projectile.aiStyle = 44;
			Projectile.hostile = true;
			Projectile.scale = 1f;
			Projectile.penetrate = -1;
            Projectile.timeLeft = 300;
		}
    }
}
