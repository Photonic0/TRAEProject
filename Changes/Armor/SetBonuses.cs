using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using TRAEProject.NewContent.Buffs;
using static Terraria.ModLoader.ModContent;

namespace TRAEProject.Changes.Armor
{
    public class SetBonuses : ModPlayer
    {
        public int shadowArmorDodgeChance = 0;
        public bool PirateSet = false;
        public override void ResetEffects()
        {
            PirateSet = false;
            shadowArmorDodgeChance = 0;
        }
        public override void UpdateDead()
        {
            PirateSet = false;
            shadowArmorDodgeChance = 0;
        }

        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {

            if (Main.rand.Next(shadowArmorDodgeChance) == 1)//if set to 0, it will give 100% dodge chance without the set bonus
            {
                DarkDodge();
                return false;
            }
            return true;
        }
        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if (PirateSet && (ProjectileID.Sets.IsAWhip[proj.type]))
            {
                target.AddBuff(BuffType<PirateTag>(), 240);
            }
        }
        void DarkDodge()
        {
            Player.immune = true;
            Player.immuneTime = 80;
            if (Player.longInvince)
                Player.immuneTime = Player.immuneTime + 40;
            for (int index = 0; index < Player.hurtCooldowns.Length; ++index)
                Player.hurtCooldowns[index] = Player.immuneTime;
            for (int i = 0; i < 80; i++)
            {
                int num = Dust.NewDust(new Vector2(Player.position.X, Player.position.Y), Player.width, Player.height, Main.rand.Next(new int[] { 65, 173 }), 0f, 0f, 100, default, 2f);
                Main.dust[num].position.X += Main.rand.Next(-20, 21);
                Main.dust[num].position.Y += Main.rand.Next(-20, 21);
                Main.dust[num].velocity *= 0.4f;
                Main.dust[num].scale *= 1f + Main.rand.Next(40) * 0.01f;
                Main.dust[num].shader = GameShaders.Armor.GetSecondaryShader(Player.cWaist, Player);
                Main.dust[num].noGravity = true;
                Main.dust[num].noLight = true;
                if (Main.rand.Next(2) == 0)
                {
                    Main.dust[num].scale *= 1f + Main.rand.Next(40) * 0.01f;
                    Main.dust[num].velocity *= 1.4f;
                }
            }
            if (Player.whoAmI == Main.myPlayer)
            {
                NetMessage.SendData(62, -1, -1, null, Player.whoAmI, 1f);
            }
        }
    }
}
