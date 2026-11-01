namespace FinalFanstasy1
{
    public class WoodenArmor : Item
    {
        public WoodenArmor()
        {
            setSlotType(SlotTypes.Body);
            setAborbsion(4);
            setEvasion(-8);
            setAllowedClasses(new List<string>{"Fighter", "Thief", "BlackBelt", "RedMage"});
        }
    }
}