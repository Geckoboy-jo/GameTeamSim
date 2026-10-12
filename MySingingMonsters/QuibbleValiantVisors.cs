namespace MySingingMonsters
{
    internal sealed class QuibbleValiantVisors : CostumeVariant
    {
        public QuibbleValiantVisors(int level)
            : base(new Quibble(level), 1, "Valiant Visors", "None", 1.07f, "Keystroke")
        {
        }
    }
}
