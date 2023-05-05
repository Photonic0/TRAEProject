using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using TRAEProject.NewContent.NPCs.BomberBones;
using TRAEProject.NewContent.NPCs.GraniteOvergrowth;
using TRAEProject.NewContent.NPCs.Underworld.Boomxie;
using TRAEProject.NewContent.NPCs.Underworld.Froggabomba;
using TRAEProject.NewContent.NPCs.Underworld.Lavamander;
using TRAEProject.NewContent.NPCs.Underworld.ObsidianBasilisk;
using TRAEProject.NewContent.NPCs.Underworld.OniRonin;
using TRAEProject.NewContent.NPCs.Underworld.Phoenix;
using TRAEProject.NewContent.NPCs.Underworld.Salalava;
using static Terraria.ModLoader.ModContent;

namespace TRAEProject.NewContent.NPCs.Banners
{
    public class BomberBonesBannerPlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;  
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
            TileObjectData.newTile.Height = 3;  
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };  
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 111;
            TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
            TileObjectData.addTile(Type);
            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(13, 88, 130), name);
        }


        public override void NearbyEffects(int i, int j, bool closer)
        {
            if (closer)  
            {
                Main.SceneMetrics.NPCBannerBuff[NPCType<BomberBonesNPC>()] = true;
            }
        }
        public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
        {
            if (i % 2 == 1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
        }
    }
    public class BoomxieBannerPlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;  //This defines if the tile is destroyed by lava
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);//
            TileObjectData.newTile.Height = 3;  //this is how many parts the sprite is devided (height)
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };  //this is how many pixels are in each devided part(pink square) (height)   so there are 3 parts with 16 x 16
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 111;
            TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
            TileObjectData.addTile(Type);
            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(13, 88, 130), name);
        }

        public override void NearbyEffects(int i, int j, bool closer)
        {
            if (closer)
            {
                Main.SceneMetrics.NPCBannerBuff[NPCType<Boomxie>()] = true;
            }
        }

        public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
        {
            if (i % 2 == 1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
        }
    }
    public class FroggabombaBannerPlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;  //This defines if the tile is destroyed by lava
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);//
            TileObjectData.newTile.Height = 3;  //this is how many parts the sprite is devided (height)
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };  //this is how many pixels are in each devided part(pink square) (height)   so there are 3 parts with 16 x 16
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 111;
            TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
            TileObjectData.addTile(Type);
            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(13, 88, 130), name);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 48, ItemType<FroggabombaBanner>());//this defines what to drop when this tile is destroyed
        }
        public override void NearbyEffects(int i, int j, bool closer)
        {
            if (closer)
            {
                Main.SceneMetrics.NPCBannerBuff[NPCType<FroggabombaClone>()] = true;

                Main.SceneMetrics.NPCBannerBuff[NPCType<Froggabomba>()] = true;
            }
        }
        public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
        {
            if (i % 2 == 1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
        }
    }
    public class GraniteOvergrowthBannerPlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;  //This defines if the tile is destroyed by lava
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);//
            TileObjectData.newTile.Height = 3;  //this is how many parts the sprite is devided (height)
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };  //this is how many pixels are in each devided part(pink square) (height)   so there are 3 parts with 16 x 16
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 111;
            TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
            TileObjectData.addTile(Type);
            //disableSmartCursor = true;
            LocalizedText name = CreateMapEntryName();
            // name.SetDefault("Granite Overgrowth Banner");
            AddMapEntry(new Color(13, 88, 130), name);
        }

        public override void NearbyEffects(int i, int j, bool closer)
        {
            if (closer)
            {

                Main.SceneMetrics.NPCBannerBuff[NPCType<GraniteOvergrowthNPC>()] = true;
            }
        }
        public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
        {
            if (i % 2 == 1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
        }
    }
    public class LavamanderBannerPlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;  //This defines if the tile is destroyed by lava
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);//
            TileObjectData.newTile.Height = 3;  //this is how many parts the sprite is devided (height)
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };  //this is how many pixels are in each devided part(pink square) (height)   so there are 3 parts with 16 x 16
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 111;
            TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
            TileObjectData.addTile(Type);
            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(13, 88, 130), name);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 48, ItemType<GraniteOvergrowthBanner>());//this defines what to drop when this tile is destroyed
        }

        public override void NearbyEffects(int i, int j, bool closer)
        {
            if (closer)
            {

                Main.SceneMetrics.NPCBannerBuff[NPCType<LavamanderNPC>()] = true;
            }
        }
        public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
        {
            if (i % 2 == 1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
        }
    }
    public class MagmanderBannerPlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;  //This defines if the tile is destroyed by lava
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);//
            TileObjectData.newTile.Height = 3;  //this is how many parts the sprite is devided (height)
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };  //this is how many pixels are in each devided part(pink square) (height)   so there are 3 parts with 16 x 16
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 111;
            TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
            TileObjectData.addTile(Type);
            //disableSmartCursor = true;
            LocalizedText name = CreateMapEntryName();
            // name.SetDefault("Granite Overgrowth Banner");
            AddMapEntry(new Color(13, 88, 130), name);
        }

        public override void NearbyEffects(int i, int j, bool closer)
        {
            if (closer)
            {

                Main.SceneMetrics.NPCBannerBuff[NPCType<Lavalarva>()] = true;
            }
        }
        public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
        {
            if (i % 2 == 1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
        }
    }
    public class SalalavaBannerPlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;  //This defines if the tile is destroyed by lava
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);//
            TileObjectData.newTile.Height = 3;  //this is how many parts the sprite is devided (height)
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };  //this is how many pixels are in each devided part(pink square) (height)   so there are 3 parts with 16 x 16
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 111;
            TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
            TileObjectData.addTile(Type);
            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(13, 88, 130), name);
        }

        public override void NearbyEffects(int i, int j, bool closer)
        {
            if (closer)
            {

                Main.SceneMetrics.NPCBannerBuff[NPCType<SalalavaNPC>()] = true;
            }
        }
        public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
        {
            if (i % 2 == 1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
        }
    }
    public class OniRoninBannerPlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;  //This defines if the tile is destroyed by lava
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);//
            TileObjectData.newTile.Height = 3;  //this is how many parts the sprite is devided (height)
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };  //this is how many pixels are in each devided part(pink square) (height)   so there are 3 parts with 16 x 16
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 111;
            TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
            TileObjectData.addTile(Type);
            //disableSmartCursor = true;
            LocalizedText name = CreateMapEntryName();
            // name.SetDefault("Granite Overgrowth Banner");
            AddMapEntry(new Color(13, 88, 130), name);
        }

        public override void NearbyEffects(int i, int j, bool closer)
        {
            if (closer)
            {

                Main.SceneMetrics.NPCBannerBuff[NPCType<OniRoninNPC>()] = true;
            }
        }
        public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
        {
            if (i % 2 == 1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
        }
    }
    public class PhoenixBannerPlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;  //This defines if the tile is destroyed by lava
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);//
            TileObjectData.newTile.Height = 3;  //this is how many parts the sprite is devided (height)
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };  //this is how many pixels are in each devided part(pink square) (height)   so there are 3 parts with 16 x 16
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 111;
            TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
            TileObjectData.addTile(Type);
            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(13, 88, 130), name);
        }

        public override void NearbyEffects(int i, int j, bool closer)
        {
            if (closer)
            {
                Main.SceneMetrics.NPCBannerBuff[NPCType<PhoenixAsh>()] = true;

                Main.SceneMetrics.NPCBannerBuff[NPCType<PhoenixNPC>()] = true;
            }
        }
        public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
        {
            if (i % 2 == 1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
        }
    }
    public class ObsidianBasiliskBannerPlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;  //This defines if the tile is destroyed by lava
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);//
            TileObjectData.newTile.Height = 3;  //this is how many parts the sprite is devided (height)
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };  //this is how many pixels are in each devided part(pink square) (height)   so there are 3 parts with 16 x 16
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 111;
            TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
            TileObjectData.addTile(Type);
            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(13, 88, 130), name);
        }

        public override void NearbyEffects(int i, int j, bool closer)
        {
            if (closer)
            {

                Main.SceneMetrics.NPCBannerBuff[NPCType<ObsidianBasiliskHead>()] = true;
                Main.SceneMetrics.NPCBannerBuff[NPCType<ObsidianBasiliskBody>()] = true;
                Main.SceneMetrics.NPCBannerBuff[NPCType<ObsidianBasiliskTail>()] = true;

            }
        }
        public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
        {
            if (i % 2 == 1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
        }
    }
}