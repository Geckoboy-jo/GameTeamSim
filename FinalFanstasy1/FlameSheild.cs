namespace FinalFanstasy1
{
    public class FlameSheild : Item
    {
        public FlameSheild()
        {
            setSlotType(SlotTypes.Shield);
            setAborbsion(12);
            setEvasion(0);
            setAllowedClasses(new List<string>{"Fighter", "Ninja"});
            setResistance(new List<string>{"Cold"});
        }
    }
}