using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game1.Components;

namespace Game1.Componenets
{
    public class Player : BaseUpdateableComponent
    {
        //public static int Speed = 5;

        public Player(Game1 game, ref Texture2D texture, int x, int y)
            :base(game, ref texture, x, y, 5)
        {
            game.Services.GetService(typeof(Camera));
        }

        public override void Update(GameTime gameTime)
        {
            Shell.Offset(GameWorld.SPEED, GameWorld.SPEED);
        }

        public override void Draw(GameTime gameTime)
        {
            _game.SpriteBatch.Draw(_texture, new Vector2(Shell.X, Shell.Y), null, Color.White, 0f, new Vector2(0,0), Scale, SpriteEffects.None, 0f);
        }
    }
}