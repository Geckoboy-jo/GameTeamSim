namespace MySingingMonsters
{
    internal sealed class CongleCatchOfTheDay : CostumeVariant
    {
        public CongleCatchOfTheDay(int level)
            : base(new Congle(level), 15, "Catch of the Day", "Cold", 1.28f, "Turbo Tumbao")
        {
        }
    }
}
