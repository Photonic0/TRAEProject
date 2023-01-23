//using Terraria;
//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;
//using Terraria.ID;
//using Terraria.ModLoader;
//using Terraria.GameContent;
//using System;

//namespace TRAEProject.Changes.Weapon.Summon.StardustPortal
//{
//    public class BezierCurveProjThing : ModProjectile
//    {
//        public override void SetDefaults()
//        {
//            Projectile.Size = new Vector2(10, 10);
//            Projectile.friendly = true;
//            Projectile.hostile = false;
//            Projectile.extraUpdates = 2;//better collision hopefully
//        }
//    }
//    public class StupidStardustPortalThingAAAA : GlobalProjectile
//    {
//        static void DrawPortal(Color[] colors, Vector2 pos, float rotation, float colorMult = 1, SpriteEffects spriteEffects = SpriteEffects.None, bool fullyOpaque = false, float scale = 1, byte opacity = 255)
//        {
//            for (int i = 0; i < colors.Length; i++)//INPUT ARRAY SHOULD BE 6 ELEMENTS LONG
//            {
//                string texturePath = "TRAEProject/Changes/Weapon/Summon/StardustPortal" + (i + 1);
//                if (fullyOpaque)
//                    texturePath += "O";
//                Texture2D texture = ModContent.Request<Texture2D>(texturePath).Value;

//                Color colorToDraw = colors[i] * colorMult;
//                colorToDraw.A = opacity;
//                Main.EntitySpriteDraw(texture, pos, null, colorToDraw, rotation, texture.Size() / 2, scale, spriteEffects, 0);
//            }
//        }
//        public override bool PreDraw(Projectile projectile, ref Color lightColor)
//        {
//            if (projectile.type == ProjectileID.MoonlordTurret)
//            {
//                projectile.scale = projectile.ai[1];
//                float rotationColorOscillation = 0.95f + (projectile.rotation * 0.75f).ToRotationVector2().Y * 0.1f;
//                Vector2 drawPos = projectile.Center - Main.screenPosition;
//                byte extraBrightness = 0;
//                Color[] goldPortalColors = new Color[6] { Color.White, new Color(250, 234, 192), new Color(250, 216, 124), new Color(250, 176, 0), new Color(183, 106, 3), new Color(91, 57, 29) };
//                Color[] bluePortalColors = new Color[6] { Color.White, new Color(115, 223, 255), new Color(35, 200, 255), new Color(104, 214, 255), new Color(0, 174, 238), new Color(0, 106, 185) };
//                //DrawPortal(bluePortalColors, drawPos, projectile.rotation + 0.25f, 0.5f, SpriteEffects.FlipHorizontally,false,projectile.scale * 1.2f);
//                //DrawPortal(bluePortalColors, drawPos, projectile.rotation, 1, SpriteEffects.FlipHorizontally,false,projectile.scale);
//                //DrawPortal(bluePortalColors, drawPos, projectile.rotation * 0.5f, 0.8f, SpriteEffects.None,false,0.9f * projectile.scale);
//                //DrawPortal(goldPortalColors, drawPos, projectile.rotation * 0.7f, 0.9f, SpriteEffects.FlipHorizontally, false, projectile.scale * rotationColorOscillation);
//                //DrawPortal(goldPortalColors, drawPos , -projectile.rotation * 0.7f, 0.9f, SpriteEffects.None, true,projectile.scale * rotationColorOscillation);
//                Color white = Color.White;
//                float projRotation = (float)(projectile.rotation / 1.75f);
//                Color lightTransparentGray = white * 0.8f;
//                lightTransparentGray.A /= 2;
//                float drawScale = projectile.scale * 1.2f * rotationColorOscillation;
//                Main.spriteBatch.End();
//                Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, Main.Rasterizer, null, Main.Transform);

//                DrawPortal(bluePortalColors, drawPos, projRotation + 0.35f, 0.7f, SpriteEffects.FlipHorizontally, true, drawScale);
//                DrawPortal(bluePortalColors, drawPos, projRotation, 1, SpriteEffects.FlipHorizontally, true, projectile.scale);
//                DrawPortal(bluePortalColors, drawPos, -projRotation, 0.8f, SpriteEffects.None, true, 0.9f * projectile.scale);
//                Main.spriteBatch.End();
//                Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, Main.DefaultSamplerState, DepthStencilState.None, Main.Rasterizer, null, Main.Transform);
//                for (int i = 0; i < 5; i++)
//                {
//                    for (int j = 0; j < goldPortalColors.Length; j++)//INPUT ARRAY SHOULD BE 6 ELEMENTS LONG
//                    {
//                        Texture2D portalLayer = ModContent.Request<Texture2D>("TRAEProject/Changes/Weapon/Summon/StardustPortal" + (i + 1)).Value;
//                        Color colorToDraw = goldPortalColors[j] * 0.5f;
//                        colorToDraw.A = 255;
//                        colorToDraw.A = (byte)(255 * (1 - (float)j / (float)5));
//                        colorToDraw.A *= 2;
//                        Main.EntitySpriteDraw(portalLayer, drawPos, null, colorToDraw, projRotation * 0.7f, portalLayer.Size() / 2, projectile.scale, SpriteEffects.FlipHorizontally, 0);
//                        Main.EntitySpriteDraw(portalLayer, drawPos, null, colorToDraw, -projRotation * 0.7f, portalLayer.Size() / 2, projectile.scale, SpriteEffects.None, 0);
//                    }
//                }
//                Main.spriteBatch.End();
//                Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive, Main.DefaultSamplerState, DepthStencilState.None, Main.Rasterizer, null, Main.Transform);
//                DrawPortal(goldPortalColors, drawPos, projRotation * 0.7f, 0.6f, SpriteEffects.FlipHorizontally, true, projectile.scale);
//                DrawPortal(goldPortalColors, drawPos, -projRotation * 0.7f, 0.6f, SpriteEffects.None, false, projectile.scale);
//                Main.spriteBatch.End();
//                Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, Main.DefaultSamplerState, DepthStencilState.None, Main.Rasterizer, null, Main.Transform);
//                Texture2D texture = ModContent.Request<Texture2D>("TRAEProject/Changes/Weapon/Summon/StardustPortal/GoldenShine").Value;
//                Color shineColor = Color.White;
//                float waveAmplitude = 100;
//                float triangleWave = (float)(1 / Math.PI * Math.Asin(Math.Sin(2 * Math.PI / waveAmplitude * Main.timeForVisualEffects)) + 0.5);
//                shineColor.A = (byte)(255 * triangleWave);
//                Color altShineColor = shineColor;
//                altShineColor.A = (byte)(255 - shineColor.A);
//                Main.EntitySpriteDraw(texture, drawPos, null, shineColor, -projRotation, texture.Size() / 2, projectile.scale, SpriteEffects.None, 0);
//                texture = TextureAssets.Extra[57].Value;
//                Main.EntitySpriteDraw(texture, drawPos, null, altShineColor, projRotation, texture.Size() / 2, projectile.scale, SpriteEffects.None, 0);

