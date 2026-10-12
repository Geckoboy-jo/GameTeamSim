namespace MySingingMonsters
{
    internal sealed class ClambleVeggieBurger : CostumeVariant
    {
        public ClambleVeggieBurger(int level)
            : base(new Clamble(level), 5, "Veggie Burger", "Plant", 1.13f, "Cymbalic Crash")
        {
        }
    }
}
