using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TRAEProject.Items.DreadItems.RedPearl;

namespace TRAEProject.Common.GlobalNPCs
{
    public class SpawnRate : GlobalNPC
    {
        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
        {
            if(NPC.AnyNPCs(NPCID.BloodNautilus))
            {
                spawnRate = 0;
                maxSpawns = 0;
            }
            else if(player.GetModPlayer<PearlEffects>().spawnUp)
            {
                spawnRate = (int)((double)spawnRate * 0.5);
                maxSpawns = (int)((float)maxSpawns * 2f);
            }
        }
    }
}
