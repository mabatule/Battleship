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
            
            for (int i = 0; i < 10000; i++)
            {
                Boats Boats = new Boats();
                Board board = new Board(10, Boats);
                Console.WriteLine("*****************************");
                board.InsertBoatsToBoard(Boats);
                board.printToTableVisible(board.matO);

            }
            Console.WriteLine("*****************************");
            //board.PrintToTableVisible(board.matV);
        }
    }
}