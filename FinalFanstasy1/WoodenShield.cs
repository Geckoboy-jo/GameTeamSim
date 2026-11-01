namespace FinalFanstasy1
{
    public class WoodenShield : Item
    {
        public WoodenShield()
        {
            setSlotType(SlotTypes.Shield);
            setAborbsion(2);
            setEvasion(0);
            setAllowedClasses(new List<string>{"Fighter", "Ninja"});
        }
    }
}