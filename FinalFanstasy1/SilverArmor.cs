namespace FinalFanstasy1
{
    public class SilverArmor : Item
    {
        public SilverArmor()
        {
            setSlotType(SlotTypes.Body);
            setAborbsion(18);
            setEvasion(-8);
            setAllowedClasses(new List<string>{"Fighter", "RedMage"});
        }
    }
}