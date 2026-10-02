using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class MammotWaterBuffalow : Monster
    {
        public List<Attack> attacks;
        public MammotWaterBuffalow(int Level)
        {
            baseHp = 225;
            baseAttack = 75;
            level = Level;
            setStats();
            elems = new List<Element>();
            elems.Add(new Element("Cold"));
            attacks = new List<Attack>();
            attacks.Add(new Attack("Water Buff-a-low", new Element("Water"), 1));
            if (level >= 5) attacks.Add(new Attack("Snow Brawl", new Element("Cold"), 1.2));

        }
    }
}
