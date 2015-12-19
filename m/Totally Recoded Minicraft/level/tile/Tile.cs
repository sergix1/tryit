using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Totally_Recoded_Minicraft.entity;
using Totally_Recoded_Minicraft.gfx;
using Totally_Recoded_Minicraft.level.tile;

namespace Totally_Recoded_Minicraft.level
{
   public class Tile
    {
       public Vector2 position;
       public bool connectsToGrass = false;
       public bool connectsToSand = false;
       public bool connectsToLava = false;
       public bool connectsToWater = false;
        public Tile(Vector2 position)
        {
            this.position = position;
         //   if (tiles[id] != null) Console.WriteLine("Duplicate tile ids!");
            //tiles[id] = this;
        }
        public virtual void Update(GameTime time)
        {

        }
        public virtual void hurt(Level level, int x, int y, Mob source, int dmg, int attackDir)
        {
        }

        public virtual void Draw(SpriteBatch sprite,Screen screen,Level level)
        {
       /*     if(walkable==0)
            {
                sprite.Draw(screen.game.collision, new Vector2(position.X, position.Y), new Rectangle(0, 0, 8, 8), Color.White * 0.5f, 0f, Vector2.Zero, 1, SpriteEffects.None, 0f);
                sprite.Draw(screen.game.collision, new Vector2((position.X+8) , position.Y ), new Rectangle(0, 0, 8, 8), Color.White * 0.5f, 0f, Vector2.Zero, 1, SpriteEffects.None, 0f);
                sprite.Draw(screen.game.collision, new Vector2((position.X ) , (position.Y+8 )), new Rectangle(0, 0, 8, 8), Color.White * 0.5f, 0f, Vector2.Zero, 1, SpriteEffects.None, 0f);
               sprite.Draw(screen.game.collision, new Vector2((position.X + 8), (position.Y+8)), new Rectangle(0, 0, 8, 8), Color.White * 0.5f, 0f, Vector2.Zero,1, SpriteEffects.None, 0f);
            }*/
        }
        public static int tickCount = 0;
        protected Random random = new Random();

        public static Tile[] tiles = new Tile[256];
       // public static Tile grass = new GrassTile(0);
        public int walkable { get; set; }
        public byte id { get; set; }
    }
}
