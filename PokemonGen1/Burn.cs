namespace PokemonGen1
{
    public class Burn : StatusCondition
    {

        public Burn(Pokemon p) { p.setCurrentAttack(p.getCurrentAttack() / 2);}
        public void applyEffect(Pokemon p)
        {
            // Burn effect: typically reduces HP each turn
            int damage = p.getMaxHp() / 16; //also halved damage of physical attacks
            p.takeDamage(damage);
             // halved damage of physical attacks
        }
    }
}