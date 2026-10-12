using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class Quarrister : Monster
    {
        public Quarrister(int Level)
        {
            baseHp = 1500;
            baseAttack = 275;
            level = Level;
            setStats();
            elems = new List<Element>();
            elems.Add(new Element("Air"));
            elems.Add(new Element("Plant"));
            elems.Add(new Element("Earth"));
            elems.Add(new Element("Cold"));
            attacks = new List<Attack>();
            attacks.Add(new Attack("Choral Ensemble", new Element("Earth"), 1));
            if (level >= 5) attacks.Add(new Attack("Breath Support", new Element("Air"), 1.03f));
            if (level >= 10) attacks.Add(new Attack("Cool Cantillation", new Element("Cold"), 1.07f));
            if (level >= 15) attacks.Add(new Attack("Torchle Timbre", new Element("Plant"), 1.12f));
        }
    }
}
