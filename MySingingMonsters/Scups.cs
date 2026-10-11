using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class Scups : Monster
    {
        public Scups(int Level)
        {
            baseHp = 660;
                        baseAttack = 195;
            level = Level;
            setStats();
            elems = new List<Element>();
            elems.Add(new Element("Air"));
            elems.Add(new Element("Earth"));
            elems.Add(new Element("Water"));
            attacks = new List<Attack>();
            attacks.Add(new Attack("Suctioneer", new Element("None"), 1));
            if (level >= 5) attacks.Add(new Attack("Adherent Anthem", new Element("Earth"), 1.08f));
            if (level >= 10) attacks.Add(new Attack("Far-reaching Call", new Element("Air"), 1.13f));
            if (level >= 15) attacks.Add(new Attack("Slosh-Along", new Element("Water"), 1.21f));
        }
    }
}
