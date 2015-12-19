using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Totally_Recoded_Minicraft.gfx;
using Totally_Recoded_Minicraft.level;
using Totally_Recoded_Minicraft.level.tile;

namespace Totally_Recoded_Minicraft.entity
{
    public class Player : Mob
    {
        Game1 game;
        float time;
        int attackDir;
        float attackTime;
        int flip1=0;
        int flip2=0;
       public int maxHealth = 10;
       public int maxStamina=10;
       public int stamina;
        public int health;
		int speed=1;
        Random random=new Random();
        public Player(Game1 game)
        {
            stamina = maxStamina;
            health=maxHealth;
            this.game = game;
            position = new Vector2(position.X+50, position.Y+50);
        }

		public void checkCorners(Level level)
		{
			if (position.X < 0)
				position.X = level.w * 16;
			if (position.X > level.w * 16)
			{
				position.X = 0;
			}
			if (position.Y < 0)
				position.Y = level.h * 16-1;
			if (position.Y > level.h * 16)
				position.Y = 0;
		}
		int limitpass;
		public void speedHack(int xa , int ya)
		{
			if (limitpass >= 100)
				speed = 1;
			if (Keyboard.GetState().IsKeyDown(Keys.F1)) {
				speed = 5;
				limitpass = 0;
			}
			if (Keyboard.GetState ().IsKeyDown (Keys.F2)) speed = 1;

				if (xa > 0)
					limitpass += speed;
				if (ya > 0)
					limitpass += speed;
		}
        public override void Update(GameTime time, Level level)
        {
			
		//	CollisionWithItems(level);

            this.time += (float)time.ElapsedGameTime.TotalMilliseconds;
            int xa = 0;
            int ya = 0;
			if (Keyboard.GetState().IsKeyDown(Keys.Up)) {
				ya -= speed;
			}
			if (Keyboard.GetState().IsKeyDown(Keys.Down)) {
				ya += speed;
			}

			if (Keyboard.GetState().IsKeyDown(Keys.Left)) {
				xa -= speed;
			}
			if (Keyboard.GetState().IsKeyDown(Keys.Right)) {
				xa += speed;
			}
			speedHack(xa,ya);//mod
            if (Keyboard.GetState().IsKeyDown(Keys.C)) attack(level,time);
			base.move(xa, ya, level);
			checkCorners(level);
			if (attackTime > 0) attackTime--;
            base.Update(time, level);

        }
        float ta;
		public Rectangle rec()
		{
			return new Rectangle((int)position.X+4,(int)position.Y+1,14,8);
		}
		private void CollisionWithItems(Level level)
		{
			foreach (Entity t in level.entities) {
				if (t.removed == false) {
					if (t.GetType() == typeof(ItemEntity)) {
						if (rec().Intersects(new Rectangle((int)t.position.X, (int)t.position.Y, 4, 4))) {
							t.removed = true;
						}
					}
				}
			}
		}
        public void attack(Level level,GameTime time)
        {
            ta+=(float)time.ElapsedGameTime.TotalMilliseconds;
            if (ta >= 100)
            {
                ta = 0;
                walkDist += 8;
                attackDir = dir;

                int yo = -2;
                int range = 20;

                attackTime = 5;
                int xt = (int)position.X >> 4;
                int yt = ((int)position.Y + yo) >> 4;
                int r = 12;
                Rectangle rec = new Rectangle(0, 0, 0, 0);
                if (attackDir == 0) rec = new Rectangle((int)base.position.X, (int)base.position.Y + 8 + 4, 16, 8);
                if (attackDir == 1) rec = new Rectangle((int)base.position.X - 4, (int)base.position.Y, 8, 16);
                if (attackDir == 2) rec = new Rectangle((int)base.position.X - 4, (int)base.position.Y, 8, 16);
                if (attackDir == 3) rec = new Rectangle((int)base.position.X + 8 + 4, (int)base.position.Y, 16, 8);
                //base.position.X + 8 + 4, base.position.Y
                int i = 0;
                try
                {
                    foreach (Tile t in level.tiles3)
                    {
                        if (t.GetType() != typeof(GrassTile))
                            if (new Rectangle((int)t.position.X, (int)t.position.Y, 16, 16).Intersects(rec))
                            {

                                level.tiles[i].hurt(level, xt, yt, this, random.Next(3) + 1, attackDir);
                                break;
                            }
                        i++;
                    }
                }
                catch { }
            }
        }
        public override  void Draw(SpriteBatch sprite,Screen screen)
        {
            int xt = 0;
            int yt = 14;
            int flip1 = (walkDist >> 3) & 1;
            int flip2 = (walkDist >> 3) & 1;
            if (base.dir == 1)
            {
                xt += 2;
            }
            if (dir > 1)
            {
                flip1 = 0;
                flip2 = ((walkDist >> 4) & 1);
                if (dir == 2)
                {
                    flip1 = 1;
                }
                xt += 4 + ((walkDist >> 3) & 1) * 2;
            }
            if (attackTime > 0 && attackDir == 1)
            {
                game.screen.draw(sprite, new Vector2(base.position.X , base.position.Y-4), 6 + 13 * 32, Color.White, SpriteEffects.None);
                game.screen.draw(sprite, new Vector2(base.position.X +8, base.position.Y -4), 6 + 13 * 32, Color.White, SpriteEffects.FlipHorizontally );
            }
            Color col = Color.White;
            game.screen.draw(sprite, new Vector2(base.position.X + 8 * flip1, base.position.Y), xt + yt * 32, col, getEffect(flip1));
            game.screen.draw(sprite, new Vector2(base.position.X + 8 - 8 * flip1, base.position.Y), xt + 1 + yt * 32,col, getEffect(flip1));
         
            if (!isSwimming())
            {
                game.screen.draw(sprite, new Vector2(base.position.X + 8 * flip2, base.position.Y + 8), xt + (yt + 1) * 32, col, getEffect(flip2));
                game.screen.draw(sprite, new Vector2(base.position.X + 8 - 8 * flip2, base.position.Y + 8), xt + 1 + (yt + 1) * 32,col, getEffect(flip2));
        
            }

            if (attackTime > 0 && attackDir == 2)
            {
                game.screen.draw(sprite, new Vector2(base.position.X -4, base.position.Y), 7 + 13 * 32, Color.White, SpriteEffects.FlipHorizontally);
                game.screen.draw(sprite, new Vector2(base.position.X -4, base.position.Y + 8), 7 + 13 * 32, Color.White, SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically);
            }
            if (attackTime > 0 && attackDir == 3)
            {
                game.screen.draw(sprite, new Vector2(base.position.X + 8 + 4, base.position.Y), 7 + 13 * 32, Color.White, SpriteEffects.None);
                game.screen.draw(sprite, new Vector2(base.position.X + 8 + 4, base.position.Y + 8), 7 + 13 * 32, Color.White,  SpriteEffects.FlipVertically);
            }
            //	screen.render(xo + 8 + 4, yo, 7 + 13 * 32, Color.get(-1, 555, 555, 555), 0);
          //  screen.render(xo + 8 + 4, yo + 8, 7 + 13 * 32, Color.get(-1, 555, 555, 555), 2);
            if (attackTime > 0 && attackDir == 0)
            {
                //xo + 0, yo + 8 + 4
                game.screen.draw(sprite, new Vector2(base.position.X, base.position.Y + 8 + 4), 6 + 13 * 32, Color.White, SpriteEffects.FlipVertically);
                game.screen.draw(sprite, new Vector2(base.position.X + 8, base.position.Y + 8 + 4), 6 + 13 * 32, Color.White, SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically);
             //   sprite.Draw(screen.game.collision, new Vector2((int)base.position.X, (int)base.position.Y + 8 + 4), new Rectangle(16, 0, 16, 8), Color.White*0.5f);
            }

     //  sprite.Draw(screen.game.collision, new Vector2((base.position.X+4), (base.position.Y +1)), new Rectangle(24, 0, 8, 14), Color.White * 0.5f, 0f, Vector2.Zero,1f, SpriteEffects.None, 0f);
            base.Draw(sprite,screen);
        }
        public SpriteEffects getEffect (int flip)
        {
            if(flip==1) return SpriteEffects.FlipHorizontally;
          return SpriteEffects.None;
        }
      /*  public bool isSwimming(Screen screen)
        {
     foreach (Tile t in screen.game.currentlevel.tiles)
            {
         if(t.GetType()==typeof(GrassTile))
         {
					if(new Rectangle((int)t.position.X, (int)t.position.Y, 16, 16).Intersects(new Rectangle(((int)position.X+4 ), (int)(position.Y ), 8, 8)))
             return false;
         }
            }
     return true;
        }*/
        public bool findStartPos(Level level)
        {
            while (true)
            {
                int x = random.Next(level.w);
                int y = random.Next(level.h);
                if (level.getTile(new Vector2(x, y)).GetType() == typeof(GrassTile))
                {
                   this.position.X = x * 16;
                    this.position.Y = y * 16;
                    return true;
                }
            }
        }
    }
}
