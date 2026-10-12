namespace MySingingMonsters
{
    internal sealed class SpungeWetsuitWhimsy : CostumeVariant
    {
        public SpungeWetsuitWhimsy(int level)
            : base(new Spunge(level), 15, "Wetsuit Whimsy", "Water", 1.2f, "Shrill Siffleur")
        {
        }
    }
}
