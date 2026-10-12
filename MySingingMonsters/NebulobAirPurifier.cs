namespace MySingingMonsters
{
    internal sealed class NebulobAirPurifier : CostumeVariant
    {
        public NebulobAirPurifier(int level)
            : base(new Nebulob(level), 15, "Air Purifier", "Air", 1.3f, null)
        {
        }
    }
}
