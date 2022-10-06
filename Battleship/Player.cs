using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Player
    {
        public string Name { get; set; }
        public Board Board{ get; set; }

        public Player(string name,int SizeBoard)
        {
            Name = name;
            Board = new Board(SizeBoard);
            Board.InsertBoatsToBoardRandom();
        }
        public void PrintMyBoard()
        {
            Board.printToTablePositions();
        }
        public bool IsLoser()
        {
            return Board.boats.CountIsEmpty();
        }
        public void Myturn(string row,int column,Board board)
        {
            int newRow = Convert.ToInt32(row[0]) - Convert.ToInt32('A');
            board.shotbyCoordinates(newRow, column-1);
        }
    }
}
