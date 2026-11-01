namespace FinalFanstasy1
{
    public class Buckler : Item
    {
        public Buckler()
        {
            setSlotType(SlotTypes.Shield);
            setAborbsion(2);
            setEvasion(0);
            setAllowedClasses(new List<string>{"Fighter", "Thief", "RedMage"});
        }
    }
}