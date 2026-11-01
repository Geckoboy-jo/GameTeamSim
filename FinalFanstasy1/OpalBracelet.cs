namespace FinalFanstasy1
{
    public class OpalBracelet : Item
    {
        public OpalBracelet()
        {
            setSlotType(SlotTypes.Body);
            setAborbsion(34);
            setEvasion(-1);
            setAllowedClasses(new List<string>{"ALL"});
        }
    }
}