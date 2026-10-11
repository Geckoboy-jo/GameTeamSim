using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class Team
    {
        public List<Monster> Monsters { get; }

        public Monster Active;

        public bool lost;
        public Team(List<Monster> monsters)
        {
            if (monsters.Count == 0)
            {
                throw new ArgumentException("A team must contain at least one monster.", nameof(monsters));
            }

            Monsters = new List<Monster>(monsters);
            Active = Monsters[0];
            lost = false;
        }

    }
}
