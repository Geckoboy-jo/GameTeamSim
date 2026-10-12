namespace MySingingMonsters
{
    internal sealed class BellowfishCrystalHabit : CostumeVariant
    {
        public BellowfishCrystalHabit(int level)
            : base(new Bellowfish(level), 10, "Crystal Habit", "Crystal", 1.28f, "Fish in a Barrel")
        {
        }
    }
}
