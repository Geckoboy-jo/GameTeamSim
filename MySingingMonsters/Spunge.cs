using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class Spunge : Monster
    {
        


        public Spunge(int Level)
        {
            baseHp = 640;
            baseAttack = 205;
            level = Level;
            setStats();
            elems = new List<Element>();
            elems.Add(new Element("Plant"));
            elems.Add(new Element("Water"));
            elems.Add(new Element("Air"));
            attacks = new List<Attack>();
            attacks.Add(new Attack("windWhistle", new Element("None"), 1  ));
            if (level >= 5) attacks.Add(new Attack("Take off hoser", new Element("Water"), 1.05f));
            if (level >= 10) attacks.Add(new Attack("Pulpy Pucker", new Element("Plant"), 1.12f));
            if (level >= 15) attacks.Add(new Attack("Shrill Self", new Element("Air"), 1.15f));

        }
    }
}
