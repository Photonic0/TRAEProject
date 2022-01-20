using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TRAEProject.Changes.Recipes
{
    public static class MiscRecipes
    {
        public static void Load(Mod mod)
        {
            Recipe BloodyTear = mod.CreateRecipe(ItemID.BloodMoonStarter).AddIngredient(ItemID.Lens, 5).AddIngredient(ItemID.VilePowder, 50).AddIngredient(ItemID.Deathweed, 10).AddTile(TileID.DemonAltar);
            BloodyTear.Register();
            Recipe BloodyTear2 = mod.CreateRecipe(ItemID.BloodMoonStarter).AddIngredient(ItemID.Lens, 5).AddIngredient(ItemID.ViciousPowder, 50).AddIngredient(ItemID.Deathweed, 10).AddTile(TileID.DemonAltar);
            BloodyTear2.Register();
        }
        public static void Modify(Recipe recipe)
        {
            Item ingredientToRemove;
            if (recipe.HasResult(ItemID.HeartreachPotion))
            {
                recipe.TryGetIngredient(ItemID.Daybloom, out ingredientToRemove);
                recipe.RemoveIngredient(ingredientToRemove);
                recipe.TryGetIngredient(ItemID.CrimsonTigerfish, out ingredientToRemove);
                recipe.RemoveIngredient(ingredientToRemove);
                recipe.AddIngredient(ItemID.Waterleaf, 1);
                recipe.AddIngredient(ItemID.PrincessFish, 1);
            }
            if (recipe.HasResult(ItemID.ThornsPotion))
            {
                recipe.TryGetIngredient(ItemID.Stinger, out ingredientToRemove);
                recipe.RemoveIngredient(ingredientToRemove);
                recipe.TryGetIngredient(ItemID.WormTooth, out ingredientToRemove);
                recipe.RemoveIngredient(ingredientToRemove);
            }
            if (recipe.HasResult(ItemID.TitanPotion))
            {
                recipe.TryGetIngredient(ItemID.Bone, out ingredientToRemove);
                recipe.RemoveIngredient(ingredientToRemove);
                recipe.TryGetIngredient(ItemID.Deathweed, out ingredientToRemove);
                recipe.RemoveIngredient(ingredientToRemove);
                recipe.AddIngredient(ItemID.CrimsonTigerfish, 1);
            }
            if (recipe.HasResult(ItemID.SuperManaPotion))
            {
                recipe.TryGetIngredient(ItemID.FallenStar, out ingredientToRemove);
                recipe.RemoveIngredient(ingredientToRemove);
                recipe.AddIngredient(ItemID.SoulofSight, 1);
            }
            if (recipe.HasResult(ItemID.PickaxeAxe) || recipe.HasResult(ItemID.Drax))
            {
                recipe.TryGetIngredient(ItemID.SoulofSight, out ingredientToRemove);
                recipe.RemoveIngredient(ingredientToRemove);
                recipe.TryGetIngredient(ItemID.SoulofFright, out ingredientToRemove);
                recipe.RemoveIngredient(ingredientToRemove);
                recipe.TryGetIngredient(ItemID.SoulofMight, out ingredientToRemove);
                recipe.RemoveIngredient(ingredientToRemove);
                recipe.AddIngredient(ItemID.SoulofFright, 20);

            }
        }
    }
}
