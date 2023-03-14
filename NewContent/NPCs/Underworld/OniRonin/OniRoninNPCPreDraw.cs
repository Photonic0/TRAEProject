using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using static Terraria.ModLoader.ModContent;

namespace TRAEProject.NewContent.NPCs.Underworld.OniRonin
{
    public partial class OniRoninNPC : ModNPC
    {
        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            teleportEffect.DrawAndUpdateTeleportEffect(NPC);
            float opacityForTpEffect = MathHelper.Clamp(1 - (teleportEffect.TimeLeft + 5) / 10, 0, 1);
            opacityForTpEffect *= opacityForTpEffect;

            Lighting.AddLight(NPC.Center, Color.White.ToVector3() * 0.5f);
            Lighting.AddLight(NPC.Center, Color.OrangeRed.ToVector3() * 1.5f);
            Texture2D texture = Request<Texture2D>("TRAEProject/Assets/SpecialTextures/GlowBallTransparent").Value;
            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, Main.DefaultSamplerState, DepthStencilState.None, Main.Rasterizer, null, Main.Transform);
            Main.EntitySpriteDraw(texture, NPC.Center - Main.screenPosition + new Vector2(0, NPC.gfxOffY), null, Color.Black * 0.8f * opacityForTpEffect, NPC.rotation, texture.Size() / 2, NPC.scale * 0.13f, NPC.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally);
            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, Main.Rasterizer, null, Main.Transform);

            texture = Request<Texture2D>(Texture).Value;
            Main.EntitySpriteDraw(texture, NPC.Center - Main.screenPosition + new Vector2(0, NPC.gfxOffY), NPC.frame, drawColor * opacityForTpEffect, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, NPC.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally);
            texture = Request<Texture2D>("TRAEProject/NewContent/NPCs/Underworld/OniRonin/OniRoninNPCDrawEffect").Value;
            for (float i = 0; i < 1; i += 0.25f)
            {
                Vector2 glowEffectOffset = new Vector2(1f).RotatedBy(MathF.Tau * i + Main.timeForVisualEffects * 0.1f);
                Main.EntitySpriteDraw(texture, NPC.Center - Main.screenPosition + glowEffectOffset + new Vector2(0, NPC.gfxOffY), NPC.frame, new Color(255, 255, 255, 0) * opacityForTpEffect * 0.75f, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, NPC.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally);
                //glowEffectOffset = new Vector2(MathF.Sin((float)(Main.timeForVisualEffects * 0.077f)) +  3).RotatedBy(MathF.Tau * i + MathHelper.PiOver4);
                glowEffectOffset = new Vector2(1.6f).RotatedBy(MathF.Tau * i + Main.timeForVisualEffects * 0.1f + MathHelper.PiOver4);

                Main.EntitySpriteDraw(texture, NPC.Center - Main.screenPosition + glowEffectOffset + new Vector2(0, NPC.gfxOffY), NPC.frame, new Color(255, 255, 255, 0) * opacityForTpEffect * 0.25f, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, NPC.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally);
            }
            return false;
        }    
    }
}
