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
         //   Random wRandom = new Random((int)((unchecked(DateTime.Now.Ticks.GetHashCode()))));
            base.Draw(sprite, screen, level);

   // screen.render(x * 16 + 0, y * 16 + 0, wRandom.nextInt(4), col, wRandom.nextInt(4));
     screen.draw(sprite, new Vector2(base.position.X, base.position.Y), 21+ wRandom.Next(4), Color.White, SpriteEffects.None);
     screen.draw(sprite, new Vector2(base.position.X+8, base.position.Y), 21+ wRandom.Next(4), Color.White, SpriteEffects.None);
     screen.draw(sprite, new Vector2(base.position.X, base.position.Y + 8), 21 + wRandom.Next(4), Color.White, SpriteEffects.None);
     screen.draw(sprite, new Vector2(base.position.X + 8, base.position.Y + 8), 21 + wRandom.Next(4), Color.White, SpriteEffects.None);
}
    }
}
