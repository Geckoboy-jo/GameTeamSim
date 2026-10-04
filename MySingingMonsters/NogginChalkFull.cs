using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class NogginChalkFull : Monster
    {

        public NogginChalkFull(int Level)
        {
            baseHp = 200;
            baseAttack = 80;
            level = Level;
            setStats();
            elems = new List<Element>();
            elems.Add(new Element("Earth"));
            attacks = new List<Attack>();
            attacks.Add(new Attack("ChalkFull", new Element("None"), 1.1f));
            if (level >= 5) attacks.Add(new Attack("EarthBeat", new Element("Earth"), 1.19f));

        }
    }
}
