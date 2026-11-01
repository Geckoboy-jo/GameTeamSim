namespace FinalFanstasy1
{
    public class BlackRobe : Item
    {
        public BlackRobe()
        {
            setSlotType(SlotTypes.Body);
            setAborbsion(24);
            setEvasion(-2);
            setAllowedClasses(new List<string>{"BlackWizard"});
            setResistance(new List<string>{"Ice", "Time"});
        }
    }
}