using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using TRAEProject.NewContent.Items.Materials;
using static Terraria.ModLoader.ModContent;
using TRAEProject.Common;

namespace TRAEProject.NewContent.Items.Weapons.Summoner.Sentries.GraniteShockerStaff
{
    public class GraniteShockerStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

            DisplayName.SetDefault("Granite Shocker Staff");
            Tooltip.SetDefault("Summons a Shocker Sentry that shoots chain lightning");
        }
        public override void SetDefaults()
        {
            Item.width = 36;
            Item.height = 36;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(0, 6, 50, 0);
            Item.rare = ItemRarityID.LightPurple;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 12;
            Item.useAnimation = 12;
            Item.useTurn = false;
            Item.autoReuse = true;

            Item.mana = 25;
            Item.UseSound = SoundID.Item78;

            Item.damage = 50;
            Item.DamageType = DamageClass.Summon;
            Item.knockBack = 1f;

            Item.sentry = true;
            Item.shoot = ProjectileType<GraniteShockerSentry>();

            //item.shootSpeed = 3.5f;



            Item.noMelee = true;
        }
        /* public override Vector2? HoldoutOffset()
         {
             return new Vector2(5, 0);
         }*/
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            player.SpawnMinionOnCursor(source, player.whoAmI, type, Item.damage, knockback);
            return false;
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool? UseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                player.MinionNPCTargetAim(false);
            }
            return base.UseItem(player);
        }
        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ItemType<GraniteBattery>(), 2)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }

    //______________________________________________________________________________________________________
    public class GraniteShockerSentry : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("GraniteShocker");
            Main.projFrames[Projectile.type] = 2;
            ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;

        }
        public override void SetDefaults()
        {

            Projectile.width = 24;
            Projectile.height = 54;
            Projectile.friendly = true;
            Projectile.ignoreWater = false;
            Projectile.sentry = true;
            Projectile.penetrate = 1;
            Projectile.timeLeft = Projectile.SentryLifeTime;
            Projectile.tileCollide = true;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
            Projectile.aiStyle = 2;
        }
        public override bool? CanDamage()
        {

            return false;
        }
        int shoottime = 0;
        NPC target;
        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough, ref Vector2 hitboxCenterFrac)
        {

            fallThrough = false;

            return true;
        }

        public override void AI()
        {
            //Projectile.velocity.Y = 10;
            Projectile.velocity.Y = 5;

            Projectile.rotation = 0;
            Player player = Main.player[Projectile.owner];

            player.UpdateMaxTurrets();

            shoottime++;
            Projectile.frame = shoottime > 50 ? 0 : 1;
            //Getting the npc to fire at
            if (Main.rand.Next(4) == 0)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Electric, 0, Projectile.velocity.Y * 0.33f, 0, default, 0.7f);

            }
            Lighting.AddLight(Projectile.Center, ((255 - Projectile.alpha) * 0.1f) / 255f, ((30 - Projectile.alpha) * 0.1f) / 255f, ((30 - Projectile.alpha) * 0.1f) / 255f);   //this is the light colors

            shoottime++;
            //Getting the npc to fire at
            for (int i = 0; i < 200; i++)
            {
    
                
                if (player.HasMinionAttackTargetNPC)
                {
                    target = Main.npc[player.MinionAttackTargetNPC];
                }
                else
                {
                    target = Main.npc[i];

                }
                //Getting the shooting trajectory
                float shootToX = target.position.X + (float)target.width * 0.5f - Projectile.Center.X;
                float shootToY = target.position.Y + (float)target.height * 0.5f - Projectile.Center.Y;
                float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));
                //bool lineOfSight = Collision.CanHitLine(Projectile.Center, 1, 1, target.Center, 1, 1);
                //If the distance between the projectile and the live target is active

                if (distance < 750f && !target.friendly && target.active && !target.dontTakeDamage && target.lifeMax > 5 && target.type != NPCID.TargetDummy)
                {

                    if (Collision.CanHit(Projectile.Center, 0, 0, target.Center, 0, 0))
                    {
                        target.TargetClosest(true);


                        if (shoottime > 75)
                        {

                            //Dividing the factor of 2f which is the desired velocity by distance
                            distance = 2f / distance;

                            //Multiplying the shoot trajectory with distance times a multiplier if you so choose to
                            shootToX *= distance * 5f;
                            shootToY *= distance * 5f;

                            for (int j = 0; j < 30; j++)
                            {
                                int dust = Dust.NewDust(new Vector2(Projectile.Center.X - 10, Projectile.Top.Y), 20, 20, DustID.Electric, 0, -2, 130, default, 1f);

                                //Main.dust[dust].noGravity = true; //this make so the dust has no gravity
                                Main.dust[dust].velocity *= 2f;
                            }

                            Vector2 perturbedSpeed = new Vector2(shootToX, shootToY).RotatedByRandom(MathHelper.ToRadians(0));

                            Projectile.NewProjectile(Projectile.GetSource_FromThis(), new Vector2(Projectile.Center.X, Projectile.Top.Y + 14), new Vector2(perturbedSpeed.X, perturbedSpeed.Y), ModContent.ProjectileType<GraniteShock>(), Projectile.damage, Projectile.knockBack, Projectile.owner);

                            SoundEngine.PlaySound(SoundID.Item, Projectile.Center);
                            shoottime = 0;
                        }
                    }

                }
            }




        }




        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return false;
        }

        public override void Kill(int timeLeft)
        {
            for (int n = 0; n < 20; n++)
            {
                int Dust = Terraria.Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Electric, 0f, 0f, 200, default, 1f);
                Main.dust[Dust].noGravity = true;
                Dust dust = Main.dust[Dust];
                dust.velocity *= 2f;
                Dust = Terraria.Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Electric, 0f, 0f, 200, default, 0.5f);
                dust = Main.dust[Dust];
                dust.velocity *= 1.2f;
                Main.dust[Dust].noGravity = true;
            }
        }
    }


    public class GraniteShock : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Granite Shock");
        }
        public override void SetDefaults()
        {
            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.extraUpdates = 100; Projectile.usesLocalNPCImmunity = true;
            ProjectileID.Sets.SentryShot[Projectile.type] = true;
            Projectile.GetGlobalProjectile<ProjectileStats>().dontHitTheSameEnemyMultipleTimes = true;
            Projectile.GetGlobalProjectile<ProjectileStats>().SmartBouncesOffEnemies = true;
            Projectile.timeLeft = 180;
            Projectile.penetrate = 5;
            Projectile.alpha = 255;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {            SoundEngine.PlaySound(SoundID.Item93, Projectile.position);

            for (int n = 0; n < 10; n++)
            {
                int Dust = Terraria.Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Electric, 0f, 0f, 200, default, 1f);
                Main.dust[Dust].noGravity = true;
                Dust dust = Main.dust[Dust];
                dust.velocity *= 2f;
                Dust = Terraria.Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Electric, 0f, 0f, 200, default, 0.9f);
                dust = Main.dust[Dust];
                dust.velocity *= 1.2f;
                Main.dust[Dust].noGravity = true;
            }
            base.OnHitNPC(target, damage, knockback, crit);
        }
        public override bool PreAI()
        {
            Projectile.localAI[0] += 1f;
            if (Projectile.localAI[0] > 3f)
            {
                Projectile.tileCollide = true;
                    Vector2 ProjectilePosition = Projectile.position;
                    ProjectilePosition -= Projectile.velocity;
                    Projectile.alpha = 255;
                    int dust = Dust.NewDust(ProjectilePosition, 1, 1, DustID.Electric, 0f, 0f, 0, default(Color), 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].noLight = true;
                    Main.dust[dust].position = ProjectilePosition;
                    Main.dust[dust].velocity *= 0.2f;
                
            }
            return true;
        }
    }
}