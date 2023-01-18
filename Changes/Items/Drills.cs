
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace TRAEProject.Changes.Items
{
    public class DrillItems : GlobalItem
    {
	    public override bool InstancePerEntity => true;       
        public int drillSpeed = -1;
        public override void SetDefaults(Item item)
        {
            switch(item.type)
            {
                case ItemID.CobaltDrill:
                case ItemID.PalladiumDrill:
                drillSpeed = 10;
                item.tileBoost = 0;
                break;
                case ItemID.MythrilDrill:
                case ItemID.OrichalcumDrill:
                drillSpeed = 8;
                item.tileBoost = 0;
                break;
                case ItemID.AdamantiteDrill:
                case ItemID.TitaniumDrill:
                case ItemID.Drax:
                case ItemID.ChlorophyteDrill:
                drillSpeed = 6;
                item.tileBoost++;
                break;
            }
        }
        public override void HoldItem(Item item, Player player)
        {
            
            if(drillSpeed > 0)
            {
                item.useTime = (int)((float)drillSpeed * (player.pickSpeed)) - 1;
            }
            
        }
    }
}
