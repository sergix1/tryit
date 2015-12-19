using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Totally_Recoded_Minicraft.entity;
using Totally_Recoded_Minicraft.gfx;
using Totally_Recoded_Minicraft.item;

namespace Totally_Recoded_Minicraft.level.tile
{
    class TreeTile : Tile
    {
        public  int id = 1;
        public int walkable=0;
        int damage;
        int life=20;
        public TreeTile(Vector2 position)
            : base(position)
        {
			connectsToGrass = true;
          id = 1;
            walkable = 0;
        }
        public override void Draw(SpriteBatch sprite, Screen screen, Level level)
        {
            Color cole = new Color(131, 131 + 111, 131, 131 + 111);
            Color col = new Color(10, 151, 30, 131);
			bool u = level.getTile(new Vector2(position.X/16, position.Y/16 - 1)) == this;
			bool l = level.getTile(new Vector2(position.X/16 - 1,position.Y/16)) == this;
			bool r = level.getTile(new Vector2(position.X/16 + 1, position.Y/16)) == this;
			bool d = level.getTile(new Vector2(position.X/16, position.Y/16+ 1)) == this;
			bool ul = level.getTile(new Vector2(position.X/16 - 1, position.Y/16 - 1)) == this;
			bool ur = level.getTile(new Vector2(position.X/16 + 1, position.Y/16- 1)) == this;
		    bool dl = level.getTile(new Vector2(position.X/16 - 1, position.Y/16 + 1)) == this;
			bool dr = level.getTile(new Vector2(position.X/16 + 1, position.Y/16+ 1)) == this;
           screen.draw(sprite, new Vector2(base.position.X, base.position.Y), 0 * 0, Color.White, SpriteEffects.None);
           screen.draw(sprite, new Vector2(base.position.X + 8, base.position.Y), 1, Color.White, SpriteEffects.None);
          screen.draw(sprite, new Vector2(base.position.X + 0, base.position.Y + 8), 2, Color.White, SpriteEffects.None);
           screen.draw(sprite, new Vector2(base.position.X + 8, base.position.Y + 8), 3, Color.White, SpriteEffects.None);


			if (u && ul && l) {
				screen.draw(sprite, new Vector2(base.position.X, base.position.Y), 10 + 1 * 32, Color.White, SpriteEffects.None);
			} else {
				screen.draw(sprite, new Vector2(base.position.X, base.position.Y), 9 + 0 * 32, Color.White, SpriteEffects.None);
			}
			if (u && ur && r) {
				screen.draw(sprite, new Vector2(base.position.X + 8, base.position.Y + 0), 10 + 2 * 32, Color.White, SpriteEffects.None);
			} else {
				screen.draw(sprite, new Vector2(base.position.X + 8, base.position.Y + 0), 10 + 0 * 32, Color.White, SpriteEffects.None);
			}

			if (d && dl && l) {
				screen.draw(sprite, new Vector2(base.position.X + 0, base.position.Y + 8), 10 + 2 * 32, Color.White, SpriteEffects.None);
			} else {
				screen.draw(sprite, new Vector2(base.position.X + 0, base.position.Y + 8), 9 + 1 * 32, Color.White, SpriteEffects.None);
			}
			if (d && dr && r) {
				screen.draw(sprite, new Vector2(base.position.X + 8, base.position.Y + 8), 10 + 1 * 32, Color.White, SpriteEffects.None);
			} else {
				screen.draw(sprite, new Vector2(base.position.X + 8, base.position.Y + 8), 10 + 3 * 32, Color.White, SpriteEffects.None);
			}
            base.Draw(sprite, screen, level);
        }
        public override void hurt(Level level, int x, int y, Mob source, int dmg, int attackDir)
        {
            hurts(level, x, y, dmg);
        }
        private void hurts(Level level, int x, int y, int dmg)
        {

             int count = random.Next(10) == 0 ? 1 : 0;
                for (int i = 0; i < count; i++)
                {
                    level.add(new ItemEntity(new ResourceItem(Resource.apple), x * 16 + random.Next(10) + 3, y * 16 + random.Next(10) + 3));
                }

           damage +=dmg;
           level.add(new SmashParticle((int)position.X+8,(int)position.Y+8));
          // level.add(new TextParticle("" + dmg, x * 16 + 8, y * 16 + 8, Color.DarkRed));
            if (damage >= life) {
                count = random.Next(2) + 1;
                for (int i = 0; i < count; i++)
                {
                    level.add(new ItemEntity(new ResourceItem(Resource.wood), x * 16 + random.Next(10) + 3, y * 16 + random.Next(10) + 3));
                }
               	level.setTile((int)position.X/16, (int)position.Y/16,new GrassTile(position), 0);
            }
        }
    }
}
