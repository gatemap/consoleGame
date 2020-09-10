using System;
using System.Collections.Generic;

namespace OnlineDay04_01
{
    class GameManager
    {
        public bool gameState = true;

        Maze maze;

        public void Init()
        {
            maze = new Maze();
            maze.mapPrinting();
        }

        public void Update()
        {
            if (!maze.gameStart)
                gameState = false;
            else
                maze.Update();
        }

        public void Render()
        {
            maze.Render();
        }
    }
}
