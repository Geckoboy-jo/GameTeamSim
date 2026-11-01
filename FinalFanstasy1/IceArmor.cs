namespace FinalFanstasy1
{
    public class IceArmor : Item
    {
        public IceArmor()
        {
            setSlotType(SlotTypes.Body);
            setAborbsion(34);
            setEvasion(-10);
            setAllowedClasses(new List<string>{"Fighter", "Ninja"});
            setResistance(new List<string>{"Fire"});
        }
    }
}