using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class Element
    {
        public string name;
        public string weakTo;

        public Element(string Name)
        {
            name = Name;
            initlizeWeaknessess(name);
             
        }
        public void initlizeWeaknessess(string name)
        {
            switch(name)
            {
                case "Cold":
                    weakTo = "Water";
                    break;
                case "Air":
                    weakTo = "Earth";
                    break;
                case "Earth":
                    weakTo = "Cold";
                    break;
                case "Water":
                    weakTo = "Plant";
                    break;
                case "Plant":
                    weakTo = "Air";
                    break;
                case "Plasma":
                    weakTo = "Shadow";
                    break;
                case "Shadow":
                    weakTo = "Mech";
                    break;
                case "Mech":
                    weakTo = "Crystal";
                    break;
                case "Crystal":
                    weakTo = "Poison";
                    break;
                case "Poison":
                    weakTo = "Plasma";
                    break;
                case "None":
                    break;
            }
        }

    }
}
