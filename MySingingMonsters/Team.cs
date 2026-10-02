using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class Team
    {
        public Monster First;
        public Monster Second;
        public Monster Third;

        public Monster Active;
        Team(Monster first, Monster second, Monster third)
        {
            First = first;
            Second = second;
            Third = third;
            Active = First;
        }

    }
}
