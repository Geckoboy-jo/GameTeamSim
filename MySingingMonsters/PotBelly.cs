using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class PotBelly : Monster
    {
        


        public PotBelly(int Level)
        {
            baseHp = 175;
            baseAttack = 85;
            level = Level;
            setStats();
            elems = new List<Element>();
            elems.Add(new Element("Plant"));
            attacks = new List<Attack>();
            attacks.Add(new Attack("Flytrap duet", new Element("None"), 1  ));
            if (level >= 5) attacks.Add(new Attack("Looping Vine", new Element("Plant"), 1.18f));

        }
    }
}
