using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Totally_Recoded_Minicraft.entity
{
    class SmashParticle :Entity
    {
        float time=0;
        public SmashParticle(int x, int y)
        {
            position.X = x;
            position.Y = y;
           // Sound.monsterHurt.play();
        }
        public override void Update(Microsoft.Xna.Framework.GameTime time, level.Level level)
        {
            this.time+=(float)time.ElapsedGameTime.TotalMilliseconds;
            if (this.time > 100)
            {
                this.time = 0;
                base.remove();
            }
        }
        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch sprite, gfx.Screen screen)
        {
            screen.draw(sprite, new Vector2(base.position.X - 8, base.position.Y - 8), 5 + 12 * 32, Color.White, SpriteEffects.FlipVertically);
            screen.draw(sprite, new Vector2(base.position.X , base.position.Y - 8), 5 + 12 * 32, Color.White, SpriteEffects.FlipVertically|SpriteEffects.FlipHorizontally);
            screen.draw(sprite, new Vector2(base.position.X-8, base.position.Y ), 5 + 12 * 32, Color.White, SpriteEffects.None);
            screen.draw(sprite, new Vector2(base.position.X , base.position.Y), 5 + 12 * 32, Color.White, SpriteEffects.FlipHorizontally);
            base.Draw(sprite, screen);

            //	time++;
         
        }


    }
}
