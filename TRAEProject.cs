using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using TRAEProject;
namespace TRAEProject
{
    public class TRAEProj : Mod
    {
        public static TRAEProj Instance;

        private static readonly int[] Emblems = new int[] { ItemID.WarriorEmblem, ItemID.RangerEmblem, ItemID.SorcererEmblem, ItemID.SummonerEmblem };

        public override void AddRecipeGroups()
        {
            RecipeGroup group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Emblem", new int[]
            {
                ItemID.WarriorEmblem,
                ItemID.RangerEmblem,
                ItemID.SorcererEmblem,
                ItemID.SummonerEmblem
            });
            RecipeGroup.RegisterGroup("Emblem", group);
            RecipeGroup CloudBalloon1 = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Cloud in a Balloon", new int[]
{
                ItemID.CloudinaBalloon,
                ItemID.BlueHorseshoeBalloon
});
            RecipeGroup.RegisterGroup("CloudBalloon", CloudBalloon1);
            RecipeGroup Jumpgroup1 = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Cloud in a Bottle", new int[]
  {
                ItemID.CloudinaBottle,
                ItemID.CloudinaBalloon,
                ItemID.BlueHorseshoeBalloon
  });
            RecipeGroup.RegisterGroup("CloudJump", Jumpgroup1);
            RecipeGroup BlizzardBalloon1 = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Blizzard in a Balloon", new int[]
{
                ItemID.BlizzardinaBalloon,
                ItemID.WhiteHorseshoeBalloon
});
            RecipeGroup.RegisterGroup("BlizzardBalloon", BlizzardBalloon1);
            RecipeGroup Jumpgroup2 = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Blizzard in a Bottle", new int[]
             {
                ItemID.BlizzardinaBottle,
                ItemID.BlizzardinaBalloon,
                ItemID.WhiteHorseshoeBalloon
             });
            RecipeGroup.RegisterGroup("BlizzardJump", Jumpgroup2);
            RecipeGroup SandstormBalloon1 = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Sandstorm in a Balloon", new int[]
{
                ItemID.SandstorminaBalloon,
                ItemID.YellowHorseshoeBalloon
});
            RecipeGroup.RegisterGroup("SandstormBalloon", SandstormBalloon1);
            RecipeGroup Jumpgroup3 = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Sandstorm in a Bottle", new int[]
 {
         ItemID.SandstorminaBottle,
                ItemID.SandstorminaBalloon,
                ItemID.YellowHorseshoeBalloon
            });
            RecipeGroup.RegisterGroup("SandstormJump", Jumpgroup3);
            RecipeGroup Cobalt = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Cobalt Bar", new int[]
{
         ItemID.CobaltBar,
                ItemID.PalladiumBar
});
            RecipeGroup.RegisterGroup("Cobalt", Cobalt);
            RecipeGroup Shadowscales = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Evil Tissue", new int[]
{
         ItemID.ShadowScale,
                ItemID.TissueSample
        });
            RecipeGroup.RegisterGroup("Shadowscales", Shadowscales);
        }
        public override void Load()
        {
            Instance = this;
            //QwertyFlexOnBame.CreateDolphin();
        }
        public override void PostAddRecipes()
        {
            foreach (Recipe recipe in Main.recipe)
            {
                Item ingredientToRemove;
                if (recipe.HasResult(ItemID.SilverBullet))
                {
                    recipe.ReplaceResult(ItemID.SilverBullet, 100);
                }
                if (recipe.HasResult(ItemID.TungstenBullet))
                {
                    recipe.ReplaceResult(ItemID.TungstenBullet, 100);
                }
                if (recipe.HasResult(ItemID.MeteorShot))
                {
                    recipe.ReplaceResult(ItemID.MeteorShot, 100);
                }
                if (recipe.HasResult(ItemID.MoonlordBullet))
                {
                    recipe.ReplaceResult(ItemID.MoonlordBullet, 500);
                }
                if (recipe.HasResult(ItemID.MoonlordArrow))
                {
                    recipe.ReplaceResult(ItemID.MoonlordArrow, 500);
                }
                if (recipe.HasResult(ItemID.VenomArrow))
                {
                    recipe.ReplaceResult(ItemID.VenomArrow, 100);
                }
                if (recipe.HasResult(ItemID.UnholyArrow))
                {
                    recipe.TryGetIngredient(ItemID.WoodenArrow, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.TryGetIngredient(ItemID.WormTooth, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.WoodenArrow, 50);
                    recipe.AddIngredient(ItemID.WormTooth, 1);
                    recipe.ReplaceResult(ItemID.UnholyArrow, 50);
                }
                if (recipe.HasResult(ItemID.UnholyArrow))
                {
                    recipe.TryGetIngredient(ItemID.WoodenArrow, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.TryGetIngredient(ItemID.WormTooth, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.WoodenArrow, 50);
                    recipe.AddIngredient(ItemID.WormTooth, 1);
                    recipe.ReplaceResult(ItemID.UnholyArrow, 50);
                }
                if (recipe.HasResult(ItemID.JestersArrow))
                {
                    recipe.TryGetIngredient(ItemID.WoodenArrow, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.TryGetIngredient(ItemID.FallenStar, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.WoodenArrow, 25);
                    recipe.AddIngredient(ItemID.FallenStar, 1);
                    recipe.ReplaceResult(ItemID.JestersArrow, 25);
                }
                if (recipe.HasResult(ItemID.ArcticDivingGear))
                {
                    recipe.TryGetIngredient(ItemID.IceSkates, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.FrozenTurtleShell);
                }
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
                if (recipe.HasResult(ItemID.AvengerEmblem))
                {
                    recipe.TryGetIngredient(ItemID.SoulofSight, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.TryGetIngredient(ItemID.SoulofFright, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.TryGetIngredient(ItemID.SoulofMight, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.SoulofMight, 10);
                }
                if (recipe.HasResult(ItemID.FireGauntlet))
                {
                    recipe.TryGetIngredient(ItemID.MechanicalGlove, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.TitanGlove, 1);
                    recipe.AddIngredient(ItemID.SoulofFright, 10);
                }
                if (recipe.HasResult(ItemID.LightDisc))
                {
                    recipe.TryGetIngredient(ItemID.SoulofMight, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.SoulofSight, 5);
                }
                if (recipe.HasResult(ItemID.Megashark))
                {
                    recipe.TryGetIngredient(ItemID.SoulofMight, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.SoulofFright, 20);
                }
                if (recipe.HasResult(ItemID.CopperShortsword))
                {
                    recipe.TryGetIngredient(ItemID.CopperBar, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.CopperBar, 2);
                }
                if (recipe.HasResult(ItemID.TinShortsword))
                {
                    recipe.TryGetIngredient(ItemID.TinBar, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.TinBar, 2);
                }
                if (recipe.HasResult(ItemID.IronShortsword))
                {
                    recipe.TryGetIngredient(ItemID.IronBar, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.IronBar, 2);
                }
                if (recipe.HasResult(ItemID.LeadShortsword))
                {
                    recipe.TryGetIngredient(ItemID.LeadBar, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.LeadBar, 2);
                }
                if (recipe.HasResult(ItemID.SilverShortsword))
                {
                    recipe.TryGetIngredient(ItemID.SilverBar, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.SilverBar, 2);
                }
                if (recipe.HasResult(ItemID.TungstenShortsword))
                {
                    recipe.TryGetIngredient(ItemID.TungstenBar, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.TungstenBar, 2);
                }
                if (recipe.HasResult(ItemID.GoldShortsword))
                {
                    recipe.TryGetIngredient(ItemID.GoldBar, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.GoldBar, 2);
                }
                if (recipe.HasResult(ItemID.PlatinumShortsword))
                {
                    recipe.TryGetIngredient(ItemID.PlatinumBar, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.PlatinumBar, 2);
                }
                if (recipe.HasResult(ItemID.PlatinumShortsword))
                {
                    recipe.TryGetIngredient(ItemID.PlatinumBar, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.PlatinumBar, 2);
                }
                if (recipe.HasResult(ItemID.FrostsparkBoots))
                {
                    recipe.TryGetIngredient(ItemID.LightningBoots, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.FlurryBoots, 1);
                }
                if (recipe.HasResult(ItemID.ObsidianWaterWalkingBoots))
                {
                    recipe.TryGetIngredient(ItemID.WaterWalkingBoots, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.TryGetIngredient(ItemID.ObsidianSkull, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.RocketBoots, 1);
                    recipe.AddIngredient(ItemID.ObsidianHorseshoe, 1);
                }
                if (recipe.HasResult(ItemID.LavaWaders))
                {
                    recipe.TryGetIngredient(ItemID.ObsidianWaterWalkingBoots, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.WaterWalkingBoots, 1);
                }
                if (recipe.HasResult(ItemID.MoonShell))
                {
                    recipe.AddIngredient(ItemID.FrozenTurtleShell, 1);
                }
                if (recipe.HasResult(ItemID.CelestialShell))
                {
                    recipe.TryGetIngredient(ItemID.MoonShell, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.NeptunesShell, 1);
                }
                if (recipe.HasResult(ItemID.Flamethrower))
                {
                    recipe.TryGetIngredient(ItemID.SoulofFright, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.SlimeGun, 1);
                    recipe.RemoveTile(TileID.MythrilAnvil);
                    recipe.AddTile(TileID.Anvils);
                }
                if (recipe.HasResult(ItemID.AncientArmorHat))
                {
                    recipe.TryGetIngredient(ItemID.AncientCloth, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.AncientCloth, 2);
                    recipe.AddIngredient(ItemID.CobaltBar, 10);
                    recipe.RemoveTile(TileID.Loom);
                    recipe.AddTile(TileID.MythrilAnvil);
                }
                if (recipe.HasResult(ItemID.AncientArmorShirt))
                {
                    recipe.TryGetIngredient(ItemID.AncientCloth, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.AncientCloth, 2);
                    recipe.AddIngredient(ItemID.CobaltBar, 20);
                    recipe.RemoveTile(TileID.Loom);
                    recipe.AddTile(TileID.MythrilAnvil);
                }
                if (recipe.HasResult(ItemID.AncientArmorPants))
                {
                    recipe.TryGetIngredient(ItemID.AncientCloth, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.AncientCloth, 2);
                    recipe.AddIngredient(ItemID.CobaltBar, 15);
                    recipe.RemoveTile(TileID.Loom);
                    recipe.AddTile(TileID.MythrilAnvil);
                }
                if (recipe.HasResult(ItemID.CopperHelmet))
                {
                    recipe.TryGetIngredient(ItemID.CopperBar, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.CopperBar, 10);
                }
                if (recipe.HasResult(ItemID.CopperChainmail))
                {
                    recipe.TryGetIngredient(ItemID.CopperBar, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.CopperBar, 18);
                }
                if (recipe.HasResult(ItemID.CopperGreaves))
                {
                    recipe.TryGetIngredient(ItemID.CopperBar, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.CopperBar, 12);
                }
                if (recipe.HasResult(ItemID.TinHelmet))
                {
                    recipe.TryGetIngredient(ItemID.TinBar, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.TinBar, 10);
                }
                if (recipe.HasResult(ItemID.TinChainmail))
                {
                    recipe.TryGetIngredient(ItemID.TinBar, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.TinBar, 18);
                }
                if (recipe.HasResult(ItemID.TinGreaves))
                {
                    recipe.TryGetIngredient(ItemID.TinBar, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.TinBar, 12);
                }
                if (recipe.HasResult(ItemID.IronHelmet))
                {
                    recipe.TryGetIngredient(ItemID.IronBar, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.IronBar, 10);
                }
                if (recipe.HasResult(ItemID.IronChainmail))
                {
                    recipe.TryGetIngredient(ItemID.IronBar, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.IronBar, 18);
                }
                if (recipe.HasResult(ItemID.IronGreaves))
                {
                    recipe.TryGetIngredient(ItemID.IronBar, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.IronBar, 12);
                }
                if (recipe.HasResult(ItemID.LeadHelmet))
                {
                    recipe.TryGetIngredient(ItemID.LeadBar, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.LeadBar, 10);
                }
                if (recipe.HasResult(ItemID.LeadChainmail))
                {
                    recipe.TryGetIngredient(ItemID.LeadBar, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.LeadBar, 18);
                }
                if (recipe.HasResult(ItemID.LeadGreaves))
                {
                    recipe.TryGetIngredient(ItemID.LeadBar, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.LeadBar, 12);
                }
                if (recipe.HasResult(ItemID.SilverHelmet))
                {
                    recipe.TryGetIngredient(ItemID.SilverBar, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.SilverBar, 10);
                }
                if (recipe.HasResult(ItemID.SilverChainmail))
                {
                    recipe.TryGetIngredient(ItemID.SilverBar, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.SilverBar, 18);
                }
                if (recipe.HasResult(ItemID.SilverGreaves))
                {
                    recipe.TryGetIngredient(ItemID.SilverBar, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.SilverBar, 12);
                }
                if (recipe.HasResult(ItemID.TungstenHelmet))
                {
                    recipe.TryGetIngredient(ItemID.TungstenBar, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.TungstenBar, 10);
                }
                if (recipe.HasResult(ItemID.TungstenChainmail))
                {
                    recipe.TryGetIngredient(ItemID.TungstenBar, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.TungstenBar, 18);
                }
                if (recipe.HasResult(ItemID.TungstenGreaves))
                {
                    recipe.TryGetIngredient(ItemID.TungstenBar, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.TungstenBar, 12);
                }
                if (recipe.HasResult(ItemID.GoldHelmet))
                {
                    recipe.TryGetIngredient(ItemID.GoldBar, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.GoldBar, 10);
                }
                if (recipe.HasResult(ItemID.GoldChainmail))
                {
                    recipe.TryGetIngredient(ItemID.GoldBar, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.GoldBar, 18);
                }
                if (recipe.HasResult(ItemID.GoldGreaves))
                {
                    recipe.TryGetIngredient(ItemID.GoldBar, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.GoldBar, 12);
                }
                if (recipe.HasResult(ItemID.PlatinumHelmet))
                {
                    recipe.TryGetIngredient(ItemID.PlatinumBar, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.PlatinumBar, 10);
                }
                if (recipe.HasResult(ItemID.PlatinumChainmail))
                {
                    recipe.TryGetIngredient(ItemID.PlatinumBar, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.PlatinumBar, 18);
                }
                if (recipe.HasResult(ItemID.PlatinumGreaves))
                {
                    recipe.TryGetIngredient(ItemID.PlatinumBar, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.PlatinumBar, 12);
                }
                if (recipe.HasResult(ItemID.MagicCuffs))
                {
                    recipe.TryGetIngredient(ItemID.ManaRegenerationBand, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.BandofStarpower, 1);
                }
                if (recipe.HasResult(ItemID.ManaCloak))
                {
                    recipe.TryGetIngredient(ItemID.ManaFlower, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.BandofStarpower, 1);
                }
                if (recipe.HasResult(ItemID.BundleofBalloons))
                {
                    recipe.RemoveRecipe();
                }
                Recipe PulseBow = CreateRecipe(ItemID.PulseBow);
                PulseBow.AddIngredient(ItemID.ShroomiteBar, 20);
                PulseBow.AddTile(TileID.Autohammer);
                Recipe BoBrecipe = CreateRecipe(ItemID.BundleofBalloons);
                BoBrecipe.AddIngredient(ItemID.SoulofFlight, 20);
                BoBrecipe.AddRecipeGroup("CloudBalloon");
                BoBrecipe.AddRecipeGroup("BlizzardJump");
                BoBrecipe.AddRecipeGroup("SandstormJump");
                BoBrecipe.AddTile(TileID.TinkerersWorkbench);
                Recipe BoBrecipe1 = CreateRecipe(ItemID.BundleofBalloons);
                BoBrecipe1.AddIngredient(ItemID.SoulofFlight, 20);
                BoBrecipe1.AddRecipeGroup("BlizzardBalloon");
                BoBrecipe1.AddRecipeGroup("CloudJump");
                BoBrecipe1.AddRecipeGroup("SandstormJump");
                BoBrecipe1.AddTile(TileID.TinkerersWorkbench);
                Recipe BoBrecipe2 = CreateRecipe(ItemID.BundleofBalloons);
                BoBrecipe2.AddIngredient(ItemID.SoulofFlight, 20);
                BoBrecipe2.AddRecipeGroup("SandstormBalloon");
                BoBrecipe2.AddRecipeGroup("CloudJump");
                BoBrecipe2.AddRecipeGroup("BlizzardJump");
                BoBrecipe2.AddTile(TileID.TinkerersWorkbench);
                RecipeHelper.RecipeEditing();
            }
        }
    }
}