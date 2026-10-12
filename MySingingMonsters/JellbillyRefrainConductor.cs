namespace MySingingMonsters
{
    internal sealed class JellbillyRefrainConductor : CostumeVariant
    {
        public JellbillyRefrainConductor(int level)
            : base(new Jellbilly(level), 5, "Refrain Conductor", "None", 1.19f, "Stingsong")
        {
        }
    }
}
