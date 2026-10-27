namespace PokemonGen1
{
    public class Element : IEquatable<Element>
    {
        private static readonly IReadOnlyDictionary<string, string[]> ResistedTypes =
            new Dictionary<string, string[]>(StringComparer.Ordinal)
            {
                ["Fire"] = ["Water", "Fire", "Rock", "Dragon"],
                ["Water"] = ["Water", "Grass", "Dragon"],
                ["Grass"] = ["Fire", "Grass", "Poison", "Flying", "Bug", "Dragon"],
                ["Normal"] = ["Rock"],
                ["Electric"] = ["Electric", "Grass", "Dragon"],
                ["Ice"] = ["Water", "Ice"],
                ["Fighting"] = ["Poison", "Flying", "Psychic", "Bug"],
                ["Poison"] = ["Poison", "Ground", "Rock", "Ghost"],
                ["Ground"] = ["Grass", "Bug"],
                ["Flying"] = ["Electric", "Rock"],
                ["Psychic"] = ["Psychic"],
                ["Bug"] = ["Fire", "Fighting", "Flying", "Ghost"],
                ["Rock"] = ["Fighting", "Ground"],
                ["Ghost"] = [],
                ["Dragon"] = []
            };

        private static readonly IReadOnlyDictionary<string, string[]> SuperEffectiveTypes =
            new Dictionary<string, string[]>(StringComparer.Ordinal)
            {
                ["Fire"] = ["Grass", "Ice", "Bug"],
                ["Water"] = ["Fire", "Ground", "Rock"],
                ["Grass"] = ["Water", "Ground", "Rock"],
                ["Normal"] = [],
                ["Electric"] = ["Water", "Flying"],
                ["Ice"] = ["Grass", "Ground", "Flying", "Dragon"],
                ["Fighting"] = ["Normal", "Ice", "Rock"],
                ["Poison"] = ["Grass", "Bug"],
                ["Ground"] = ["Fire", "Electric", "Poison", "Rock"],
                ["Flying"] = ["Grass", "Fighting", "Bug"],
                ["Psychic"] = ["Fighting", "Poison"],
                ["Bug"] = ["Grass", "Psychic", "Poison"],
                ["Rock"] = ["Fire", "Ice", "Flying", "Bug"],
                ["Ghost"] = ["Ghost"],
                ["Dragon"] = ["Dragon"]
            };

        private static readonly IReadOnlyDictionary<string, string[]> ImmuneTypes =
            new Dictionary<string, string[]>(StringComparer.Ordinal)
            {
                ["Normal"] = ["Ghost"],
                ["Electric"] = ["Ground"],
                ["Fighting"] = ["Ghost"],
                ["Ground"] = ["Flying"],
                ["Ghost"] = ["Normal", "Psychic"]
            };

        private string name = string.Empty;
        private List<Element> weaknesses = new();
        private List<Element> strengths = new();
        private List<Element> immunities = new();

        public string getName() { return name; }

        public void setName(string name)
        {
            this.name = name;
            weaknesses = setWeaknesses(name);
            strengths = setStrengths(name);
            immunities = setImmunities(name);
        }

        public Element(string typeName)
        {
            setName(typeName);
        }

        private Element (string typeName, bool initializeMatchups)
        {
            name = typeName;
            if (!initializeMatchups)
                return;

            weaknesses = setWeaknesses(typeName);
            strengths = setStrengths(typeName);
            immunities = setImmunities(typeName);
        }

        public List<Element> setWeaknesses(string typeName)
        {
            return CreateTypes(ResistedTypes, typeName);
        }

        public List<Element> setStrengths(string typeName)
        {
            return CreateTypes(SuperEffectiveTypes, typeName);
        }

        public List<Element> setImmunities(string typeName)
        {
            return CreateTypes(ImmuneTypes, typeName);
        }

        public List<Element> getWeaknesses() { return weaknesses; }
        public List<Element> getStrengths() { return strengths; }
        public List<Element> getImmunities() { return immunities; }

        public double calculateEffectiveness(Element targetType)
        {
            if (ContainsType(immunities, targetType.name))
                return 0;
            if (ContainsType(strengths, targetType.name))
                return 2;
            if (ContainsType(weaknesses, targetType.name))
                return 0.5;
            return 1;
        }

        public bool Equals(Element? other)
        {
            return other != null && name == other.name;
        }

        public override bool Equals(object? obj)
        {
            return obj is Element other && Equals(other);
        }

        public override int GetHashCode()
        {
            return StringComparer.Ordinal.GetHashCode(name);
        }

        private static List<Element> CreateTypes(IReadOnlyDictionary<string, string[]> chart, string typeName)
        {
            if (!chart.TryGetValue(typeName, out string[]? matchups))
                return new List<Element>();

            return matchups.Select(name => new Element(name, false)).ToList();
        }

        private static bool ContainsType(IEnumerable<Element> types, string typeName)
        {
            return types.Any(type => type.name == typeName);
        }
    }
}
