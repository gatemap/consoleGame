using System;

namespace OnlineDay04_01
{
    class Program
    {
        static void Main(string[] args)
        {
            GameManager manager = new GameManager();
            manager.Init();
            
            while(manager.gameState)
            {
                manager.Update();
                manager.Render();
            }


            Console.ReadLine();
        }
    }
}
