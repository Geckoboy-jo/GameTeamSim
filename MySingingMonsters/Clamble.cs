using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class Clamble : Monster
    {
        public Clamble(int Level)
        {
            baseHp = 600;
                        baseAttack = 220;
            level = Level;
            setStats();
            elems = new List<Element>();
            elems.Add(new Element("Plant"));
            elems.Add(new Element("Earth"));
            elems.Add(new Element("Cold"));
            attacks = new List<Attack>();
            attacks.Add(new Attack("Hi-Hat Sizzle", new Element("None"), 1));
            if (level >= 5) attacks.Add(new Attack("Cymbalic Crash", new Element("Plant"), 1.08f));
            if (level >= 10) attacks.Add(new Attack("Mood Plating", new Element("Earth"), 1.17f));
            if (level >= 15) attacks.Add(new Attack("Glacial Glissando", new Element("Cold"), 1.23f));
        }
    }
}
