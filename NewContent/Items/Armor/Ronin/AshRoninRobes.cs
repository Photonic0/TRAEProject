using Microsoft.Xna.Framework;
using Terraria;
using System;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent.Creative;
using TRAEProject.NewContent.Items.Materials;
using log4net.Util;
using TRAEProject.Common;
using TRAEProject.NewContent.Items.Armor.Reptilian;

namespace TRAEProject.NewContent.Items.Armor.Ronin
{
	[AutoloadEquip(EquipType.Body)]
    public class AshRoninRobes : ModItem
	{
        // Total stats:
        // 30 defense
        // +33% magic and summon damage
        // +7% magic critical hit chance
        // +3 minions
        // +80 max mana
        // Restore mana on whip strikes
        // +11% movement speed
        public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Ash Ronin Robes");
			//Tooltip.SetDefault("11% increased magic and summon damage\nIncreased your maximum number of minions by 1");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults()
		{
			Item.value = Item.sellPrice(0, 5, 0, 0);
			Item.rare = ItemRarityID.Yellow;
			Item.width = 30;
			Item.height = 22;
			Item.defense = 10;
		}
		public override void AddRecipes()
		{
			CreateRecipe(1)
				.AddIngredient(ItemType<MagicalAsh>(), 4)
				.AddIngredient(ItemType<DriedRose>(), 1)
                .AddTile(TileID.MythrilAnvil)
                .Register();
		}

		public override void UpdateEquip(Player player)
		{
            player.GetDamage<SummonDamageClass>() += 0.11f;
            player.GetDamage<MagicDamageClass>() += 0.11f;
            player.maxMinions++; 

        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return head.type == ItemType<AshRoninHat>() && legs.type == ItemType<AshRoninPants>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Increases your max number of minions by 2\nFirst whip strike restores 4% of maximum mana";
            player.maxMinions += 2;
            player.GetModPlayer<AshRoninSet>().AshRoninSetBonus = true;
        }
    }
    public class AshRoninBool : GlobalProjectile
    {
        public override bool InstancePerEntity => true;

        public bool OnlyOnce = false;
    }
    public class AshRoninSet : ModPlayer
    {
        public bool AshRoninSetBonus;
        public override void ResetEffects()
        {
            AshRoninSetBonus = false;
        }
        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if (AshRoninSetBonus && ProjectileID.Sets.IsAWhip[proj.type] && !proj.GetGlobalProjectile<AshRoninBool>().OnlyOnce)
            {
                proj.GetGlobalProjectile<AshRoninBool>().OnlyOnce = true;
                if (Player.statMana < Player.statManaMax2)
                {
                    Player.statMana += (int)(Player.statManaMax2 * 0.04);
                    Player.ManaEffect((int)(Player.statManaMax2 * 0.04));
                }
                 
                if (Player.statMana > Player.statManaMax2)
                    Player.statMana = Player.statManaMax2;
            }
        }
    }
}




