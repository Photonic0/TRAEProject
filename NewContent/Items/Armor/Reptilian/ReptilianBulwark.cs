using Microsoft.Xna.Framework;
using Terraria;
using System;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent.Creative;
using TRAEProject.NewContent.Items.Materials;

namespace TRAEProject.NewContent.Items.Armor.Reptilian
{
	[AutoloadEquip(EquipType.Body)]
    public class ReptilianBulwark : ModItem
	{
        // Total stats:
        // 42 defense
        // +33% melee and summon damage
        // +2 minions
        // +30% melee speed (sort of)
        // +15% whip range
        // +7% melee crit chance
        // +11% movement speed
        public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Reptilian Bulwark");
			// Tooltip.SetDefault("11% increased melee and summon damage\nIncreased your maximum number of minions by 1");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults()
		{
			Item.value = Item.sellPrice(0, 5, 0, 0);
			Item.rare = ItemRarityID.Yellow;
			Item.width = 30;
			Item.height = 22;
			Item.defense = 14;
		}
		public override void AddRecipes()
		{
			CreateRecipe(1)
				.AddIngredient(ItemType<SalamanderTail>(), 2)
				.AddIngredient(ItemType<ObsidianScale>(), 4)
                .AddTile(TileID.MythrilAnvil)
                .Register();
		}

		public override void UpdateEquip(Player player)
		{
            player.GetDamage<SummonDamageClass>() += 0.11f;
            player.GetDamage<MeleeDamageClass>() += 0.11f;
            player.maxMinions++;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return head.type == ItemType<ReptilianMask>() && legs.type == ItemType<ReptilianGreaves>();
		}

		public override void UpdateArmorSet(Player player)
        {
            player.maxMinions += 2;
            player.setBonus = "Increased your maximum number of minions by 2\nIncreases melee speed by 30% after striking an enemy with a whip";
            player.GetModPlayer<ReptilianSet>().ReptilianSetBonus = true;
		}
    }
    public class ReptilianSet : ModPlayer
    {
        public bool ReptilianSetBonus;
        public override void ResetEffects()
        {
            ReptilianSetBonus = false;
        }
        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if (ReptilianSetBonus && ProjectileID.Sets.IsAWhip[proj.type])
            {
                Player.AddBuff(BuffType<ReptilianMight>(), 8 * 60);
            }
        }
    }
    public class ReptilianMight : ModBuff
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Reptilian Might");
            // Description.SetDefault("30% increased melee speed");
            Main.buffNoSave[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetAttackSpeed(DamageClass.Melee) += 0.3f;

        }
    }
}




