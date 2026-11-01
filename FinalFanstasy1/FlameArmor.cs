namespace FinalFanstasy1
{
    public class FlameArmor : Item
    {
        public FlameArmor()
        {
            setSlotType(SlotTypes.Body);
            setAborbsion(34);
            setEvasion(-10);
            setAllowedClasses(new List<string>{"Fighter", "Ninja"});
            setResistance(new List<string>{"Cold"});
        }
    }
}