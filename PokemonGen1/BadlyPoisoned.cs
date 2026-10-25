namespace PokemonGen1
{
    public class BadlyPoisoned : StatusCondition
    {
        private int turnCount;
        public BadlyPoisoned(){ turnCount = 0; }
        public int getTurnCount() { return turnCount; }
        public void iterateTurn() { turnCount++; }
        public void applyEffect(Pokemon p)
        {
            // Badly poisoned effect: typically reduces HP each turn, increasing over time
            iterateTurn();
            int damage = (p.getMaxHp() / 16) * getTurnCount();
            p.takeDamage(damage);
        }
    }
}