using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class Furcorn : Monster
    {
        public Furcorn(int Level)
        {
            baseHp = 350;
                        baseAttack = 160;
            level = Level;
            setStats();
            elems = new List<Element>();
            elems.Add(new Element("Plant"));
            elems.Add(new Element("Cold"));
            attacks = new List<Attack>();
            attacks.Add(new Attack("Warbly Falsetto", new Element("None"), 1));
            if (level >= 5) attacks.Add(new Attack("Bud Ballad", new Element("Plant"), 1.19f));
            if (level >= 10) attacks.Add(new Attack("Silky Shiver", new Element("Cold"), 1.31f));
        }
    }
}
