using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TRAEProject
{
// EVERYTHING you see here was copypasted from Qwerty's mod code for his Sword Enlarger item. All credits go to him. 
    public class BigSword : ModPlayer
    {
        public float size = 1f;
        public float oldSize = 1f;
        public float Enlarger = 0;

        private Item previousItem = new Item();

        public override void ResetEffects()
        {
            size = 1f;
        }

        public override void PreUpdate()
        {
            previousItem.scale /= oldSize;
            previousItem = new Item();
        }
        public override bool PreItemCheck()
        { 
            if (!Player.HeldItem.IsAir)
            {
                if ((Player.HeldItem.useStyle == ItemUseStyleID.Swing|| Player.HeldItem.useStyle == ItemUseStyleID.Thrust || Player.HeldItem.useStyle == 101) && Player.HeldItem.CountsAsClass<MeleeDamageClass>() && Player.HeldItem.pick == 0 && Player.HeldItem.hammer == 0 && Player.HeldItem.axe == 0)
                {
					Player.HeldItem.scale = Player.HeldItem.GetGlobalItem<EnalargeItem>().defaultScale * size * Player.HeldItem.GetGlobalItem<EnalargeItem>().increasedSize * Player.HeldItem.GetGlobalItem<PrefixChange>().newSizeModifier;
                }
            }
            return base.PreItemCheck();
        }
    }

    public class EnalargeItem : GlobalItem
    {
        public float defaultScale = 1f;
        public float increasedSize = 1f;
        public override bool InstancePerEntity => true;
        public override GlobalItem Clone(Item item, Item itemClone)
        {
            return base.Clone(item, itemClone);
        }
        public override void SetDefaults(Item item)
        {
            defaultScale = item.scale;
            switch (item.type)
            {
                case ItemID.CopperBroadsword:
                case ItemID.TinBroadsword:
                case ItemID.IronBroadsword:
                case ItemID.LeadBroadsword:
                case ItemID.SilverBroadsword:
                case ItemID.TungstenBroadsword:
                case ItemID.GoldBroadsword:
                case ItemID.PlatinumBroadsword:
                    increasedSize = 1.25f;
                    return;
                case ItemID.CobaltSword:
                    increasedSize = 1.59f;
                    return;
                case ItemID.PalladiumSword:
                case ItemID.MythrilSword:
                case ItemID.OrichalcumSword:
                    increasedSize = 1.66f;
                    return;
                case ItemID.AdamantiteSword:
                case ItemID.TitaniumSword:
                case ItemID.Excalibur:
                case ItemID.TrueExcalibur: // REVISIT
                    increasedSize = 1.75f;
                    return;
            // REVISIT
				case ItemID.ChlorophyteSaber:
                case ItemID.TrueNightsEdge: // REVISIT
                    increasedSize = 1.35f;
                    return;

				case ItemID.Bladetongue:
				case ItemID.ChlorophyteClaymore:
                    increasedSize = 1.45f; // up from 1.25
                    return;
	            case ItemID.Frostbrand:
		            increasedSize = 1.5f; // up from 1.15
                    return;
                case ItemID.TerraBlade:
           	    case ItemID.TheHorsemansBlade:
                    increasedSize = 1.6f;
                    return;
				case ItemID.InfluxWaver:
                    increasedSize = 1.5f; // up from 1.05
                    return;
				case ItemID.Keybrand:
	            case ItemID.DD2SquireBetsySword:
                    increasedSize = 1.7f;
                    return;
				case ItemID.BreakerBlade:
                    increasedSize = 1.75f; // up from 1.05f
                    return;
			    case 3063: // meowmere
                    increasedSize = 1.95f; // up from 1.05
                    return;
				case 3065: // star wrath
                    increasedSize = 1.85f; // up from 1.05
                    return;
		
            }
        }

        public override void PostReforge(Item item)
        {
            defaultScale = item.scale;
        }
    }
}