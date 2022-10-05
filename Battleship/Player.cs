using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Player
    {
        private string Name { get; set; }
        private Boats Boats { get; set; }
        private Board Board{ get; set; }

        public Player(string name)
        {
            Name = name;
            Boats = new Boats();
            
            Board = new Board(10, Boats);

            
        }
    }
}
