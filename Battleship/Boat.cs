using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Boat
    {
        private string Name { get; set; }
        private int Squares { get; set; }
        public Boat(string name, int squares)
        {
            Name = name;
            Squares = squares;
        }
    }
}
