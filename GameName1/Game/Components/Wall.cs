using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game1.Components
{
    public class Wall : BaseDrawableComponent, IDrawable
    {

        public Wall(Game1 game, ref Texture2D texture, int x, int y)
            :base(game, ref texture, x, y) 
        { }

        public override void Draw(GameTime gameTime)
        {
            _game.SpriteBatch.Draw(_texture, new Vector2(Shell.X, Shell.Y), null, Color.White, 0f, new Vector2(0,0), Scale, SpriteEffects.None, 0f);
            base.Draw(gameTime);
        }
    }
}