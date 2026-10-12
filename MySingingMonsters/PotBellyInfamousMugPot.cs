using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class PotBellyInfamousMugPot : Monster 
    {
        public PotBellyInfamousMugPot(int Level)
        {
            baseHp = 275;
            baseAttack = 65;
            level = Level;
            setStats();
            elems = new List<Element>();
            elems.Add(new Element("Plant"));
            attacks = new List<Attack>();
            attacks.Add(new Attack("Flytrap Duet", new Element("None"), 1));
            if (level >= 10) attacks.Add(new Attack("Infamous Mug Pot", new Element("None"), 1.21f));
            if (level >= 5) attacks.Add(new Attack("Looping Vines", new Element("Plant"), 1.18f));

        }
    }
}
