using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class Ghazt : Monster
    {
        public Ghazt(int Level)
        {
            baseHp = 800;
                        baseAttack = 325;
            level = Level;
            setStats();
            elems = new List<Element>();
            elems.Add(new Element("Plasma"));
            attacks = new List<Attack>();
            attacks.Add(new Attack("Orb Swatter", new Element("None"), 1));
            if (level >= 5) attacks.Add(new Attack("Xylem & Flow 'em", new Element("Plant"), 1.25f));
            if (level >= 10) attacks.Add(new Attack("Got Ghosted", new Element("Plasma"), 1.1f));
        }
    }
}
