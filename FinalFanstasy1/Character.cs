namespace FinalFanstasy1
{
    public class Character
    {
        #region Properties
        private Stat Health  = new Stat();
        private Stat Strength  = new Stat();
        private Stat Agility  = new Stat();
        private Stat Intelligence  = new Stat();
        private Stat Vitality  = new Stat();
        private Stat Luck  = new Stat();
        private Stat hitPercentage  = new Stat();
        private Stat MagicDefence  = new Stat();
        private bool IsAlive { get; set; }
        private SpellSlot L1 { get; set; } = new SpellSlot(1);
        private SpellSlot L2 { get; set; } = new SpellSlot(2);
        private SpellSlot L3 { get; set; } = new SpellSlot(3);
        private SpellSlot L4 { get; set; } = new SpellSlot(4);
        private SpellSlot L5 { get; set; } = new SpellSlot(5);
        private SpellSlot L6 { get; set; } = new SpellSlot(6);
        private SpellSlot L7 { get; set; } = new SpellSlot(7);
        private SpellSlot L8 { get; set; } = new SpellSlot(8);

        #endregion
        #region Getters and Setters
        //getters and setters
        public Stat getHealth(){return Health;}
        public Stat getStrength(){return Strength;}
        public Stat getAgility(){return Agility;}
        public Stat getIntelligence(){return Intelligence;}
        public Stat getVitality(){return Vitality;}
        public Stat getLuck(){return Luck;}
        public Stat getHitPercentage(){return hitPercentage;}
        public Stat getMagicDefence(){return MagicDefence;}
        public bool getIsAlive(){return IsAlive;}
        public SpellSlot getL1(){return L1;}
        public SpellSlot getL2(){return L2;}
        public SpellSlot getL3(){return L3;}
        public SpellSlot getL4(){return L4;}
        public SpellSlot getL5(){return L5;}
        public SpellSlot getL6(){return L6;}
        public SpellSlot getL7(){return L7;}
        public SpellSlot getL8(){return L8;}

        public void setHealth(Stat health){Health = health;}
        public void setStrength(Stat strength){Strength = strength;}
        public void setAgility(Stat agility){Agility = agility;}
        public void setIntelligence(Stat intelligence){Intelligence = intelligence;}
        public void setVitality(Stat vitality){Vitality = vitality;}
        public void setLuck(Stat luck){Luck = luck;}
        public void setHitPercentage(Stat hitPercentage){this.hitPercentage = hitPercentage;}
        public void setMagicDefence(Stat magicDefence){MagicDefence = magicDefence;}
        public void setIsAlive(bool isAlive){IsAlive = isAlive;}
        public void setL1(SpellSlot l1){L1 = l1;}
        public void setL2(SpellSlot l2){L2 = l2;}
        public void setL3(SpellSlot l3){L3 = l3;}
        public void setL4(SpellSlot l4){L4 = l4;}
        public void setL5(SpellSlot l5){L5 = l5;}
        public void setL6(SpellSlot l6){L6 = l6;}
        public void setL7(SpellSlot l7){L7 = l7;}
        public void setL8(SpellSlot l8){L8 = l8;}
        #endregion
        #region Methods
        public void takeDamage(int damage)
        {
            getHealth().setCurrent(getHealth().getCurrent() - damage);
            if (getHealth().getCurrent() <= 0)
            {
                setIsAlive(false);
                getHealth().setCurrent(0);
            }
        }
        public void heal(int amount)
        {if (getIsAlive()) getHealth().setCurrent(Math.Min(getHealth().getCurrent() + amount, getHealth().getMax()));}
        
        
        #endregion
    }
}