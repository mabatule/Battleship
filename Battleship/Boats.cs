using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Boats
    {
        public List<Tuple<string,int>> boatsTuple { get; set; }
        public Boats()
        {
            boatsTuple = new List<Tuple<string, int>>();
            boatsTuple.Add(new Tuple<string, int>("Cruiser"   , 1));
            boatsTuple.Add(new Tuple<string, int>("Destroyer" , 2));
            boatsTuple.Add(new Tuple<string, int>("Submarine" , 3));
            boatsTuple.Add(new Tuple<string, int>("Battleship", 4));
            boatsTuple.Add(new Tuple<string, int>("Aircraft"  , 5));
        }
    }
}
