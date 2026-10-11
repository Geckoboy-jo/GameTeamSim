using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class Dandidoo : Monster
    {
        public Dandidoo(int Level)
        {
            baseHp = 500;
                        baseAttack = 110;
            level = Level;
            setStats();
            elems = new List<Element>();
            elems.Add(new Element("Plant"));
            elems.Add(new Element("Air"));
            attacks = new List<Attack>();
            attacks.Add(new Attack("Dainty Ditty", new Element("None"), 1));
            if (level >= 5) attacks.Add(new Attack("Dandifloret Flurry", new Element("Plant"), 1.16f));
            if (level >= 10) attacks.Add(new Attack("Sashay Away", new Element("Air"), 1.38f));
        }
    }
}
