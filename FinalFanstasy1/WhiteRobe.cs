namespace FinalFanstasy1
{
    public class WhiteRobe : Item
    {
        public WhiteRobe()
        {
            setSlotType(SlotTypes.Body);
            setAborbsion(24);
            setEvasion(-2);
            setAllowedClasses(new List<string>{"WhiteWizard"});
            setResistance(new List<string>{"Fire", "Death"});
            getGivenSpells().add("Cure");
        }
    }
}