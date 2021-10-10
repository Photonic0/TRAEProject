
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent.Creative;
namespace TRAEProject.Items.FlamethrowerAmmo
{
    public class BloodyGel : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloody Gel");
            Tooltip.SetDefault("Destroys your enemy from the inside");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }
        public override void SetDefaults()
        {
            Item.damage = 33;
            Item.DamageType = DamageClass.Ranged;
            Item.knockBack = 2;
            Item.value = Item.sellPrice(0, 0, 0, 20);
            Item.rare = ItemRarityID.LightPurple;
            Item.width = 16;
            Item.height = 16;
            Item.shootSpeed = 4;
            Item.consumable = true;
            Item.shoot = ProjectileType<BloodyGelP>();
            Item.ammo = AmmoID.Gel;
            Item.maxStack = 3000;
        }

        public override void AddRecipes()
        {
            CreateRecipe(20).AddIngredient(ItemID.Gel)
                .AddIngredient(ItemID.Gel, 1)
                .AddTile(TileID.BloodMoonMonolith)
                .Register();
        }
    }

    public class BloodyGelP : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("BloodyGel");     //The English name of the Projectile

        }
        public override string Texture => "Terraria/Images/Item_0";
        public override void SetDefaults()
        {
            Projectile.aiStyle = 1;
            Projectile.timeLeft = 60;
            Projectile.penetrate = 3;
            Projectile.extraUpdates = 2;
            Projectile.ignoreWater = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.hostile = false;
            Projectile.friendly = true;
            Projectile.usesLocalNPCImmunity = true;
Projectile.GetGlobalProjectile<TRAEGlobalProjectile>().dontHitTheSameEnemyMultipleTimes = true;

            Projectile.GetGlobalProjectile<TRAEGlobalProjectile>().AddsBuff = BuffType<BloodBoiling>();
            Projectile.GetGlobalProjectile<TRAEGlobalProjectile>().AddsBuffDuration = 120;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.GetGlobalNPC<ChangesNPCs>().BoilingBloodDMG = damage;
        }
        public override void AI()
        {
                            Projectile.localAI[0] += 1;
            if (Projectile.localAI[0] % 10f == 0f)
            {
                Dust.NewDustDirect(Projectile.Center, 0, -1, DustID.Smoke, 0, -1);
            }
			for (int i = 0; i < 3; i++)
                {
                    Vector2 ProjectilePosition = Projectile.position;
                    ProjectilePosition -= Projectile.velocity * (i * 0.25f);
                    Projectile.alpha = 255;
                    int dust = Dust.NewDust(ProjectilePosition, 1, 1, DustID.BloodWater, 0f, 0f, 0, default(Color), 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].position = ProjectilePosition;
                    Main.dust[dust].scale = Main.rand.Next(70, 110) * 0.013f;
                    Main.dust[dust].velocity *= 0.2f;
                }
        }
		public override void Kill(int timeLeft)
		{		
            for (int i = 0; i < 3; ++i)
            {
                int dust = Dust.NewDust(new Vector2(Projectile.Center.X, Projectile.Center.Y), 6, 6, DustID.Smoke, 0.0f, 0.0f, 100, default, 3f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 0.8f;
                Main.dust[dust].velocity.Y -= 0.3f;
            }
        }
        }
    public class BloodBoiling : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("BloodBoiling");
            Description.SetDefault("Mah blood! It hurts! No wait, i'm a player so this does nothing to me. Oh well.");
            Main.debuff[Type] = true;

        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<ChangesNPCs>().BoilingBlood = true;
        }
    }
}


