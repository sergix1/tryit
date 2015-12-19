using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Totally_Recoded_Minicraft.gfx;
using Totally_Recoded_Minicraft.level;

namespace Totally_Recoded_Minicraft.entity
{
   public  class Entity
    {
        public Vector2 position;
        public int xr = 6;
        public int yr = 6;
        public Level level;
        public bool removed;
       public  Random random = new Random();
        public virtual void Update(GameTime time, Level level)
        {

        }
      public virtual void Draw(SpriteBatch sprite,Screen screen)
        {

        }
      public void remove()
      {
          removed = true;
      }
        internal bool move(int xa, int ya,Level level)
        {
            if (placeIsFree(new Vector2(position.X+xa,position.Y),level ))
            {
                position.X += xa;
     
            }
            if (placeIsFree(new Vector2(position.X , position.Y + ya), level))
            {
                position.Y += ya;
            }
           return true;
        }

       public void init(Level level) {
		this.level = level;
	}

       public bool placeIsFree(Vector2 positionToMove,Level level)
        {
            int i = 0;
           foreach(level.Tile t in level.tiles)
           {
               if(level.tiles[i].walkable==0)
               {

                   if (new Rectangle(((int)t.position.X), ((int)t.position.Y), 16, 16).Intersects(new Rectangle(((int)positionToMove.X + 4), (int)(positionToMove.Y + 13), 8, 3)))
                   {
                       return false;
                   }
               }
               i++;
           }
            return true;
        }
    }
}
