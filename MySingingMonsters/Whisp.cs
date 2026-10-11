using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class Whisp : Monster
    {
        public Whisp(int Level)
        {
            baseHp = 1030;
                        baseAttack = 400;
            level = Level;
            setStats();
            elems = new List<Element>();
            elems.Add(new Element("Plasma"));
            elems.Add(new Element("Shadow"));
            attacks = new List<Attack>();
            attacks.Add(new Attack("Dreamy Dirge", new Element("None"), 1));
            if (level >= 5) attacks.Add(new Attack("Other Side", new Element("Plasma"), 1.1f));
            if (level >= 10) attacks.Add(new Attack("Hover Haunt", new Element("Shadow"), 1.21f));
        }
    }
}
