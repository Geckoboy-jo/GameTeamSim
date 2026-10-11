using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class Shrubb : Monster
    {
        public Shrubb(int Level)
        {
            baseHp = 375;
                        baseAttack = 140;
            level = Level;
            setStats();
            elems = new List<Element>();
            elems.Add(new Element("Plant"));
            elems.Add(new Element("Earth"));
            attacks = new List<Attack>();
            attacks.Add(new Attack("Saliva Salute", new Element("None"), 1));
            if (level >= 5) attacks.Add(new Attack("Glottal Grounding", new Element("Earth"), 1.23f));
            if (level >= 10) attacks.Add(new Attack("Mahnie on Trees", new Element("Plant"), 1.42f));
        }
    }
}
