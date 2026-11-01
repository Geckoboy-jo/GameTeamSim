namespace FinalFanstasy1
{
    public class Item
    {
        #region Properties
        private int aborbsion;
        private int evasion;
        private List<string> resistance = new List<string>();
        private SlotTypes slotType;
        private List<string> allowedClasses = new List<string>();
        private List<string> givenSpells = new List<string>();
        #endregion
        #region Getters and Setters
        public int getAborbsion(){return aborbsion;}
        public int getEvasion(){return evasion;}
        public List<string> getResistance(){return resistance;}
        public SlotTypes getSlotType(){return slotType;}
        public List<string> getAllowedClasses(){return allowedClasses;}
        public List<string> getGivenSpells(){return givenSpells;}

        public void setAborbsion(int aborbsion){this.aborbsion = aborbsion;}
        public void setEvasion(int evasion){this.evasion = evasion;}
        public void setResistance(List<string> resistance){this.resistance = resistance;}
        public void setSlotType(SlotTypes slotType){this.slotType = slotType;}  
        public void setAllowedClasses(List<string> allowedClasses){this.allowedClasses = allowedClasses;}
        public void setGivenSpells(List<string> givenSpells){this.givenSpells = givenSpells;}
        #endregion
        #region Methods
        
        #endregion
    }
}