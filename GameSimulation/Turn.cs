using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation
{
    internal class Turn
    {
        public Character chara;
        List<Dice> usableDice = new List<Dice>();


        Turn()
        {
            for(int i =0; i < chara.diceNum; i++)
            {
                Dice dice = new Dice();
                dice.rollDice(chara.modifier);
                usableDice.Add(dice);
            }

        }

        public void endTurn() { usableDice.Clear(); }
    }
}
