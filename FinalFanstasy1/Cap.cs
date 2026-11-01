namespace FinalFanstasy1
{
    public class Cap : Item
    {
        public Cap()
        {
            setSlotType(SlotTypes.Head);
            setAborbsion(1);
            setEvasion(-1);
            setAllowedClasses(new List<string>{"All"});
        }
    }
}