//                return false;
//            }
//            return true;
//        }
//        public override bool InstancePerEntity => true;
//        public static Vector2 CubicBezier(Vector2 start, Vector2 controlPoint1, Vector2 controlPoint2, Vector2 end, float t)
//        {
//            float tSquared = t * t;
//            float tCubed = t * t * t;
//            return
//                start * (-tCubed + 3 * tSquared - 3 * t - 1) +
//                controlPoint1 * (3 * tCubed - 6 * tSquared + 3 * t) +
//                controlPoint2 * (-3 * tCubed + 3 * tSquared) +
//                end * tCubed;
//        }
//        NPC targetNPC = null;

//        public override bool PreAI(Projectile projectile)
//        {
//            if (projectile.type == ProjectileID.MoonlordTurret)
//            {
//             //   return true;
//                if (projectile.scale > 0.05f)
//                {
//                    if (Main.rand.NextBool())
//                    {
//                        Vector2 randomRotationUnitVec = Vector2.UnitY.RotatedByRandom(MathHelper.TwoPi);
//                        Dust spawnedDust = Main.dust[Dust.NewDust(projectile.Center - randomRotationUnitVec * Main.rand.Next(20, 31) * projectile.scale - new Vector2(4, 4), 0, 0, DustID.YellowTorch)];
//                        spawnedDust.noGravity = true;
//                        spawnedDust.velocity = randomRotationUnitVec * 2f * projectile.scale;
//                        //spawnedDust.velocity = Vector2.Zero;
//                        spawnedDust.scale = 0.5f + Main.rand.NextFloat() * projectile.scale * 0.6f;
//                        spawnedDust.fadeIn = projectile.scale;
//                        spawnedDust.customData = projectile.Center;
//                    }
//                    if (Main.rand.NextBool())
//                    {
//                        Vector2 randomRotationUnitVec = Vector2.UnitY.RotatedByRandom(MathHelper.TwoPi);
//                        Dust spawnedDust = Main.dust[Dust.NewDust(projectile.Center - randomRotationUnitVec * 30f * projectile.scale - new Vector2(4, 4), 0, 0, DustID.BlueCrystalShard)];
//                        spawnedDust.noGravity = true;
//                        spawnedDust.velocity = randomRotationUnitVec.RotatedBy(-MathHelper.PiOver2) * 3f * projectile.scale;
//                        spawnedDust.scale = 0.5f + Main.rand.NextFloat() * projectile.scale * 1.6f;
//                        spawnedDust.fadeIn = 0.5f * projectile.scale;
//                        //spawnedDust.customData = projectile.Center;
//                    }
//                }
//                float distanceSQ = float.MaxValue;
//                for (int i = 0; i < Main.npc.Length; i++)
//                {
//                    if ((targetNPC == null || Main.npc[i].DistanceSQ(projectile.Center) < distanceSQ) && Main.npc[i].active && !Main.npc[i].friendly)
//                        targetNPC = Main.npc[i];
//                }
//                if (targetNPC != null && targetNPC.DistanceSQ(projectile.Center) < 10000000 && targetNPC.active)
//                {
//                    if (projectile.ai[0] % 3 == 0)
//                    {
//                        float color = Main.rand.Next(0,2) * 0.565f + 0.05f + Main.rand.NextFloat()/20;
//                        int dmg = (int)(100 * (Main.player[projectile.owner].GetDamage(DamageClass.Summon).Additive) * (Main.player[projectile.owner].GetDamage(DamageClass.Summon).Multiplicative));
//                        dmg = (int)(dmg * 0.4f);//DAMAGE MULTIPLIER
//                        Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center, Main.rand.NextVector2Circular(7,7) + Main.rand.NextVector2CircularEdge(3,3), ProjectileID.FairyQueenMagicItemShot, dmg, 3, Main.myPlayer, targetNPC.whoAmI, color);
//                    }
//                }
             
//                projectile.ai[0]++;
//                projectile.ai[1] = MathHelper.Lerp(projectile.ai[1], 1, 0.1f);
//                projectile.velocity = Vector2.Zero;
//                projectile.rotation += 0.08f;
//                return false;
//            }
//            return true;
//        }
//    }
//}
