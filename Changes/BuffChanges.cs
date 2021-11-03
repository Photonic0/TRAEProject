using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using TRAEProject;
using TRAEProject.Buffs;
using TRAEProject.Changes.Items;
namespace ChangesBuffs
{
    public class ChangesBuffs : GlobalBuff
    {
        public override void Update(int type, NPC npc, ref int buffIndex)
        {
            if (BuffID.Sets.IsAnNPCWhipDebuff[type] && npc.HasBuff(BuffType<PirateTag>()))
            {
                npc.GetGlobalNPC<ChangesNPCs>().TagDamage += 5;
                npc.GetGlobalNPC<ChangesNPCs>().TagCritChance += 5;
            }
            switch (type)
            {
                case BuffID.MaceWhipNPCDebuff:
                    npc.GetGlobalNPC<ChangesNPCs>().TagCritChance += 10;
                    return;
                case BuffID.RainbowWhipNPCDebuff:
                    npc.GetGlobalNPC<ChangesNPCs>().TagDamage += 30;
                    npc.GetGlobalNPC<ChangesNPCs>().TagCritChance += 20; // this isn't exactly 30% crit but whatevs
                    return;
                case BuffID.ScytheWhipEnemyDebuff:
                    npc.GetGlobalNPC<ChangesNPCs>().TagDamage += 10;
                    return;
            }
        }
        public override void Update(int type, Player player, ref int buffIndex)
        {
            switch (type)
            {
                case BuffID.ThornWhipPlayerBuff:
                    player.meleeSpeed -= 0.05f;
                    player.autoReuseGlove = true;
                    return;
                case BuffID.SwordWhipPlayerBuff:
                    player.meleeSpeed -= 0.1f;
                    player.autoReuseGlove = true; 
                    return;
                case BuffID.ScytheWhipPlayerBuff:
                    player.meleeSpeed -= 0.15f;
                    player.autoReuseGlove = true;
                    return;
                case BuffID.ObsidianSkin:
                    player.buffImmune[BuffID.OnFire] = false;
					player.fireWalk = false;
                    return;
                case BuffID.StarInBottle:
                    player.statManaMax2 += 20;
                    return;
                case BuffID.Titan:
                    player.meleeScaleGlove = true;
                    return;
                case BuffID.Thorns:
                    player.thorns -= 1f;
                    player.GetModPlayer<OnHitItems>().newthorns += 0.33f;
                    return;
                case BuffID.Archery:
                    player.arrowDamage -= 0.08f; //  because Archery Potion uses a unique multiplier -8% makes it effectively +10% arrow damage 
                    return;
                case BuffID.Rabies:
                    player.AddBuff(BuffType<NeoFeralBite>(), player.buffTime[buffIndex], false);
                    player.DelBuff(buffIndex);
                    return;

                case BuffID.ManaRegeneration:
                    player.GetModPlayer<TRAEPlayer>().manaRegenBoost += 0.2f;
                    return;
                case BuffID.ManaSickness:               
                    player.manaSickReduction = 0f;
                    return;
                case BuffID.WellFed:
                    player.moveSpeed -= 0.15f;
                    return;
                case BuffID.WellFed2:
                    player.moveSpeed -= 0.225f;
                    return;
                case BuffID.WellFed3:
                    player.moveSpeed -= 0.3f;
                    return;
                case BuffID.Swiftness:
                    player.moveSpeed -= 0.05f;
                    return; 
				case BuffID.Panic:
                    player.moveSpeed -= 0.5f;
                    return; 
            }
        }

        public override void ModifyBuffTip(int type, ref string tip, ref int rare)
        {
            switch (type)
            {
                case BuffID.StardustDragonMinion:
                    tip = "The Lunar Dragon will fight for you";
                    return;
                case BuffID.BeetleEndurance1:
                    tip = "Damage taken reduced by 10%";
                    return;
                case BuffID.BeetleEndurance2:
                    tip = "Damage taken reduced by 20%";
                    return;
                case BuffID.BeetleEndurance3:
                    tip = "Damage taken reduced by 30%";
                    return;
                case BuffID.Panic:
                    tip = "Greatly increased movement capabilities";
                    return;
                case BuffID.Archery:
                    tip = "10% increased arrow damage, 20% increased arrow speed";
                    return;
                case BuffID.Titan:
                    tip = "50% increased knockback and 10% increased melee weapon size";
                    return;
                case BuffID.AmmoReservation:
                    tip = "Prevents basic ammo consumption";
                    return;
                case BuffID.Inferno:
                    tip = "Your attacks cause fiery explosions";
                    return;
                case BuffID.WeaponImbueNanites:
                    tip = "Melee attacks confuse enemies and increase health regeneration";
                    return;
                case BuffID.ManaRegeneration:
                    tip = "Increases mana regeneration by 20%";
                    return;
	            case BuffID.ManaSickness:
                    tip = "Can't drink another mana potion";
                    return;
                case BuffID.Swiftness:
                    tip = "20% increased movement speed";
                    return;
            }
        }
    }
}

        