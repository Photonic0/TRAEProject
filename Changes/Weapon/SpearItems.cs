using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using TRAEProject.Changes.Projectiles.Spears;
using static Terraria.ModLoader.ModContent;

namespace TRAEProject.Changes.Weapon
{
    class SpearItems : GlobalItem
    {
        public override bool InstancePerEntity => true;
        public override GlobalItem Clone(Item item, Item itemClone)
        {
            return base.Clone(item, itemClone);
        }
        public int altShoot = -1;
        public bool canGetMeleeModifers = false;
        public override void SetDefaults(Item item)
        {
            switch (item.type)
            {
                case ItemID.Spear:
					item.useStyle = 1;
					canGetMeleeModifers = true;
					item.shoot = ProjectileType<BasicSpear>();
                    altShoot = ProjectileType<BasicSpearThrow>();

                    item.useTime = item.useAnimation = 27;
                    item.shootSpeed = 5; //only the throw uses this
                    break;

				case ItemID.TheRottedFork:
					item.useStyle = 1;
					canGetMeleeModifers = true;
					item.shoot = ProjectileType<RottedFork>();
					altShoot = ProjectileType<RottedForkThrow>();

					item.damage = 21;
					item.shootSpeed = 5.5f; //only the throw uses this
					break;

				case ItemID.BoneJavelin:
					item.useStyle = 1;
					canGetMeleeModifers = true;
					item.shoot = ProjectileType<BoneSpear>();
					altShoot = ProjectileType<BoneSpearThrow>();

					item.useTime = item.useAnimation = 20;
					item.damage = 16;
					item.DamageType = DamageClass.Melee;
					item.autoReuse = false;
					item.consumable = false;
					item.maxStack = 1;
					item.value = Item.sellPrice(silver: 30);
					break;
				case ItemID.ChlorophytePartisan:
					item.useStyle = 1;
					canGetMeleeModifers = true;
					item.shoot = ProjectileType<ChloroPartisan>();
					altShoot = ProjectileType<ChloroPartisanThrow>();

					item.shootSpeed = 12f; //only the throw uses this
					break;
				case ItemID.MythrilHalberd:
					item.useStyle = 1;
					canGetMeleeModifers = true;
					item.shoot = ProjectileType<MythrilHalberd>();
					altShoot = ProjectileType<MythrilHalberdThrow>();

                    item.damage = 49;
					item.channel = true; //Bwa ha ha ha
					break;
			}
        }
        public override bool AltFunctionUse(Item item, Player player)
        {
            if (altShoot != -1)
            {
                return true;
            }
            return base.AltFunctionUse(item, player);
        }
        public override void ModifyShootStats(Item item, Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (altShoot != -1)
            {
                if (player.altFunctionUse == 2)
                {
                    type = altShoot;
                    player.itemAnimation = player.itemAnimationMax = item.useTime / 3;
                }
            }
        }
        public override int ChoosePrefix(Item item, UnifiedRandom rand)
        {
            if(canGetMeleeModifers)
            {
				int num = 0;
				#region pick
				int num9 = rand.Next(40);
				if (num9 == 0)
				{
					num = 1;
				}
				if (num9 == 1)
				{
					num = 2;
				}
				if (num9 == 2)
				{
					num = 3;
				}
				if (num9 == 3)
				{
					num = 4;
				}
				if (num9 == 4)
				{
					num = 5;
				}
				if (num9 == 5)
				{
					num = 6;
				}
				if (num9 == 6)
				{
					num = 7;
				}
				if (num9 == 7)
				{
					num = 8;
				}
				if (num9 == 8)
				{
					num = 9;
				}
				if (num9 == 9)
				{
					num = 10;
				}
				if (num9 == 10)
				{
					num = 11;
				}
				if (num9 == 11)
				{
					num = 12;
				}
				if (num9 == 12)
				{
					num = 13;
				}
				if (num9 == 13)
				{
					num = 14;
				}
				if (num9 == 14)
				{
					num = 15;
				}
				if (num9 == 15)
				{
					num = 36;
				}
				if (num9 == 16)
				{
					num = 37;
				}
				if (num9 == 17)
				{
					num = 38;
				}
				if (num9 == 18)
				{
					num = 53;
				}
				if (num9 == 19)
				{
					num = 54;
				}
				if (num9 == 20)
				{
					num = 55;
				}
				if (num9 == 21)
				{
					num = 39;
				}
				if (num9 == 22)
				{
					num = 40;
				}
				if (num9 == 23)
				{
					num = 56;
				}
				if (num9 == 24)
				{
					num = 41;
				}
				if (num9 == 25)
				{
					num = 57;
				}
				if (num9 == 26)
				{
					num = 42;
				}
				if (num9 == 27)
				{
					num = 43;
				}
				if (num9 == 28)
				{
					num = 44;
				}
				if (num9 == 29)
				{
					num = 45;
				}
				if (num9 == 30)
				{
					num = 46;
				}
				if (num9 == 31)
				{
					num = 47;
				}
				if (num9 == 32)
				{
					num = 48;
				}
				if (num9 == 33)
				{
					num = 49;
				}
				if (num9 == 34)
				{
					num = 50;
				}
				if (num9 == 35)
				{
					num = 51;
				}
				if (num9 == 36)
				{
					num = 59;
				}
				if (num9 == 37)
				{
					num = 60;
				}
				if (num9 == 38)
				{
					num = 61;
				}
				if (num9 == 39)
				{
					num = 81;
				}
				#endregion
				return num;
            }
            return base.ChoosePrefix(item, rand);
        }
    }
}
