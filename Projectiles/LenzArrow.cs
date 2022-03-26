using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using BTDsex.Projectiles;

namespace BTDsex.Projectiles
{
    internal class LenzArrow : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lenz Arrow");
        }

        public override void SetDefaults()
        {
            projectile.width = 40;
            projectile.height = 10;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.timeLeft = 600;
            projectile.ranged = true;
        }

        public override void AI()
        {
            //rotating to where it's going
            projectile.rotation = projectile.velocity.ToRotation();
        }

        //spawn the icy implosion when hit
        public override void Kill(int timeLeft)
        {
            Player player = Main.player[projectile.owner];
            //proper net
            if (Main.netMode != NetmodeID.Server && Main.myPlayer == player.whoAmI)
            {
                Vector2 noSpeed = new Vector2(0, 0);
                Projectile.NewProjectile(projectile.position, noSpeed,
                    ModContent.ProjectileType<LenzIceBoom>(), projectile.damage / 5,
                    -3, Main.myPlayer);
            }
        }
    }
}