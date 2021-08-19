using Terraria.ID;
using Terraria.ModLoader;

namespace AccesoryPrefixChange
{
    public class AccModPlayer : ModPlayer
    {
        public override void PostUpdateEquips()
        {        
            for(int i = 3; i < 10; i++)
            {
                //The Player.armor[] array represents the items the Player has equiped
                //indexes 0-2 are the Player's armor
                //indexes 3-9 are the accesories (what we are checking)
                //indexes 10-19 are vanity slots
                if(Player.armor[i].active)
                {
                    if (Player.armor[i].prefix == PrefixID.Brisk)
                    {
                        Player.jumpSpeedBoost += 0.05f; // remember that jump speed bonuses are weird
                    }
                    if (Player.armor[i].prefix == PrefixID.Fleeting)
                    {
                        Player.jumpSpeedBoost += 0.1f;
                    }
                    if (Player.armor[i].prefix == PrefixID.Hasty2)
                    {
                        Player.jumpSpeedBoost += 0.15f;
                    }
                    if (Player.armor[i].prefix == PrefixID.Quick2)
                    {
                        Player.jumpSpeedBoost += 0.2f;
                    }
                    if (Player.armor[i].prefix == PrefixID.Wild)
                    {
                        Player.meleeSpeed += 0.01f;
                    }
                    if (Player.armor[i].prefix == PrefixID.Rash)
                    {
                        Player.meleeSpeed += 0.02f;
                    }
                    if (Player.armor[i].prefix == PrefixID.Intrepid)
                    {
                        Player.meleeSpeed += 0.03f;
                    }
                    if (Player.armor[i].prefix == PrefixID.Violent)
                    {
                        Player.meleeSpeed += 0.04f;
                    }
                    if (Player.armor[i].prefix == PrefixID.Arcane)
                    {
                        //Player.manaCost -= 0.04f;
                    }
                }
            }
        }
    }
}
