namespace PokemonGen1
{
    public class Sleep : StatusCondition
    {
        private int turnCount;
        public Sleep(Pokemon p){ turnCount = 0; }
        public int getTurnCount() { return turnCount; }
        public void iterateTurn() { turnCount++; }
        public void applyEffect(Pokemon p)
        {
            // Sleep effect: typically prevents action for a number of turns
            iterateTurn();
            // Implementation for preventing action would go here
            if(getTurnCount()==1) if(new Random().Next(1,4) == 1) p.setStatusCondition(new NoStatus(p));
            else if(getTurnCount() > 1 && getTurnCount() < 7) if(new Random().Next(1,8) == 1) p.setStatusCondition(new NoStatus(p));
            else if(getTurnCount() >= 7) p.setStatusCondition(new NoStatus(p));
        }
    }
}