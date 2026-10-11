using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class Jeeode : Monster
    {
        public Jeeode(int Level)
        {
            baseHp = 950;
                        baseAttack = 310;
            level = Level;
            setStats();
            elems = new List<Element>();
            elems.Add(new Element("Crystal"));
            attacks = new List<Attack>();
            attacks.Add(new Attack("Impartial Armonica", new Element("None"), 1));
            if (level >= 5) attacks.Add(new Attack("Perspire-cacity", new Element("Water"), 1.25f));
            if (level >= 10) attacks.Add(new Attack("Carat Caress", new Element("Crystal"), 1.1f));
        }
    }
}
