using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Totally_Recoded_Minicraft.level.tile
{
    class FlowerTile : Tile
    {
        byte data;
        public FlowerTile(Vector2 position,byte data)
            : base(position)
        {
            this.data = data;
			connectsToGrass = true;
            id = 6;
            walkable = 1;
        }
        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch sprite, gfx.Screen screen, Level level)
        {
            // 1 + 1 * 32
            int shape = (data / 16) % 2;
         if(shape==0)   screen.draw(sprite, new Vector2(base.position.X, base.position.Y), 1 + 1 * 32, Color.White, SpriteEffects.None);
         else screen.draw(sprite, new Vector2(base.position.X, base.position.Y), 0 * 0, Color.White, SpriteEffects.None);
            if (shape == 1) screen.draw(sprite, new Vector2(base.position.X + 8, base.position.Y), 1 + 1 * 32, Color.White, SpriteEffects.None);
            else screen.draw(sprite, new Vector2(base.position.X + 8, base.position.Y), 1, Color.White, SpriteEffects.None);
         if (shape == 1) screen.draw(sprite, new Vector2(base.position.X, base.position.Y + 8), 1 + 1 * 32, Color.White, SpriteEffects.None);
         else screen.draw(sprite, new Vector2(base.position.X + 0, base.position.Y + 8), 2, Color.White, SpriteEffects.None);
         if (shape == 0) screen.draw(sprite, new Vector2(base.position.X + 8, base.position.Y + 8), 1 + 1 * 32, Color.White, SpriteEffects.None);
         else screen.draw(sprite, new Vector2(base.position.X + 8, base.position.Y + 8), 3, Color.White, SpriteEffects.None);
            base.Draw(sprite, screen, level);
        }
    }
}
