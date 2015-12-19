using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Totally_Recoded_Minicraft.gfx;

namespace Totally_Recoded_Minicraft.entity
{
    class TextParticle : Entity
    {
        private String msg;
        private Color col;
        private int time = 0;
        public double xa, ya, za;
        public double xx, yy, zz;
        float timer;
        public TextParticle(String msg, int x, int y, Color col)
        {
            this.msg = msg;
            base.position.X = x;
            base.position.Y = y;
            this.col = col;
            xx = x;
            yy = y;
            zz = 2;
            GaussianRandom random = new GaussianRandom(this.random);
            xa = random.NextGaussian() * 0.3;
            ya = random.NextGaussian() * 0.2;
            za = this.random.NextDouble() * 0.7 + 2;
        }
        public override void Update(GameTime time, level.Level level)
        {
            this.timer+=(int)time.ElapsedGameTime.TotalMilliseconds;
            if (this.timer > 600)
            {
                remove();
            }
            xx += xa;
            yy += ya;
            zz += za;
            if (zz < 0)
            {
                zz = 0;
                za *= -0.5;
                xa *= 0.6;
                ya *= 0.6;
            }
            za -= 0.15;
            position.X = (int)xx;
            position.Y = (int)yy;
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch sprite, gfx.Screen screen)
        {
            Font.draw(sprite, msg, screen, (int)base.position.X, (int)base.position.Y, col);
            Font.draw(sprite, msg, screen, (int)base.position.X - msg.Length * 4, (int)base.position.Y - (int)(zz), col);
            base.Draw(sprite, screen);
        }
    }
}
