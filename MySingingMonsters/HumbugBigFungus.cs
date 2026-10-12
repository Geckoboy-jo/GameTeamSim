namespace MySingingMonsters
{
    internal sealed class HumbugBigFungus : CostumeVariant
    {
        public HumbugBigFungus(int level)
            : base(new Humbug(level), 5, "Big Fungus", "Poison", 1.2f, "Foreign Contaminant")
        {
        }
    }
}
