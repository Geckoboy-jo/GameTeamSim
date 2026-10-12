namespace MySingingMonsters
{
    internal sealed class BellowfishAquaslimeSpout : CostumeVariant
    {
        public BellowfishAquaslimeSpout(int level)
            : base(new Bellowfish(level), 1, "Aquaslime Spout", "Water", 1.07f, "Polka Party")
        {
        }
    }
}
