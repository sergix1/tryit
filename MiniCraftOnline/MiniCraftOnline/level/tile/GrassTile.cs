using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Totally_Recoded_Minicraft.gfx;

namespace Totally_Recoded_Minicraft.level.tile
{
    class GrassTile : Tile
    {

        public GrassTile(Vector2 position):base(position)
        {
            connectsToGrass = true;
            walkable = 1;
          id = 0;
        }
        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch sprite, Screen screen, Level level)
        {
         Color col = new Color(131,131+111,131,131+111);

         bool u = !level.getTile(new Vector2(position.X/16 , position.Y/16-1)).connectsToGrass;
         bool d = !level.getTile(new Vector2(position.X / 16, position.Y / 16 + 1)).connectsToGrass;
          bool l =!level.getTile(new Vector2(position.X/16-1,position.Y/16)).connectsToGrass;
          bool r = !level.getTile(new Vector2(position.X / 16 + 1, position.Y / 16)).connectsToGrass;
     //   bool u = !level.getTile(x, y - 1).connectsToGrass;
			if (!u && !l) {
				screen.draw(sprite, new Vector2(base.position.X, base.position.Y), 0, Color.White, SpriteEffects.None);
			}
			else
				screen.draw(sprite, new Vector2(base.position.X, base.position.Y), 0, Color.White, SpriteEffects.None);
			if (!u && !r) {
				screen.draw(sprite, new Vector2(base.position.X + 8, base.position.Y), 1, Color.White, SpriteEffects.None);
			}
			else
				screen.draw(sprite, new Vector2(base.position.X + 8, base.position.Y),(r ? 13 : 12) + (u ? 0 : 1) * 32, Color.White, SpriteEffects.None);
			if (!d && !l) {
				screen.draw(sprite, new Vector2(base.position.X + 0, base.position.Y + 8), 2, Color.White, SpriteEffects.None);
			} else {
				screen.draw(sprite, new Vector2(base.position.X + 0, base.position.Y + 8),  (l ? 11 : 12) + (d ? 2 : 1) * 32, Color.White, SpriteEffects.None);
			
			}
			if (!d && !r) {
				screen.draw(sprite, new Vector2(base.position.X + 8, base.position.Y + 8), 3, Color.White, SpriteEffects.None);
			}
			else
				screen.draw(sprite, new Vector2(base.position.X + 8, base.position.Y + 8),(r ? 13 : 12) + (d ? 2 : 1) * 32, Color.White, SpriteEffects.None);
				base.Draw(sprite, screen, level);
        }
    }
}
