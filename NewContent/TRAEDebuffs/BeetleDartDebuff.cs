using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using TRAEProject.Common;
using static Terraria.ModLoader.ModContent;
using TRAEProject.NewContent.Items.Weapons.Ammo;
namespace TRAEProject.NewContent.TRAEDebuffs
{
    public class BeetleDartDebuff: TRAEDebuff
    {
        public override void ModifyHitByItem(NPC npc, Player player, Item item, ref int damage, ref float knockback, ref bool crit)
        {
            damage = (int)(damage * 1.25);
        }
        public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            damage = (int)(damage * 1.25);
        }
        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            if (Main.rand.Next(3) < 1)
            {
                int d = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width, npc.height, DustID.PurpleMoss, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default, 1f);
                Main.dust[d].velocity *= 0.8f;
                Main.dust[d].velocity.Y -= 0.3f;
            }
        }

    }
}
