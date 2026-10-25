namespace PokemonGen1
{
    public class Poison : StatusCondition
    {
        public void applyEffect(Pokemon p)
        {
            // Poison effect: typically reduces HP each turn
            int damage = p.getMaxHp() / 16;
            p.takeDamage(damage);
        }
    }
}