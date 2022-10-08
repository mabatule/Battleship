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
            Console.WriteLine("1 .- Carrier with 5 boxes");
            Console.WriteLine("2 .- Battleship with 4 boxes");
            Console.WriteLine("3 .- Cruiser with 3 boxes");
            Console.WriteLine("4 .- Submarine with 3 boxes");
            Console.WriteLine("5 .- Destroyer with 2 boxes");
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
                var dataFirst = players[SecondPlayer].readParams();

                players[firstPlayer].Myturn(dataFirst.Item1, dataFirst.Item2, players[SecondPlayer].Board);
                endGame = players[SecondPlayer].IsLoser();

                System.Threading.Thread.Sleep(4000);
                Console.Clear();


                firstPlayer  = firstPlayer  == 1 ? 0:1;
                SecondPlayer = SecondPlayer == 0 ? 1:0;
                /*Console.WriteLine($"Player {FirtsPlayer.Name} turn:");
                SecondPlayer.PrintMyBoard();
                var dataFirst = readParams();

                FirtsPlayer.Myturn(dataFirst.Item1, dataFirst.Item2, SecondPlayer.Board);
                endGame = SecondPlayer.IsLoser();

                System.Threading.Thread.Sleep(4000);
                Console.Clear();*/

                /*if (!endGame){
                    Console.WriteLine($"Player {SecondPlayer.Name} turn:");
                    FirtsPlayer.PrintMyBoard();
                    var dataSecond = readParams();

                    SecondPlayer.Myturn(dataSecond.Item1, dataSecond.Item2, FirtsPlayer.Board);
                    endGame = FirtsPlayer.IsLoser();
                    
                    System.Threading.Thread.Sleep(4000);
                    Console.Clear();
                }*/

            } while (!endGame);
            
            if (players[0].IsLoser()) {
                Console.WriteLine($"Congratulations {players[1].Name} won");
            }
            else{
                Console.WriteLine($"Congratulations {players[0].Name} won");
            }
            Console.WriteLine("\n\n\n\n\n\n\n");
        }
    }
}
