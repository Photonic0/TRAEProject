using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;

namespace TRAEProject.Changes.Accesory
{
    public class Wings : GlobalItem
    {
        public override void HorizontalWingSpeeds(Item item, Player player, ref float speed, ref float acceleration)
        {
            if ( item.type == ItemID.BetsyWings && player.TryingToHoverDown)
            {
                speed *= 0.75f;
                acceleration *= 0.75f;
            }
            if (item.type == ItemID.WingsVortex && player.TryingToHoverDown)
            {
                speed *= 0.9f;
            }
            if (item.type == ItemID.RainbowWings)
            {
                speed *= 0.9f;
            }
            if (item.type == ItemID.WingsStardust)
            {
                speed *= 1.2f;
            }
            if (item.type == ItemID.TatteredFairyWings || item.type == ItemID.FestiveWings)
            {
                speed *= 1.25f;
            }
        }
        public override void VerticalWingSpeeds(Item item, Player player, ref float ascentWhenFalling, ref float ascentWhenRising, ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            if (item.type == ItemID.MothronWings)
            {
                maxAscentMultiplier *= 1.2f;
            }
            if (item.type == ItemID.SpookyWings || item.type == ItemID.FestiveWings)
            {
                maxAscentMultiplier *= 1.25f;
            }
            if (item.type == ItemID.BetsyWings || item.type == ItemID.WingsNebula)
            {
                maxAscentMultiplier *= 0.75f;
            }
            if (item.type == ItemID.RainbowWings)
            {
                maxAscentMultiplier *= 0.9f;
            }
            if (item.type == ItemID.WingsStardust)
            {
                maxAscentMultiplier *= 0.8f;
            }
        }

    }
}






