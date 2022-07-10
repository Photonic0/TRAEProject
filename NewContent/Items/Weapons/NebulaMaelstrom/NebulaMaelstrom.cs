using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TRAEProject.Common;
using TRAEProject.NewContent.Items.Materials;
using System;
using static Terraria.ModLoader.ModContent;
using Terraria.Audio;

namespace TRAEProject.NewContent.Items.Weapons.NebulaMaelstrom
{
    class NebulaMaelstrom : ModItem
    {
        public override void SetStaticDefaults()
        {
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

            DisplayName.SetDefault("Nebula Maelstrom");
            Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 32;
            Item.damage = 50;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.mana = 30;
            Item.rare = ItemRarityID.Lime;
            Item.value = Item.sellPrice(gold: 5);
            Item.DamageType = DamageClass.Magic;
            Item.knockBack = 2f;
            Item.shootSpeed = 8f;
            Item.noMelee = true;
            Item.shoot = ProjectileType<MaelstromBall>();
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item20;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-2f, 0f);
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {

            for (int i = 0; i < 1000; i++)
            {
                if (Main.projectile[i].type == ProjectileType<MaelstromBall>() && Main.projectile[i].active && Main.projectile[i].owner == player.whoAmI)
                {
                    Main.projectile[i].Kill();
                }
            }
            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ItemID.FragmentNebula, 12)
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }
    public class MaelstromBall : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nebula Ball");
            Main.projFrames[Projectile.type] = 5;

        }
        public override void SetDefaults()
        {
            Projectile.width = 34;
            Projectile.height = 34;
            Projectile.friendly = true;
            Projectile.ignoreWater = false;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.usesIDStaticNPCImmunity = true;
            Projectile.idStaticNPCHitCooldown = 10;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 900;
            Projectile.tileCollide = false;
        }
        public float angletimer = 0;
        public int manaDrain = 0;
        public int BeforeItStartsAttacking = 60;
        public int attacktimer = 2;

        public override void AI()
        {
            int Range = 1000;
            for (int k = 0; k < 200; k++)
            {
                NPC nPC = Main.npc[k];
                if (nPC.active && !nPC.friendly && nPC.damage > 0 && !nPC.dontTakeDamage && Vector2.Distance(Projectile.Center, nPC.Center) <= Range)
                {
                    Vector2 projPosition = new Vector2(Projectile.position.X + Projectile.width * 0.5f, Projectile.position.Y + Projectile.height * 0.5f);
                    float npcX = nPC.position.X + nPC.width / 2 - projPosition.X;
                    float npcY = nPC.position.Y + nPC.height / 2 - projPosition.Y;
                    float distance = (float)Math.Sqrt(npcX * npcX + npcY * npcY);
                    float num176 = 5f;
                    num176 *= 1 + (0.05f * (distance / 50f));
                   

                    distance = num176 / distance;
                    Projectile.velocity.X = npcX * distance;
                    Projectile.velocity.Y = npcY * distance;
                }
            }
            Projectile.frameCounter++;
            if (Projectile.frameCounter >= 12)
            {
                Projectile.frameCounter = 0;
                Projectile.frame = (Projectile.frame + 1) % 5;
            }

            Projectile.ai[0]++;
            angletimer += 0.15f;
            if (angletimer > 360)
            {
                angletimer = 0;
            }


            if (Projectile.ai[0] >= 62)
            {
                Projectile.ai[0] -= 2;
                Vector2 direction = Vector2.One.RotatedBy(angletimer) * 3f;
                for (int i = 0; i < 2; i++)
                {
                    float velocity = i < 1 ? 3f : -3f;
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, direction * velocity, ProjectileType<MaelstromSubshot>(), Projectile.damage, 1f, Projectile.owner);
                }
            }
        }
    }
    public class MaelstromSubshot : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nebula Ball");

        }
        public override void SetDefaults()
        {
            Projectile.width = 5;
            Projectile.height = 5;
            Projectile.friendly = true;
            Projectile.ignoreWater = false;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.usesIDStaticNPCImmunity = true;
            Projectile.idStaticNPCHitCooldown = 10;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 60;
            Projectile.tileCollide = false;
        }

        public override void AI()
        {
            Projectile.localAI[1] += 1f;
            if (Projectile.localAI[1] > 30)
            {
                int Range = 1000;
                for (int k = 0; k < 200; k++)
                {
                    NPC nPC = Main.npc[k];
                    if (nPC.active && !nPC.friendly && nPC.damage > 0 && !nPC.dontTakeDamage && Vector2.Distance(Projectile.Center, nPC.Center) <= Range)
                    {
                        Vector2 projPosition = new Vector2(Projectile.position.X + Projectile.width * 0.5f, Projectile.position.Y + Projectile.height * 0.5f);
                        float npcX = nPC.position.X + nPC.width / 2 - projPosition.X;
                        float npcY = nPC.position.Y + nPC.height / 2 - projPosition.Y;
                        float distance = (float)Math.Sqrt(npcX * npcX + npcY * npcY);
                        float num176 = 5f;
                        if (Main.expertMode)
                        {
                            if (distance > 150f)
                            {
                                num176 *= 1 + (0.05f * (distance / 50f));
                            }
                        }
                        distance = num176 / distance;
                        Projectile.velocity.X = npcX * distance;
                        Projectile.velocity.Y = npcY * distance;
                    }
                }
            }
        }
    }
}

