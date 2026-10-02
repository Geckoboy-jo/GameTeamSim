using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class Mammot : Monster
    {
        public Mammot(int Level)
        {
            baseHp = 225;
            baseAttack = 75;
            level = Level;
            setStats();
            elems = new List<Element>();
            elems.Add(new Element("Cold"));
        }
    }
}
