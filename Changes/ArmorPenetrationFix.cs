using Mono.Cecil.Cil;
using MonoMod.Cil;
using System;
using Terraria;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using TRAEProject.NewContent.Items.Weapons.Summoner.TailWhip;
using TRAEProject.NewContent.TRAEDebuffs;
using Terraria.ModLoader;

namespace TRAEProject.Changes
{
    public class ArmorPenetrationFix : GlobalNPC
    {
        public override void SetStaticDefaults()
        {
            IL_NPC.checkArmorPenetration += HookAPCheck;
            IL_NPC.StrikeNPC += HookStrike;
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
                if(npc.GetGlobalNPC<ObsidianSkulledStacks>().stacks > 0)
                {
                    AP += 3 * npc.GetGlobalNPC<ObsidianSkulledStacks>().stacks;
                }
                if (npc.HasBuff(BuffID.WitheredArmor))
                {
                    AP += 18;
                }
                if (npc.HasBuff(BuffType<TailWhipTag>()))
                {
                    AP += 16;
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
