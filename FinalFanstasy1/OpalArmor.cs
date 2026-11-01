namespace FinalFantasy1
{
    public class OpalArmor : Item
    {
        public OpalArmor()
        {
            setSlotType(SlotTypes.Body);
            setAborbsion(42);
            setEvasion(-10);
            setAllowedClasses(new List<string>{"Knight"});
            setResistance(new List<string>{"Lightning"});
        }
    }
}