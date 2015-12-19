using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Totally_Recoded_Minicraft.gfx
{
    class Font
    {
        private static String chars = "" + //
        "ABCDEFGHIJKLMNOPQRSTUVWXYZ      " + //
        "0123456789.,!?'\"-+=/\\%()<>:;     " + //
        "";
        public static void draw(SpriteBatch sprite,String msg, Screen screen, int x, int y, Color col)
        {
            msg = msg.ToUpper();
            for (int i = 0; i < msg.Length; i++)
            {
                int ix = chars.IndexOf(msg[i]);
                if (ix >= 0)
                {
                    screen.draw(sprite, new Microsoft.Xna.Framework.Vector2(x + i * 8, y), ix + 30 * 32, col,  SpriteEffects.None);
            //        screen.render(x + i * 8, y, ix + 30 * 32, col, 0);
                }
            }
        }
        public static void DrawFrame()
        {

        }
    }
}
