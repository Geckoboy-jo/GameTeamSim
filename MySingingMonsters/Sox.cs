using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class Sox : Monster
    {
        public Sox(int Level)
        {
            baseHp = 1095;
                        baseAttack = 395;
            level = Level;
            setStats();
            elems = new List<Element>();
            elems.Add(new Element("Plasma"));
            elems.Add(new Element("Crystal"));
            attacks = new List<Attack>();
            attacks.Add(new Attack("Unknown Saying", new Element("None"), 1));
            if (level >= 5) attacks.Add(new Attack("Caudal Cuddle", new Element("Plasma"), 1.1f));
            if (level >= 10) attacks.Add(new Attack("Precious Pads", new Element("Crystal"), 1.23f));
        }
    }
}
