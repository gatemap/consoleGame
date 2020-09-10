using System;

namespace OnlineDay04_01
{
    class Program
    {
        static void Main(string[] args)
        {
            GameManager manager = new GameManager();
            manager.Init();
            manager.Render();


            /*
            while(manager.gameState)
            {
                manager.Update();
            }
            */

            Console.ReadLine();
        }
    }
}
