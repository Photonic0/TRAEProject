using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using TRAEProject.Items.Summoner.Whip;
namespace TRAEProject.Items.Summoner.AbsoluteZero
{
    public class AbsoluteZero : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Absolute Zero");
            Tooltip.SetDefault("Your summons will focus struck enemies\n12 summon tag damage\n25% summon tag critical strike chance\nMinion critical hits will freeze enemies");
            ItemID.Sets.SummonerWeaponThatScalesWithAttackSpeed[Item.type] = true;
        }
        public override void SetDefaults()
        {
            Item.autoReuse = false;
            Item.useStyle = 1;     
            Item.width = 18;
            Item.height = 18;
            Item.shoot = ProjectileType<AbsoluteZeroP>();
            Item.UseSound = SoundID.Item152;
            Item.noMelee = true;
            Item.DamageType = DamageClass.Summon;
            Item.noUseGraphic = true;
            Item.damage = 180;
            Item.useTime = Item.useAnimation = 30;
            Item.knockBack = 3f;
            Item.shootSpeed = 4.75f;
            Item.rare = ItemRarityID.Yellow;
            Item.value = Item.sellPrice(0, 10, 0, 0);
        }
    }
 
    public class AbsoluteZeroP : WhipProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("AbsoluteZero");
        }
        public override void WhipDefaults()
        {
            originalColor = new Color(29, 41, 81);
            whipRangeMultiplier = 1.4f;
            fallOff = 0.33f;
            tag = BuffType<AbsoluteZeroTag>();
            whipSegments = 40;
            tipScale = 1.25f;
        }
    }
    public class AbsoluteZeroTag : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("AbsoluteZeroTag");
            Description.SetDefault("You will be frozen when hit by a critical hit. Except not, because you are a player and not an enemy, but whatever.");
            Main.debuff[Type] = true;
  
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<ChangesNPCs>().TagDamage += 12;
            npc.GetGlobalNPC<ChangesNPCs>().TagCritChance += 25;
        }
    }
}
