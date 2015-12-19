using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Totally_Recoded_Minicraft.entity;
using Totally_Recoded_Minicraft.gfx;
using Totally_Recoded_Minicraft.level.tile;
using Totally_Recoded_Minicraft.levelgen;

namespace Totally_Recoded_Minicraft.level
{
    public class Level
    {
        Game1 game;
        public int w, h;
        public int grassColor = 141;
        public int dirtColor = 322;
        public int sandColor = 550;
        public List<Tile> tiles;
        public List<Tile> tiles2;
        public List<Tile> tiles3;
        public List<Entity> entities;
        public List<List<Entity>> entitiesInTiles;
        public Player player;
        string seed;
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random((int)((unchecked(DateTime.Now.Ticks.GetHashCode()))));
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public Level(Game1 game, int w, int h)
        {
            entities= new List<Entity>();
            this.game = game;
            this.w = w;
            this.h = h;
           seed = RandomString(6);
			List<Tile> maps = LevelGen.createAndValidateTopMap(w, h,seed);
            this.tiles3 = maps;
            this.tiles = maps;
            entitiesInTiles = new List<List<Entity>>();
            for (int i = 0; i < w * h; i++)
            {
             //   entitiesInTiles[i] = new List<Entity>();
                entitiesInTiles.Add(new List<Entity>());
            }
        }
        public void Update(GameTime Time)
        {
            this.UpdateEntitys(Time);
        }
        public void UpdateEntitys(GameTime time)
        {
            rowSprites.Add(game.player);
            try
            {
                foreach (Entity e in entities)
                {
                    if(!e.removed)
                    e.Update(time, this);
                }
            }
            catch { }
            rowSprites.Clear();
        }
        public void DrawMap(SpriteBatch sprite,Screen screen)
        {
			Texture2D tex= new Texture2D(game.GraphicsDevice,game.mapWidth,game.mapHeigth);
                 Texture2D texblue = new Texture2D(game.GraphicsDevice, game._width ,game._height);
                //  int[] pixels = new int[w * h];
                 Color[] pixels = new Color[w * h];
                  int i = 0;     
            foreach(Tile t in tiles)
                    {
                //          if (t.GetType() == typeof(WaterTile)) pixels[i] = 0x000080;
               //           if (t.GetType() == typeof(GrassTile)) pixels[i] = 0x208020;
				if (t.GetType() == typeof(WaterTile))   pixels[i] = new Color(22,22,137);
				if (t.GetType () == typeof(GrassTile))	pixels [i] = new Color (96,165,96);
				if (t.GetType () == typeof(SandTile))   pixels [i] = new Color (226, 226, 111);
				if (t.GetType() == typeof(TreeTile)) pixels[i] =new Color (50,119,50);
				if (t.GetType() == typeof(RockTile)) pixels[i] =new Color (81,81,81);

				if (t.GetType () == typeof(FlowerTile))
	pixels [i] = new Color (240,240,240);
                       // if (t.GetType() == typeof(FlowerTile)) pixels[i] = Color.LightCyan;
                          i++;
                      }
			int x = 0;
             //     tex.SetData<int>(pixels);
			foreach(Tile t in tiles)
			{
				if (new Rectangle(((int)game.player.position.X + 4), (int)(game.player.position.Y + 13), 8, 3).Intersects (new Rectangle ((int)t.position.X, (int)t.position.Y, 16, 16))) 
				{

					pixels [x] = Color.Violet;
					break;
				}
				x++;
			}
            tex.SetData<Color>(pixels);
         Color[] pixels2 = new Color[game._width * game._height];
            for (int l = 0; l < game._width * game._height;l++ )
            {
				pixels2[l] = new Color(22,22,137);
            }
            texblue.SetData<Color>(pixels2);
                sprite.Draw(texblue, new Vector2(0, 0), Color.White);

                  sprite.Draw(tex, new Vector2(16, 0), Color.White);
                  Font.draw(sprite, "Map", screen, game._width/2-15, 0, Color.GreenYellow);
                  Font.draw(sprite, "Seed: " + seed, screen, game._width / 2 - 15, 100, Color.GreenYellow);
	x = 0;
			foreach(Tile t in tiles)
			{
				if (new Rectangle(((int)game.player.position.X + 4), (int)(game.player.position.Y + 13), 8, 3).Intersects (new Rectangle ((int)t.position.X, (int)t.position.Y, 16, 16))) 
				{
					
					int posY=x/w;// 200/100 = 2
					//Console.WriteLine(posY)
					int posX =x % w; // 0
				Font.draw (sprite, "Player", screen, posX-5, posY-10, Color.Violet);
					break;
				}
				x++;
			}
        }
        private List<Entity> rowSprites = new List<Entity>();
        public void DrawTiles(SpriteBatch sprite, Screen screen, int xScroll, int yScroll)
        {
            int i = 0;
            foreach (Tile t in tiles3)
            {
                if (new Rectangle((int)t.position.X, (int)t.position.Y, 16, 16).Intersects(new Rectangle(screen.game.cam.recCamera().X - 100, screen.game.cam.recCamera().Y - 100, screen.game.cam.recCamera().Width + 150, screen.game.cam.recCamera().Height + 100)))
                    tiles[i].Draw(sprite, screen, this);
                //   GetEnumerator
                i++;
            }
        }
        public void DrawSprites(SpriteBatch sprite, Screen screen, int xScroll, int yScroll)
        {
            int xo = xScroll >> 4;
            int yo = yScroll >> 4;
            int w = (screen.w + 15) >> 4;
            int h = (screen.h + 15) >> 4;
            screen.setOffset(xScroll, yScroll);

          //rowSprites.Add(screen.game.player);
      //      entitiesr = entities;
    //        rowSprites = entities;
			if (entities.Count > 0) {
                sortAndRender(sprite, screen,entities);
			}
			rowSprites.Clear();
            //  }
            screen.setOffset(0, 0);
            //   }
        }
        private void sortAndRender(SpriteBatch sprite, Screen screen, List<Entity> list)
        {
            // Collections.sort(list, spriteSorter);
            for (int i = 0; i < list.Count; i++)
            {
                if (!list[i].removed)
                list[i].Draw(sprite, screen);
            }
        }
        public void add(Entity entity) 
        {
		if (entity.GetType() ==typeof(Player)) {
            player = (Player)entity;
		}
		entity.removed = false;
		entities.Add(entity);
		entity.init(this);


	}


        public void setTile(int x, int y, Tile t, int dataVal)
        {
            int num = (int)x + (int)(y * w);
            tiles[num] = new GrassTile(new Vector2(tiles[num].position.X, tiles[num].position.Y));
        }
        internal Tile getTile(Vector2 p)
        {
            int num = (int)p.X + (int)(p.Y * w);
            return tiles[num];

        }
    }
}


