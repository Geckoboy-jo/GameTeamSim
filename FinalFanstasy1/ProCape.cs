namespace FinalFanstasy1
{
    public class ProCape : Item
    {
        public ProCape()
        {
            setSlotType(SlotTypes.Shield);
            setAborbsion(8);
            setEvasion(-2);
            setAllowedClasses(new List<string>{"Fighter", "Thief", "RedMage", "WhiteMage", "BlackMage"});
        }
    }
}