namespace FinalFanstasy1
{
    public class ChainArmor : Item
    {
        public ChainArmor()
        {
            setSlotType(SlotTypes.Body);
            setAborbsion(15);
            setEvasion(-15);
            setAllowedClasses(new List<string>{"Fighter", "RedMage"});
        }
    }
}