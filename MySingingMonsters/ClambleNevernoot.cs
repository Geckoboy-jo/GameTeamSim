namespace MySingingMonsters
{
    internal sealed class ClambleNevernoot : CostumeVariant
    {
        public ClambleNevernoot(int level)
            : base(new Clamble(level), 15, "Nevernoot", "Cold", 1.28f, "Glacial Glissando")
        {
        }
    }
}
