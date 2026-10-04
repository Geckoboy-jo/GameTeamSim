using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal partial class Monster
    {
        public float HP { get; set; }
        public float baseHp { get; set; }
        public float Attack { get; set; }
        public float baseAttack { get; set; }

        public int level { get; set; }
        public bool isAlive { get; set; }
        public List<Element> elems;
        public List<Attack> attacks;
        public void setStats()
        {
            HP = (float)(baseHp*(1+.2692f*(level-1)));
            Attack = (float)(baseAttack * (1 + .2692f * (level - 1)));
            isAlive = true;
        }
        public void takeDamage(float damage)
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
