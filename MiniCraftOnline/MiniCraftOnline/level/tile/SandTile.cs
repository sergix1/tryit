using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Totally_Recoded_Minicraft.level.tile
{
    class SandTile :Tile
    {
        
        public SandTile(Vector2 position):base(position)
        {
			connectsToSand = true;
         //   connectsToGrass = true;
            walkable = 1;
          id = 0;
        }
        public override void Update(Microsoft.Xna.Framework.GameTime time)
        {
            base.Update(time);
        }
        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch sprite, gfx.Screen screen, Level level)
        {
            base.Draw(sprite, screen, level);
			int x = (int)position.X / 16;
			int y = (int)position.Y / 16;
			bool u = !level.getTile(new Vector2(x, y - 1)).connectsToSand;
			bool d = !level.getTile(new Vector2(x, y + 1)).connectsToSand;
			bool l = !level.getTile(new Vector2(x - 1, y)).connectsToSand;
			bool r = !level.getTile(new Vector2(x + 1, y)).connectsToSand;
			if (!u && !l) {
				screen.draw(sprite, new Vector2(base.position.X, base.position.Y), 26, Color.White, SpriteEffects.None);
			}
			else
				screen.draw(sprite, new Vector2(base.position.X, base.position.Y), 3+(l ? 11 : 12) + (u ? 0 : 1) * 32+6*32, Color.White, SpriteEffects.None);	
           
			if (!u && !r) 
			screen.draw(sprite, new Vector2(base.position.X + 8, base.position.Y), 27, Color.White, SpriteEffects.None);
          else
				screen.draw(sprite, new Vector2(base.position.X + 8, base.position.Y), 3+(r ? 13 : 12) + (u ? 0 : 1) * 32+6*32, Color.White, SpriteEffects.None);
			if (!d && !l) {
				screen.draw(sprite, new Vector2(base.position.X + 0, base.position.Y + 8), 28, Color.White, SpriteEffects.None);
			}
			else
				screen.draw(sprite, new Vector2(base.position.X + 0, base.position.Y + 8), 3+(l ? 11 : 12) + (d ? 2 : 1) * 32+6*32, Color.White, SpriteEffects.None);
			if (!d && !r) {
				screen.draw(sprite, new Vector2(base.position.X + 8, base.position.Y + 8), 29, Color.White, SpriteEffects.None);
			} else {
				screen.draw(sprite, new Vector2(base.position.X + 8, base.position.Y + 8), 3+(r ? 13 : 12) + (d ? 2 : 1) * 32+6*32, Color.White, SpriteEffects.None);
			}
			}
    }
}
