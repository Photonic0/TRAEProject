using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TRAEProject.Changes.Accesory
{

    public class ObsidianSkullEffect : ModPlayer
    {
        bool skull = false;
        float range = 300f;
        public override void ResetEffects()
        {
            skull = false;
        }
        public override void PostUpdateEquips()
        {
            if (Player.fireWalk)
            {
                Player.fireWalk = false;
                skull = true;
  
			}
        }
        public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
        {
            if (skull && (target.Center - Player.Center).Length() < range)
            {
                damage = (int)(damage * 1.1f);              
				for (int i = 0; i < 4; i++) 
				{
Vector2 speed = Main.rand.NextVector2CircularEdge(1f, 1f);
	Dust d = Dust.NewDustPerfect(target.Center, DustID.Shadowflame, speed * 5, Scale: 2.5f);
	d.noGravity = true;
				}
            }
        }
        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (skull && (target.Center - Player.Center).Length() < range)
            {
                damage = (int)(damage * 1.1f);			
				for (int i = 0; i < 4; i++) 
				{
Vector2 speed = Main.rand.NextVector2CircularEdge(1f, 1f);
	Dust d = Dust.NewDustPerfect(target.Center, DustID.Shadowflame, speed * 5, Scale: 2.5f);
	d.noGravity = true;
				}
            }
        }
    }
}
