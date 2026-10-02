using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class Monster
    {
        public float HP { get; set; }
        public float baseHp { get; set; }
        public float Attack { get; set; }
        public float baseAttack { get; set; }

        public int level { get; set; }
        private bool isAlive { get; set; }
        public List<Element> elems;

        public void setStats()
        {
            HP = (float)(baseHp*(1+.2692*(level-1)));
            Attack = (float)(baseAttack * (1 + .2692 * (level - 1)));
        }
        public void takeDame(float damage)
        {
            HP -= damage;
            if (HP <= 0)
            {
                isAlive = false;
                HP = 0;
            }
        }
        public void heal(float healAmount)
        {
            HP += healAmount;
            if (HP > baseHp){HP = baseHp;}
        }
       
    }
}
