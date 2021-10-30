using Microsoft.Xna.Framework;
using System;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using TRAEProject.Buffs;
using TRAEProject.Projectiles;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using TRAEProject.Changes;

namespace TRAEProject
{
    public class TRAEPlayer : ModPlayer
    {
        public int shadowArmorDodgeChance = 0;
        private Item previousItem = new Item();
        public float newManaRegen = 0;
        public float manaRegenBoost = 1;
        public bool PirateSet = false;
        public bool manaCloak = false;
        public bool newManaFlower = false;
		public int manaFlowerTimer = 0;
		public int manaFlowerLimit = 0;
        public bool wErewolf = false;
        public bool Celled = false;
        public bool MagicDagger = false;
        public bool icceleration = false;
        public bool waterRunning = false;
        public bool Hivepack = false;
        int beetimer = 0;
        int beesStored = 0;
        int timebeforeReleasingBees = 0;
        int ifHoneyedWithBeepack = 1;
        public int minionCritChance = 0;
        public int titatimer = 0;
        public bool FastFall = false;
        public bool AquaAffinity = false;
        public bool LavaShield = false;
        public int magicdaggercount = 0;
        public int chanceNotToConsumeAmmo = 0;
        public override void ResetEffects()
        {
            PirateSet = false;
            manaCloak = false;
            newManaFlower = false;
            manaRegenBoost = 1;
        shadowArmorDodgeChance = 0;
            wErewolf = false;
            Celled = false;
            MagicDagger = false;
            icceleration = false;
            waterRunning = false;
            titatimer = 0;
            Hivepack = false;
            ifHoneyedWithBeepack = 1;
            FastFall = false;
            AquaAffinity = false;
            LavaShield = false;
            chanceNotToConsumeAmmo = 0;
		    minionCritChance = 0;
        }
        public override void UpdateDead()
        {
            PirateSet = false;
            manaCloak = false;
            newManaFlower = false;
            manaRegenBoost = 1;
            shadowArmorDodgeChance = 0;
            wErewolf = false;
            Celled = false;
            icceleration = false;
            waterRunning = false;
            titatimer = 0;
            Hivepack = false;
            beetimer = 0;
            beesStored = 0;
            timebeforeReleasingBees = 0;
            ifHoneyedWithBeepack = 1;
            FastFall = false;
            AquaAffinity = false;
            magicdaggercount = 0;
            chanceNotToConsumeAmmo = 0;
			minionCritChance = 0;
        }
        public override void PostUpdate()
        {
            Player.manaRegenCount = 0;
            Player.manaRegen = 0;
            Player.manaRegenDelay = 999;
			Player.manaSickTimeMax = 9999;
            int reachThisNumberAndThenIncreaseManaBy1 = 60;
            if (Player.statMana < Player.statManaMax2)
            {
                newManaRegen += Player.statManaMax2 * 0.1f * manaRegenBoost;
                if (newManaRegen >= reachThisNumberAndThenIncreaseManaBy1)
                {
                    newManaRegen -= 60;
                    ++Player.statMana;
                }
            }
			if (newManaFlower)
			{	
		       ++manaFlowerTimer;
			   if (manaFlowerTimer >= 60)
			   {
				   manaFlowerTimer = 0;
				   manaFlowerLimit = 0;
			   }
			}
			Player.lifeSteal -= 0.41666667f; // this stat increases by 0.5f every frame, or by 30 per second. with this change it goes down to 5 per second.
            if (Player.wingsLogic > 0 && Player.rocketBoots != 0 && Player.velocity.Y != 0f && Player.rocketTime != 0)
            {
                int num45 = 6;
                int num46 = Player.rocketTime * num45;
                Player.wingTime += num46;
                if (Player.wingTime > (Player.wingTimeMax + num46))
                {
                    Player.wingTime = Player.wingTimeMax + num46;
                }
                Player.rocketTime = 0;
            } // this is for Obsidian Rocket Boots to increase Flight time 

            if (LavaShield && Player.lavaWet)
            {
                Player.AddBuff(BuffType<LavaShield>(), 900);
            }
            if (LavaShield && waterRunning && Player.wet)
            {
                Player.AddBuff(BuffType<LavaShield>(), 9000);
            }            
            if (Player.shroomiteStealth && !Player.mount.Active) // Always active while on the ground, Stealth disappears slower, reduced all bonuses by 25%, max damage is reduced by a further 10%.  
            {
                if (Player.stealth <= 0.25f)
                {
                    Player.stealth = 0.25f;
                    if (Main.netMode == NetmodeID.MultiplayerClient)
                    {
                        NetMessage.SendData(MessageID.PlayerStealth, -1, -1, null, Player.whoAmI);
                    }
                }
                if (Player.itemAnimation > 0)
                {
                    Player.stealthTimer = 0;
                }
                if (Player.velocity.Y == 0 && Player.stealth > 0.25f)
                {
                    Player.stealth -= 0.015f;
                }
                if (Player.velocity.X > -0.1 && Player.velocity.X < 0.1 && Player.velocity.Y > -0.1 && Player.velocity.Y < 0.1 && Player.mount.Active)
                {
                    if (Player.stealthTimer == 0 && Player.stealth > 0f)
                    {
                        Player.stealth += 0.015f;
                    }
                }
                else
                {
                    float VelocityY = Math.Abs(Player.velocity.Y);
                    Player.stealth += VelocityY * 0.0035f;
                    float Velocity = Math.Abs(Player.velocity.X) + Math.Abs(Player.velocity.Y);
                    Player.stealth -= Velocity * 0.0075f;
                    if (Player.stealth > 1f)
                    {
                        Player.stealth = 1f;
                    }
                    if (Player.mount.Active)
                    {
                        Player.stealth = 1f;
                    }
                }
                Player.GetDamage<RangedDamageClass>() -= (1f - Player.stealth) * 0.1f;// at maximum stealth (0.25, not 0 like in vanilla), damage is increased by 45%. With this code, it's reduced by 10%, making it +35%
                //Player.aggro -= (int)((1f - Player.stealth) * 750f);
                if (Player.stealthTimer > 0)
                {
                    Player.stealthTimer--;
                }
            }
            if (Player.shieldRaised)
            {
                Player.moveSpeed *= 1.5f;
                Player.maxRunSpeed *= 2f;
            }
        }
        public override void OnRespawn(Player Player)
        {
            Player.statLife = Player.statLifeMax;
            return;
        }
        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (Player.hasRaisableShield && Player.HeldItem.type == ItemID.DD2SquireDemonSword && Main.rand.Next(5) == 0)
            {
                Block();
                return false;
            }
            if (Main.rand.Next(shadowArmorDodgeChance) == 1)
            {
                DarkDodge();
                return false;
            }
            return true;
        }
        public override void PostUpdateEquips()
        {
            if (wErewolf && Player.statLife < Player.statLifeMax2 * 0.67)
            {
                Player.buffImmune[BuffID.Werewolf] = false;
                Player.AddBuff(BuffID.Werewolf, 1, false);
                Player.wereWolf = true;
                Player.GetDamage<GenericDamageClass>() += 0.11f;
                Player.GetCritChance<GenericDamageClass>() += 9;
                Player.meleeSpeed += 0.07f;
            }
            if (icceleration)
            {
                Player.runAcceleration *= 2f;
            }
            if (waterRunning)
            {
                int num = 2;
                int num2 = 2;
                int num3 = (int)((Player.position.X + (Player.width / 2)) / 16f);
                int num4 = (int)((Player.position.Y + Player.height) / 16f);
                for (int j = num3 - num; j <= num3 + num; j++)
                {
                    for (int k = num4 - num2; k < num4 + num2; k++)
                    {
                        if (Main.tile[j, k].LiquidAmount > 200 && Main.tile[j, k].LiquidType == 0 ||
                            Main.tile[j, k].LiquidAmount > 200 && Main.tile[j, k].LiquidType == 2 ||
                            Main.tile[j, k].LiquidAmount > 200 && Main.tile[j, k].LiquidType == 1
                            )
                        {
                            Player.AddBuff(BuffType<WaterAffinity>(), 600);
                        }
                    }
                }
            }
            if (FastFall && Player.controlDown && Player.gravDir != -1)
            {
                Player.maxFallSpeed *= 2f;
                if (Player.velocity.Y < 0)
                    Player.velocity.Y += 0.7f;
                Player.velocity.Y += 0.2f;
            }
            if (Hivepack)
            {
                if (Player.HasBuff(BuffID.Honey))
                {
                    ifHoneyedWithBeepack = 2;
                }
                if (Player.velocity.Y > -0.1 && Player.velocity.Y < 0.1)
                {
                    timebeforeReleasingBees = 0;
                    ++beetimer;
                }
                if (beetimer == 8 * ifHoneyedWithBeepack && beesStored < 16)
                {
                    ++beesStored;
                    beetimer = 0;
                    Dust.NewDustDirect(Player.oldPosition, Player.width, Player.height, 153, 1, 1, 0, default, 0.8f);
                    Terraria.Audio.SoundEngine.PlaySound(SoundID.Item10, (int)Player.position.X, (int)Player.position.Y);
                }
                if (Player.velocity.Y < -0.1 || Player.velocity.Y > 0.1)
                {
                    ++timebeforeReleasingBees;
                    beetimer = 0;
                    if (timebeforeReleasingBees > 10 * ifHoneyedWithBeepack && beesStored > 0)
                    {
                        timebeforeReleasingBees = 0;
                        --beesStored;
						int BeeID = ProjectileID.Bee;
                        if (ifHoneyedWithBeepack == 2)
                        {
							BeeID = ProjectileID.GiantBee;
                        }
                        int bee = Projectile.NewProjectile(Player.GetProjectileSource_Misc(Player.whoAmI), Player.position.X, Player.position.Y, 1 * Player.direction, 0, BeeID, 10 * ifHoneyedWithBeepack, 2, Player.whoAmI);

                    }
                }

                Player.jumpSpeedBoost += 0.225f * beesStored;
            }
        }
        public override void UpdateBadLifeRegen()
        {
            if (Player.HasBuff(BuffID.Bleeding) && Main.expertMode)
            {
                if (Player.lifeRegen > 0)
                {
                    Player.lifeRegen = 0;
                }
                Player.lifeRegen -= 4;
            }
            if (Celled)
            {
                if (Player.lifeRegen > 0)
                {
                    Player.lifeRegen = 0;
                }
                Player.lifeRegen -= 20;
            }
        }
        public override void UpdateLifeRegen()
        {
            if (Player.HasBuff(BuffID.Regeneration))
            {
                if (Player.lifeRegen > 0)
                {
                    Player.lifeRegen -= 2;
                }
            }
            if (Player.HasBuff(BuffType<NanoHealing>()))
            {
                if (Player.lifeRegen < 0)
                {
                    Player.lifeRegen += 8; // used only to negate up to 4 damage over time
                    if (Player.lifeRegen > 0)
                    {
                        Player.lifeRegen = 0;
                    }
                }
                Player.lifeRegenTime += 3; // makes it tick up four times faster
                Player.lifeRegenCount += 2; // adds 1 hp/s
            }
        }
        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (Celled && hitDirection == 0 && damageSource.SourceOtherIndex == 8)
            {
                damageSource = PlayerDeathReason.ByCustomReason(Player.name + " was consumed by cells");
                return true;
            }
            if (Player.HasBuff(BuffID.Bleeding) && hitDirection == 0 && damageSource.SourceOtherIndex == 8)
            {
                damageSource = PlayerDeathReason.ByCustomReason(Player.name + " bled to death");
                return true;
            }
            return true;
        }
        public override bool CanConsumeAmmo(Item weapon, Item ammo)
        { 
            Player Player = Main.player[weapon.playerIndexTheItemIsReservedFor];
            if (Main.rand.Next(100) < chanceNotToConsumeAmmo)
                return false;
            if ((weapon.type == ItemID.VenusMagnum) && Main.rand.Next(3) == 0)
                return false;
            if (weapon.type == ItemID.ChainGun && Main.rand.Next(10) == 0)
                return false;
            if (weapon.CountsAsClass<RangedDamageClass>() && Player.ammoPotion)
            {
                if (weapon.type != ItemID.StarCannon && weapon.type != ItemID.Clentaminator && weapon.type != ItemID.CoinGun)
                {
                    return false;
                }
            }
            return true;
        }
        private static readonly bool[] MechBonus = new bool[] { NPC.downedMechBoss1, NPC.downedMechBoss2, NPC.downedMechBoss3 };
        public override void ModifyHitByProjectile(Projectile proj, ref int damage, ref bool crit)
        {
            switch (proj.type)
            {
                case ProjectileID.CursedFlameHostile:
                case ProjectileID.EyeFire:
                case ProjectileID.EyeLaser:
                case ProjectileID.DeathLaser:
                case ProjectileID.BombSkeletronPrime:
                    {
                        for (int i = 0; i < MechBonus.Length; ++i) // repeats it three times for each mech
                        {
                            if (MechBonus[i]) // checks if that mech boss has been defeated
                            {
                                damage += (int)(damage * 0.1);
                            }
                        }
                        break;
                    }
            }
            
        }
        //public override void ModifyManaCost(Item item, ref float reduce, ref float mult)
        //{
        //    if (Player.manaSick && Player.manaFlower)
        //        mult *= 0.75f; // can't do this in ChangesBuffs because who knows why        
        //}

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if (PirateSet && (ProjectileID.Sets.IsAWhip[proj.type]))
            {
                target.AddBuff(BuffType<PirateTag>(), 240);
            }
            if (proj.CountsAsClass(DamageClass.Magic) && newManaFlower == true && crit && manaFlowerLimit < 3)
            {
                if (Main.rand.Next(3) == 0)
                {
                    Item.NewItem(target.getRect(), ItemID.Star, 1);
					++manaFlowerLimit;
                } 
            }
            if (proj.CountsAsClass(DamageClass.Magic) && manaCloak == true && crit && Main.rand.Next(3) == 0)
            {
                int[] spread = {3, 4, 5};
                TRAEMethods.SpawnProjectilesFromAbove(Player.GetProjectileSource_Misc(Player.whoAmI), target.position, 1, 400, 600, spread, 20, ProjectileID.ManaCloakStar, damage / 3, 2f, Player.whoAmI);
            }
            if (Player.inferno)
            {
                Lighting.AddLight((int)(target.Center.X / 16f), (int)(target.Center.Y / 16f), 0.65f, 0.4f, 0.1f);
                int OnFireID = 24;
                float range = 100f;
                int RingDamage = damage / 10 + 1;
                Vector2 spinningpoint1 = ((float)Main.rand.NextDouble() * 6.283185f).ToRotationVector2();
                Vector2 spinningpoint2 = spinningpoint1;
                float RandomNumberBetweenSixAndTen = Main.rand.Next(3, 5) * 2;
                int Twenty = 20;
                float OneOrMinusOne = Main.rand.Next(2) == 0 ? 1f : -1f; // one in three chance of it being 1
                bool flag = true;
                for (int i = 0; i < Twenty * RandomNumberBetweenSixAndTen; ++i) // makes 120 or 240 dusts total
                {
                    if (i % Twenty == 0)
                    {
                        spinningpoint2 = spinningpoint2.RotatedBy(OneOrMinusOne * (6.28318548202515 / RandomNumberBetweenSixAndTen), default);
                        spinningpoint1 = spinningpoint2;
                        flag = !flag;
                    }
                    else
                    {
                        float num4 = 6.283185f / (Twenty * RandomNumberBetweenSixAndTen);
                        spinningpoint1 = spinningpoint1.RotatedBy(num4 * OneOrMinusOne * 3.0, default);
                    }
                    float num5 = MathHelper.Lerp(7.5f, 60f, i % Twenty / Twenty);
                    int index2 = Dust.NewDust(new Vector2(target.Center.X, target.Center.Y), 6, 6, 127, 0.0f, 0.0f, 100, default, 3f);
                    Dust dust1 = Main.dust[index2];
                    dust1.velocity = Vector2.Multiply(dust1.velocity, 0.1f);
                    Dust dust2 = Main.dust[index2];
                    dust2.velocity = Vector2.Add(dust2.velocity, Vector2.Multiply(spinningpoint1, num5));
                    if (flag)
                        Main.dust[index2].scale = 0.9f;
                    Main.dust[index2].noGravity = true;
                }
                for (int k = 0; k < 200; k++)
                {
                    NPC nPC = Main.npc[k];
                    if (nPC.active && !nPC.friendly && nPC.damage > 0 && !nPC.dontTakeDamage && Vector2.Distance(target.Center, nPC.Center) <= range)
                    {
                        int finalDefense = nPC.defense - Player.armorPenetration;
                        nPC.ichor = false;
                        nPC.betsysCurse = false;
                        if (finalDefense < 0)
                        {
                            finalDefense = 0;
                        }
                        RingDamage += finalDefense / 2;
                        Player.ApplyDamageToNPC(nPC, RingDamage, 0f, 0, crit: false);
                        if (nPC.FindBuffIndex(OnFireID) == -1)
                        {
                            nPC.AddBuff(OnFireID, 120);
                        }
                    }
                }
            }
            return;
        }
      
        void DarkDodge()
        {
            Player.immune = true;
            Player.immuneTime = 80;
            if (Player.longInvince)
                Player.immuneTime = Player.immuneTime + 40;
            for (int index = 0; index < Player.hurtCooldowns.Length; ++index)
                Player.hurtCooldowns[index] = Player.immuneTime;
            for (int i = 0; i < 80; i++)
            {
                int num = Dust.NewDust(new Vector2(Player.position.X, Player.position.Y), Player.width, Player.height, Main.rand.Next(new int[]{65, 173}), 0f, 0f, 100, default, 2f);
                Main.dust[num].position.X += Main.rand.Next(-20, 21);
                Main.dust[num].position.Y += Main.rand.Next(-20, 21);
                Main.dust[num].velocity *= 0.4f;
                Main.dust[num].scale *= 1f + Main.rand.Next(40) * 0.01f;
                Main.dust[num].shader = GameShaders.Armor.GetSecondaryShader(Player.cWaist, Player);
                Main.dust[num].noGravity = true;
                Main.dust[num].noLight = true;
                if (Main.rand.Next(2) == 0)
                {
                    Main.dust[num].scale *= 1f + Main.rand.Next(40) * 0.01f;
                    Main.dust[num].velocity *= 1.4f;
                }
            }
            if (Player.whoAmI == Main.myPlayer)
            {
                NetMessage.SendData(62, -1, -1, null, Player.whoAmI, 1f);
            }
        }
        void Block()
        {
            Player.immune = true;
            Player.immuneTime = 80;
            if (Player.longInvince)
                Player.immuneTime = Player.immuneTime + 40;
            for (int index = 0; index < Player.hurtCooldowns.Length; ++index)
                Player.hurtCooldowns[index] = Player.immuneTime;
            Player.AddBuff(BuffID.ParryDamageBuff, 600, false);
            Terraria.Audio.SoundEngine.PlaySound(SoundID.Item37, Player.position);
            for (int i = 0; i < 20; i++)
            {
                Dust dust = Dust.NewDustDirect(Player.position, Player.width, Player.height, 57, 0f, 0f, 255, default, Main.rand.Next(20, 26) * 0.05f);
                dust.noLight = true;
                dust.noGravity = true;
            }
        }

        public void MagicDaggerSpawn(Player Player, int damage, float knockBack)
        {
            if (magicdaggercount < 75)
            { 
                int magic = Projectile.NewProjectile(Player.GetProjectileSource_Misc(Player.whoAmI), Player.Center.X, Player.Center.Y, 0, 0, ProjectileType<MagicDaggerNeo>(), damage / 2, knockBack / 2, Main.myPlayer);
                float size = 0.75f + damage * 0.002f;
                Main.projectile[magic].scale = size;
                if (Main.rand.Next(2) == 0)
                    Main.projectile[magic].localAI[1] = 180;
                Main.projectile[magic].direction = Player.direction;
                Main.projectile[magic].timeLeft = Main.rand.Next(600, 900);
                ++Player.GetModPlayer<TRAEPlayer>().magicdaggercount;
            }
        }
    }
 }
    




