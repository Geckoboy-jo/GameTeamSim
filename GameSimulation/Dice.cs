using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation
{
    internal class Dice
    {
        //value of the dice capped at 6
        public int value;
        
        

        //roll dice function 
        public void rollDice(int modifier)
        {
            Random random = new Random();
            value = random.Next(1,7) + modifier;
            if (value > 6) value = 6;
            if (value < 1) value = 1;
        }
        

    }
}
