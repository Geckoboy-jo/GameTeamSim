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
        public float basePower;

        public Attack(string Name, Element Type, float BasePower)
        {
            name = Name;
            type = Type;
            basePower = BasePower;  
        }
    }
}
