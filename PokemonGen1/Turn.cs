namespace PokemonGen1
{
    class Turn
    {
        private Pokemon activePokemon;
        private Move selectedMove;

        public Turn(Pokemon activePokemon, Move selectedMove)
        {
            this.activePokemon = activePokemon;
            this.selectedMove = selectedMove;
            executeTurn();
        }
        private void executeTurn()
        {   
            if(selectedMove is SwitchActive sa)
            {
                sa.moveEffect(activePokemon);
                return;
            }
            StatusCondition status = activePokemon.getStatusCondition();
            if(status is Paralyzed p)
            {
                if(new Random().Next(0, 4) != 1) selectedMove.moveEffect(activePokemon); // 25% chance to be fully paralyzed
            }
            else if(status is not Frozen f && status is not Sleep s)
            {
                selectedMove.moveEffect(activePokemon); 
            }
            status.ApplyEffect(activePokemon); // If frozen or asleep, still attempt the move effect
            
        }


        public Pokemon getActivePokemon() { return activePokemon; }
        public Move getSelectedMove() { return selectedMove; }
        public Pokemon getTarget() { return selectedMove.getTarget(); }
    }
}