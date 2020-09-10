using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace OnlineDay04_01
{
    class Maze
    {
        TimeCheck time = new TimeCheck();
        public enum state
        {
            Wall, Road, Player, State_max
        };

        int[,] map =  new int[50, 50];
        int[] playerPos = new int[2];
        int distance = 0;
        public bool gameStart = true;
        ConsoleKeyInfo cKey;

        public void Update()
        {
            if (KeyAvailable)
            {
                cKey = ReadKey();

                switch (cKey.Key)
                {
                    case ConsoleKey.T:
                        gameStart = false;
                        break;
                    case ConsoleKey.R:
                        distance = 0;
                        time = new TimeCheck();
                        mapPrinting();
                        break;
                    case ConsoleKey.UpArrow:
                        if (!isWall(playerPos[0], playerPos[1] - 1))
                        {
                            map[playerPos[1] - 1, playerPos[0]] = (int)state.Player;
                            map[playerPos[1], playerPos[0]] = (int)state.Road;
                            playerPos[1]--;

                            SetCursorPosition(playerPos[0] * 2, playerPos[1] + 1);
                            ForegroundColor = ConsoleColor.Black;
                            Write("■");

                            SetCursorPosition(playerPos[0] * 2, playerPos[1] );
                            ForegroundColor = ConsoleColor.DarkYellow;
                            Write("★");
                            distance++;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (!isWall(playerPos[0], playerPos[1] + 1))
                        {
                            map[playerPos[1] + 1, playerPos[0]] = (int)state.Player;
                            map[playerPos[1], playerPos[0]] = (int)state.Road;
                            playerPos[1]++;

                            SetCursorPosition(playerPos[0] * 2, playerPos[1] - 1);
                            ForegroundColor = ConsoleColor.Black;
                            Write("■");

                            SetCursorPosition(playerPos[0] * 2, playerPos[1]);
                            ForegroundColor = ConsoleColor.DarkYellow;
                            Write("★");
                            distance++;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (!isWall(playerPos[0]+1, playerPos[1]))
                        {
                            map[playerPos[1], playerPos[0] + 1] = (int)state.Player;
                            map[playerPos[1], playerPos[0]] = (int)state.Road;
                            playerPos[0]++;

                            SetCursorPosition(playerPos[0] * 2 - 2, playerPos[1]);
                            ForegroundColor = ConsoleColor.Black;
                            Write("■");

                            SetCursorPosition(playerPos[0] * 2, playerPos[1]);
                            ForegroundColor = ConsoleColor.DarkYellow;
                            Write("★");
                            distance++;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (!isWall(playerPos[0] - 1, playerPos[1]))
                        {
                            map[playerPos[1], playerPos[0] - 1] = (int)state.Player;
                            map[playerPos[1], playerPos[0]] = (int)state.Road;
                            playerPos[0]--;

                            SetCursorPosition(playerPos[0] * 2 + 2, playerPos[1]);
                            ForegroundColor = ConsoleColor.Black;
                            Write("■");

                            SetCursorPosition(playerPos[0] * 2, playerPos[1]);
                            ForegroundColor = ConsoleColor.DarkYellow;
                            Write("★");
                            distance++;
                        }
                        break;
                    default:
                        break;
                }
            }

            if (isFin())
                gameStart = false;
        }

        public void Render()
        {
            ForegroundColor = ConsoleColor.White;

            SetCursorPosition(map.GetLength(1) * 2 + 2, 0);
            Write($"현재 이동거리 : {distance}");

            SetCursorPosition(map.GetLength(1) * 2 + 2, 1);
            time.TimerPrint();
        }

        public void mapPrinting()
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
                        playerPos[0] = j;   // x축
                        playerPos[1] = i;   // y축
                    }
                }
                WriteLine();
            }

            CursorVisible = false;
        }

        bool isWall(int x, int y)
        {
            if (map[y, x] == (int)state.Wall)
                return true;
            else if (map[y, x] == (int)state.Road)
                return false;

            return false;
        }

        bool isFin()
        {
            if (playerPos[0] == map.GetLength(1) - 2 && playerPos[1] == map.GetLength(0) - 1)
            {
                SetCursorPosition(map.GetLength(1) * 2 + 2, 2);
                ForegroundColor = ConsoleColor.Green;
                WriteLine("Finish!");
                ForegroundColor = ConsoleColor.White;
                SetCursorPosition(map.GetLength(1) * 2 + 2, 4);
                Write($"총 이동거리 : {distance}, 걸린 시간 : ");
                time.TimerPrint();
                CursorVisible = false;
                return true;
            }
            else
                return false;
        }

        void mapSetting()
        {
            Random rnd = new Random();
            SetCursorPosition(0, 0);

            for(int i=1;i<map.GetLength(0);i++)
            {
                for(int j=1;j<map.GetLength(1);j++)
                {
                    if (rnd.Next(100) < 65)
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
