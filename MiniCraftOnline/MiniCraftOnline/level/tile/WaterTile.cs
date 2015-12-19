using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Totally_Recoded_Minicraft.level.tile
{
    class WaterTile : Tile
    {
        Random wRandom;
           public WaterTile(Vector2 position)
            : base(position)
        {
            connectsToSand = true;
            connectsToWater = true;
            id = 2;
            walkable = 1;
          wRandom = new Random((int)((unchecked(DateTime.Now.Ticks.GetHashCode()))));
        }
        public override void Update(GameTime time)
           {
			
               base.Update(time);
           }
        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch sprite, gfx.Screen screen, Level level)
        {
			int x = (int)position.X / 16;
			int y = (int)position.Y / 16;
            base.Draw(sprite, screen, level);
			bool u = !level.getTile(new Vector2(position.X/16, position.Y/16 - 1)).connectsToWater;
			bool d = !level.getTile(new Vector2(position.X/16, position.Y/16 + 1)).connectsToWater;
			bool l = !level.getTile(new Vector2(position.X/16 - 1, position.Y/16)).connectsToWater;
			bool r = !level.getTile(new Vector2(position.X/16 + 1, position.Y/16)).connectsToWater;

			bool su = u && level.getTile(new Vector2(x, y - 1)).connectsToSand;
			bool sd = d && level.getTile(new Vector2(x, y + 1)).connectsToSand;
			bool sl = l && level.getTile(new Vector2(x - 1, y)).connectsToSand;
		    bool sr = r && level.getTile(new Vector2(x + 1, y)).connectsToSand;


			if (!u && !l) {
				screen.draw(sprite, new Vector2(base.position.X, base.position.Y), 21 + wRandom.Next(4), Color.White, SpriteEffects.None);
			} 
			else
			{
				if (su || sl) {
					screen.draw(sprite, new Vector2(base.position.X, base.position.Y), (l ? 14 : 15) + (u ? 0 : 1) * 32+3*32, Color.White, SpriteEffects.None);
				}
				else
				screen.draw(sprite, new Vector2(base.position.X, base.position.Y), (l ? 14 : 15) + (u ? 0 : 1) * 32, Color.White, SpriteEffects.None);
			}


			if (!u && !r) {
					screen.draw(sprite, new Vector2(base.position.X + 8, base.position.Y), 21 + wRandom.Next(4), Color.White, SpriteEffects.None);
			
				} else {
				if (su || sr) {
					screen.draw(sprite, new Vector2(base.position.X + 8, base.position.Y), (r ? 16 : 15) + (u ? 0 : 1) * 32+3*32, Color.White, SpriteEffects.None);
				}
				else
					screen.draw(sprite, new Vector2(base.position.X + 8, base.position.Y), (r ? 16 : 15) + (u ? 0 : 1) * 32, Color.White, SpriteEffects.None);
				
				}


			if (!d && !l) {
				screen.draw(sprite, new Vector2(base.position.X, base.position.Y + 8), 21 + wRandom.Next(4), Color.White, SpriteEffects.None);
			} else {
				if(sd || sl)
					screen.draw(sprite, new Vector2(base.position.X, base.position.Y + 8),(l ? 14 : 15) + (d ? 2 : 1) * 32+3*32, Color.White, SpriteEffects.None);
					else
				screen.draw(sprite, new Vector2(base.position.X, base.position.Y + 8),(l ? 14 : 15) + (d ? 2 : 1) * 32, Color.White, SpriteEffects.None);
			}
			if (!d && !r) {
				
				screen.draw(sprite, new Vector2(base.position.X + 8, base.position.Y + 8), 21 + wRandom.Next(4), Color.White, SpriteEffects.None);
			} else {
				if (sd || sr) {
					screen.draw(sprite, new Vector2(base.position.X + 8, base.position.Y + 8), (r ? 16 : 15) + (d ? 2 : 1) * 32+3*32, Color.White, SpriteEffects.None);
				}
				else
				screen.draw(sprite, new Vector2(base.position.X + 8, base.position.Y + 8), (r ? 16 : 15) + (d ? 2 : 1) * 32, Color.White, SpriteEffects.None);
			}
			}
    }
}
