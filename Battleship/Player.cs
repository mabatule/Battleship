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
            Board.printToTableVisible();
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
        public Tuple<string, int> readParams()
        {
            char row;
            int column;
            bool flag = false;
            do
            {
                Console.WriteLine("Insert row digit [A-J]:");
                var readRow = Console.ReadLine()?? "";
                row = readRow == "" ? 'X' : readRow.ToUpper()[0] ;
                
                Console.WriteLine("Insert column digit [1-10]:");
                var readColumn = Console.ReadLine() ?? "";
                column = Convert.ToInt32(readColumn==""?0:readColumn);

                if ((row >= 'A' && row <= 'J') && (column >= 1 && column <= 10)){
                    flag = true;
                }
                else{
                    Console.Clear();
                    PrintMyBoard();
                    Console.WriteLine("************ Insert the parameters correctly Row [A-J] and Column [1-10] ************");
                }
            } while (!flag);

            return new Tuple<string, int>(row.ToString(), column);
        }
    }
}
