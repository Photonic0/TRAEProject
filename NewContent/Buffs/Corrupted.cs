using TRAEProject.NPCs;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using TRAEProject.Common;
namespace TRAEProject.NewContent.Buffs
{
	public class Corrupted : ModBuff
	{

		public override void SetStaticDefaults() {
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
			DisplayName.SetDefault("Corrupted");
			Description.SetDefault("Hi there! I see that you cheated this debuff into your character. Either that or there is something seriously wrong with my code. Whichever it is... I hope you are having a great day.");
		}
		float ScourgeTime = 0f;
		float TinyEaterDelay = 90f;
		int TinyEaterCount = 2; 
		public override void Update(NPC npc, ref int buffIndex) {
			npc.GetGlobalNPC<TRAENPCDebuffEffects>().Corrupted = true;
			++ScourgeTime;
			if (ScourgeTime >= TinyEaterDelay)
			{
				ScourgeTime = 0;
				for (int i = 0; i < TinyEaterCount; ++i)
				{
					float velX = Main.rand.Next(-35, 36) * 0.1f;
					float velY = Main.rand.Next(-35, 36) * 0.1f;
					Projectile.NewProjectile(npc.GetProjectileSpawnSource(), npc.Center.X, npc.Center.Y, velX, velY, ProjectileID.TinyEater, 52, 0f, Main.myPlayer, 0f, 0f);				
				}
			}	
		}
	}
}