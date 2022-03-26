using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Diagnostics;
using Microsoft.Xna.Framework;

namespace BTDsex.Projectiles
{
    public class DartMonkeBigBall : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ultra Juggarnaut Balls");
        }

        public override void SetDefaults()
        {
            projectile.width = 30;
            projectile.height = 30;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.penetrate = 200;
            projectile.timeLeft = 300;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.ranged = true;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            //deduct a bounce
            //if can't bounce, simply kill
            //if it can, reflect like light
            --projectile.penetrate;
            if (projectile.penetrate <= 0)
            {
                projectile.Kill();
            }
            else
            {
                Collision.HitTiles(projectile.position + projectile.velocity,
                    projectile.velocity, projectile.width, projectile.height);
                Main.PlaySound(SoundID.Item10, projectile.position);

                //when a projectile hits a wall, before calling OnTileCollide
                //it effectively slides along the wall
                //so by seeing which velocity component is changed
                //you can see what component need to be inverted
                if (projectile.velocity.X != projectile.oldVelocity.X)
                    projectile.velocity.X = -projectile.oldVelocity.X;
                if (projectile.velocity.Y != projectile.oldVelocity.Y)
                    projectile.velocity.Y = -projectile.oldVelocity.Y;
            }
            return false;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            //make a sound
            Main.PlaySound(SoundID.DD2_FlameburstTowerShot, projectile.position);

            //split into 3 smaller projectiles when hitting walls
            //or enemies
            if (projectile.owner == Main.myPlayer)
            {
                for (int i = 0; i < 3; ++i)
                {
                    //a random spray upwards
                    //hopefully
                    float speedX = Main.rand.NextFloat(-2f, 2f);
                    float speedY = -10f;

                    Vector2 speedOverall = new Vector2(speedX, speedY);

                    //proper multiplayer in mind
                    Player player = Main.player[projectile.owner];
                    if (Main.netMode != NetmodeID.Server && Main.myPlayer == player.whoAmI)
                    {
                        Projectile.NewProjectile(projectile.position, speedOverall,
                            ModContent.ProjectileType<DartMonkeSmallBall>(), (int)(projectile.damage * 0.8),
                            projectile.knockBack, Main.myPlayer);
                    }
                }
            }
        }
    }
}