using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TRAEProject.Changes.Prefixes
{
    public class AccModPlayer : ModPlayer
    {
        public const int SpeedValue = 3;
        public const int JumpValue = 4;
        public override void PostUpdateEquips()
        {
            for (int i = 3; i < 10; i++)
            {
                //The Player.armor[] array represents the items the Player has equiped
                //indexes 0-2 are the Player's armor
                //indexes 3-9 are the accesories (what we are checking)
                //indexes 10-19 are vanity slots
                if (Player.armor[i].active)
                {
                    if (Player.armor[i].prefix == PrefixID.Brisk)
                    {
                        Player.moveSpeed -= 0.01f;
                        Player.jumpSpeedBoost += Mobility.JSV(JumpValue * 0.01f); // remember that jump speed bonuses are weird
                    }
                    if (Player.armor[i].prefix == PrefixID.Fleeting)
                    {
                        Player.moveSpeed -= 0.02f;
                        Player.jumpSpeedBoost += Mobility.JSV(JumpValue * 2 * 0.01f);
                    }
                    if (Player.armor[i].prefix == PrefixID.Hasty2)
                    {
                        Player.moveSpeed -= 0.03f;
                        Player.moveSpeed += SpeedValue * 0.01f;
                    }
                    if (Player.armor[i].prefix == PrefixID.Quick2)
                    {
                        Player.moveSpeed -= 0.04f;
                        Player.moveSpeed += SpeedValue * 2 * 0.01f;
                    } 
                    
                    if (Player.armor[i].prefix == PrefixID.Wild)
                    {
                        Player.GetAttackSpeed(DamageClass.Melee) += 0.01f;
                    }
                    if (Player.armor[i].prefix == PrefixID.Rash)
                    {
                        Player.GetAttackSpeed(DamageClass.Melee) += 0.02f;
                    }
                    if (Player.armor[i].prefix == PrefixID.Intrepid)
                    {
                        Player.GetAttackSpeed(DamageClass.Melee) += 0.03f;
                    }
                    if (Player.armor[i].prefix == PrefixID.Violent)
                    {
                        Player.GetAttackSpeed(DamageClass.Melee) += 0.04f;
                    }
                    if (Player.armor[i].prefix == PrefixID.Arcane)
                    {
                        //Player.manaCost -= 0.04f;
                    } 
                }
            }
        }
    }
    public class AccesroyPrefixTooltipis : GlobalItem
    { 
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
                        for (int i = 1; i <= 4; i++)
                        {
                            if (line.Text.Contains("" + i))
                            {
                                line.Text = line.Text.Replace("" + i, "" + (i * 2));
                                break;
                            }
                        }
                    }
                    if (line.Name == "PrefixAccMoveSpeed")
                    {
                        //if the tooltip has a character equal to 'i' replace it with a number that twice as big as 'i'
                        for (int i = 1; i <= 4; i++)
                        {
                            if (line.Text.Contains("" + i))
                            {
                                if (line.Text.Contains("" + i))
                                {
                                    switch(i)
                                    {
                                        case 1:
                                            line.Text = line.Text.Replace("" + i, "" + AccModPlayer.JumpValue);
                                            break;
                                        case 3:
                                            line.Text = line.Text.Replace("" + i, "" + AccModPlayer.SpeedValue);
                                            break;
                                        case 2:
                                                line.Text = line.Text.Replace("" + i, "" + (AccModPlayer.JumpValue * 2));
                                            break;
                                        case 4:
                                            line.Text = line.Text.Replace("" + i, "" + (AccModPlayer.SpeedValue * 2));
                                        break;
                                    }
                                    if(i == 1 || i == 2)
                                    {
                                        line.Text = line.Text.Replace("movement speed", "jump speed");
                                    }
                                    break;
                                }
                                break;
                            }
                        }
                    }
                    if (line.Name == "PrefixAccMaxMana")
                    {
                        //line.Text += " and 4% reduced mana costs";
                    }
                }
            }
        }
    }
}
