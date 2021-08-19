using System;
using TRAEProject.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ChangesProjectiles
{
    public class ChangesTiles : GlobalTile
    {
        public override void FloorVisuals(int type, Player player)
        {
            //if (type == Tile.Liquid_Water)
            //    player.AddBuff(BuffID.Swiftness, 600);
            //return;
        }
    }
}