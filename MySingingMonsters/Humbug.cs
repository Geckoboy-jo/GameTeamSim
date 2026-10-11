using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class Humbug : Monster
    {
        public Humbug(int Level)
        {
            baseHp = 1000;
                        baseAttack = 300;
            level = Level;
            setStats();
            elems = new List<Element>();
            elems.Add(new Element("Poison"));
            attacks = new List<Attack>();
            attacks.Add(new Attack("Woozy Wingbeat", new Element("None"), 1));
            if (level >= 5) attacks.Add(new Attack("Foreign Contaminant", new Element("Earth"), 1.25f));
            if (level >= 10) attacks.Add(new Attack("Toxic Trait", new Element("Poison"), 1.1f));
        }
    }
}
