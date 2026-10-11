using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class Bellowfish : Monster
    {
        public Bellowfish(int Level)
        {
            baseHp = 1155;
                        baseAttack = 390;
            level = Level;
            setStats();
            elems = new List<Element>();
            elems.Add(new Element("Mech"));
            elems.Add(new Element("Crystal"));
            attacks = new List<Attack>();
            attacks.Add(new Attack("Polka Party", new Element("None"), 1));
            if (level >= 5) attacks.Add(new Attack("Say My Name", new Element("Crystal"), 1.13f));
            if (level >= 10) attacks.Add(new Attack("Fish in a Barrel", new Element("Mech"), 1.22f));
        }
    }
}
