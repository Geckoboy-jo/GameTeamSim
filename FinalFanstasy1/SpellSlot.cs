namespace FinalFanstasy1
{
    public class SpellSlot
    {
        #region Properties

        private int maxSlots { get; set; }
        private int remainingSlots { get; set; }
        private int level { get; set; }
        #endregion
        public SpellSlot(int level)
        {
            this.level = level;
        }
        #region Getters and Setters
        public int getMaxSlots(){return maxSlots;}
        public int getRemainingSlots(){return remainingSlots;}
        public int getLevel(){return level;}

        public void setMaxSlots(int maxSlots){this.maxSlots = maxSlots;}
        public void setRemainingSlots(int remainingSlots){this.remainingSlots = remainingSlots;}
        public void setLevel(int level){this.level = level;}
        #endregion
        #region methods
        public void useSlot()
        {
            if (remainingSlots > 0)
                remainingSlots--;
        }
        public void resetSlots()
        {
            remainingSlots = maxSlots;
        }
        #endregion
    }
}