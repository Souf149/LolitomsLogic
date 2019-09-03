using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace LolitomsLogic
{
    public class UmaruSword : ModItem {


        public override void SetStaticDefaults() {
            Tooltip.SetDefault("With the power of anime at your side!");
        }

        public override void SetDefaults() {
            item.damage = 100;            
            item.melee = true;          
            item.width = 40;           
            item.height = 40;          
            item.useTime = 20;          
            item.useAnimation = item.useTime;        
            item.useStyle = 1;         
            item.knockBack = 6;        
            item.value = Item.buyPrice(gold: 1);          
            item.rare = 13;             
            item.UseSound = SoundID.Item1;     
            item.autoReuse = true;         
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void MeleeEffects(Player player, Rectangle hitbox) {
            if (Main.rand.NextDouble() < 0.2) {
                //Emit dusts when swing the sword
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType("UmaruDust"));
            }
        }


    }
}
