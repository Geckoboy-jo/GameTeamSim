using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class TRox : Monster
    {
        public TRox(int Level)
        {
            baseHp = 650;
                        baseAttack = 200;
            level = Level;
            setStats();
            elems = new List<Element>();
            elems.Add(new Element("Earth"));
            elems.Add(new Element("Water"));
            elems.Add(new Element("Cold"));
            attacks = new List<Attack>();
            attacks.Add(new Attack("Construction Bite", new Element("None"), 1));
            if (level >= 5) attacks.Add(new Attack("Seismic Stomp", new Element("Earth"), 1.07f));
            if (level >= 10) attacks.Add(new Attack("Frosty Footwork", new Element("Cold"), 1.17f));
            if (level >= 15) attacks.Add(new Attack("Hydro Power", new Element("Water"), 1.24f));
        }
    }
}
