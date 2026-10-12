using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class Thumpies : Monster
    {
        


        public Thumpies(int Level)
        {
            baseHp = 650;
            baseAttack = 200;
            level = Level;
            setStats();
            elems = new List<Element>();
            elems.Add(new Element("Plant"));
            elems.Add(new Element("Cold"));
            elems.Add(new Element("Air"));
            attacks = new List<Attack>();
            attacks.Add(new Attack("Odd-ball Oldie", new Element("None"), 1  ));
            if (level >= 5) attacks.Add(new Attack("Stump Thump", new Element("Plant"), 1.09f));
            if (level >= 10) attacks.Add(new Attack("Lofty Leaping", new Element("Air"), 1.14f));
            if (level >= 15) attacks.Add(new Attack("Dimension Hop", new Element("Cold"), 1.23f));

        }
    }
}
