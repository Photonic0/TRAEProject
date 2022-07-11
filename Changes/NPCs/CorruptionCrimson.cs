using Microsoft.Xna.Framework;
using Terraria;
using System;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using static Terraria.ModLoader.ModContent;

namespace TRAEProject.Changes.NPCs
{
    public static class ArmorRecipes
    {
        public static void Load(Mod mod)
        {
            Recipe Leather = Recipe.Create(ItemID.Leather).AddIngredient(ItemID.Vertebrae, 5).AddTile(TileID.Tables);
            Leather.Register();
        }
        public static void Modify(Recipe recipe)
        {
            Item ingredientToRemove; 
            if (recipe.HasResult(ItemID.UnholyArrow))
            {
                recipe.TryGetIngredient(ItemID.WoodenArrow, out ingredientToRemove);
                recipe.RemoveIngredient(ingredientToRemove);
                recipe.TryGetIngredient(ItemID.WormTooth, out ingredientToRemove);
                recipe.RemoveIngredient(ingredientToRemove);
                recipe.AddIngredient(ItemID.WoodenArrow, 33);
                recipe.AddIngredient(ItemID.WormTooth, 1);
                recipe.AddIngredient(ItemID.RottenChunk, 1);
                recipe.ReplaceResult(ItemID.UnholyArrow, 33);
            }
            if (recipe.HasResult(ItemID.WormFood))
            {
                recipe.TryGetIngredient(ItemID.RottenChunk, out ingredientToRemove);
                recipe.RemoveIngredient(ingredientToRemove);
                recipe.TryGetIngredient(ItemID.VilePowder, out ingredientToRemove);
                recipe.RemoveIngredient(ingredientToRemove);
                recipe.AddIngredient(ItemID.RottenChunk, 8);
                recipe.AddIngredient(ItemID.WormTooth, 12);
                recipe.AddIngredient(ItemID.VilePowder, 30);
            }
            if (recipe.HasResult(ItemID.BloodySpine))
            {
                recipe.TryGetIngredient(ItemID.Vertebrae, out ingredientToRemove);
                recipe.RemoveIngredient(ingredientToRemove);
                recipe.TryGetIngredient(ItemID.ViciousPowder, out ingredientToRemove);
                recipe.RemoveIngredient(ingredientToRemove);
                recipe.AddIngredient(ItemID.Vertebrae, 8);
                recipe.AddIngredient(ItemID.WormTooth, 12);
                recipe.AddIngredient(ItemID.ViciousPowder, 30);
            }
        }
    }

    public class EvilBiomeEnemies: GlobalNPC
    {               
	
	public override bool InstancePerEntity => true;
        public override void SetDefaults(NPC npc)
        {
            switch (npc.type)
            {
             
            }
        }
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            switch (npc.type)
            {
                case NPCID.BloodCrawler:
                case NPCID.BloodCrawlerWall:
                    npcLoot.Add(ItemDropRule.Common(ItemID.WormTooth, 5, 1));
                    return;
                case NPCID.Crimera:
                    npcLoot.Add(ItemDropRule.Common(ItemID.Leather, 10, 1));
                    return;
                case NPCID.FaceMonster:
                    npcLoot.Add(ItemDropRule.Common(ItemID.WormTooth, 2, 3, 7));
                    npcLoot.Add(ItemDropRule.Common(ItemID.Leather, 10, 1));
                    return;
                case NPCID.EaterofSouls:
                    npcLoot.Add(ItemDropRule.Common(ItemID.Leather, 12, 1));
                    return;
                case NPCID.DevourerHead:
                    npcLoot.RemoveWhere(rule =>
                    {
                        if (rule is not CommonDrop drop) // Type of drop you expect here
                            return false;
                        return drop.itemId == ItemID.RottenChunk; // compare more fields if needed
                    });
                    npcLoot.Add(ItemDropRule.Common(ItemID.RottenChunk, 1, 2, 4));
                    npcLoot.Add(ItemDropRule.Common(ItemID.Leather, 5, 1));
                    return;
            }
        }
    }
}