using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace TRAEProject.NewContent.Buffs
{
    class ShackledDefenses : ModBuff
    {
		public override void SetStaticDefaults()
		{
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
			DisplayName.SetDefault("Shackled Defenses");
			Description.SetDefault("Defense increased by 10");
		}
        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense += 10;
        }
    }
}
