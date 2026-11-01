namespace FinalFanstasy1
{
    public class DragonArmor : Item
    {
        public DragonArmor()
        {
            setSlotType(SlotTypes.Body);
            setAborbsion(42);
            setEvasion(-10);
            setAllowedClasses(new List<string>{"Knight"});
            setResistance(new List<string>{"Fire", "Cold", "Lightning"});
        }
    }
}