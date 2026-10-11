using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class Nebulob : Monster
    {
        public Nebulob(int Level)
        {
            baseHp = 1060;
                        baseAttack = 400;
            level = Level;
            setStats();
            elems = new List<Element>();
            elems.Add(new Element("Plasma"));
            elems.Add(new Element("Mech"));
            attacks = new List<Attack>();
            attacks.Add(new Attack("Rhythm & Ooze", new Element("None"), 1));
            if (level >= 5) attacks.Add(new Attack("Exo-suit Swing", new Element("Mech"), 1.12f));
            if (level >= 10) attacks.Add(new Attack("Ectoplasmic Jive", new Element("Plasma"), 1.2f));
        }
    }
}
