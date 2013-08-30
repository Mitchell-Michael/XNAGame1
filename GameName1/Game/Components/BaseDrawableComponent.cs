using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game1.Components
{
    public class BaseDrawableComponent : DrawableGameComponent
    {
        protected Game1 _game;
        protected Texture2D _texture;
        protected Vector2 Scale;

        public Rectangle Shell;

        public int Depth;

        public BaseDrawableComponent(Game1 game, ref Texture2D texture, int x, int y)
            : base(game)
        {
            _game = game;
            _texture = texture;
            var position = new Vector2(x, y);
            Scale = new Vector2((float)GameWorld.Width / (float)(texture.Width * GameWorld.GRID_X), (float)GameWorld.Height / (float)(texture.Height * GameWorld.GRID_Y));
            position.X = x * _texture.Width;
            position.Y = y * _texture.Height;
            position = Vector2.Multiply(position, Scale);
            Shell = new Rectangle((int)position.X, (int)position.Y, (int)(position.X + _texture.Width * Scale.X), (int)(position.Y + _texture.Height * Scale.Y));
            Depth = GameWorld.TERRAIN_LEVEL;
        }
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}