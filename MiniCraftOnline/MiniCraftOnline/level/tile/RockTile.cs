using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Totally_Recoded_Minicraft.level.tile
{
    class RockTile : Tile
    {
        public RockTile(Vector2 position):base(position)
        {
		//	connectsToGrass = true;

            id = 5;
            walkable = 0;
        }
        public override void Update(Microsoft.Xna.Framework.GameTime time)
        {
            base.Update(time);
        }
        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch sprite, gfx.Screen screen, Level level)
        {
			int x = (int)position.X / 16;
			int y = (int)position.Y / 16;
            base.Draw(sprite, screen, level);
			bool u = level.getTile(new Vector2(x, y - 1)).GetType() != this.GetType();
			bool d = level.getTile(new Vector2(x, y + 1)).GetType() != this.GetType();
			bool l = level.getTile(new Vector2(x - 1, y)).GetType() != this.GetType();
			bool r = level.getTile(new Vector2(x + 1, y)).GetType() != this.GetType();

			bool ul = level.getTile(new Vector2(x - 1, y - 1)).GetType() != this.GetType();
			bool dl = level.getTile(new Vector2(x - 1, y + 1)).GetType() != this.GetType();
			bool ur = level.getTile(new Vector2(x + 1, y - 1)).GetType() != this.GetType();
			bool dr = level.getTile(new Vector2(x + 1, y + 1)).GetType() != this.GetType();
        //    screen.render(x * 16 + 0, y * 16 + 0, 0, col, 0);

			if (!u && !l) {
				if (!ul)
					screen.draw(sprite, new Vector2(base.position.X, base.position.Y), 21+1*32, Color.White, SpriteEffects.None);
				else
				{
					screen.draw(sprite, new Vector2(base.position.X, base.position.Y), 7 + 0 * 32, Color.White, SpriteEffects.FlipHorizontally|SpriteEffects.FlipVertically);
				}
				} else
				screen.draw(sprite, new Vector2(base.position.X, base.position.Y),  (l ? 6 : 5) + (u ? 2 : 1) * 32, Color.White,SpriteEffects.FlipHorizontally|SpriteEffects.FlipVertically);

			if (!u && !r) {
				if (!ur) 
					screen.draw(sprite, new Vector2(base.position.X + 8, base.position.Y), 22 + 1 * 32, Color.White, SpriteEffects.None);
				else {
				}
					screen.draw(sprite, new Vector2(base.position.X + 8, base.position.Y), 8 + 0 * 32, Color.White, SpriteEffects.FlipHorizontally|SpriteEffects.FlipVertically);
			} else {
			}
				screen.draw(sprite, new Vector2(base.position.X + 8, base.position.Y), (r ? 4 : 5) + (u ? 2 : 1) * 32, Color.White, SpriteEffects.FlipHorizontally|SpriteEffects.FlipVertically);

			if (!d && !l) {
				if (!dl) {
					screen.draw(sprite, new Vector2(base.position.X + 0, base.position.Y + 8), 23 + 1 * 32, Color.White, SpriteEffects.None);
				} else {
					screen.draw(sprite, new Vector2(base.position.X + 0, base.position.Y + 8), 7 + 1 * 32, Color.White, SpriteEffects.FlipHorizontally|SpriteEffects.FlipVertically);
				}
			}
				else
				screen.draw(sprite, new Vector2(base.position.X + 0, base.position.Y + 8),(l ? 6 : 5) + (d ? 0 : 1) * 32, Color.White, SpriteEffects.FlipHorizontally|SpriteEffects.FlipVertically);

			if (!d && !r) {
				if (!dr) 
						screen.draw(sprite, new Vector2(base.position.X + 8, base.position.Y + 8), 24 + 1 * 32, Color.White, SpriteEffects.None);
				else {

					screen.draw(sprite, new Vector2(base.position.X + 8, base.position.Y + 8), 8 + 1 * 32, Color.White, SpriteEffects.FlipHorizontally|SpriteEffects.FlipVertically);
				}

			}
			else
				screen.draw(sprite, new Vector2(base.position.X + 8, base.position.Y + 8), (r ? 4 : 5) + (d ? 0 : 1) * 32, Color.White, SpriteEffects.FlipHorizontally|SpriteEffects.FlipVertically);
    }
	}
}
