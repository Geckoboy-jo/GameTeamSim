namespace FinalFanstasy1
{
    public class IronArmor : Item
    {
        public IronArmor()
        {
            setSlotType(SlotTypes.Body);
            setAborbsion(24);
            setEvasion(-23);
            setAllowedClasses(new List<string>{"Fighter"});
        }
    }
}