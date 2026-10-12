namespace MySingingMonsters
{
    internal sealed class BoodooWeAllScream : CostumeVariant
    {
        public BoodooWeAllScream(int level)
            : base(new Boodoo(level), 5, "We All Scream", "Cold", 1.15f, "Jarring Jingle")
        {
        }
    }
}
