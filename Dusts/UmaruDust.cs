using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace LolitomsLogic.Dusts {
    public class UmaruDust : ModDust {
        public override void OnSpawn(Dust dust) {
            dust.velocity *= 1.4f;
            dust.noGravity = false;
            dust.frame = new Rectangle(0, 0, 16, 16);
        }

        public override bool Update(Dust dust) {
            // dust.position += dust.velocity;
            dust.position.Y += 5;
            dust.rotation += 0.1f;
            dust.scale -= 0.01f;
            if (dust.scale < 0.9f) {
                dust.active = false;
            }
            return false;
        }
    }
}
