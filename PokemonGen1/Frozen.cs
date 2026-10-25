using System;
namespace PokemonGen1
{
    public class Frozen : StatusCondition
    {
        public void applyEffect(Pokemon p)
        {
            // Frozen effect: typically prevents action each turn
            // For simplicity, we won't implement thawing mechanics here
            if (new Random().NextDouble() < 0.05) // Example: 5% chance to thaw each turn
            {
                p.setStatusCondition(new NoStatus(p));
            }
        }
    }
}