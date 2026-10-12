namespace MySingingMonsters
{
    internal sealed class PunkletonMouthWaterer : CostumeVariant
    {
        public PunkletonMouthWaterer(int level)
            : base(new Punkleton(level), 5, "Mouth Waterer", "Water", 1.05f, "Bone Jangles")
        {
        }
    }
}
