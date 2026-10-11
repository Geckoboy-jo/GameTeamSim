using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class Maw : Monster
    {
        public Maw(int Level)
        {
            baseHp = 390;
                        baseAttack = 135;
            level = Level;
            setStats();
            elems = new List<Element>();
            elems.Add(new Element("Water"));
            elems.Add(new Element("Cold"));
            attacks = new List<Attack>();
            attacks.Add(new Attack("Tonguey Trill", new Element("None"), 1));
            if (level >= 5) attacks.Add(new Attack("Frigid Refrain", new Element("Cold"), 1.13f));
            if (level >= 10) attacks.Add(new Attack("Liquid Quip", new Element("Water"), 1.33f));
        }
    }
}
