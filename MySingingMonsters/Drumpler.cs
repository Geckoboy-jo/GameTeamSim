using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class Drumpler : Monster
    {
        public Drumpler(int Level)
        {
            baseHp = 450;
                        baseAttack = 120;
            level = Level;
            setStats();
            elems = new List<Element>();
            elems.Add(new Element("Earth"));
            elems.Add(new Element("Cold"));
            attacks = new List<Attack>();
            attacks.Add(new Attack("Flim Flam", new Element("None"), 1));
            if (level >= 5) attacks.Add(new Attack("Elastic Heart", new Element("Earth"), 1.14f));
            if (level >= 10) attacks.Add(new Attack("Drumroll, Freeze", new Element("Cold"), 1.38f));
        }
    }
}
