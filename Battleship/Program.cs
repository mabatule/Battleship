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
            Boats Boats = new Boats();
            Board board = new Board(10, Boats);
            var aux=board.directionOptions(4,3,5);
            foreach (var item in aux)
            {
                Console.WriteLine(item);
            }
            
            Console.WriteLine("*****************************");
            //board.PrintToTableVisible(board.matV);
        }
    }
}