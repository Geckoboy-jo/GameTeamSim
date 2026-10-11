using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class PomPom : Monster
    {
        public PomPom(int Level)
        {
            baseHp = 670;
                        baseAttack = 190;
            level = Level;
            setStats();
            elems = new List<Element>();
            elems.Add(new Element("Air"));
            elems.Add(new Element("Earth"));
            elems.Add(new Element("Cold"));
            attacks = new List<Attack>();
            attacks.Add(new Attack("Pep Rally", new Element("None"), 1));
            if (level >= 5) attacks.Add(new Attack("Uplifting Cheer", new Element("Air"), 1.07f));
            if (level >= 10) attacks.Add(new Attack("Icebreaker", new Element("Cold"), 1.15f));
            if (level >= 15) attacks.Add(new Attack("Supportive Shout", new Element("Earth"), 1.23f));
        }
    }
}
