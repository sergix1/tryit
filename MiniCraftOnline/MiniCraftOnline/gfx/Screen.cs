using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Totally_Recoded_Minicraft.entity;

namespace Totally_Recoded_Minicraft.gfx
{
    public class Screen
    {
        public int xOffset;
        public int yOffset;

        public int BIT_MIRROR_X = 0x01;
        public int BIT_MIRROR_Y = 0x02;

        public int w, h;
        Resources resources;
        public Game1 game{ get;private set;}
        public int[] pixels;
        SpriteSheet sheet;
        public Screen(int w, int h, Resources resources, Game1 game)
        {
            this.game = game;
            this.w = w;
            this.h = h;
            this.resources = resources;
            sheet = new SpriteSheet(resources.icons);
            pixels = new int[resources.icons.Width * resources.icons.Height];
        }
        public void clear(int color)
        {
            for (int i = 0; i < pixels.Length; i++)
                pixels[i] = color;
        }
        
        public void draw(SpriteBatch batch, Vector2 Position, int tile,Color col,  SpriteEffects effect)
        {
            Position.X -= xOffset;
            Position.Y -= yOffset;
            bool mirrorX = (getBits(effect) & BIT_MIRROR_X) > 0;
            bool mirrorY = (getBits(effect) & BIT_MIRROR_Y) > 0;
		int xTile = tile % 32;
		int yTile = tile / 32;
        int toffs = xTile * 8 + yTile * 8 * sheet.width;

        //Console.WriteLine(col);
        batch.Draw(game._resources.icons, new Vector2(Position.X,Position.Y), new Rectangle(xTile*8, yTile * 8, 8, 8),col, 0f, Vector2.Zero, 1f, effect, 0f);
        }
        public void setOffset(int xOffset, int yOffset)
        {
            this.xOffset = xOffset;
            this.yOffset = yOffset;
        }
        public int getBits(SpriteEffects effect)
        {
            if (effect == SpriteEffects.None) return 0;
            else return 1;

        }
    }
}
