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

        public bool lost;
        public Team(Monster First, Monster Second, Monster Third)
        {
            this.First = First;
            this.Second = Second;
            this.Third = Third;
            this.Active = First;
            lost = false;
        }
        public List<Monster> getMonsters()
        {
            return new List<Monster> { First, Second, Third };
        }

    }
}
