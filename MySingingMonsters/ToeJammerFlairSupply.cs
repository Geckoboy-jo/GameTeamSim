namespace MySingingMonsters
{
    internal sealed class ToeJammerFlairSupply : CostumeVariant
    {
        public ToeJammerFlairSupply(int level)
            : base(new ToeJammer(level), 1, "Flair Supply", "Air", 1f, "Doo-Wop")
        {
        }
    }
}
