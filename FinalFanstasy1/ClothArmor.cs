namespace FinalFanstasy1
{
    public class ClothArmor : Item
    {
        public ClothArmor()
        {
            setSlotType(SlotTypes.Body);
            setAborbsion(1);
            setEvasion(-2);
            setAllowedClasses(new List<string>{"All"});
        }
    }
}