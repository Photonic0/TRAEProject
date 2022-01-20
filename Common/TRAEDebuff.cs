using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace TRAEProject.Common
{
    public abstract class TRAEDebuff
    {
        public int timeLeft = 10;
        public static void Apply<T>(NPC npc, int time, int stackLimit = 1) where T : TRAEDebuff, new()
        {
            if(stackLimit != -1 && npc.GetGlobalNPC<ProcessTRAEDebuffs>().HasDebuff<T>())
            {
                List<TRAEDebuff> list = npc.GetGlobalNPC<ProcessTRAEDebuffs>().All<T>();
                if(list.Count >= stackLimit)
                {
                    if(list[0].timeLeft < time)
                    {
                        list[0].timeLeft = time;
                    }
                    return;
                }
            }
            npc.GetGlobalNPC<ProcessTRAEDebuffs>().debuffs.Add(new T() { timeLeft = time });
        }
        public virtual void Update(NPC npc)
        {

        }
        public virtual void UpdateLifeRegen(NPC npc, ref int damage)
        {

        }
        public virtual void DrawEffects(NPC npc, ref Color drawColor)
        {

        }
        public virtual void CheckDead(NPC npc)
        {

        }
    }
    public class ProcessTRAEDebuffs : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        public List<TRAEDebuff> debuffs = new List<TRAEDebuff>();
        public bool HasDebuff<T>()
        {
            for(int k = 0; k < debuffs.Count; k++)
            {
                if(debuffs[k] is T)
                {
                    return true;
                }
            }
            return false;
        }
        public List<TRAEDebuff> All<T>()
        {
            List<TRAEDebuff> list = new List<TRAEDebuff>();
            for (int k = 0; k < debuffs.Count; k++)
            {
                if (debuffs[k] is T)
                {
                    list.Add(debuffs[k]);
                }
            }
            return list;
        }
        public override void AI(NPC npc)
        {
            for (int k = 0; k < debuffs.Count; k++)
            {
                debuffs[k].Update(npc);
            }
        }
        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            for (int k = 0; k < debuffs.Count; k++)
            {
                debuffs[k].UpdateLifeRegen(npc, ref damage);
            }
        }
        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            for (int k = 0; k < debuffs.Count; k++)
            {
                debuffs[k].DrawEffects(npc, ref drawColor);
            }
        }
        public override void PostAI(NPC npc)
        {
            for (int k = 0; k < debuffs.Count; k++)
            {
                debuffs[k].timeLeft--;
                if(debuffs[k].timeLeft<= 0)
                {
                    debuffs.Remove(debuffs[k]);
                }
            }
        }
        public override bool CheckDead(NPC npc)
        {
            for (int k = 0; k < debuffs.Count; k++)
            {
                debuffs[k].CheckDead(npc);
            }
            return base.CheckDead(npc);
        }
    }
}
