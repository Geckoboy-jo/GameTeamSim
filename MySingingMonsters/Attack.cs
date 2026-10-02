using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class Attack
    {
        public Element type;
        public string name;
        public double basePower;

        public Attack(string Name, Element Type, double BasePower)
        {
            name = Name;
            type = Type;
            basePower = BasePower;  
        }
    }
}
