using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class Punkleton : Monster
    {
        public Punkleton(int Level)
        {
            baseHp = 600;
                        baseAttack = 310;
            level = Level;
            setStats();
            elems = new List<Element>();
            elems.Add(new Element("Seasonal"));
            attacks = new List<Attack>();
            attacks.Add(new Attack("Gourd Scare", new Element("Plant"), 1));
            if (level >= 5) attacks.Add(new Attack("Bone Jangles", new Element("None"), 1.14f));
            if (level >= 10) attacks.Add(new Attack("Patch-work Lilt", new Element("Plant"), 1.2f));
        }
    }
}
