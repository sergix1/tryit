﻿using Microsoft.Xna.Framework;
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
            connectsToGrass = true;
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

            screen.draw(sprite, new Vector2(base.position.X, base.position.Y),26, Color.White, SpriteEffects.None);
            screen.draw(sprite, new Vector2(base.position.X + 8, base.position.Y), 27, Color.White, SpriteEffects.None);
            screen.draw(sprite, new Vector2(base.position.X + 0, base.position.Y + 8), 28, Color.White, SpriteEffects.None);
            screen.draw(sprite, new Vector2(base.position.X + 8, base.position.Y + 8), 29, Color.White, SpriteEffects.None);
        }
    }
}