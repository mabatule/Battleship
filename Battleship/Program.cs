using Battleship;
using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var board = new Board(10);

            board.PrintToTableVisible(board.matO);
            Console.WriteLine("*****************************");
            board.PrintToTableVisible(board.matV);
        }
    }
}