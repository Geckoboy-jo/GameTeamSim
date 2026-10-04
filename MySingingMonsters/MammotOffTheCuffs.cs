using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class MammotOffTheCuffs : Monster
    {
        
        public MammotOffTheCuffs(int Level)
        {
            baseHp = 225;
            baseAttack = 75;
            level = Level;
            setStats();
            elems = new List<Element>();
            elems.Add(new Element("Cold"));
            attacks = new List<Attack>();
            attacks.Add(new Attack("off the cuffs", new Element("None"), 1.2f));
            if (level >= 5) attacks.Add(new Attack("Snow Brawl", new Element("Cold"), 1.2f));

        }
    }
}
