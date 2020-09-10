using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDay04_01
{
    class GameManager
    {
        public bool gameState = true;

        Maze maze;
        ConsoleKeyInfo cKey;

        public void Init()
        {
            maze = new Maze();
        }

        public void Update()
        {
            if (Console.KeyAvailable)
            {
                cKey = Console.ReadKey();

                switch (cKey.Key)
                {
                    case ConsoleKey.S:
                        gameState = false;
                        break;
                }
            }
        }

        public void Render()
        {
            maze.Render();
        }
    }
}
