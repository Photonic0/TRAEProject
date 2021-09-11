using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TRAEProject.Changes.Items
{
    public class SummonStaffs : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            switch(item.type)
            {
                case ItemID.TempestStaff:
                    item.damage = 42;
                    break;
                case ItemID.DeadlySphereStaff:
                    item.damage = 20; // down from 50
                    return;
            }
        }
    }
}
