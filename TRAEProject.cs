using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using TRAEProject;
using TRAEProject.Changes.Weapon;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using TRAEProject.NewContent.Items.Accesories.ShadowflameCharm;
using static Terraria.ModLoader.ModContent;
using ReLogic.Content;
using TRAEProject.NewContent.Items.Armor.IceArmor;
using TRAEProject.Changes.Weapon.Ranged;
using TRAEProject.Changes.Recipes;

namespace TRAEProject
{
    public class TRAEProj : Mod
    {
        public static TRAEProj Instance;

        private static readonly int[] Emblems = new int[] { ItemID.WarriorEmblem, ItemID.RangerEmblem, ItemID.SorcererEmblem, ItemID.SummonerEmblem };
        public static Texture2D debugCross;

        public const string DreadHead1 = "TRAEProject/Changes/NPCs/Boss/Dreadnautilus/MapIcon";
        public const string DreadHead2 = "TRAEProject/Changes/NPCs/Boss/Dreadnautilus/MapIcon2";
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
            RecipeGroup Adamantite = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Adamantite Bar", new int[]
            {
                ItemID.AdamantiteBar,
                ItemID.TitaniumBar
            });
            RecipeGroup.RegisterGroup("Adamantite", Adamantite); // RENAME THIS TO ADAMANTITE
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
                IceMajestyCape = AddEquipTexture(GetModItem(ItemType<IceMajestyBreastplate>()), EquipType.Back, "TRAEProject/NewContent/Items/Armor/IceArmor/IceMajestyBreastplate_Back");
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
            WeaponRecipes.Load(this);
            AccesoryRecipes.Load(this);
            MiscRecipes.Load(this);
            ArmorRecipes.Load(this);
        }
        public override void PostAddRecipes()
        {
            foreach (Recipe recipe in Main.recipe)
            {
                WeaponRecipes.Modify(recipe);
                AccesoryRecipes.Modify(recipe);
                MiscRecipes.Modify(recipe);
                ArmorRecipes.Modify(recipe);
            }
        }
    }
}
