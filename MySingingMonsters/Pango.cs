using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class Pango : Monster
    {
        public Pango(int Level)
        {
            baseHp = 525;
                        baseAttack = 105;
            level = Level;
            setStats();
            elems = new List<Element>();
            elems.Add(new Element("Air"));
            elems.Add(new Element("Cold"));
            attacks = new List<Attack>();
            attacks.Add(new Attack("Beak Bristle", new Element("None"), 1));
            if (level >= 5) attacks.Add(new Attack("Frostbite", new Element("Cold"), 1.15f));
            if (level >= 10) attacks.Add(new Attack("Flightless Fancy", new Element("Air"), 1.47f));
        }
    }
}
