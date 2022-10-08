using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Boats
    {
        public List<string> boatsName { get; set; }
        public List<int> boatsCount { get; set; }
        public Boats()
        {
            boatsName = new List<string>() { "Cruiser", "Destroyer", "Submarine", "Battleship", "Aircraft" };
            boatsCount = new List<int>() { 3,2,3,4,5};
            //Test Easy
            //boatsName = new List<string>() { "Destroyer" };
            //boatsCount = new List<int>() {2};
        }
        public void accurateShot(char initial)
        {
            for (int i = 0; i < boatsName.Count(); i++){
                if (boatsName[i][0] == initial) boatsCount[i]--;
            }
        }
        public bool boatSank(char initial)
        {
            for (int i = 0; i < boatsName.Count(); i++){
                if (boatsName[i][0] == initial) return boatsCount[i]==0;
            }
            return false;
        }
        public bool CountIsEmpty(){ 
            return boatsCount.Sum()==0;
        }
    }
}
