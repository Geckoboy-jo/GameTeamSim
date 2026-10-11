using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class Dragong : Monster
    {
        public Dragong(int Level)
        {
            baseHp = 1190;
                        baseAttack = 380;
            level = Level;
            setStats();
            elems = new List<Element>();
            elems.Add(new Element("Mech"));
            elems.Add(new Element("Poison"));
            attacks = new List<Attack>();
            attacks.Add(new Attack("Bang a Gong", new Element("None"), 1));
            if (level >= 5) attacks.Add(new Attack("Plates Spinning", new Element("Mech"), 1.12f));
            if (level >= 10) attacks.Add(new Attack("Toxungen Toll", new Element("Poison"), 1.24f));
        }
    }
}
