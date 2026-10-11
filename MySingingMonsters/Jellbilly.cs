using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class Jellbilly : Monster
    {
        public Jellbilly(int Level)
        {
            baseHp = 1125;
            baseAttack = 390;
            level = Level;
            setStats();
            elems = new List<Element>();
            elems.Add(new Element("Plasma"));
            elems.Add(new Element("Poison"));
            attacks = new List<Attack>();
            attacks.Add(new Attack("Pocket Drawl", new Element("None"), 1));
            if (level >= 5) attacks.Add(new Attack("Stingsong", new Element("Poison"), 1.14f));
            if (level >= 10) attacks.Add(new Attack("Gelled Ballad", new Element("Plasma"), 1.2f));
        }
    }
}
