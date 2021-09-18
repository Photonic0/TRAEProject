using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TRAEProject.Changes.Weapon
{
    public class SwordSize : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
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
                    item.scale *= 1.25f;
                    return;
                // REVISIT
                case ItemID.TrueNightsEdge: // REVISIT
                    item.scale = 1.35f;
                    return;

                case ItemID.Bladetongue:
                    item.scale = 1.45f; // up from 1.25
                    return;
                case ItemID.Frostbrand:
                    item.scale = 1.5f; // up from 1.15
                    return;
                case ItemID.TerraBlade:
                case ItemID.TheHorsemansBlade:
                    item.scale = 1.6f;
                    return;
                case ItemID.InfluxWaver:
                    item.scale = 1.5f; // up from 1.05
                    return;
                case 3063: // meowmere
                    item.scale = 1.95f; // up from 1.05
                    return;
                case 3065: // star wrath
                    item.scale = 1.85f; // up from 1.05
                    return;

            }
        }
    }
}
