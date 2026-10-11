using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class Boodoo : Monster
    {
        public Boodoo(int Level)
        {
            baseHp = 1125;
                        baseAttack = 395;
            level = Level;
            setStats();
            elems = new List<Element>();
            elems.Add(new Element("Shadow"));
            elems.Add(new Element("Crystal"));
            attacks = new List<Attack>();
            attacks.Add(new Attack("Zill Thriller", new Element("None"), 1));
            if (level >= 5) attacks.Add(new Attack("Jarring Jingle", new Element("Shadow"), 1.11f));
            if (level >= 10) attacks.Add(new Attack("Shaker Shine", new Element("Crystal"), 1.23f));
        }
    }
}
