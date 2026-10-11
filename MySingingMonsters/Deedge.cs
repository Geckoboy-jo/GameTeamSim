using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class Deedge : Monster
    {
        public Deedge(int Level)
        {
            baseHp = 1025;
            baseAttack = 350;
            level = Level;
            setStats();
            elems = new List<Element>();
            elems.Add(new Element("Air"));
            elems.Add(new Element("Plant"));
            elems.Add(new Element("Water"));
            elems.Add(new Element("Cold"));
            attacks = new List<Attack>();
            attacks.Add(new Attack("Chill Vibes", new Element("Cold"), 1));
            if (level >= 5) attacks.Add(new Attack("Waveforms", new Element("Water"), 1.05f));
            if (level >= 10) attacks.Add(new Attack("Seed Sampler", new Element("Plant"), 1.12f));
            if (level >= 15) attacks.Add(new Attack("Air Drop", new Element("Air"), 1.15f));
        }
    }
}
