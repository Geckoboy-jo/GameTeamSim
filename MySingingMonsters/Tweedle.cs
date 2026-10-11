using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class Tweedle : Monster
    {
        public Tweedle(int Level)
        {
            baseHp = 300;
                        baseAttack = 60;
            level = Level;
            setStats();
            elems = new List<Element>();
            elems.Add(new Element("Air"));
            attacks = new List<Attack>();
            attacks.Add(new Attack("Birdsong", new Element("None"), 1));
            if (level >= 5) attacks.Add(new Attack("Gossip Gust", new Element("Air"), 1.05f));
        }
    }
}
