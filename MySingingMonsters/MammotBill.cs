namespace MySingingMonsters
{
    internal sealed class MammotBill : CostumeVariant
    {
        public MammotBill(int level)
            : base(new Mammot(level), 10, "\"Bill\"", "None", 2f, null)
        {
        }
    }
}
