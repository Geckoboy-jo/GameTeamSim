using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class Cybop : Monster
    {
        public Cybop(int Level)
        {
            baseHp = 550;
                        baseAttack = 100;
            level = Level;
            setStats();
            elems = new List<Element>();
            elems.Add(new Element("Air"));
            elems.Add(new Element("Earth"));
            attacks = new List<Attack>();
            attacks.Add(new Attack("Propeller Whirl", new Element("None"), 1));
            if (level >= 5) attacks.Add(new Attack("Uptempo Updraft", new Element("Air"), 1.08f));
            if (level >= 10) attacks.Add(new Attack("Fission Tackle", new Element("Earth"), 1.47f));
        }
    }
}
