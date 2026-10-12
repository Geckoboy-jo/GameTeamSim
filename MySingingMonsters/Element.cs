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
        public bool isEtherial;
        public Element(string Name)
        {
            name = Name;
            initlizeWeaknessess(name);
            if(name == "Plasma" || name == "Shadow" || name == "Mech" || name == "Crystal" || name == "Poison")
            {isEtherial = true;}
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
                case "Seasonal":
                    break;
            }
        }

    }
}
