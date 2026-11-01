namespace FinalFanstasy1
{
    public class SilverSheild : Item
    {
        public SilverSheild()
        {
            setSlotType(SlotTypes.Shield);
            setAborbsion(8);
            setEvasion(0);
            setAllowedClasses(new List<string>{"Fighter", "Ninja"});
        }
    }
}