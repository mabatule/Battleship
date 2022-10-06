using Battleship;
using System;
using System.Drawing;
using System.Linq;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
                string firstName, secondName;
                Console.WriteLine("Enter your name player 1");
                firstName = Console.ReadLine();
                Console.WriteLine("Enter your name player 2");
                secondName = Console.ReadLine();
                GameBattleship game = new GameBattleship(firstName, secondName,10);
                game.startGame();
        }
    }
}