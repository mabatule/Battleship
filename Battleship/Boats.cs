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
            boatsTuple.Add(new Tuple<string, int>("cruiser"   , 1));
            boatsTuple.Add(new Tuple<string, int>("destroyer" , 2));
            boatsTuple.Add(new Tuple<string, int>("submarine" , 3));
            boatsTuple.Add(new Tuple<string, int>("battleship", 4));
            boatsTuple.Add(new Tuple<string, int>("aircraft"  , 5));
        }
    }
}
