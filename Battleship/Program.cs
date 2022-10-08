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
            GameBattleship game = new GameBattleship(10);
                game.startGame();
        }
    }
}