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
    internal class DragonBreathFirewall : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dragon Breath Firewall");
        }

        public override void SetDefaults()
        {
            projectile.width = 60;
            projectile.height = 60;
            projectile.hostile = false;
            projectile.friendly = true;
            projectile.timeLeft = 600;
            projectile.ignoreWater = true;
            projectile.magic = true;
            projectile.tileCollide = false;
            projectile.penetrate = 50000;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            //if can hit the npc, apply daybreak
            if (projectile.CanHit(target))
            {
                target.AddBuff(BuffID.Daybreak, 600);
            }
        }
    }
}