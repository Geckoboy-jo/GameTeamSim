namespace MySingingMonsters
{
    internal sealed class ClambleYouVeGotMail : CostumeVariant
    {
        public ClambleYouVeGotMail(int level)
            : base(new Clamble(level), 1, "You've Got Mail", "Earth", 1.09f, "Hi-Hat Sizzle")
        {
        }
    }
}
