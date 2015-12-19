using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Totally_Recoded_Minicraft.gfx
{
    public class Resources
    {
        public Texture2D icons{get ; private set ;}
        public Texture2D icons2 { get; private set; }
        public Resources(ContentManager Content)
        {
            icons = Content.Load<Texture2D>("icons");
            icons2=Content.Load<Texture2D>("icons2");
        }

    }
}
