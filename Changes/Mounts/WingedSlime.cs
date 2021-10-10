using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TRAEProject.Changes.Mounts
{
    class WingedSlime : ModPlayer
    {
        public override void PostUpdate()
        {
            if (Player.mount.Type == MountID.QueenSlime)
            {
                Vector2 instaVel = Vector2.UnitX * Player.velocity.X * -0.5f;
                instaVel = Collision.TileCollision(Player.position, instaVel, Player.width, Player.height);
                Player.position += instaVel;
            }
        }
    }
}
