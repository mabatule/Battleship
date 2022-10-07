using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    internal class GameBattleship
    {
        public Player FirtsPlayer { get; set; }
        public Player SecondPlayer { get; set; }
        public GameBattleship(string nameFirstPlayer,string nameSecondPlayer,int SizeBoard)
        {
            FirtsPlayer =new Player(nameFirstPlayer, SizeBoard);
            SecondPlayer =new Player(nameSecondPlayer, SizeBoard);
        }
        public void printInitialMessasge()
        {
            Console.WriteLine("▬▬             ▬▬   ▬▬▬▬▬▬▬▬   ▬▬▬            ▬▬▬▬▬▬▬▬▬          ▬ ▬ ▬        ▬▬         ▬▬   ▬▬▬▬▬▬▬▬   ▬▬▬");
            Console.WriteLine("▬▬             ▬▬   ▬▬▬▬▬▬▬▬   ▬▬▬          ▬▬▬▬▬▬▬▬▬▬▬▬      ▬▬      ▬▬      ▬▬▬▬     ▬▬▬▬   ▬▬▬▬▬▬▬▬   ▬▬▬");
            Console.WriteLine("▬▬    ▬▬▬▬▬    ▬▬   ▬▬▬        ▬▬▬         ▬▬▬              ▬▬          ▬▬    ▬▬ ▬▬   ▬▬ ▬▬   ▬▬▬        ▬▬▬");
            Console.WriteLine("▬▬   ▬▬   ▬▬   ▬▬   ▬▬▬▬▬▬▬    ▬▬▬       ▬▬▬               ▬▬            ▬▬   ▬▬  ▬▬ ▬▬  ▬▬   ▬▬▬▬▬▬▬    ▬▬▬");
            Console.WriteLine("▬▬  ▬▬▬   ▬▬▬  ▬▬   ▬▬▬▬▬▬▬    ▬▬▬       ▬▬▬               ▬▬            ▬▬   ▬▬   ▬▬    ▬▬   ▬▬▬▬▬▬▬    ▬▬▬");
            Console.WriteLine("▬▬ ▬▬      ▬▬▬ ▬▬   ▬▬▬        ▬▬▬         ▬▬▬              ▬▬          ▬▬    ▬▬         ▬▬   ▬▬▬        ▬▬▬");
            Console.WriteLine("▬▬▬           ▬▬▬   ▬▬▬▬▬▬▬▬   ▬▬▬▬▬▬▬      ▬▬▬▬▬▬▬▬▬▬▬▬      ▬▬      ▬▬      ▬▬         ▬▬   ▬▬▬▬▬▬▬▬   ");
            Console.WriteLine("▬▬             ▬▬   ▬▬▬▬▬▬▬▬   ▬▬▬▬▬▬▬        ▬▬▬▬▬▬▬▬▬          ▬ ▬ ▬        ▬▬         ▬▬   ▬▬▬▬▬▬▬▬   ▬▬▬");
        }
        public Tuple<string,int> readParams()
        {
            char row;
            int column;
            bool flag=false;
            do
            {
                Console.WriteLine("Insert row digit [A-J]:");
                row = Console.ReadLine().ToUpper()[0];
                Console.WriteLine("Insert column digit [1-10]:");
                column = Convert.ToInt32(Console.ReadLine());
                if ((row>='A' && row<='J') && (column>=1 && column<=10)){
                    flag = true;
                }
                else{
                    Console.Clear();
                    SecondPlayer.PrintMyBoard();
                    Console.WriteLine("************ Insert the parameters correctly Row [A-J] and Column [1-10] ************");
                }
            } while (!flag);

            return new Tuple<string,int>(row.ToString(), column);
        }
        public void startGame()
        {
            printInitialMessasge();
            System.Threading.Thread.Sleep(3000);

            Console.Clear();
            var endGame = false;
            do
            {
                Console.WriteLine($"Player {FirtsPlayer.Name} turn:");
                SecondPlayer.PrintMyBoard();
                var dataFirst = readParams();

                FirtsPlayer.Myturn(dataFirst.Item1, dataFirst.Item2, SecondPlayer.Board);
                endGame = SecondPlayer.IsLoser();

                System.Threading.Thread.Sleep(4000);
                Console.Clear();

                if (!endGame){
                    Console.WriteLine($"Player {SecondPlayer.Name} turn:");
                    FirtsPlayer.PrintMyBoard();
                    var dataSecond = readParams();
                    SecondPlayer.Myturn(dataSecond.Item1, dataSecond.Item2, FirtsPlayer.Board);
                    endGame = FirtsPlayer.IsLoser();
                    System.Threading.Thread.Sleep(4000);
                    Console.Clear();
                }

            } while (!endGame);
            
            if (FirtsPlayer.IsLoser()) {
                Console.WriteLine($"Congratulations {SecondPlayer.Name} won");
            }
            else{
                Console.WriteLine($"Congratulations {FirtsPlayer.Name} won");
            }
        }
    }
}
