using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
public class ChangesWorld : ModSystem
{
    private readonly int[] PyramidItems = new int[] { ItemID.SandstorminaBottle, ItemID.FlyingCarpet, ItemID.AnkhCharm, ItemID.AncientChisel, ItemID.SandBoots, ItemID.ThunderSpear, ItemID.ThunderStaff, ItemID.CatBast, ItemID.MagicConch};

    public override void PostWorldGen()
    {
        for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
        {
            Chest chest = Main.chest[chestIndex];
            if (WorldGen.genRand.NextBool(2) && chest != null && Main.tile[chest.x, chest.y].type == TileID.Containers && Main.tile[chest.x, chest.y].frameX == 0 * 36)
            {
                for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                {
                    if (chest.item[inventoryIndex].type == ItemID.None)
                    {
                        chest.item[inventoryIndex].SetDefaults(ItemID.FlaskofPoison);
                        break;
                    }
                }
            }
            if (WorldGen.genRand.NextBool(2) && chest != null && Main.tile[chest.x, chest.y].type == TileID.Containers && Main.tile[chest.x, chest.y].frameX == 1 * 36)
            {
                for (int i = 0; i < 40; i++)
                {
                    if (chest.item[i].type == ItemID.None)
                    {
                        {
                            chest.item[i].SetDefaults(ItemID.FlaskofFire, false);
                        }
                        break;
                    }
                    if (chest.item[i].type == ItemID.SandstorminaBottle|| chest.item[i].type == ItemID.FlyingCarpet)
                    {
                        chest.item[i].SetDefaults(ItemID.PharaohsMask, false);
                        ++i;
                        chest.item[i].SetDefaults(ItemID.PharaohsRobe, false);
                        break;
                    }
                }
            }
            if (WorldGen.genRand.NextBool(2) && chest != null && Main.tile[chest.x, chest.y].type == TileID.Containers && Main.tile[chest.x, chest.y].frameX == 1 * 36)
            {
                for (int i = 0; i < 40; i++)
                {
                    if (chest.item[i].type == ItemID.None)
                    {
                        {
                            chest.item[i].SetDefaults(ItemID.FlaskofFire, false);
                        }
                        break;
                    }
                }
            }
            //if (chest != null && Main.tile[chest.x, chest.y].type == TileID.Containers && Main.tile[chest.x, chest.y].frameX == 1 * 36)
            //{
            //    bool isADesertChest = false;
            //    int num = 0; // I dont remember what all these variables are aaaaa
            //    int num2 = 2;
            //    int num3 = chest.x;
            //    int num4 = chest.y;
            //    for (int j = num3 - num; j <= num3 + num; j++)
            //    {
            //        for (int k = num4 - num2; k < num4 + num2; k++)
            //        {
            //            if (Main.tile[j, k].type == TileID.SandstoneBrick) // BUT they check if the chest is on top of Sandstone bricks, in other words, in a Pyramid.
            //            {
            //                isADesertChest = true;
            //            }
            //        }
            //    }
            //    for (int i = 0; i < 40; i++)
            //    {
            //        if (i == 0 && isADesertChest)
            //        {
            //            int pyramiditem = Main.rand.Next(PyramidItems);
            //            chest.item[i].SetDefaults(pyramiditem, false);
            //            break;
            //        }
            //    }    
            //}
            if (chest != null && Main.tile[chest.x, chest.y].type == TileID.Containers && Main.tile[chest.x, chest.y].frameX == 11 * 36)
            {
                for (int i = 0; i < 40; i++)
                {
                    if (i == 0)
                    {
                        if (WorldGen.genRand.NextBool(8))
                        {
                            chest.item[i].SetDefaults(ItemID.FrostStaff, false);
                            break;
                        }
                    }
                }
            }
            if (chest != null && Main.tile[chest.x, chest.y].type == TileID.Containers2 && Main.tile[chest.x, chest.y].frameX == 10 * 36)
            {
                int pyramiditem = Main.rand.Next(PyramidItems);
                for (int i = 0; i < 40; i++)
                {
                    if (i == 0)
                    {
                        chest.item[i].SetDefaults(pyramiditem, false);
                        break;
                    }
                }
                for (int i = 0; i < 40; i++)
                {    
                    if (i == 2 && WorldGen.genRand.NextBool(3))
                    {
                        {
                            chest.item[i].SetDefaults(ItemID.MysticCoilSnake);
                            break;
                        }
                    }
                }
            }
        }
    }
}




