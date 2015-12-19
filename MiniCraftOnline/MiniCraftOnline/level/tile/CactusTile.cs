using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MiniCraftOnline
{
	public class CactusTile : Totally_Recoded_Minicraft.level.Tile
	{
		public CactusTile(Vector2 position):base(position)
		{
			connectsToSand = true;
		}
		public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch sprite, Totally_Recoded_Minicraft.gfx.Screen screen, Totally_Recoded_Minicraft.level.Level level)
		{
			base.Draw(sprite, screen, level);
			screen.draw(sprite, new Vector2(base.position.X, base.position.Y), 26, Color.White, SpriteEffects.None);
			screen.draw(sprite, new Vector2(base.position.X + 8, base.position.Y), 27, Color.White, SpriteEffects.None);
			screen.draw(sprite, new Vector2(base.position.X + 0, base.position.Y + 8), 28, Color.White, SpriteEffects.None);
			screen.draw(sprite, new Vector2(base.position.X + 8, base.position.Y + 8), 29, Color.White, SpriteEffects.None);

			screen.draw(sprite, new Vector2(base.position.X, base.position.Y),8 + 2 * 32, Color.White, SpriteEffects.None);
			screen.draw(sprite, new Vector2(base.position.X+8, base.position.Y),9 + 2 * 32, Color.White, SpriteEffects.None);
			screen.draw(sprite, new Vector2(base.position.X, base.position.Y+8),8 + 3 * 32, Color.White, SpriteEffects.None);
			screen.draw(sprite, new Vector2(base.position.X+8, base.position.Y+8),9 + 3 * 32, Color.White, SpriteEffects.None);
		}
	}
}

