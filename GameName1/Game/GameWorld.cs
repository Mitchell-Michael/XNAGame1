using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using System.IO;
using Game1.Components;

namespace Game1
{
    public class GameWorld
    {
        public static int GRID_X = 19;
        public static int GRID_Y = 12;

        public static int SPEED = 1;

        public static int Width { get; private set; }
        public static int Height { get; private set; }

        public static readonly int BACKGROUND_LEVEL = 0;
        public static readonly int TERRAIN_LEVEL = 1;
        public static readonly int GAME_LEVEL = 2;
        public static readonly int PROJECTILE_LEVEL = 3;

        public int LevelNumber { get; private set; }
        public int[,] LevelData { get; private set; }

        public int MaxX { get; set; }
        public int MaxY { get; set; }

        public GameWorld(Game game, int level)
        {
            Width = game.Window.ClientBounds.Width;
            Height = game.Window.ClientBounds.Height;
            LevelNumber = level;
            LevelData = LoadLevel(level);
        }

        private int[,] LoadLevel(int level)
        {
            var lines = File.ReadAllLines("../../../Levels/" + level + ".txt");
            MaxY = lines.Length;
            MaxX = lines[0].Split(' ').Length;
            var levelData = new int[MaxX, MaxY];
            for (int y = 0; y < MaxY; y++)
            {
                var data = lines[y].Split(' ');
                for (int x = 0; x < MaxX; x++)
                {
                    levelData[x, y] = int.Parse(data[x]);
                }
            }
            return levelData;
        }
        public bool PointInGrid(Vector2 point, int gridx, int gridy)
        {
            return new Rectangle((int)point.X, (int)point.Y, Width, Height).Contains(new Rectangle((int)(gridx * Width), (int)(gridy * Height), Width, Height));
        }
    }
}