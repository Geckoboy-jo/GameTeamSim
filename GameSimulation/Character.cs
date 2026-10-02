using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation
{
    internal class Character
    {
        //attributes
        public int maxHP{get; set;}
        public int hp { get; set;}
        public int MaxSpeed { get; set;}
        public int speed {  get; set;}
        public int maxDice {  get; set;}
        public int diceNum {  get; set;}
        public int shield {  get; set;}
        public bool isDead {  get;set; }
        public bool isUndead {  get;set; }
        public int team {  get; set; }
        public int modifier { get; set; }

        



        public void takeDamage(int damage)
        {
            if(damage>shield)
            {
                damage-=shield;
                shield = 0 ;
            }
            else if(damage<=shield)
            {
                shield -=damage;
                return;
            }
            hp -= damage;
            if (hp <= 0) isDead = true;

        }
        public void heal(int num)
        {
            if(!isDead && !isUndead)
            {
                hp+=num;
                if (hp > maxHP) hp=maxHP;
            }
            if (!isDead && isUndead) takeDamage(num);  
        }
        public void gainShield(int num) { shield+=num; }
    }
}
