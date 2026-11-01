namespace FinalFanstasy1
{
    public class IronSheild : Item
    {
        public IronSheild()
        {
            setSlotType(SlotTypes.Shield);
            setAborbsion(4);
            setEvasion(0);
            setAllowedClasses(new List<string>{"Fighter", "Ninja"});
        }
    }
}