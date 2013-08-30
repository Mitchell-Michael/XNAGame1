using Game1.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game1
{
    public class Camera
    {
        protected Rectangle _viewport;

        private Point _lastPosition;

        public Camera(ref Rectangle target)
        {
            ChangeTarget(ref target);
        }

        public void ChangeTarget(ref Rectangle target)
        {
            _lastPosition = new Point(target.Center.X, target.Center.Y);
            _viewport = new Rectangle(target.Center.X - GameWorld.Width / 2, target.Center.Y - GameWorld.Height / 2, GameWorld.Width, GameWorld.Height);
        }

        public void Draw(BaseDrawableComponent component, GameTime gameTime)
        {
            if (_viewport.Contains(component.Shell))
            {
                component.Draw(gameTime);
            }
        }
        
        public void Update(GameTime gameTime, ref Rectangle target)
        {
            _viewport.Offset(target.Center.X - _lastPosition.X, target.Center.Y - _lastPosition.Y);
            _lastPosition = target.Center;
        }
    }
}