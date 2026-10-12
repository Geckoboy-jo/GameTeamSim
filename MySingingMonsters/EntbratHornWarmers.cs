namespace MySingingMonsters
{
    internal sealed class EntbratHornWarmers : CostumeVariant
    {
        public EntbratHornWarmers(int level)
            : base(new Entbrat(level), 10, "Horn Warmers", "Air", 1.2f, "Gigantic Gurgle")
        {
        }
    }
}
