using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class Pummel : Monster
    {
        public Pummel(int Level)
        {
            baseHp = 540;
                        baseAttack = 240;
            level = Level;
            setStats();
            elems = new List<Element>();
            elems.Add(new Element("Plant"));
            elems.Add(new Element("Earth"));
            elems.Add(new Element("Water"));
            attacks = new List<Attack>();
            attacks.Add(new Attack("Tonguethumping", new Element("None"), 1));
            if (level >= 5) attacks.Add(new Attack("Gill Giddiness", new Element("Water"), 1.07f));
            if (level >= 10) attacks.Add(new Attack("Insane Membrane", new Element("Plant"), 1.18f));
            if (level >= 15) attacks.Add(new Attack("Mudskipper", new Element("Earth"), 1.24f));
        }
    }
}
