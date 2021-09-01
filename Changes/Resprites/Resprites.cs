using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace TRAEProject.Changes.Resprites
{
    public class Resprites : ModSystem
    {
        string path = "TRAEProject/Changes/Resprites/";
        public override void PostSetupContent()
        {
            TextureAssets.Item[ItemID.StardustDragonStaff] = Request<Texture2D>(path + "LunarDragonStaff");
            TextureAssets.Projectile[ProjectileID.StardustDragon1] = Request<Texture2D>(path + "LunarDragonHead");
            TextureAssets.Projectile[ProjectileID.StardustDragon2] = Request<Texture2D>(path + "LunarDragonSpike");
            TextureAssets.Projectile[ProjectileID.StardustDragon3] = Request<Texture2D>(path + "LunarDragonBody");
            TextureAssets.Projectile[ProjectileID.StardustDragon4] = Request<Texture2D>(path + "LunarDragonTail");
            TextureAssets.Buff[BuffID.StardustDragonMinion] = Request<Texture2D>(path + "LunarDragonBuff");

            TextureAssets.Item[ItemID.MoonlordTurretStaff] = Request<Texture2D>(path + "StardustPortalStaff");
            TextureAssets.Projectile[ProjectileID.MoonlordTurret] = Request<Texture2D>(path + "StardustPortal");
            TextureAssets.Projectile[ProjectileID.MoonlordTurretLaser] = Request<Texture2D>(path + "StardustPortalBeam");

            TextureAssets.Item[ItemID.DarkLance] = Request<Texture2D>(path + "DarkLance");
        }
    }
}
