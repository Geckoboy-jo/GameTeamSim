namespace FinalFanstasy1
{
    public class Class : Character
    {
        #region Properties
        private Item headSlot;
        private Item bodySlot;
        private Item handSlot;
        private Item shieldSlot;
        private int aborbsion;
        private int evasion;
        #endregion
    
        #region Getters and Setters
        public Item getHeadSlot(){return headSlot;}
        public Item getBodySlot(){return bodySlot;}
        public Item getHandSlot(){return handSlot;}
        public Item getShieldSlot(){return shieldSlot;}
        public int getAborbsion(){return aborbsion;}

        public void setHeadSlot(Item headSlot){this.headSlot = headSlot;}
        public void setBodySlot(Item bodySlot){this.bodySlot = bodySlot;}
        public void setHandSlot(Item handSlot){this.handSlot = handSlot;}
        public void setShieldSlot(Item shieldSlot){this.shieldSlot = shieldSlot;}
        public void setAborbsion(int aborbsion){this.aborbsion = aborbsion;}
        #endregion
        #region Methods
        public void calculateTotalStatsFromEquipment()
        {
            if (headSlot != null) applyStats(headSlot);
            if (bodySlot != null) applyStats(bodySlot);
            if (handSlot != null) applyStats(handSlot);
            if (shieldSlot != null) applyStats(shieldSlot);
        }
        public void applyStats(Item item)
        {
            aborbsion += item.getAborbsion();

        }
        #endregion
        
    }
}