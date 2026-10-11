using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class Entbrat : Monster
    {
        public Entbrat(int Level)
        {
            baseHp = 900;
            baseAttack = 375;
            level = Level;
            setStats();
            elems = new List<Element>();
            elems.Add(new Element("Plant"));
            elems.Add(new Element("Earth"));
            elems.Add(new Element("Water"));
            elems.Add(new Element("Cold"));
            attacks = new List<Attack>();
            attacks.Add(new Attack("Shaggy Bark", new Element("Plant"), 1));
            if (level >= 5) attacks.Add(new Attack("Root Roar", new Element("Earth"), 1.06f));
            if (level >= 10) attacks.Add(new Attack("Gigantic Gurgle", new Element("Water"), 1.12f));
            if (level >= 15) attacks.Add(new Attack("Permafrost", new Element("Cold"), 1.18f));

        }
    }
}
