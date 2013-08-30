#region Using Statements
using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using Game1.Components;
using Game1.Componenets;
#endregion

namespace Game1
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        public SpriteBatch SpriteBatch { get; set; }
        Texture2D box;
        Texture2D circle;
        private int x = 0;
        private int y = 0;

        private IList<BaseDrawableComponent> levelDrawComponenents;
        private IList<BaseUpdateableComponent> levelUpdateComponenet;

        private Camera _camera;

        private Player _player;

        public Game1()
            : base()
        {
            try
            {
                graphics = new GraphicsDeviceManager(this);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
            box = Content.Load<Texture2D>("bluebox.png");
            circle = Content.Load<Texture2D>("bluedot.png");
            StartGame(1);
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (var component in levelUpdateComponenet)
            {
                component.Update(gameTime);
            }

            _camera.Update(gameTime, ref _player.Shell);
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            SpriteBatch.Begin();

            foreach (var component in levelDrawComponenents)
            {
                _camera.Draw(component, gameTime);
            }
            SpriteBatch.End();
        }

        private void StartGame(int level)
        {
            var world = new GameWorld(this, 1);
            levelDrawComponenents = new List<BaseDrawableComponent>();
            levelUpdateComponenet = new List<BaseUpdateableComponent>();
            var data = world.LevelData;

            for ( int y = 0; y < world.LevelData.GetLength(1); y++)
            {
                for (int x = 0; x < world.LevelData.GetLength(0); x++)
                {
                    switch (world.LevelData[x,y])
                    {
                        case 1:
                            levelDrawComponenents.Add(new Wall(this, ref box, x, y));
                            break;
                        case 2:
                            _player = new Player(this, ref circle, x, y);
                            levelDrawComponenents.Add(_player);
                            levelUpdateComponenet.Add(_player);
                            _camera = new Camera(ref _player.Shell);
                            Services.AddService(typeof(Camera), _camera);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void EndGame()
        {
            Components.Clear();
        }
    }
}