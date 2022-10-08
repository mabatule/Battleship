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
        private const int numberofPlayer = 2;
        public List<Player> players { get; set; }
        public GameBattleship(int SizeBoard)
        {
            players = new List<Player>();   
            string firstName, secondName;
            
            Console.WriteLine("Enter your name player 1");
            firstName = Console.ReadLine();
            players.Add(new Player(firstName, SizeBoard));
            Console.WriteLine("Enter your name player 2");
            secondName = Console.ReadLine();
            players.Add(new Player(secondName, SizeBoard));

        }
        public void printInitialMessasge()
        {
            Console.Clear();
            Console.WriteLine("▬▬             ▬▬   ▬▬▬▬▬▬▬▬   ▬▬▬            ▬▬▬▬▬▬▬▬▬          ▬ ▬ ▬        ▬▬         ▬▬   ▬▬▬▬▬▬▬▬   ▬▬▬");
            Console.WriteLine("▬▬             ▬▬   ▬▬▬▬▬▬▬▬   ▬▬▬          ▬▬▬▬▬▬▬▬▬▬▬▬      ▬▬      ▬▬      ▬▬▬▬     ▬▬▬▬   ▬▬▬▬▬▬▬▬   ▬▬▬");
            Console.WriteLine("▬▬    ▬▬▬▬▬    ▬▬   ▬▬▬        ▬▬▬         ▬▬▬              ▬▬          ▬▬    ▬▬ ▬▬   ▬▬ ▬▬   ▬▬▬        ▬▬▬");
            Console.WriteLine("▬▬   ▬▬   ▬▬   ▬▬   ▬▬▬▬▬▬▬    ▬▬▬       ▬▬▬               ▬▬            ▬▬   ▬▬  ▬▬ ▬▬  ▬▬   ▬▬▬▬▬▬▬    ▬▬▬");
            Console.WriteLine("▬▬  ▬▬▬   ▬▬▬  ▬▬   ▬▬▬▬▬▬▬    ▬▬▬       ▬▬▬               ▬▬            ▬▬   ▬▬   ▬▬    ▬▬   ▬▬▬▬▬▬▬    ▬▬▬");
            Console.WriteLine("▬▬ ▬▬      ▬▬▬ ▬▬   ▬▬▬        ▬▬▬         ▬▬▬              ▬▬          ▬▬    ▬▬         ▬▬   ▬▬▬        ▬▬▬");
            Console.WriteLine("▬▬▬           ▬▬▬   ▬▬▬▬▬▬▬▬   ▬▬▬▬▬▬▬      ▬▬▬▬▬▬▬▬▬▬▬▬      ▬▬      ▬▬      ▬▬         ▬▬   ▬▬▬▬▬▬▬▬   ");
            Console.WriteLine("▬▬             ▬▬   ▬▬▬▬▬▬▬▬   ▬▬▬▬▬▬▬        ▬▬▬▬▬▬▬▬▬          ▬ ▬ ▬        ▬▬         ▬▬   ▬▬▬▬▬▬▬▬   ▬▬▬");
        }
        public void InformationBoats()
        {
            Console.WriteLine("Five types of boats are available:");
            Console.WriteLine("[A] Aircraft with 5 boxes  [B] Battleship with 4 boxes  [C] Cruiser with 3 boxes");
            Console.WriteLine("[S] Submarine with 3 boxes [D] Destroyer with 2 boxes");
            Console.WriteLine("*******************************");
        }
        public void PrintToWin(int win,int loser)
        {
            Console.WriteLine("****************************************");
            Console.WriteLine("\n");
            Console.WriteLine($"Congratulations {players[win].Name} won ! \n");
            Console.WriteLine("****************************************");
            Console.WriteLine($"Table of {players[loser].Name} with his defeated boats");
            players[loser].PrintMyBoard();
            InformationBoats();
        }
        public void startGame()
        {

            int firstPlayer=0;
            int SecondPlayer = 1;
            printInitialMessasge();
            System.Threading.Thread.Sleep(3000);

            Console.Clear();
            var endGame = false;
            do
            {

                Console.WriteLine($"Player {players[firstPlayer].Name} turn:");
                players[SecondPlayer].PrintMyBoard();
                InformationBoats();
                var dataFirst = players[SecondPlayer].readParams();

                players[firstPlayer].Myturn(dataFirst.Item1, dataFirst.Item2, players[SecondPlayer].Board);
                endGame = players[SecondPlayer].IsLoser();

                System.Threading.Thread.Sleep(4000);
                Console.Clear();


                firstPlayer  = firstPlayer  == 1 ? 0:1;
                SecondPlayer = SecondPlayer == 0 ? 1:0;
            } while (!endGame);
            
            if (players[0].IsLoser()) {
                PrintToWin(1,0);
            }
            else{
                PrintToWin(0, 1);
            }
            Console.WriteLine("*****************************************************************");
        }
    }
}
