using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class Arackulele : Monster
    {
        public Arackulele(int Level)
        {
            baseHp = 1090;
                        baseAttack = 390;
            level = Level;
            setStats();
            elems = new List<Element>();
            elems.Add(new Element("Shadow"));
            elems.Add(new Element("Mech"));
            attacks = new List<Attack>();
            attacks.Add(new Attack("Silk Strum", new Element("None"), 1));
            if (level >= 5) attacks.Add(new Attack("Fretful Feeling", new Element("Shadow"), 1.11f));
            if (level >= 10) attacks.Add(new Attack("Amped Abdomen", new Element("Mech"), 1.22f));
        }
    }
}
