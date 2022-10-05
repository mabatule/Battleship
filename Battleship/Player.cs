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
        private List<Boat> Boats { get; set; }
        private Board Board{ get; set; }

        public Player(string name)
        {
            Name = name;
            Boats = new List<Boat>();
            Boats.Add(new Boat("aircraft"  , 5));
            Boats.Add(new Boat("battleship", 4));
            Boats.Add(new Boat("submarine" , 3));
            Boats.Add(new Boat("destroyer" , 2));
            Boats.Add(new Boat("cruiser"   , 1));

            //Board = board;
        }
    }
}
