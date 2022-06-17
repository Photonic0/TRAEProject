using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ID.ArmorIDs;

namespace TRAEProject.Changes.Armor
{
    public class HairHeadpiece : GlobalItem
    {
        public override void SetStaticDefaults()
        {

            Head.Sets.DrawHatHair[Head.ChlorophyteHeadgear] = true;
            Head.Sets.DrawFullHair[Head.GarlandHat] = true;
        }
    }
}
