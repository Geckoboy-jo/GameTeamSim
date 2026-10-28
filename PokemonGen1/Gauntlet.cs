namespace PokemonGen1
{
    public class Gauntlet
    {   
        private string catagory;
        private Team PlayerTeam;
        private Team OpponentTeam;
        private int round; 
        private PokemonFinder finder;

        public Gauntlet(string catagory, Team pt)
        {
            this.catagory = catagory;
            PlayerTeam = pt;
            OpponentTeam = new Team(); // Initialize the opponent team as a new team
            finder = new PokemonFinder(catagory); // Initialize the PokemonFinder
        }

        public void NextRound()
        {
            setRound(round + 1); 
            finder.FillTeam(OpponentTeam, round); // Generate a new opponent team for the round
            Battle CurrentBattle = new Battle(PlayerTeam, OpponentTeam);
        }

        //getters and setters
        public int getRound() {return round;}
        public Team getPlayerTeam() {return PlayerTeam;}
        public Team getOpponentTeam() {return OpponentTeam;}
        public string getCatagory() {return catagory;}
        public PokemonFinder getFinder() {return finder;}
        public void setRound(int newRound)
        {
            round = newRound;
            if (round > 100) round = 100;
        }
        public void setPlayerTeam(Team newTeam) { PlayerTeam = newTeam; }
        public void setOpponentTeam(Team newTeam) { OpponentTeam = newTeam; }
        public void setCatagory(string newCatagory) { catagory = newCatagory; }
        public void setFinder(PokemonFinder newFinder) { finder = newFinder; }
    }   
}