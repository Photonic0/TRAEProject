using Mono.Cecil.Cil;
using MonoMod.Cil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace TRAEProject.Changes
{
    public class ArmorPenetrationFix : GlobalNPC
    {
        public override void SetStaticDefaults()
        {
            IL.Terraria.NPC.checkArmorPenetration += HookAPCheck;
            IL.Terraria.NPC.StrikeNPC += HookStrike;
        }
        private void HookAPCheck(ILContext il)
        {
            var c = new ILCursor(il);

            //load arguments onto the stack
            c.Emit(OpCodes.Ldarg_0);
            c.Emit(OpCodes.Ldarg_1);

            //C# code
            c.EmitDelegate<Func<NPC, int, int>>((npc, AP) =>
            {
                if(npc.betsysCurse)
                {
                    AP += 40;
                }
                if(npc.ichor)
                {
                    AP += 15;
                }
                return AP;
            });
            //update the armorPenetration argument
            c.Emit(OpCodes.Starg_S, il.Method.Parameters[1]);

        }
        private void HookStrike(ILContext il)
        {
            var c = new ILCursor(il);
            if (!c.TryGotoNext(i => i.MatchLdloc(1)))
            {
                return; // Patch unable to be applied
            }
            c.Emit(OpCodes.Ldarg_0); //load the NPC
            c.Emit(OpCodes.Ldfld, typeof(NPC).GetField(nameof(NPC.defense))); //get the Npcs defense and put it on top of the stack
            c.Emit(OpCodes.Stloc_2); //set local variable 2 to the npc's defense, effectively canceling what ichor and betsy's wrath removed
        }
    }

}
