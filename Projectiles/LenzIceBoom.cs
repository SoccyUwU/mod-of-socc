using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using BTDsex.Projectiles;
using Microsoft.Xna.Framework;

namespace BTDsex.Projectiles
{
    public class LenzIceBoom : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lenz Ice Implosion");
        }

        public override void SetDefaults()
        {
            projectile.width = 250;
            projectile.height = 250;
            projectile.penetrate = 77943;
            projectile.timeLeft = 100;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.ranged = true;
            projectile.alpha = 255;
        }

        //fade in and out
        public override void AI()
        {
            //fade in
            if (projectile.timeLeft > 60)
                if (projectile.alpha > 0)
                    projectile.alpha -= 7;
            //fade out
            if (projectile.timeLeft < 40)
                if (projectile.alpha < 255)
                    projectile.alpha += 8;
        }

        //severely slow enemies hit
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.honeyWet = true;
        }

        //spawn the second burst of explosion on hit
        public override void Kill(int timeLeft)
        {
            Player player = Main.player[projectile.owner];
            //explode sound play
            Main.PlaySound((SoundID.DD2_ExplosiveTrapExplode).WithVolume(1.5f), projectile.position);
            //proper net
            if (Main.netMode != NetmodeID.Server && Main.myPlayer == player.whoAmI)
            {
                Vector2 noSpeed = new Vector2(0, 0);
                float newPosX = projectile.position.X + projectile.width / 2;
                float newPosY = projectile.position.Y + projectile.height / 2;
                Vector2 centralPos = new Vector2(newPosX, newPosY);
                Projectile.NewProjectile(centralPos, noSpeed,
                    ModContent.ProjectileType<LenzBam>(), projectile.damage * 50, 15, Main.myPlayer);
            }
        }
    }
}