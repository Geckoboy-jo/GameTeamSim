using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class Blabbit : Monster
    {
        public Blabbit(int Level)
        {
            baseHp = 675;
                        baseAttack = 200;
            level = Level;
            setStats();
            elems = new List<Element>();
            elems.Add(new Element("Seasonal"));
            attacks = new List<Attack>();
            attacks.Add(new Attack("Bubble Burst", new Element("Water"), 1));
            if (level >= 5) attacks.Add(new Attack("Eggs-Tra Helping", new Element("None"), 1.14f));
            if (level >= 10) attacks.Add(new Attack("Troubled Waters", new Element("Water"), 1.2f));
        }
    }
}
