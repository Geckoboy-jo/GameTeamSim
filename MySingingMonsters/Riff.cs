using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class Riff : Monster
    {
        public Riff(int Level)
        {
            baseHp = 1200;
                        baseAttack = 325;
            level = Level;
            setStats();
            elems = new List<Element>();
            elems.Add(new Element("Air"));
            elems.Add(new Element("Earth"));
            elems.Add(new Element("Water"));
            elems.Add(new Element("Cold"));
            attacks = new List<Attack>();
            attacks.Add(new Attack("Righteous Shred", new Element("Air"), 1));
            if (level >= 5) attacks.Add(new Attack("Snowstrum", new Element("Cold"), 1.05f));
            if (level >= 10) attacks.Add(new Attack("Tectonic Thrash", new Element("Earth"), 1.09f));
            if (level >= 15) attacks.Add(new Attack("Streaming Solo", new Element("Water"), 1.14f));
        }
    }
}
