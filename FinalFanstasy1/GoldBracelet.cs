namespace FinalFanstasy1
{
    public class GoldBracelet : Item
    {
        public GoldBracelet()
        {
            setSlotType(SlotTypes.Body);
            setAborbsion(24);
            setEvasion(-1);
            setAllowedClasses(new List<string>{"ALL"});
        }
    }
}