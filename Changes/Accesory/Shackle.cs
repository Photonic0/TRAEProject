using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TRAEProject.NewContent.Buffs;
using static Terraria.ModLoader.ModContent;

namespace TRAEProject.Changes.Accesory
{
    public class Shackle : GlobalItem
    {
        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            if(item.type == ItemID.Shackle)
            {
                player.GetModPlayer<ShackleEffects>().cuffs += 1;
            }
        }
    }

    class ShackleEffects : ModPlayer
    {
        public int cuffs = 0;
        public override void ResetEffects()
        {
            cuffs = 0;
        }
        public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
            if (cuffs > 0)
            {
                Player.AddBuff(BuffType<ShackledDefenses>(), cuffs * ((int)damage * 6 + 300));
            }
        }
    }
}
