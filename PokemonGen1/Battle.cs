namespace PokemonGen1
{
    public class Battle
    {
        private Team Player;
        private Team Opponent;
        private List<StageEffect> StageEffects;
        public Battle(Team player, Team opponent)
        {
            Player = player;
            Opponent = opponent;
            StageEffects = new List<StageEffect>();
        }
        
        public Team getPlayerTeam(){return Player;}
        public Team getOpponentTeam(){return Opponent;}
        public List<StageEffect> getStageEffects(){return StageEffects;}
        public Move chooseOpponentMove(AIEngine ai, IReadOnlyList<Move> opponentMoveSlots, int? disabledMoveIndex = null)
        {
            ArgumentNullException.ThrowIfNull(ai);
            ArgumentNullException.ThrowIfNull(opponentMoveSlots);

            Pokemon trainerPokemon = Opponent.getActiveMember();
            Pokemon playerPokemon = Player.getActiveMember();
            if (trainerPokemon == null || playerPokemon == null)
                throw new InvalidOperationException("Both teams need an active Pokémon before trainer AI can choose a move.");

            return ai.ChooseMove(trainerPokemon, playerPokemon, opponentMoveSlots, disabledMoveIndex);
        }
        public void addStageEffect(StageEffect effect){StageEffects.Add(effect);}
        public void applyStageEffects()
        {
            foreach(var effect in StageEffects)
            {
                effect.applyEffect(this);
            }
        }

        
        

    }
}