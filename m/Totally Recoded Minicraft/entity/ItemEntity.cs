using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Totally_Recoded_Minicraft.item;

namespace Totally_Recoded_Minicraft.entity
{
    class ItemEntity : Entity
    {
        private int lifeTime;
        protected int walkDist = 0;
        protected int dir = 0;
        public int hurtTime = 0;
        protected int xKnockback, yKnockback;
        public double xa, ya, za;
        public double xx, yy, zz;
        public Item item;
        private int time = 0;
        float timer;
        public ItemEntity(Item item, int x, int y)
        {
            this.item = item;
            xx = this.position.X = x;
            yy = this.position.Y= y;
            xr = 3;
            yr = 3;

            zz = 2;
            GaussianRandom random = new GaussianRandom(this.random);
            xa = random.NextGaussian() * 0.3;
            ya = random.NextGaussian() * 0.2;
            za = this.random.NextDouble() * 0.7 + 1;

            lifeTime = 60 * 10 + this.random.Next(60)*10;
        }
        public override void Update(GameTime time, level.Level level)
        {
            timedis += (float)time.ElapsedGameTime.TotalMilliseconds;
            timer+=(float)time.ElapsedGameTime.TotalMilliseconds;
            if (timer >= lifeTime*10)
            {
                timer = 0;
                remove();
                return;
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
            int ox = (int)position.X;
            int oy = (int)position.Y;
            int nx = (int)xx;
            int ny = (int)yy;
            int expectedx = nx - (int)position.X;
            int expectedy = ny - (int)position.Y;
            move(nx - (int)position.X, ny - (int)position.Y,level);
            int gotx = (int)position.X - ox;
            int goty = (int)position.Y - oy;
            xx += gotx - expectedx;
            yy += goty - expectedy;

            if (hurtTime > 0) hurtTime--;
        }
        float timedis;
        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch sprite, gfx.Screen screen)
        {
            if (timer >= lifeTime * 8)
            {
                if (timedis < 125) return;
                else timedis = 0;
            }
            screen.draw(sprite, new Vector2(base.position.X - 4, base.position.Y - 4), item.getSprite(), Color.White, SpriteEffects.None);
            screen.draw(sprite, new Vector2(base.position.X - 4, base.position.Y - 4 - (int)(zz)), item.getSprite(), Color.White, SpriteEffects.None);
            base.Draw(sprite, screen);
        }
    }
}
