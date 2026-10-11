using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class Shellbeat : Monster
    {
        public Shellbeat(int Level)
        {
            baseHp = 1375;
                        baseAttack = 300;
            level = Level;
            setStats();
            elems = new List<Element>();
            elems.Add(new Element("Air"));
            elems.Add(new Element("Plant"));
            elems.Add(new Element("Earth"));
            elems.Add(new Element("Water"));
            attacks = new List<Attack>();
            attacks.Add(new Attack("Flowing Fills", new Element("Water"), 1));
            if (level >= 5) attacks.Add(new Attack("Blossom Backbeat", new Element("Plant"), 1.05f));
            if (level >= 10) attacks.Add(new Attack("In the (Air) Pocket", new Element("Air"), 1.09f));
            if (level >= 15) attacks.Add(new Attack("Trench Groove", new Element("Earth"), 1.13f));
        }
    }
}
