using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.GameContent.ItemDropRules;
using static Terraria.ModLoader.ModContent;

namespace TRAEProject.Items.DreadItems.DreadSummon
{
    class DreadSummon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloodlaiden Bait");
            DisplayName.SetDefault("Will lure a powerful blood moon monster");

        }
        public override void SetDefaults()
		{
			Item.maxStack = 999;
			Item.consumable = true;
			Item.width = 12;
			Item.height = 12;
			Item.value = Item.sellPrice(0, 0, 10);
            Item.makeNPC = NPCID.BloodNautilus;
            Item.useStyle = 4;
        }


        public override bool CanUseItem(Player player)
        {
            if (!NPC.AnyNPCs(NPCID.BloodNautilus) && Main.bloodMoon)
            {
                NPC.SpawnOnPlayer(player.whoAmI, NPCID.BloodNautilus);
                SoundEngine.PlaySound(SoundID.Roar, player.position, 0);
                Item.stack--;
                return true;
            }
            return false;
        }
    }
    class BatiDrop : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if(npc.type == NPCID.BloodEelHead || npc.type == NPCID.GoblinShark)
            {
                npcLoot.Add(ItemDropRule.Common(ItemType<DreadSummon>(), 1, 1, 1));
            }
        }
    }
}
