using static System.Reflection.Assembly;
using System.Reflection;
namespace PokemonGen1
{
    public class PokemonFinder
    {
        public List<string> availablePokemon;
        string catagory;



        public void FillTeam(Team team){ while(team.isFull() == false) team.addMember(getRandomPokemon(new Random().Next(1, 101)));}
        public PokemonFinder(string newCatagory)
        {
            this.catagory = newCatagory;
            availablePokemon = new List<string>();
            populateList(catagory);
        }

        public Pokemon getRandomPokemon(int level){return getPokemonByName(availablePokemon[new Random().Next(availablePokemon.Count)], level);}
        public Pokemon getPokemonByName(string name, int level)
        {
            var type = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == name);
            if (type != null)
            {
                Pokemon p = (Pokemon)Activator.CreateInstance(type)!;
                p.setLevel(level);
                return p;
            }
            return null;
        }
        public void populateList(){populateList("All");}
        public void populateList(string catagory)
        {
            if(catagory == "All" || catagory == "")
            {
                addAllPokemon();
                return;
            }
            var type = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == catagory);
            if (type != null)
            {
                Pokemon p = (Pokemon)Activator.CreateInstance(type)!;
                addPokemonByType(new Element(catagory));
            }
            else
            {
                Console.WriteLine("Unknown category: " + catagory);
            }
            
        }
        public void addAllPokemon()
        {
            foreach(Pokemon p in Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsSubclassOf(typeof(Pokemon)) && t.Name != "Pokemon").Select(t => (Pokemon)Activator.CreateInstance(t)!))
            {
                availablePokemon.Add(p.getName());
            }
        }
        public void addPokemonByType(Element type)
        {
            foreach(Pokemon p in Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsSubclassOf(typeof(Pokemon)) && t.Name != "Pokemon").Select(t => (Pokemon)Activator.CreateInstance(t)!))
            {
                if(p.getTypes().Any(t => t.getName() == type.getName()))
                {
                    availablePokemon.Add(p.getName());
                }
            }
        }
    }
}