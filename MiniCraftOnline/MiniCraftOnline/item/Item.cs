using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Totally_Recoded_Minicraft.entity;
using Totally_Recoded_Minicraft.gfx;
using Totally_Recoded_Minicraft.level;

namespace Totally_Recoded_Minicraft.item
{
    public class Item
    {
        public int getColor()
        {
            return 0;
        }

        public virtual int getSprite()
        {
            return 0;
        }

        public void onTake(ItemEntity itemEntity)
        {
        }

        public void renderInventory(Screen screen, int x, int y)
        {
        }

        public bool interact(Player player, Entity entity, int attackDir)
        {
            return false;
        }

        public void renderIcon(Screen screen, int x, int y)
        {
        }

        public bool interactOn(Tile tile, Level level, int xt, int yt, Player player, int attackDir)
        {
            return false;
        }

        public bool isDepleted()
        {
            return false;
        }

        public bool canAttack()
        {
            return false;
        }

        public int getAttackDamageBonus(Entity e)
        {
            return 0;
        }

        public String getName()
        {
            return "";
        }

     /*   public bool matches(Item item)
        {
            return item.getClass() == getClass();
        }*/
    }
}
