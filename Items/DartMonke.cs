using Terraria.ID;
using Terraria.ModLoader;
using BTDsex.Projectiles;
using Terraria;
using Microsoft.Xna.Framework;

namespace BTDsex.Items
{
    public class DartMonke : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spike-O-Pult"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("BTD sex reference zomg");
        }

        public override void SetDefaults()
        {
            item.damage = 25;
            item.ranged = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 5;
            item.value = 10000;
            item.rare = ItemRarityID.Expert;
            item.UseSound = SoundID.DD2_BallistaTowerShot;
            item.autoReuse = true;
            item.shootSpeed = 12f;
            item.noMelee = true;
            item.shoot = ModContent.ProjectileType<DartMonkeBigBall>();
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
    }
}