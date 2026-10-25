namespace PokemonGen1
{
    public class Type : IEquatable<Type>
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
        private List<Type> weaknesses = new();
        private List<Type> strengths = new();
        private List<Type> immunities = new();

        public string getName() { return name; }

        public void setName(string name)
        {
            this.name = name;
            weaknesses = setWeaknesses(name);
            strengths = setStrengths(name);
            immunities = setImmunities(name);
        }

        public Type(string typeName)
        {
            setName(typeName);
        }

        private Type(string typeName, bool initializeMatchups)
        {
            name = typeName;
            if (!initializeMatchups)
                return;

            weaknesses = setWeaknesses(typeName);
            strengths = setStrengths(typeName);
            immunities = setImmunities(typeName);
        }

        public List<Type> setWeaknesses(string typeName)
        {
            return CreateTypes(ResistedTypes, typeName);
        }

        public List<Type> setStrengths(string typeName)
        {
            return CreateTypes(SuperEffectiveTypes, typeName);
        }

        public List<Type> setImmunities(string typeName)
        {
            return CreateTypes(ImmuneTypes, typeName);
        }

        public List<Type> getWeaknesses() { return weaknesses; }
        public List<Type> getStrengths() { return strengths; }
        public List<Type> getImmunities() { return immunities; }

        public double calculateEffectiveness(Type targetType)
        {
            if (ContainsType(immunities, targetType.name))
                return 0;
            if (ContainsType(strengths, targetType.name))
                return 2;
            if (ContainsType(weaknesses, targetType.name))
                return 0.5;
            return 1;
        }

        public bool Equals(Type? other)
        {
            return other != null && name == other.name;
        }

        public override bool Equals(object? obj)
        {
            return obj is Type other && Equals(other);
        }

        public override int GetHashCode()
        {
            return StringComparer.Ordinal.GetHashCode(name);
        }

        private static List<Type> CreateTypes(IReadOnlyDictionary<string, string[]> chart, string typeName)
        {
            if (!chart.TryGetValue(typeName, out string[]? matchups))
                return new List<Type>();

            return matchups.Select(name => new Type(name, false)).ToList();
        }

        private static bool ContainsType(IEnumerable<Type> types, string typeName)
        {
            return types.Any(type => type.name == typeName);
        }
    }
}
