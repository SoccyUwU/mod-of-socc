using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace BTDsex.Projectiles
{
    internal class DragonBreathFlame : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dragon Breath Flame");
        }

        public override void SetDefaults()
        {
            projectile.width = 50;
            projectile.height = 30;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.penetrate = 200;
            projectile.timeLeft = 20;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.magic = true;
        }

        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation();

            //leave a bunch of trail
            for (int i = 0; i < 10; ++i)
            {
                Dust.NewDust(projectile.position, projectile.width,
                    projectile.height, DustID.Fire, 0, 0, 0, default, 3);
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            //if can hit the enemy, inflict daybreak
            if (projectile.CanHit(target))
            {
                target.AddBuff(BuffID.Daybreak, 600);
            }
        }
    }
}