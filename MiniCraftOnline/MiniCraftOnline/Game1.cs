using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using Totally_Recoded_Minicraft.entity;
using Totally_Recoded_Minicraft.gfx;
using Totally_Recoded_Minicraft.level;

namespace Totally_Recoded_Minicraft
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public const string _name ="Minicraft Recoded";
        public int _width = 160;
        public int _height = 120;
        public int _scale=3;
        public Resources _resources;
        public Player player;
        public Screen screen;
        public Level currentlevel;
        private int[] colors = new int[256];
        private int[] pixels;
        Texture2D image;
        public Texture2D collision;
        public Camera cam;
		public int mapWidth=128;
		public int mapHeigth=128;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.Window.Title=_name;
			this.graphics.IsFullScreen = false;
             this.graphics.PreferredBackBufferWidth = _width *_scale;
            this.graphics.PreferredBackBufferHeight = _height *_scale;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            cam = new Camera(new Viewport(0, 0, _width * (int)_scale, _height * (int)_scale), this);
            base.Initialize();
        }
        public void restartGame()
        {
            
            screen = new Screen(_width,_height,_resources,this);
            player = new Player(this);
			currentlevel = new Level(this, this.mapWidth, this.mapHeigth);
            player.findStartPos(currentlevel);
           currentlevel.add(player);
        }
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            _resources = new Resources(Content);
            collision = Content.Load<Texture2D>("colisions");
            image = new Texture2D(GraphicsDevice, _width, _height);
            pixels = new int[_width * _height];
            image.GetData<int>(pixels);
            restartGame();
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

		bool keyres;
        protected override void Update(GameTime gameTime)
        {
    //        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
   //             Exit();
            if (focus())
            {
                cam.Update(gameTime);
                currentlevel.Update(gameTime);
                // TODO: Add your update logic here

                base.Update(gameTime);
            }
			if (Keyboard.GetState ().IsKeyDown (Keys.F5)) {
				if (keyres) {
					keyres = false;
					restartGame ();
				}
			}
			if (Keyboard.GetState ().IsKeyUp (Keys.F5)) {
				keyres = true;
			}
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// 
        public bool focus()
        {
            return this.IsActive;
        }
        private void renderFocus()
        {
            string msg = "Click to focus!";
            int xx = (_width - msg.Length * 8) / 2;
            int yy = (_height - 8) / 2;
            int w = msg.Length;
            int h = 1;

            screen.draw(spriteBatch, new Vector2(xx - 8, yy - 8), 0 + 13 * 32, Color.White, SpriteEffects.None);
            screen.draw(spriteBatch, new Vector2(xx + w * 8, yy - 8), 0 + 13 * 32, Color.White, SpriteEffects.FlipHorizontally);
            screen.draw(spriteBatch, new Vector2(xx - 8, yy + 8), 0 + 13 * 32, Color.White, SpriteEffects.FlipVertically);
            screen.draw(spriteBatch, new Vector2(xx + w * 8, yy + 8), 0 + 13 * 32, Color.White, SpriteEffects.FlipVertically | SpriteEffects.FlipHorizontally);
            screen.draw(spriteBatch, new Vector2(xx + w * 8, yy + 8), 0 + 13 * 32, Color.White, SpriteEffects.FlipVertically | SpriteEffects.FlipHorizontally);
            for (int x = 0; x < w; x++)
            {
                screen.draw(spriteBatch, new Vector2(xx + x * 8, yy - 8), 1 + 13 * 32, Color.White, SpriteEffects.None);
                screen.draw(spriteBatch, new Vector2(xx + x * 8, yy + 8), 1 + 13 * 32, Color.White, SpriteEffects.FlipVertically);
                screen.draw(spriteBatch, new Vector2(xx + w * 8, yy + 8), 0 + 13 * 32, Color.White, SpriteEffects.FlipVertically | SpriteEffects.FlipHorizontally);
            }
            for (int y = 0; y < h; y++)
            {
                screen.draw(spriteBatch, new Vector2(xx - 8, yy + y * 8), 2 + 13 * 32, Color.White, SpriteEffects.None);
                screen.draw(spriteBatch, new Vector2(xx + w * 8, yy + y * 8), 2 + 13 * 32, Color.White, SpriteEffects.FlipHorizontally);
            }
            Font.draw(spriteBatch,msg, screen, xx, yy, Color.White);
            /*    


       */
           // if ((tickCount / 20) % 2 == 0)
           // {
             //   Font.draw(msg, screen, xx, yy, Color.get(5, 333, 333, 333));
           /* }
            else
            {
                Font.draw(msg, screen, xx, yy, Color.get(5, 555, 555, 555));
            }*/
		}
		bool keymap;
		bool pressm;
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.Black);
          spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, cam._transform);
         //   currentlevel.Draw(spriteBatch);
            currentlevel.DrawTiles(spriteBatch, screen, 0, 0);
            currentlevel.DrawSprites(spriteBatch, screen, 0, 0);
            
            if (!focus()) 
              renderFocus();
        
            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, Matrix.CreateScale(new Vector3(_scale, _scale, 1)));
           drawGui();
            spriteBatch.End();
            base.Draw(gameTime);
        }

        private void drawGui()
        {
            for (int y = 0; y < 2; y++)
            {
                for (int x = 0; x < 20; x++)
                {
                    screen.draw(spriteBatch,new Vector2(x * 8, screen.h - 16 + y * 8), 18*8, Color.Black, 0);
                }
            }
            for (int i = 0; i < player.maxHealth; i++)
            {
                if (i < player.health)
                    screen.draw(spriteBatch, new Vector2(i * 8, screen.h - 16), 0 + 12 * 32, Color.White, 0);
                else
                    screen.draw(spriteBatch, new Vector2(i * 8, screen.h - 16), 0 + 11 * 32, Color.White, 0);


            }
            for (int i = 0; i < player.maxStamina; i++)
            {
                if (i < player.stamina)
                    screen.draw(spriteBatch,new Vector2(i * 8, screen.h - 8), 1 + 12 * 32, Color.White, 0);
                else
                    screen.draw(spriteBatch,new Vector2(i * 8, screen.h - 8), 1 + 11 * 32, Color.White, 0);
            }
			if (Keyboard.GetState ().IsKeyDown (Keys.M)) {
				if (pressm) {
					keymap = !keymap;
					pressm = false;
				}


			}
			if(keymap)
				currentlevel.DrawMap(spriteBatch,screen);
			if (Keyboard.GetState ().IsKeyUp (Keys.M)) {
				pressm = true;
			}
      //   currentlevel.DrawMap(spriteBatch,screen);

        }
    }
}
