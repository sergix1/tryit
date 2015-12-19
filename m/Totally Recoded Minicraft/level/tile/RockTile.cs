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
            id = 5;
            walkable = 0;
        }
        public override void Update(Microsoft.Xna.Framework.GameTime time)
        {
            base.Update(time);
        }
        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch sprite, gfx.Screen screen, Level level)
        {
            base.Draw(sprite, screen, level);

        //    screen.render(x * 16 + 0, y * 16 + 0, 0, col, 0);

			screen.draw(sprite, new Vector2(base.position.X, base.position.Y),  21+1*32, Color.White, SpriteEffects.None);
			screen.draw(sprite, new Vector2(base.position.X + 8, base.position.Y), 22+1*32, Color.White, SpriteEffects.None);
			screen.draw(sprite, new Vector2(base.position.X + 0, base.position.Y + 8), 23+1*32,  Color.White, SpriteEffects.None);
			screen.draw(sprite, new Vector2(base.position.X + 8, base.position.Y + 8), 24+1*32,  Color.White, SpriteEffects.None);
        }
    }
}
