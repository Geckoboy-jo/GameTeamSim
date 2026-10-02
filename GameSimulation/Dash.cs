using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation
{
    public class Dash : Ability
    {
        Dash()
        {
            diceCost = 1;
            attackType = "burst";
            range = 0;
        }
        
        public bool upgrone;
        public bool upgrtwo;

        public void useAbility(Dice dice)
        {
            if (upgrone && upgrtwo) user.speed += dice.value + 2;
            else if ((!upgrone && upgrtwo) || (upgrone && !upgrtwo)) user.speed += dice.value + 1;
            else user.speed += dice.value;
            
        }
    }
}
