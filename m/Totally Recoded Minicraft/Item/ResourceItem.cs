using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Totally_Recoded_Minicraft.entity;
using Totally_Recoded_Minicraft.level;
using Totally_Recoded_Minicraft.item;
using Totally_Recoded_Minicraft.gfx;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Totally_Recoded_Minicraft.item
{
    class ResourceItem : Item
    {
        public Resource resource;
	public int count = 1;

	public ResourceItem(Resource resource) {
		this.resource = resource;
	}

	public ResourceItem(Resource resource, int count) {
		this.resource = resource;
		this.count = count;
	}

	public Color getColor() {
		return resource.color;
	}
	public override int getSprite() {
		return resource.sprite;
	}

	public void renderIcon(SpriteBatch batch,Screen screen, int x, int y) {
		screen.draw(batch,new Microsoft.Xna.Framework.Vector2(x, y), resource.sprite, resource.color, SpriteEffects.None);
	}

	/*public void renderInventory(SpriteBatch sprite,Screen screen, int x, int y) {
		screen.render(x, y, resource.sprite, resource.color, 0);
		Font.draw(resource.name, screen, x + 32, y, Color.get(-1, 555, 555, 555));
		int cc = count;
		if (cc > 999) cc = 999;
		Font.draw("" + cc, screen, x + 8, y, Color.get(-1, 444, 444, 444));
	}
        */
	public String getName() {
		return resource.name;
	}

	public void onTake(ItemEntity itemEntity) {
	}

	public bool interactOn(Tile tile, Level level, int xt, int yt, Player player, int attackDir) {
		if (resource.interactOn(tile, level, xt, yt, player, attackDir)) {
			count--;
			return true;
		}
		return false;
	}

	public bool isDepleted() {
		return count <= 0;
	}

    }
}
