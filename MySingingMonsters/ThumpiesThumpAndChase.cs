namespace MySingingMonsters
{
    internal sealed class ThumpiesThumpAndChase : CostumeVariant
    {
        public ThumpiesThumpAndChase(int level)
            : base(new Thumpies(level), 15, "Thump and Chase", "Cold", 1.3f, "Dimension Hop")
        {
        }
    }
}
