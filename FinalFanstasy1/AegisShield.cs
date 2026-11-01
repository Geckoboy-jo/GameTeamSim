namespace FinalFanstasy1
{
    public class AegisShield : Item
    {
        public AegisShield()
        {
            setSlotType(SlotTypes.Shield);
            setAborbsion(16);
            setEvasion(0);
            setAllowedClasses(new List<string>{"Knight"});
            setResistance(new List<string>{"Poison"});
        }
    }
}