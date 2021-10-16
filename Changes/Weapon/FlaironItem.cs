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
    public class FlaironItem : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            if(item.type == ItemID.Flairon)
            {
                item.channel = true;
                item.useTime = item.useAnimation = 40;
                item.damage = 150;
                item.autoReuse = false;
                item.noMelee = true;
            }
        }
        //Heavy Flails actually display twice as much damage in thier tooltip than they actually have
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (item.type == ItemID.Flairon)
            {
                foreach (TooltipLine line in tooltips)
                {
                    if (line.mod == "Terraria" && line.Name == "Damage") //this checks if it's the line we're interested in
                    {
                        string[] strings = line.text.Split(' ');
                        int dmg = int.Parse(strings[0]);
                        dmg *= 2;
                        line.text = dmg + "";//change tooltip
                        for (int i = 1; i < strings.Length; i++)
                        {
                            line.text += " " + strings[i];
                        }
                    }
                }
            }
        }
    }
}
