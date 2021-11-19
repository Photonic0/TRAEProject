using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TRAEProject
{
    class PrefixChange : GlobalItem
    {

        public override bool InstancePerEntity => true;
        public override GlobalItem Clone(Item item, Item itemClone)
        {
            return base.Clone(item, itemClone);
        }

        public override void HoldItem(Item item, Player player)
        {
            //newSizeModifier = 1f;
        }
        //public override void ModifyWeaponDamage(Item item, Player player, ref float add, ref float mult, ref float flat)
        //{
        //    if (player.HeldItem.prefix == PrefixID.Massive)
        //    {
        //        mult *= 1.05f;
        //    }
        //    return;
        //}
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            //check if item has an appropriate prefix
            if (item.prefix == PrefixID.Brisk || item.prefix == PrefixID.Fleeting || item.prefix == PrefixID.Hasty2 || item.prefix == PrefixID.Quick2 || item.prefix == PrefixID.Wild || item.prefix == PrefixID.Rash || item.prefix == PrefixID.Intrepid || item.prefix == PrefixID.Violent || item.prefix == PrefixID.Arcane)
            {
                foreach (TooltipLine line in tooltips)
                {
                    //find the tooltip line we want to change based on its name
                    if (line.Name == "PrefixAccMeleeSpeed")
                    {
                        //if the tooltip has a character equal to 'i' replace it with a number that twice as big as 'i'
                        for(int i = 1; i <= 4; i++)
                        {
                            if (line.text.Contains("" + i))
                            {
                                line.text = line.text.Replace("" + i, "" + (i * 2));
                                break;
                            }
                        }                        
                    }
                    if (line.Name == "PrefixAccMoveSpeed")
                    {
                        //if the tooltip has a character equal to 'i' replace it with a number that twice as big as 'i'
                        for (int i = 1; i <= 4; i++)
                        {
                            if (line.text.Contains("" + i))
                            { 
                                line.text = line.text.Replace("" + i, "" + (i * 1));
                                break;
                            }
                        }
                        line.text += " and jump speed";
                    }
                    if (line.Name == "PrefixAccMaxMana")
                    {
                       //line.text += " and 4% reduced mana costs";
                    }
                }
            }
        }
    }
}
