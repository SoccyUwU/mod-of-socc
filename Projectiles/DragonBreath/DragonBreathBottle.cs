using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BTDsex.Projectiles
{
    internal class DragonBreathBottle : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dragon Breath Bottle");
        }

        public override void SetDefaults()
        {
            projectile.width = 30;
            projectile.height = 50;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = false;
            projectile.magic = true;
        }

        public override void Kill(int timeLeft)
        {
            Player player = Main.player[projectile.owner];

            //proper mp
            if (Main.netMode != NetmodeID.Server && Main.myPlayer == player.whoAmI)
            {
                //a vector representing no speed
                Vector2 noSpeed = new Vector2(0, 0);

                //spawn wall of fire on death
                Projectile.NewProjectile(projectile.position, noSpeed,
                    ModContent.ProjectileType<DragonBreathFirewall>(),
                    (int)(projectile.damage * 2.5), 6, Main.myPlayer);
            }
        }

        public override void AI()
        {
            //gravity
            //if falling, fall slower
            if (projectile.velocity.Y >= 0)
                projectile.velocity.Y = projectile.velocity.Y + 0.2f;
            else
                projectile.velocity.Y = projectile.velocity.Y + 0.3f;

            //cap speed
            if (projectile.velocity.Y > 16f)
            {
                projectile.velocity.Y = 16f;
            }
        }

        //simply phase through enemies
        public override bool? CanHitNPC(NPC target)
        {
            return false;
        }
    }
}