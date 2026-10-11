using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class Schmoochle : Monster
    {
        public Schmoochle(int Level)
        {
            baseHp = 650;
                        baseAttack = 210;
            level = Level;
            setStats();
            elems = new List<Element>();
            elems.Add(new Element("Seasonal"));
            attacks = new List<Attack>();
            attacks.Add(new Attack("Fluttery Sensation", new Element("Air"), 1));
            if (level >= 5) attacks.Add(new Attack("Sweet Nothings", new Element("None"), 1.14f));
            if (level >= 10) attacks.Add(new Attack("Rainbow Chase", new Element("Air"), 1.2f));
        }
    }
}
