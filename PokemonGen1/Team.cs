namespace PokemonGen1
{
    public class Team
    {
        // Team implementation goes here
        private List<Pokemon> members;
        private Pokemon activeMember;

        public Team()
        {
            members = new List<Pokemon>();
            activeMember = null;
        }
        ~Team()
        {
            members.Clear();
            activeMember = null;
        }
        
        public void addMember(Pokemon p){members.Add(p); }
        public List<Pokemon> getMembers(){return members;}
        public int getMemberCount(){return members.Count;}
        public Pokemon getActiveMember(){return activeMember;}
        public void setActiveMember(Pokemon p){activeMember = p;}

    }
}