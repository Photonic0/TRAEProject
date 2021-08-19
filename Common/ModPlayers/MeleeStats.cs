using Mono.Cecil.Cil;
using MonoMod.Cil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using TRAEProject.Buffs;
using static Terraria.ModLoader.ModContent;

namespace TRAEProject.Common.ModPlayers
{
    class MeleeStats : ModPlayer
    {

        public float weaponSize = 1f;
        public int inflictHeavyBurn = 0;
        public float meleeVelocity = 1f;
        public override void ResetEffects()
        {
            weaponSize = 1f;
            inflictHeavyBurn = 0;
            meleeVelocity = 1f;
        }
        #region Sword Size
        public override void SetStaticDefaults()
        {
            IL.Terraria.Player.GetAdjustedItemScale += HookSize;
        }
        private void HookSize(ILContext il)
        {
            var c = new ILCursor(il);

            for (int i = 0; i < 2; i++)
            {
                if (!c.TryGotoNext(i => i.MatchLdloc(0)))
                {
                    return; // Patch unable to be applied
                }
            }

            //EDIT: Pop the old value so we don't have stack issues
            c.Index++;
            c.Emit(OpCodes.Pop);

            //push the item onto the stack
            c.Emit(OpCodes.Ldarg_1);
            //push the player onto the stack
            c.Emit(OpCodes.Ldarg_0);
            //push the local variable onto the stack
            c.Emit(OpCodes.Ldloc_0);

            c.EmitDelegate<Func<Item, Player, float, float>>((item, player, scale) =>
            {
                if (item.CountsAsClass(DamageClass.Melee))
                {
                    scale *= player.GetModPlayer<MeleeStats>().weaponSize;
                }
                return scale;
            });
            //pop the variable at the top of the stack onto the local variable
            c.Emit(OpCodes.Stloc_0);
            //push the local variable onto the stack
            c.Emit(OpCodes.Ldloc_0);
        }
        #endregion
        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            if(inflictHeavyBurn >0 && item.CountsAsClass(DamageClass.Melee))
            {
                target.AddBuff(BuffType<Heavyburn>(), inflictHeavyBurn);
            }
        }

    }
}
