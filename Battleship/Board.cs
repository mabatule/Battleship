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
        public Boats boats { get; set; }
        public Board(int Size)
        {
            boats = new Boats();
            this.Size = Size;
            matV = new string[Size, Size];
            initializeMat(matV, "▬");
            matO = new string[Size, Size];
            initializeMat(matO, "0");
        }

        public void initializeMat(string[,] mat,string car)
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    mat[i, j] = car;
                }
            }
        }
        public void printToTableVisible()
        {
            char rows = 'A';
            //print a row for the column reference [1-10]
            Console.Write("      ");
            for (int i = 1; i <= Size; i++){Console.Write($"[{i}]  ");}
            Console.WriteLine();
            //prints the table with their respective reference columns [A-J]
            for (int i = 0; i < Size; i++)
            {

                Console.Write($"[{rows}]");
                for (int j = 0; j < Size; j++)
                {

                    Console.Write("    " + matV[i, j]);
                }
                rows++;
                Console.WriteLine(); Console.WriteLine();
            }
        }
        public void printToTablePositions()
        {
            char rows = 'A';
            //print a row for the column reference [1-10]
            Console.Write("      ");
            for (int i = 1; i <= Size; i++) { Console.Write($"[{i}]  "); }
            Console.WriteLine();
            //prints the table with their respective reference columns [A-J]
            for (int i = 0; i < Size; i++)
            {
                Console.Write($"[{rows}]");
                for (int j = 0; j < Size; j++)
                {
                    Console.Write("    " + matO[i, j]);
                }
                rows++;
                Console.WriteLine(); Console.WriteLine();
            }
        }
        public  bool validationUp(int row, int column, int n)
        {
            bool flag = true;
            for (int i = 0; i < n; i++){
                if (matO[row--, column] != "0") flag = false;  
            }
            return flag;
        }
        public bool validationDown(int row, int column, int n)
        {
            bool flag = true;
            for (int i = 0; i < n; i++)
            {
                if (matO[row++, column] != "0") flag = false;
            }
            return flag;
        }
        public bool validationLeft(int row, int column, int n)
        {
            bool flag = true;
            for (int i = 0; i < n; i++)
            {
                if (matO[row, column--] != "0") flag = false;
            }
            return flag;
        }
        public bool validationRight(int row, int column, int n)
        {
            bool flag = true;
            for (int i = 0; i < n; i++)
            {
                if (matO[row, column++] != "0") flag = false;
            }
            return flag;
        }
        public List<string> directionInsertOptions(int row, int column, int cells) {
            List<string> direction = new List<string>();
            if (row - cells  >= 0)
            {
                if (validationUp(row, column, cells))
                direction.Add("up");
            }
            if (row+cells < Size ){
                if (validationDown(row,column, cells)) 
                    direction.Add("down");
            }
            if (column-cells >= 0)
            {
                if (validationLeft(row, column, cells))
                    direction.Add("left");
            }
            if (column + cells  < Size)
            {
                if (validationRight(row, column,cells))
                    direction.Add("right");
            }
            return direction;
        }
        void insertBoat(string direction,int row,int column,string boat,int n)
        {
            switch (direction)
            {
                case "up":
                    for (int i = 0; i < n; i++) matO[row--, column] = boat[0].ToString();
                    break;
                case "down":
                    for (int i = 0; i < n; i++) matO[row++, column] = boat[0].ToString();
                    break;
                case "left":
                    for (int i = 0; i < n; i++) matO[row, column--] = boat[0].ToString();
                    break;
                case "right":
                    for (int i = 0; i < n; i++) matO[row, column++] = boat[0].ToString();
                    break;
                default:
                    break;
            }
        }
        public void InsertBoatsToBoardRandom()
        {
            Random ramdom = new Random();
            int i = 0;
            
            while(i< boats.boatsName.Count())
            {
                int row = ramdom.Next(Size);
                int column =ramdom.Next(Size);
                var boatName = boats.boatsName[i];
                var boatCells = boats.boatsCount[i];

                var directions = directionInsertOptions(row, column, boatCells);
                if (directions.Count!=0){
                    var azar = ramdom.Next(directions.Count());
                    var directionAzar = directions[azar];
                    insertBoat(directionAzar, row, column, boatName, boatCells);
                    i++;
                }
            }
        }
        public void shotbyCoordinates(int row,int column)
        {
            if (matO[row,column] == "0"){
                Console.WriteLine("Water Shot");
            }
            else{
                char initialBoat = matO[row, column][0];
                boats.accurateShot(initialBoat);
                matV[row, column] = matO[row, column];
                matO[row, column] = "0";
                Console.Clear();
                printToTableVisible();
                if (boats.boatSank(initialBoat)){
                    Console.WriteLine("Sunk");
                }
                else{
                    Console.WriteLine("Accurate shot");
                }
            }
        }

    }
}
