using TRAEProject.NPCs;
using Terraria;
using Terraria.ModLoader;
using TRAEProject.Changes.Items;
using static Terraria.ModLoader.ModContent;
namespace TRAEProject.Buffs
{
	public class DamageReferred : ModBuff
	{
		public override string Texture => "TRAEProject/Buffs/DamageReferred";
		public override void SetStaticDefaults() {
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
			DisplayName.SetDefault("Damage Referred");
			Description.SetDefault("The gel absorbed the damage... temporarily");
		}

		public override void Update(Player player, ref int buffIndex) 
		{
			player.GetModPlayer<OnHitItems>().RoyalGelDOT = true;
		}
	}
}