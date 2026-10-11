using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class Reebro : Monster
    {
        public Reebro(int Level)
        {
            baseHp = 900;
                        baseAttack = 315;
            level = Level;
            setStats();
            elems = new List<Element>();
            elems.Add(new Element("Mech"));
            attacks = new List<Attack>();
            attacks.Add(new Attack("Suit Stomp", new Element("None"), 1));
            if (level >= 5) attacks.Add(new Attack("Steam Machine", new Element("Air"), 1.25f));
            if (level >= 10) attacks.Add(new Attack("Mech Support", new Element("Mech"), 1.1f));
        }
    }
}
