using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class Quibble : Monster
    {
        public Quibble(int Level)
        {
            baseHp = 380;
                        baseAttack = 115;
            level = Level;
            setStats();
            elems = new List<Element>();
            elems.Add(new Element("Air"));
            elems.Add(new Element("Water"));
            attacks = new List<Attack>();
            attacks.Add(new Attack("Keystroke", new Element("None"), 1));
            if (level >= 5) attacks.Add(new Attack("Soaring Melody", new Element("Air"), 1.13f));
            if (level >= 10) attacks.Add(new Attack("Pond Sonata", new Element("Water"), 1.32f));
        }
    }
}
