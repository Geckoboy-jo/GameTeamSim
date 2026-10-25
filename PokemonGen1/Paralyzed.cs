namespace PokemonGen1
{
    public class Paralyzed : StatusCondition
    {
        public void applyEffect(Pokemon p)
        {
            // Paralysis effect: typically reduces speed and may prevent action
            p.setCurrentSpeed((int)(p.getCurrentSpeed() * .75)); // reduced speed due to paralysis
        }
    }
}