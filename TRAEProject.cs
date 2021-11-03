using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using TRAEProject;
using TRAEProject.Changes.Weapon;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using TRAEProject.Items.Accesories.ShadowflameCharm;
using static Terraria.ModLoader.ModContent;
using ReLogic.Content;
using TRAEProject.Items.Armor.IceArmor;

namespace TRAEProject
{
    public class TRAEProj : Mod
    {
        public static TRAEProj Instance;

        private static readonly int[] Emblems = new int[] { ItemID.WarriorEmblem, ItemID.RangerEmblem, ItemID.SorcererEmblem, ItemID.SummonerEmblem };
        public static Texture2D debugCross;

        public const string DreadHead1 = "TRAEProject/Changes/Dreadnautilus/MapIcon";
        public const string DreadHead2 = "TRAEProject/Changes/Dreadnautilus/MapIcon2";
        public static int IceMajestyCape;
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
            RecipeGroup Cobalt = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Adamantite Bar", new int[]
{
         ItemID.AdamantiteBar,
                ItemID.TitaniumBar
});
            RecipeGroup.RegisterGroup("Cobalt", Cobalt); // RENAME THIS TO ADAMANTITE
            RecipeGroup Shadowscales = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Evil Tissue", new int[]
{
         ItemID.ShadowScale,
                ItemID.TissueSample
        });
            RecipeGroup.RegisterGroup("Shadowscales", Shadowscales); RecipeGroup group1 = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Tsunami in a Bottle", new int[]
      {
                ItemID.TsunamiInABottle,
                ItemID.SharkronBalloon
      });
            RecipeGroup.RegisterGroup("TsunamiJump", group1);
            RecipeGroup group2 = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Fart in a jar", new int[]
             {
                ItemID.FartinaJar,
                ItemID.FartInABalloon
             });
            RecipeGroup.RegisterGroup("FartJump", group2);
            RecipeGroup group3 = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Honey Balloon", new int[]
 {
                ItemID.HoneyComb,
                ItemID.HoneyBalloon
 });
            RecipeGroup.RegisterGroup("HoneyBalloon", group3);
        }
    
        public override void Load()
        {
            Instance = this;
            AddBossHeadTexture(DreadHead1);
            AddBossHeadTexture(DreadHead2);
            if(!Main.dedServ)
            {
                IceMajestyCape = AddEquipTexture(GetModItem(ItemType<IceMajestyBreastplate>()), EquipType.Back, "TRAEProject/Items/Armor/IceArmor/IceMajestyBreastplate_Back");
            }
            Main.QueueMainThreadAction(() =>
            {
                QwertyFlexOnBame.CreateDolphin();
                if (!Main.dedServ)
                {
                    debugCross = Request<Texture2D>("TRAEProject/DebugCross", AssetRequestMode.ImmediateLoad).Value;
                }

            });
            
        }
        public override void AddRecipes()
        {
            Recipe HermesBoots = CreateRecipe(ItemID.HermesBoots).AddIngredient(ItemID.Aglet, 1).AddIngredient(ItemID.Silk, 20).AddTile(TileID.Loom);
            HermesBoots.Register();
            Recipe BloodyTear = CreateRecipe(ItemID.BloodMoonStarter).AddIngredient(ItemID.Lens, 5).AddIngredient(ItemID.VilePowder, 50).AddIngredient(ItemID.Deathweed, 10).AddTile(TileID.DemonAltar);
            BloodyTear.Register();
            Recipe BloodyTear2 = CreateRecipe(ItemID.BloodMoonStarter).AddIngredient(ItemID.Lens, 5).AddIngredient(ItemID.ViciousPowder, 50).AddIngredient(ItemID.Deathweed, 10).AddTile(TileID.DemonAltar);
            BloodyTear2.Register();
            Recipe Magnet = CreateRecipe(ItemID.CelestialMagnet).AddIngredient(ItemID.TreasureMagnet, 1).AddIngredient(ItemID.ManaCrystal, 5).AddTile(TileID.Anvils);
            Magnet.Register();
            Recipe AvengerEmblem = CreateRecipe(ItemID.AvengerEmblem).AddRecipeGroup("Emblem").AddIngredient(ItemID.SoulofMight, 15).AddTile(TileID.TinkerersWorkbench);
            AvengerEmblem.Register();
            Recipe StardustPortal = CreateRecipe(ItemID.MoonlordTurretStaff).AddIngredient(3459, 18).AddTile(TileID.LunarCraftingStation);
            StardustPortal.Register();
            Recipe DarkLance = CreateRecipe(ItemID.DarkLance);
            DarkLance.AddIngredient(ItemID.DemoniteBar, 10);
            DarkLance.AddIngredient(ItemID.ShadowScale, 5);
            DarkLance.AddTile(TileID.Anvils);
            DarkLance.Register();
            Recipe WaspGun = CreateRecipe(ItemID.WaspGun);
            WaspGun.AddIngredient(ItemID.BeeGun, 1);
            WaspGun.AddIngredient(ItemID.SoulofFright, 20);
            WaspGun.AddTile(TileID.MythrilAnvil);
            WaspGun.Register();
            Recipe PulseBow = CreateRecipe(ItemID.PulseBow);
            PulseBow.AddIngredient(ItemID.ShroomiteBar, 20);
            PulseBow.AddTile(TileID.Autohammer);
            PulseBow.Register();
            Recipe BoBrecipe = CreateRecipe(ItemID.BundleofBalloons);
            BoBrecipe.AddIngredient(ItemID.SoulofFlight, 20);
            BoBrecipe.AddRecipeGroup("CloudBalloon");
            BoBrecipe.AddRecipeGroup("BlizzardJump");
            BoBrecipe.AddRecipeGroup("SandstormJump");
            BoBrecipe.AddTile(TileID.TinkerersWorkbench);
            BoBrecipe.Register();
            Recipe BoBrecipe1 = CreateRecipe(ItemID.BundleofBalloons);
            BoBrecipe1.AddIngredient(ItemID.SoulofFlight, 20);
            BoBrecipe1.AddRecipeGroup("BlizzardBalloon");
            BoBrecipe1.AddRecipeGroup("CloudJump");
            BoBrecipe1.AddRecipeGroup("SandstormJump");
            BoBrecipe1.AddTile(TileID.TinkerersWorkbench);
            BoBrecipe1.Register();
            Recipe BoBrecipe2 = CreateRecipe(ItemID.BundleofBalloons);
            BoBrecipe2.AddIngredient(ItemID.SoulofFlight, 20);
            BoBrecipe2.AddRecipeGroup("SandstormBalloon");
            BoBrecipe2.AddRecipeGroup("CloudJump");
            BoBrecipe2.AddRecipeGroup("BlizzardJump");
            BoBrecipe2.AddTile(TileID.TinkerersWorkbench);
                           BoBrecipe2.Register();
        }
        public override void PostAddRecipes()
        {
            foreach (Recipe recipe in Main.recipe)
            {
                Item ingredientToRemove;
                if (recipe.HasResult(ItemID.SilverBullet))
                {
                    recipe.ReplaceResult(ItemID.SilverBullet, 100);
                    recipe.TryGetIngredient(ItemID.MusketBall, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.MusketBall, 100);
                }
                if (recipe.HasResult(ItemID.TungstenBullet))
                {
                    recipe.ReplaceResult(ItemID.TungstenBullet, 100);
                    recipe.TryGetIngredient(ItemID.MusketBall, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.MusketBall, 100);
                }
                if (recipe.HasResult(ItemID.MeteorShot))
                {
                    recipe.ReplaceResult(ItemID.MeteorShot, 100);
                    recipe.TryGetIngredient(ItemID.MusketBall, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.MusketBall, 100);
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
                    recipe.TryGetIngredient(ItemID.WoodenArrow, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.WoodenArrow, 100);
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
                if (recipe.HasResult(ItemID.MechanicalGlove))
                {
                    recipe.TryGetIngredient(ItemID.PowerGlove, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.FeralClaws, 1);
                }
                if (recipe.HasResult(ItemID.BerserkerGlove))
                {
                    recipe.TryGetIngredient(ItemID.PowerGlove, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.FeralClaws, 1);
                }
                if (recipe.HasResult(ItemID.FireGauntlet))
                {
                    recipe.TryGetIngredient(ItemID.MechanicalGlove, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.TitanGlove, 1);
                    recipe.AddIngredient(ItemID.SoulofFright, 10);
                }
                if (recipe.HasResult(ItemID.TrueExcalibur))
                {
                    recipe.TryGetIngredient(ItemID.ChlorophyteBar, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
					recipe.AddIngredient(ItemID.ChlorophyteSaber, 1);
					recipe.AddIngredient(ItemID.SoulofMight, 20);
                    recipe.AddIngredient(ItemID.SoulofLight, 20);
                }
				
                if (recipe.HasResult(ItemID.Megashark))
                {
                    recipe.TryGetIngredient(ItemID.SoulofMight, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.SoulofFright, 20);
                }
				if (recipe.HasResult(ItemID.TrueNightsEdge))
                {
                    recipe.TryGetIngredient(ItemID.SoulofFright, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.TryGetIngredient(ItemID.SoulofMight, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.ChlorophyteClaymore, 1);
					recipe.AddIngredient(ItemID.SoulofNight, 20);
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
              
                if (recipe.HasResult(ItemID.FrostsparkBoots))
                {
                    recipe.TryGetIngredient(ItemID.LightningBoots, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.FlurryBoots, 1);
                }
                if (recipe.HasResult(ItemID.LightningBoots))
                {
                    recipe.TryGetIngredient(ItemID.Aglet, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                }
                if (recipe.HasResult(ItemID.TerrasparkBoots))
                {
                    recipe.TryGetIngredient(ItemID.FrostsparkBoots, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove); 
                    recipe.TryGetIngredient(ItemID.LavaWaders, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.LightningBoots, 1); 
                    recipe.AddIngredient(ItemID.Tabi, 1);
                    recipe.AddIngredient(ItemID.BrokenHeroSword, 1);
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
					recipe.TryGetIngredient(ItemID.ObsidianRose, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);		
					recipe.TryGetIngredient(ItemID.MoltenCharm, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
							recipe.TryGetIngredient(ItemID.LavaCharm, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
							recipe.TryGetIngredient(ItemID.WaterWalkingBoots, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.WaterWalkingBoots, 1);
					    recipe.AddIngredient(ItemID.LavaCharm, 1);
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
				if (recipe.HasResult(ItemID.MoltenCharm))
                {
                    recipe.TryGetIngredient(ItemID.LavaCharm, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.TryGetIngredient(ItemID.ObsidianSkull, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
					recipe.AddIngredient(ItemID.LavaCharm);
						recipe.AddIngredient(ItemType<ShadowflameCharmItem>());
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
                    recipe.AddRecipeGroup("Cobalt", 10);
                    recipe.RemoveTile(TileID.Loom);
                    recipe.AddTile(TileID.MythrilAnvil);
                }
                if (recipe.HasResult(ItemID.AncientArmorShirt))
                {
                    recipe.TryGetIngredient(ItemID.AncientCloth, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.AncientCloth, 2);
                     recipe.AddRecipeGroup("Cobalt", 20);
                    recipe.RemoveTile(TileID.Loom);
                    recipe.AddTile(TileID.MythrilAnvil);
                }
                if (recipe.HasResult(ItemID.AncientArmorPants))
                {
                    recipe.TryGetIngredient(ItemID.AncientCloth, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.AncientCloth, 2);
                    recipe.AddRecipeGroup("Cobalt", 15);
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
                if (recipe.HasResult(ItemID.AnkhCharm))
                {
                    recipe.RemoveRecipe();
                }
                if (recipe.HasResult(ItemID.StardustDragonStaff))
                {
                    recipe.RemoveRecipe();
                }
                if (recipe.HasResult(ItemID.CountercurseMantra))
                {
                    recipe.TryGetIngredient(ItemID.Megaphone, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.AnkhCharm, 1);
			}          
			if (recipe.HasResult(ItemID.AnkhShield))
                {
                    recipe.TryGetIngredient(ItemID.ObsidianShield, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.CobaltShield, 1);
                }
                if (recipe.HasResult(ItemID.SniperScope))
                {
                    recipe.TryGetIngredient(ItemID.DestroyerEmblem, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.EyeoftheGolem, 1);
                }
                if (recipe.HasResult(ItemID.ReconScope))
                {
                    recipe.TryGetIngredient(ItemID.PutridScent, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove); 
                    recipe.TryGetIngredient(ItemID.SniperScope, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.RifleScope, 1);
                    recipe.AddIngredient(ItemID.MagicQuiver, 1);
                }
                if (recipe.HasResult(ItemID.AnkhShield))
                {
                    recipe.TryGetIngredient(ItemID.ObsidianShield, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.CobaltShield, 1);
                }
                if (recipe.HasResult(ItemID.ObsidianSkull))
                {
                    recipe.AddIngredient(ItemID.Bone, 20);
                }
                if (recipe.HasResult(ItemID.ObsidianHorseshoe))
                {
                    recipe.TryGetIngredient(ItemID.ObsidianSkull, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.Obsidian, 20);
                }                
				if (recipe.HasResult(ItemID.BoneJavelin))
                {
                     recipe.ReplaceResult(ItemID.BoneJavelin, 1);
                    recipe.TryGetIngredient(3380, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(3380, 10);
                }
                if (recipe.HasResult(ItemID.BoneJavelin))
                {
                    recipe.ReplaceResult(ItemID.BoneJavelin, 1);
                    recipe.TryGetIngredient(3380, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(3380, 10);
                }                                  
                if (recipe.HasResult(ItemID.FrogGear))
                {
                    recipe.TryGetIngredient(ItemID.FrogWebbing, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
					recipe.TryGetIngredient(ItemID.FrogFlipper, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
					       recipe.TryGetIngredient(ItemID.Flipper, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);	       
					recipe.TryGetIngredient(ItemID.TigerClimbingGear, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                     recipe.AddIngredient(ItemID.FrogLeg, 1);
					      recipe.AddIngredient(ItemID.Tabi, 1);
                }
                if (recipe.HasResult(ItemID.FartinaJar))
                {
                    recipe.TryGetIngredient(ItemID.CloudinaBottle, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.Bottle);
                }
                if (recipe.HasResult(ItemID.EnchantedBoomerang))
                {
                    recipe.TryGetIngredient(ItemID.FallenStar, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.FallenStar, 5);
                    recipe.AddIngredient(ItemID.Ruby, 1);
                }
                if (recipe.HasResult(ItemID.HornetStaff))
                {
                    recipe.TryGetIngredient(ItemID.BeeWax, out ingredientToRemove);
                    recipe.RemoveIngredient(ingredientToRemove);
                    recipe.AddIngredient(ItemID.Stinger, 8);
                    recipe.AddIngredient(ItemID.Hive, 10);
                }

            }
        }
    }
}
