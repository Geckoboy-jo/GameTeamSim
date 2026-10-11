using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class Yool : Monster
    {
        public Yool(int Level)
        {
            baseHp = 625;
                        baseAttack = 250;
            level = Level;
            setStats();
            elems = new List<Element>();
            elems.Add(new Element("Seasonal"));
            attacks = new List<Attack>();
            attacks.Add(new Attack("Wintry Words", new Element("Cold"), 1));
            if (level >= 5) attacks.Add(new Attack("Ho-liday Cheer", new Element("None"), 1.14f));
            if (level >= 10) attacks.Add(new Attack("Carol of the Yells", new Element("Cold"), 1.2f));
        }
    }
}
