using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class Oaktopus : Monster
    {
        public Oaktopus(int Level)
        {
            baseHp = 365;
                        baseAttack = 145;
            level = Level;
            setStats();
            elems = new List<Element>();
            elems.Add(new Element("Plant"));
            elems.Add(new Element("Water"));
            attacks = new List<Attack>();
            attacks.Add(new Attack("Rumble Rasp", new Element("None"), 1));
            if (level >= 5) attacks.Add(new Attack("Tentacle Canticle", new Element("Water"), 1.14f));
            if (level >= 10) attacks.Add(new Attack("Sapling Shanty", new Element("Plant"), 1.21f));
        }
    }
}
