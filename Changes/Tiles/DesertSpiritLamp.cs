using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using TRAEProject.NewContent.Items.Misc.PermaBuffs;

namespace TRAEProject.Changes
{
    public class DesertSpiritLamp : GlobalTile
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }
        public override void MouseOver(int i, int j, int type)
        {
            if(type == TileID.DjinnLamp)
            {
                Player player = Main.LocalPlayer;
                player.noThrow = 2;
                player.cursorItemIconEnabled = true;
                player.cursorItemIconID = ItemID.DjinnLamp;
            }
            base.MouseOver(i, j, type);
        }
        public override void RightClick(int i, int j, int type)
        {
            if(type == TileID.DjinnLamp)
            {
                Player player = Main.LocalPlayer;
                player.noThrow = 2;
                //Main.NewText(Main.tile[i, j].TileFrameX);
                Tile tile = Main.tile[i, j];
                Vector2 lampCenter = new Vector2(i * 16 + (tile.TileFrameX == 0 ?  8 : -8), j * 16) + new Vector2(8, 8);
                //Main.NewText(lampCenter + ", " + player.MountedCenter);
                if((lampCenter - player.MountedCenter).Length()  < 32)
                {
                    player.GetModPlayer<LampInteraction>().rubHere = lampCenter;
                }

            }
        }
    }
    public class LampInteraction : ModPlayer
    {
        public Vector2? rubHere = null;
        int rubTime = 0;
        public override void PostUpdate()
        {
            if(rubHere != null)
            {
                Vector2 rubAt = (Vector2)rubHere;
                if((rubAt - Player.MountedCenter).Length()  > 32)
                {
                    rubTime = 0;
                    rubHere = null;
                    return;
                }
                Player.direction = Math.Sign(rubAt.X - Player.MountedCenter.X);
                rubTime++;

				Player.CompositeArmStretchAmount stretch = Player.CompositeArmStretchAmount.Quarter;
				if (rubTime % 30 > 10)
				{
					stretch = Player.CompositeArmStretchAmount.ThreeQuarters;
				}
				if (rubTime % 30 > 20)
				{
					stretch = Player.CompositeArmStretchAmount.Full;
				}
				float rotation = (rubAt - Player.MountedCenter).ToRotation() - (float)Math.PI / 2f;
				Player.SetCompositeArmBack(enabled: true, stretch, rotation);
                if(Player.GetModPlayer<PermaBuffs>().speedWish)
                {
                    return;
                }
                //Dust.NewDustPerfect(rubAt, 6);
                Vector2 nozzle = rubAt + new Vector2(-14, -6);
                Dust d = Dust.NewDustPerfect(nozzle, 6, -1.5f * Vector2.UnitY);
                d.noGravity = true;
                d.color = Color.SkyBlue;
                if(rubTime > 120)
                {
                    for(int i =0; i < 50; i++)
                    {
                        float r = (float)Math.PI / -2f + Main.rand.NextFloat()*(float)Math.PI / 4f * (Main.rand.NextBool() ? -1 : 1);
                        Dust c = Dust.NewDustPerfect(nozzle, 6, TRAEMethods.PolarVector(Main.rand.NextFloat()*8f, r));
                        c.noGravity = true;
                        c.color = Color.SkyBlue;
                    }
                    Player.GetModPlayer<PermaBuffs>().speedWish = true;
                    rubTime = 0;
                    rubHere = null;
                }

            }
            else
            {
                rubTime = 0;
            }
        }
    }
}