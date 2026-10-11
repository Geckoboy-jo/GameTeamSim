using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class Kazilleon : Monster
    {
        public Kazilleon(int Level)
        {
            baseHp = 1155;
                        baseAttack = 390;
            level = Level;
            setStats();
            elems = new List<Element>();
            elems.Add(new Element("Shadow"));
            elems.Add(new Element("Poison"));
            attacks = new List<Attack>();
            attacks.Add(new Attack("Gruff Gurgle", new Element("None"), 1));
            if (level >= 5) attacks.Add(new Attack("Holy Halitosis", new Element("Poison"), 1.14f));
            if (level >= 10) attacks.Add(new Attack("Camo Creep", new Element("Shadow"), 1.21f));
        }
    }
}
