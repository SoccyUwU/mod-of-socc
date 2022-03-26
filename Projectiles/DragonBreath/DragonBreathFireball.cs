using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using BTDsex;

namespace BTDsex.Projectiles
{
    internal class DragonBreathFireball : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dragon Breath Fireball");
        }

        public override void SetDefaults()
        {
            projectile.width = 30;
            projectile.height = 30;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.timeLeft = 600;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.magic = true;
        }

        public enum AISlots
        {
            ifSwitchTarget = 0
        }

        public override void AI()
        {
            //velocity = (velocity * (inertia - 1f) + idealVelocity) / inertia;
            NPC homingTarget = Main.npc[0];
            //if it's time to switch
            if (projectile.ai[0] == 1f)
            {
            }
        }
    }
}