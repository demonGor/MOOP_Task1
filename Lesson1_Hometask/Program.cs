using System;

namespace Lesson1_Hometask
{
    class Program
    {
        static void Main(string[] args)
        {
            GameController gameController = new GameController();
            gameController.PlayGame();
            Console.ReadKey();
        }
    }
}
