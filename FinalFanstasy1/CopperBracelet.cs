namespace FinalFanstasy1
{
    public class CopperBracelet : Item
    {
        public CopperBracelet()
        {
            setSlotType(SlotTypes.Body);
            setAborbsion(4);
            setEvasion(-1);
            setAllowedClasses(new List<string>{"ALL"});
        }
    }
}