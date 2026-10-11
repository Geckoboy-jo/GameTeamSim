using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class Reedling : Monster
    {
        public Reedling(int Level)
        {
            baseHp = 750;
                        baseAttack = 180;
            level = Level;
            setStats();
            elems = new List<Element>();
            elems.Add(new Element("Air"));
            elems.Add(new Element("Plant"));
            elems.Add(new Element("Earth"));
            attacks = new List<Attack>();
            attacks.Add(new Attack("Flute Toot", new Element("None"), 1));
            if (level >= 5) attacks.Add(new Attack("Aerophone Phonics", new Element("Air"), 1.07f));
            if (level >= 10) attacks.Add(new Attack("Rich Register", new Element("Earth"), 1.12f));
            if (level >= 15) attacks.Add(new Attack("Piccolo Pith", new Element("Plant"), 1.21f));
        }
    }
}
