using System;
using System.Collections.Generic;
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
        public void startGame()
        {
            string row;
            int column;
            //printInitialMessasge();
            //System.Threading.Thread.Sleep(3000);
            Console.Clear();
            var endGame = false;
            do
            {
                Console.WriteLine($"Player {FirtsPlayer.Name} turn:");
                SecondPlayer.PrintMyBoard();
                Console.WriteLine("Insert one digit [A-J]:");
                row= Console.ReadLine();
                Console.WriteLine("Insert one digit [1-10]:");
                column = Convert.ToInt32(Console.ReadLine());
                FirtsPlayer.Myturn(row.ToUpper(), column, SecondPlayer.Board);
                
                
                System.Threading.Thread.Sleep(3000);
                Console.Clear();

                Console.WriteLine($"Player {SecondPlayer.Name} turn:");
                FirtsPlayer.PrintMyBoard();
                Console.WriteLine("Insert one digit [A-J]:");
                row = Console.ReadLine();
                Console.WriteLine("Insert one digit [1-10]:");
                column = Convert.ToInt32(Console.ReadLine());
                SecondPlayer.Myturn(row.ToUpper(), column,FirtsPlayer.Board);

                endGame= (FirtsPlayer.IsLoser() || FirtsPlayer.IsLoser());

                System.Threading.Thread.Sleep(3000);
                Console.Clear();

            } while (!endGame);
            if (FirtsPlayer.IsLoser()) {
                Console.WriteLine($"Congratulations {SecondPlayer.Name} won");
            }
            else
            {
                Console.WriteLine($"Congratulations {FirtsPlayer.Name} won");
            }
        }
    }
}
