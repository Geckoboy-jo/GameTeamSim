namespace FinalFanstasy1
{
    public class OpalShield : Item
    {
        public OpalShield()
        {
            setSlotType(SlotTypes.Shield);
            setAborbsion(16);
            setEvasion(0);
            setAllowedClasses(new List<string>{"Knight"});
            setResistance(new List<string>{"Lightning"});
        }
    }
}