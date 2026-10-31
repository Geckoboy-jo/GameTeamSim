namespace FinalFanstasy1
{
    public class Stat
    {
        #region Properties
        private int baseValue { get; set; }
        private int currentValue { get; set; }
        private int maxValue { get; set; }
        #endregion
        #region Getters and Setters
        public int getBaseValue(){return baseValue;}
        public int getCurrentValue(){return currentValue;}
        public int getMaxValue(){return maxValue;}

        public void setBaseValue(int value){baseValue = value;}
        public void setCurrentValue(int value){currentValue = value;}
        public void setMaxValue(int value){maxValue = value;}
        #endregion
        #region Methods
        //empty for now
        #endregion
    }
}