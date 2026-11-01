namespace FinalFanstasy1
{
    public class IceShield : Item
    {
        public IceShield()
        {
            setSlotType(SlotTypes.Shield);
            setAborbsion(12);
            setEvasion(0);
            setAllowedClasses(new List<string>{"Fighter", "Ninja"});
            setResistance(new List<string>{"Fire"});
        }
    }
}