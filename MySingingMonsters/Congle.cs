using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class Congle : Monster
    {
        public Congle(int Level)
        {
            baseHp = 630;
                        baseAttack = 210;
            level = Level;
            setStats();
            elems = new List<Element>();
            elems.Add(new Element("Air"));
            elems.Add(new Element("Water"));
            elems.Add(new Element("Cold"));
            attacks = new List<Attack>();
            attacks.Add(new Attack("Eggshell Swell", new Element("None"), 1));
            if (level >= 5) attacks.Add(new Attack("Muffled Tones", new Element("Air"), 1.07f));
            if (level >= 10) attacks.Add(new Attack("Scrambled Samba", new Element("Water"), 1.16f));
            if (level >= 15) attacks.Add(new Attack("Turbo Tumbao", new Element("Cold"), 1.22f));
        }
    }
}
