using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using BTDsex.Projectiles;
using Microsoft.Xna.Framework;

namespace BTDsex.Items
{
    internal class DragonBreath : ModItem
    {
        public int shotsUntilNextFirewall = 10;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dragon's Breath"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("Flings flames that inflict daybreak\nDispense firewalls around while firing");
        }

        public override void SetDefaults()
        {
            item.damage = 105;
            item.magic = true;
            item.width = 40;
            item.height = 20;
            item.useTime = 3;
            item.useAnimation = 24;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 3;
            item.value = 10000;
            item.rare = ItemRarityID.Expert;
            item.UseSound = SoundID.DD2_BetsyFireballShot;
            item.autoReuse = true;
            item.shootSpeed = 40f;
            item.noMelee = true;
            item.mana = 1;
            item.shoot = ModContent.ProjectileType<DragonBreathFlame>();
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 10);
            recipe.AddIngredient(ItemID.IronBar, 3);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        //WARNING: shotsUntilNextFirewall isn't net synced
        //please figure out how
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            //every few shots, shoot a wall of fire canister
            --shotsUntilNextFirewall;
            if (shotsUntilNextFirewall <= 0)
            {
                shotsUntilNextFirewall = 10;
                float firewallSpeedX = Main.rand.NextFloat(-5f, 5f);
                float firewallSpeedY = -7f;
                Vector2 firewallSpeed = new Vector2(firewallSpeedX, firewallSpeedY);

                //proper mp
                if (Main.netMode != NetmodeID.Server && player.whoAmI == Main.myPlayer)
                {
                    Projectile.NewProjectile(player.position, firewallSpeed,
                        ModContent.ProjectileType<DragonBreathBottle>(),
                        item.damage, 0, Main.myPlayer);
                }
            }
            return true;
        }
    }
}