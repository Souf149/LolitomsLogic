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
            item.damage = 200;            
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

            // projectile
            item.shoot = 503;
            item.shootSpeed = 8f;
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

        // Star Wrath/Starfury style weapon. Spawn projectiles from sky that aim towards mouse.
        // See Source code for Star Wrath projectile to see how it passes through tiles.
		 	
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			Vector2 target = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);
			float ceilingLimit = target.Y; // where the projectile hits the floor

            // set the ceiling limit not lower than the player
			if (ceilingLimit > player.Center.Y - 200f)
			{
				ceilingLimit = player.Center.Y - 200f;
			}


			for (int i = 0; i < 3; i++)
			{

                position = player.Center;
                position.Y -= 400 * i;

                if (player.direction < 0) { // facing to the left -1
                    position.X -= item.width + 30 * i;
                }
                else {
                    position.X += item.width + 30 * i;
                }
				
				speedX = 0;
				speedY = 50;
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage * 2, knockBack, player.whoAmI, 0f, ceilingLimit);
                
			}
			return false;
		}



    }
}
