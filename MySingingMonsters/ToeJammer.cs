using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class ToeJammer : Monster
    {
        public ToeJammer(int Level)
        {
            baseHp = 250;
                        baseAttack = 70;
            level = Level;
            setStats();
            elems = new List<Element>();
            elems.Add(new Element("Water"));
            attacks = new List<Attack>();
            attacks.Add(new Attack("Doo-Wop", new Element("None"), 1));
            if (level >= 5) attacks.Add(new Attack("Dew Drop", new Element("Water"), 1.14f));
        }
    }
}
