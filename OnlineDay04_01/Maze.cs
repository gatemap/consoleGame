using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace OnlineDay04_01
{
    class Maze
    {
        public enum state
        {
            Wall, Road, Player, State_max
        };

        int[,] map =  new int[50, 50];

        public void Render()
        {
            mapPrinting();
        }

        void mapPrinting()
        {
            mapSetting();

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == (int)state.Wall)
                    {
                        ForegroundColor = ConsoleColor.White;
                        Write("■");
                    }
                    else if (map[i, j] == (int)state.Road)
                    {
                        ForegroundColor = ConsoleColor.Black;
                        Write("■");
                    }
                    else if (map[i, j] == (int)state.Player)
                    {
                        ForegroundColor = ConsoleColor.DarkYellow;
                        Write("★");
                    }
                }
                WriteLine();
            }

            CursorVisible = false;
        }

        void mapSetting()
        {
            Random rnd = new Random();
            SetCursorPosition(0, 0);

            for(int i=1;i<map.GetLength(0);i++)
            {
                for(int j=1;j<map.GetLength(1);j++)
                {
                    if (rnd.Next(100) < 55)
                        map[i, j] = (int)state.Road;
                    else
                        map[i, j] = (int)state.Wall;
                }
            }

            makeBorderLine();

            map[0, 1] = (int)state.Player;
            map[1, 1] = (int)state.Road;
            map[map.GetLength(0)-1, map.GetLength(1)-2] = (int)state.Road;
        }

        void makeBorderLine()
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                map[0, j] = (int)state.Wall;
                map[map.GetLength(0) - 1, j] = (int)state.Wall;
            }
            for (int i = 1; i < map.GetLength(0); i++)
            {
                map[i, 0] = (int)state.Wall;
                map[i, map.GetLength(1) - 1] = (int)state.Wall;
            }
        }
    }
}
