namespace MySingingMonsters
{
    internal sealed class ToeJammerSlipperyWhenIced : CostumeVariant
    {
        public ToeJammerSlipperyWhenIced(int level)
            : base(new ToeJammer(level), 10, "Slippery when Iced", "Cold", 1.2f, null)
        {
        }
    }
}
