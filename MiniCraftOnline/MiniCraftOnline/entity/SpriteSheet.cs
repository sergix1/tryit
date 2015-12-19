using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Totally_Recoded_Minicraft.entity
{
    class SpriteSheet
    {
        public int width, height;
        public int[] pixels;

        public SpriteSheet(Texture2D image)
        {
          pixels = new int[image.Width * image.Height];
            width = image.Width;
            height = image.Height;
            image.GetData<int>(pixels);
            for (int i = 0; i < pixels.Length; i++)
            {
                pixels[i] = (pixels[i] & 0xff) / 64;
            }
        //    pixels = image.GetData<int>(pixels);
        }
    }
}
