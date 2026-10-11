using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class Hoola : Monster
    {
        public Hoola(int Level)
        {
            baseHp = 700;
                        baseAttack = 190;
            level = Level;
            setStats();
            elems = new List<Element>();
            elems.Add(new Element("Seasonal"));
            attacks = new List<Attack>();
            attacks.Add(new Attack("Sandstorm", new Element("Earth"), 1));
            if (level >= 5) attacks.Add(new Attack("Hoop and Holler", new Element("None"), 1.14f));
            if (level >= 10) attacks.Add(new Attack("Feels like Summer", new Element("Earth"), 1.2f));
        }
    }
}
