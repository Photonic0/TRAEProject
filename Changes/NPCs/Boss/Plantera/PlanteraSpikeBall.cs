using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace TRAEProject.Changes.NPCs.Boss.Plantera
{
    class PlanteraSpikeBall : GlobalProjectile
    {
        public override void SetDefaults(Projectile projectile)
        {
            if(projectile.type == ProjectileID.ThornBall)
            {
                projectile.alpha = 0;
                projectile.scale = 1.5f;
            }
        }
        public override bool PreAI(Projectile projectile)
        {
            if (projectile.type == ProjectileID.ThornBall)
            {
                if (projectile.ai[1] == 0)
                {

                }
                else
                {
                    if (projectile.alpha > 0)
                    {
                        projectile.alpha -= 30;
                        if (projectile.alpha < 0)
                        {
                            projectile.alpha = 0;
                        }
                    }
                    if (Main.expertMode)
                    {
                        float num146 = 18f;
                        int num147 = Player.FindClosest(projectile.Center, 1, 1);
                        Vector2 vector12 = Main.player[num147].Center - projectile.Center;
                        vector12.Normalize();
                        vector12 *= num146;
                        int num148 = 200;
                        projectile.velocity.X = (projectile.velocity.X * (float)(num148 - 1) + vector12.X) / (float)num148;
                        /*
                        if (projectile.velocity.Length() > 16f)
                        {
                            projectile.velocity.Normalize();
                            projectile.velocity *= 16f;
                        }
                        */
                    }

                    projectile.ai[0] += 1f;
                    if (projectile.ai[0] > 15f)
                    {
                        projectile.ai[0] = 15f;
                        if (projectile.velocity.Y == 0f && projectile.velocity.X != 0f)
                        {
                            projectile.velocity.X *= 0.97f;
                            if ((double)projectile.velocity.X > -0.01 && (double)projectile.velocity.X < 0.01)
                            {
                                projectile.Kill();
                            }
                        }
                        projectile.velocity.Y += 0.2f;
                    }
                    projectile.rotation += projectile.velocity.X * 0.05f;
                }
                //Main.NewText(projectile.ai[0] + ", " + projectile.ai[1] + ", " + projectile.localAI[0] + ", " + projectile.localAI[1]);
                return false;
            }
            return true;
        }
        public override bool OnTileCollide(Projectile projectile, Vector2 oldVelocity)
        {
            
            if (projectile.type == ProjectileID.ThornBall)
            {
                if (projectile.velocity.X != oldVelocity.X)
                {
                    projectile.velocity.X = -oldVelocity.X;
                }
                if (projectile.ai[1] == 0)
                {
                    if (projectile.velocity.Y != oldVelocity.Y)
                    {
                        projectile.velocity.Y = -oldVelocity.Y;
                    }
                }
                else
                {
                    if (projectile.velocity.Y != oldVelocity.Y)
                    {
                        
                        Player target = null;
                        float maxDist = 1000;
                        for (int i = 0; i < 255; i++)
                        {
                            if (Main.player[i].active)
                            {
                                if (Math.Abs(Main.player[i].Center.X - projectile.Center.X) < maxDist && Main.player[i].Center.Y < projectile.Center.Y)
                                {
                                    maxDist = Math.Abs(Main.player[i].Center.X - projectile.Center.X);
                                    target = Main.player[i];
                                }
                            }
                        }
                        if(target != null)
                        {
                            projectile.velocity.Y = (projectile.Center.Y - target.Center.Y) * -1 * (1f / 140f) - 0.6f;
                            projectile.ai[0] = -140 + 15;
                            //Main.NewText(projectile.velocity.Y);
                        }
                        else
                        {
                            if (projectile.velocity.Y != oldVelocity.Y)
                            {
                                projectile.velocity.Y = -oldVelocity.Y;
                            }
                        }
                        
                    }
                }
                projectile.localAI[0] = 1;
                return false;
            }
            return true;
        }
        public override bool PreDraw(Projectile projectile, ref Color lightColor)
        {
            if (projectile.type == ProjectileID.ThornBall)
            {
                Texture2D texture = TextureAssets.Projectile[projectile.type].Value;
                Main.EntitySpriteDraw(texture, projectile.Center - Main.screenPosition,
                            null, lightColor, projectile.rotation,
                            new Vector2(texture.Width * 0.5f, texture.Height * 0.5f), projectile.scale, SpriteEffects.None, 0);
                return false;
            }
            return base.PreDraw(projectile, ref lightColor);
        }
    }
}
