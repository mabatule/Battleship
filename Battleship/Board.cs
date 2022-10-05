using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Board
    {
        public string[,] matV { get; set; }
        public string[,] matO { get; set; }
        public int Size { get; set; }
        public Board(int Size,Boats boats)
        {
            this.Size = Size;
            matV = new string[Size, Size];
            string formatEmpty = Convert.ToChar(166).ToString();
            InitializeMat(matV, formatEmpty);
            matO = new string[Size, Size];
            InitializeMat(matO, "0");

        }

        public void InitializeMat(string[,] mat,string car)
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    mat[i, j] = car;
                }
            }
        }
        public  void PrintToTableVisible(string[,] mat)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write("    " + mat[i,j]);
                }

                Console.WriteLine(); Console.WriteLine();
            }
        }
        public  bool validationRowConflict(int row, int column, int n)
        {
            bool flag = true;
            for (int i = row; i < n; i++){
                if (matO[i, column] != "0") flag = false;  
            }
            return flag;
        }
        public bool validationColumnConflict(int row, int column, int n)
        {
            bool flag = true;
            for (int i = column; i < n; i++){
                if (matO[row, i] != "0") flag = false;
            }
            return flag;
        }
        public List<string> directionOptions(int row, int column, int cells) {
            List<string> direction = new List<string>();
            if (row+cells -1 < Size ){
                if (validationRowConflict(row,column,row+cells)) 
                    direction.Add("down");
            }
            if (row-cells+1 >= 0)
            {
                if (validationRowConflict(row, column, row - cells))
                    direction.Add("up");
            }
            if (column + cells -1 < Size)
            {
                if (validationRowConflict(row, column, column + cells))
                    direction.Add("right");
            }
            if (column - cells + 1>= 0)
            {
                if (validationRowConflict(row, column, column - cells))
                    direction.Add("left");
            }
            return direction;
        }

      
    }
}
