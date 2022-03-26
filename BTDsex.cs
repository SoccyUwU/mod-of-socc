using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using System;
using System.Diagnostics;

namespace BTDsex
{
    public class BTDsex : Mod
    {
    }

    public static class SexUtil
    {
        // violently sexes the closest npc to the given projectile
        // and return it
        public static NPC SexNpcClose(this Projectile proj)
        {
            NPC closest = Main.npc[0];
            float closestDis = float.MaxValue;
            float manhatDis;
            for (int i = 0; i < 200; ++i)
            {
                if (Main.npc[i].CanBeChasedBy())
                {
                    manhatDis = Math.Abs(proj.position.X - Main.npc[i].position.X)
                                   + Math.Abs(proj.position.Y - Main.npc[i].position.Y);
                    if (manhatDis < closestDis)
                    {
                        closestDis = manhatDis;
                        closest = Main.npc[i];
                    }
                }
            }
            return closest;
        }
    }
}