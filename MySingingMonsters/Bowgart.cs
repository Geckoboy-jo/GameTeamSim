using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class Bowgart : Monster
    {
        public Bowgart(int Level)
        {
            baseHp = 590;
                        baseAttack = 225;
            level = Level;
            setStats();
            elems = new List<Element>();
            elems.Add(new Element("Plant"));
            elems.Add(new Element("Water"));
            elems.Add(new Element("Cold"));
            attacks = new List<Attack>();
            attacks.Add(new Attack("Hey Fiddle Diddle", new Element("None"), 1));
            if (level >= 5) attacks.Add(new Attack("Crisp Concerto", new Element("Cold"), 1.06f));
            if (level >= 10) attacks.Add(new Attack("Puddle Pavane", new Element("Water"), 1.16f));
            if (level >= 15) attacks.Add(new Attack("Spicy Spiccato", new Element("Plant"), 1.22f));
        }
    }
}
