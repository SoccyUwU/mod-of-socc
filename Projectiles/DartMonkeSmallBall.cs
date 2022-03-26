using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace BTDsex.Projectiles
{
    internal class DartMonkeSmallBall : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ultra Smolarnaut Ball");
        }

        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 20;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.penetrate = 2;
            projectile.timeLeft = 240;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.ranged = true;
        }

        public override void AI()
        {
            //gravity
            projectile.velocity.Y = projectile.velocity.Y + 0.3f;
            if (projectile.velocity.Y > 16f)
            {
                projectile.velocity.Y = 16f;
            }
        }
    }
}