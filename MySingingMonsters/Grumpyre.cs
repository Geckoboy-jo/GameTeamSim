using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class Grumpyre : Monster
    {
        public Grumpyre(int Level)
        {
            baseHp = 850;
                        baseAttack = 320;
            level = Level;
            setStats();
            elems = new List<Element>();
            elems.Add(new Element("Shadow"));
            attacks = new List<Attack>();
            attacks.Add(new Attack("Inscrutable Growl", new Element("None"), 1));
            if (level >= 5) attacks.Add(new Attack("Cold Reading", new Element("Cold"), 1.25f));
            if (level >= 10) attacks.Add(new Attack("Under My Umbral-uh", new Element("Shadow"), 1.1f));
        }
    }
}
