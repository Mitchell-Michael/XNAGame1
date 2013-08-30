using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game1.Components
{
    public class BaseUpdateableComponent : BaseDrawableComponent
    {

        public int Speed;

        public BaseUpdateableComponent(Game1 game, ref Texture2D texture, int x, int y, int speed)
            :base(game, ref texture, x, y)
        {
            Speed = speed;
            Depth = GameWorld.GAME_LEVEL;
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}