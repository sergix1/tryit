using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Totally_Recoded_Minicraft.entity;
using Totally_Recoded_Minicraft.level;

namespace Totally_Recoded_Minicraft.item
{
    public class Resource
    {
        public static Resource apple = new Resource("Apple", 9 + 4 * 32, Color.White);
        public static Resource wood = new Resource("Wood", 1 + 4 * 32, Color.White);
        public Color color;
        public String name;
        public int sprite;
        public Resource(String name, int sprite, Color color)
        {
            this.name = name;
            this.sprite = sprite;
            this.color = color;
        }
        public bool interactOn(Tile tile, Level level, int xt, int yt, Player player, int attackDir)
        {
            return false;
        }
    }
}
