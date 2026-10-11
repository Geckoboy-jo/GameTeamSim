using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class FungPray : Monster
    {
        public FungPray(int Level)
        {
            baseHp = 1220;
                        baseAttack = 380;
            level = Level;
            setStats();
            elems = new List<Element>();
            elems.Add(new Element("Crystal"));
            elems.Add(new Element("Poison"));
            attacks = new List<Attack>();
            attacks.Add(new Attack("In Stridulation", new Element("None"), 1));
            if (level >= 5) attacks.Add(new Attack("Grain Boundary", new Element("Crystal"), 1.13f));
            if (level >= 10) attacks.Add(new Attack("Go Ask Alice", new Element("Poison"), 1.24f));
        }
    }
}
