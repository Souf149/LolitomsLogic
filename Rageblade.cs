using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace LolitomsLogic {
    public class Rageblade : ModItem {

        private int frames = 0;
        private int maxUseTime = 60;
        private int minUseTime = 10;
        private bool reachedMaxSpeed = false;


        public override void SetStaticDefaults() {
            Tooltip.SetDefault("With the power of anime at your side!");
        }

        public override void SetDefaults() {
            item.damage = 200;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.useTime = maxUseTime;
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

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit) {
            // make item slower every 2 seconds
            setAttackTime(item.useTime - 4);
            
            frames = 0;
            

        }

        public override void UpdateInventory(Player player) {
            frames++;

            // make item slower every 2 seconds until max
            if (frames > 30) {
                
                
                setAttackTime(item.useTime + 1);
                
                frames = 0;
            }

            // if the max attackspeed has been reached
            reachedMaxSpeed = (item.useTime == minUseTime);

            


        }

        private void setAttackTime(int time) {
            item.useTime = time;
            item.useAnimation = time;

            if(time < minUseTime) {
                setAttackTime(minUseTime);
            }

            if(time > maxUseTime) {
                setAttackTime(maxUseTime);
            }

        }


        public override void MeleeEffects(Player player, Rectangle hitbox) {
            if (reachedMaxSpeed) {
                //Emit dusts when swing the sword
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 20);
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 21);
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 27);
            }
        }



    }
}
