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
    public class Lenz : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lenz");
            Tooltip.SetDefault("Delivers an icy one-two punch followed by an explosion\n" +
                "\'The bow seems to be sentient, chanting tales of a distant past...\'\n" +
                "Look at them, they come to this place when they know they're not pure.\n" +
                "Terrarians use the keys, but they are mere trespassers.\n" +
                "Only I, Vor, know the true power of the Void.\n" +
                "It is time. I will teach these trespassers the redemptive power of my instrument.\n" +
                "They will learn its simple truth.");
        }

        public override void SetDefaults()
        {
            item.damage = 50;
            item.ranged = true;
            item.width = 150;
            item.height = 300;
            item.scale = 0.3f;
            item.height = 20;
            item.useTime = 40;
            item.useAnimation = 40;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 6;
            item.value = 69;
            item.rare = ItemRarityID.Expert;
            item.UseSound = SoundID.DD2_SkyDragonsFuryShot;
            item.autoReuse = true;
            item.shootSpeed = 40f;
            item.noMelee = true;
            item.shoot = ModContent.ProjectileType<LenzArrow>();
        }
    }
}