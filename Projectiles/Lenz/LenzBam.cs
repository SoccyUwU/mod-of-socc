using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;

namespace BTDsex.Projectiles
{
    public class LenzBam : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lenz Explosion");
        }

        public override void SetDefaults()
        {
            projectile.width = 260;
            projectile.height = 260;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.penetrate = 77943;
            projectile.timeLeft = 30;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.ranged = true;
            projectile.alpha = 255;
        }

        //get rid of the slow in case the enemies haven't died by now
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            //apparently enemies aren't affected by honey
            //and marking them wet don't apply water physics
            //so fuck this idea
        }

        //quick fade in-out
        public override void AI()
        {
            if (projectile.timeLeft > 15)
                if (projectile.alpha > 0)
                    projectile.alpha -= 25;
            if (projectile.timeLeft < 15)
                if (projectile.alpha < 255)
                    projectile.alpha += 25;
        }
    }
}