using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace LolitomsLogic.NPCs {
    class TheFakeEmiltca : ModNPC {

        public override void SetDefaults() {
            npc.width = 27;
            npc.height = 44;
            npc.aiStyle = -1;
            npc.damage = 1;
            npc.defense = 100;
            npc.lifeMax = 1;
            npc.HitSound = SoundID.NPCHit2;
            npc.DeathSound = SoundID.NPCDeath2;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.knockBackResist = 0f;

            // Because our width and height don't match the texture size, we use drawOffsetY to attempt to center the drawing of the NPC. This lets the hitbox better conform to the shape of our NPC. Hitboxes don't rotate, so this approach is needed to let the hitbox better represent the position of the damageable portion of the NPC.
            drawOffsetY = 30;
        }


    }
}
