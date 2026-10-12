namespace MySingingMonsters
{
    internal sealed class QuarristerTentacool : CostumeVariant
    {
        public QuarristerTentacool(int level)
            : base(new Quarrister(level), 10, "Tentacool", "Water", 1.09f, "Cool Cantillation")
        {
        }
    }
}
