using System.Collections.Generic;

namespace Ontwikkelopdracht_Game
{
    public struct LevelPreset
    {
        public static List<GameObject> Test => new List<GameObject>(OuterWalls)
        {
            new Player
            {
                X = 50,
                Y = 50
            },
            new Bot
            {
                X = 500,
                Y = 500,
                BaseCooldown = 100
            },
            new Event
            {
                X = 350,
                Y = 350,
                Action = GameEvent.Win
            },
            new Wall
            {
                X = 150,
                Y = 150
            },
            
        };

        public static List<GameObject> One => new List<GameObject>(OuterWalls)
        {
            new Player
            {
                X = 50,
                Y = 50
            },
            new Event
            {
                X = 800,
                Y = 600,
                Action = GameEvent.Win
            },
            new Wall
            {
                X = 400,
                Y = 300,
                Width = 50,
                Height = World.Height - 300
            },
            new Wall
            {
                X = 500,
                Y = 200,
                Width = 300,
                Height = 50
            },
            new Bot
            {
                X = 300,
                Y = 650,
                BaseCooldown = 100
            },
            new Bot
            {
                X = 700,
                Y = 300,
                BaseCooldown = 100
            }
        };

        private static List<GameObject> OuterWalls => new List<GameObject>
        {
            new Wall
            {
                X = 0,
                Y = 0,
                Width = World.Width,
                Height = 50
            },
            new Wall
            {
                X = 0,
                Y = 0,
                Width = 50,
                Height = World.Height
            },
            new Wall
            {
                X = 0,
                Y = World.Height - 50,
                Width = World.Width,
                Height = 50
            },
            new Wall
            {
                X = World.Width - 50,
                Y = 0,
                Width = 50,
                Height = World.Height
            }
        };
    }
}