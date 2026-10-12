using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PokemonOverlord
{
    public abstract class Pokemon
    {
        // Properties
        private float HP { get; set; }
        private float maxHP { get; set; }
        private bool isAlive { get; set; }
        private int rp { get; set; } // Resource points for special moves
        private int maxRP { get; set; }
        private int bp { get; set; } // Battle points for special moves
        private int maxBP { get; set; }

        private float attack { get; set; }
        private float speed { get; set; }
        private float defense { get; set; }



        // Constructor
        public Pokemon(float Max)
        {
            HP = Max;
            maxHP = Max;
            isAlive = true;
        }

        public void takeDamage(float damage)
        {
            HP -= damage;
            if (HP < 0) HP = 0;
            if (HP == 0) isAlive = false;
        }
        public void heal(float amount)
        {
            HP += amount;
            if(HP > maxHP) HP = maxHP;
        }


    }

}
