namespace FinalFanstasy1
{
    public class SilverBracelet : Item
    {
        public SilverBracelet()
        {
            setSlotType(SlotTypes.Body);
            setAborbsion(15);
            setEvasion(-1);
            setAllowedClasses(new List<string>{"ALL"});
        }
    }
}