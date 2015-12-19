using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Totally_Recoded_Minicraft.level;

namespace Totally_Recoded_Minicraft.entity
{
   public class Mob : Entity
    {
       public int walkDist;
       public int dir;
        internal bool move(int xa, int ya,Level level)
        {
            if (xa != 0 || ya != 0)
            {
                walkDist++;
                if (xa < 0) dir = 2;
                if (xa > 0) dir = 3;
                if (ya < 0) dir = 1;
                if (ya > 0) dir = 0;
            }
            return base.move(xa, ya,level);
        }
    }
}
