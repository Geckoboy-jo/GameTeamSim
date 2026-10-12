namespace MySingingMonsters
{
    internal sealed class WhispFractalCrown : CostumeVariant
    {
        public WhispFractalCrown(int level)
            : base(new Whisp(level), 10, "Fractal Crown", "Cold", 1.23f, "Hover Haunt")
        {
        }
    }
}
