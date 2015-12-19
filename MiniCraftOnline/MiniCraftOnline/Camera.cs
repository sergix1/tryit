using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Totally_Recoded_Minicraft
{
    public class Camera
    {
        protected float _zoom; //Camera Zoom Value
       public Matrix _transform; //Camera Transform Matrix
        protected Matrix _inverseTransform; //Inverse of Transform Matrix
        public Vector2 _pos; //Camera Position
        protected float _rotation; //Camera Rotation Value (Radians)
        public Viewport _viewport; //Cameras Viewport
        public Game1 game;
        public Camera(Viewport viewport,Game1 game)
        {
            this.game = game;
            this._viewport = viewport;
        }
        public Rectangle recCamera()
        {
            _pos = new Vector2((int)game.player.position.X - ((int)game._width / 2)+10, (int)game.player.position.Y - ((int)game._height / 2)+15);
            if (_pos.X < 0)
            {
                _pos.X = 0;
            }
            if (_pos.Y < 0)
            {
                _pos.Y = 0;
            }

		//	8*
			if (_pos.Y > game.mapHeigth*16-game._width+16  ) {
				_pos.Y = game.mapHeigth*16-game._width+16;
			}
			if (_pos.X >game.mapWidth*16-game._width ) {
				_pos.X = game.mapWidth*16-game._width ;
			}
       /*     if(game.currentlevel.w*16<_pos.X)
            {
                _pos.X = game.currentlevel.bigX*16;
            }
                 if(game.currentlevel.h*16<_pos.Y)
            {
                _pos.Y=game.currentlevel.bigY*16;
            }*/
            return new Rectangle((int)_pos.X, (int)_pos.Y, game._width, game._height);
        }

       public void Update(GameTime time)
        {

            _transform =   Matrix.CreateScale(new Vector3(game._scale, game._scale, 1))*    
                Matrix.CreateTranslation((int)-recCamera().X *game._scale , ((int)-recCamera().Y) *game._scale , 0) *
        Matrix.CreateTranslation(new Vector3(_viewport.X * 0.5f,
           _viewport.Y * 0.5f, 0)); ;
        }


    }
}
