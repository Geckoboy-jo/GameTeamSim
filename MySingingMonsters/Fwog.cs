using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class Fwog : Monster
    {
        public Fwog(int Level)
        {
            baseHp = 410;
                        baseAttack = 130;
            level = Level;
            setStats();
            elems = new List<Element>();
            elems.Add(new Element("Earth"));
            elems.Add(new Element("Water"));
            attacks = new List<Attack>();
            attacks.Add(new Attack("Hypnotic Call", new Element("None"), 1));
            if (level >= 5) attacks.Add(new Attack("River Ribbit", new Element("Water"), 1.13f));
            if (level >= 10) attacks.Add(new Attack("Muddy Croak", new Element("Earth"), 1.35f));
        }
    }
}
