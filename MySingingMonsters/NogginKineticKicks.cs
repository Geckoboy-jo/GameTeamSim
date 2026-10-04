using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class NogginKineticKicks : Monster
    {

        public NogginKineticKicks(int Level)
        {
            baseHp = 200;
            baseAttack = 80;
            level = Level;
            setStats();
            elems = new List<Element>();
            elems.Add(new Element("Earth"));
            attacks = new List<Attack>();
            attacks.Add(new Attack("Paradiddle", new Element("None"), 1));
            if (level >= 5) attacks.Add(new Attack("Kinetic kicks", new Element("Earth"), 1.25f));

        }
    }
}
