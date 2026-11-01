namespace FinalFanstasy1
{
    public class SteelArmor : Item
    {
        public SteelArmor()
        {
            setSlotType(SlotTypes.Body);
            setAborbsion(34);
            setEvasion(-33);
            setAllowedClasses(new List<string>{"Fighter"});
        }
    }
}