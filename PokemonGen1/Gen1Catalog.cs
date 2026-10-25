using System.Reflection;
using System.Text.Json;

namespace PokemonGen1
{
    public static partial class Gen1Catalog
    {
        private static readonly CatalogData Catalog = LoadCatalog();
        private static readonly IReadOnlyDictionary<string, Gen1SpeciesData> SpeciesByName =
            Catalog.Species.ToDictionary(species => Normalize(species.Name));
        private static readonly IReadOnlyDictionary<int, Gen1SpeciesData> SpeciesByDexNumber =
            Catalog.Species.ToDictionary(species => species.DexNumber);
        private static readonly IReadOnlyDictionary<string, Gen1MoveData> MovesByName =
            Catalog.Moves.ToDictionary(move => Normalize(move.Name));

        static Gen1Catalog()
        {
            if (Catalog.Species.Count != 151 || Catalog.Moves.Count != 165)
                throw new InvalidDataException("The Red/Blue catalog must contain all 151 species and 165 moves.");

            foreach (Gen1SpeciesData species in Catalog.Species)
            {
                if (species.DexNumber is < 1 or > 151 || species.Types.Length is < 1 or > 2)
                    throw new InvalidDataException($"Invalid species data for '{species.Name}'.");

                foreach (string moveName in species.InitialMoves
                    .Concat(species.LevelUpMoves.Select(move => move.Move))
                    .Concat(species.TmHmMoves))
                {
                    if (!MovesByName.ContainsKey(Normalize(moveName)))
                        throw new InvalidDataException($"Unknown move '{moveName}' in {species.Name}'s learnset.");
                }
            }
        }

        public static IReadOnlyList<Gen1SpeciesData> Species => Catalog.Species;
        public static IReadOnlyList<Gen1MoveData> Moves => Catalog.Moves;

        public static Gen1SpeciesData GetSpecies(string name)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            string key = Normalize(name);
            if (name.EndsWith("♀", StringComparison.Ordinal) || key == "NIDORANFEMALE")
                key = "NIDORANF";
            else if (name.EndsWith("♂", StringComparison.Ordinal) || key == "NIDORANMALE")
                key = "NIDORANM";

            if (SpeciesByName.TryGetValue(key, out Gen1SpeciesData? species))
                return species;

            throw new KeyNotFoundException($"Generation I species '{name}' was not found.");
        }

        public static Gen1SpeciesData GetSpecies(int dexNumber)
        {
            if (SpeciesByDexNumber.TryGetValue(dexNumber, out Gen1SpeciesData? species))
                return species;

            throw new KeyNotFoundException($"Generation I Pokédex number {dexNumber} was not found.");
        }

        public static Gen1MoveData GetMove(string name)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            if (MovesByName.TryGetValue(Normalize(name), out Gen1MoveData? move))
                return move;

            throw new KeyNotFoundException($"Generation I move '{name}' was not found.");
        }

        public static Pokemon CreatePokemon(string speciesName, int level)
        {
            return Gen1PokemonFactory.Create(GetSpecies(speciesName), level);
        }

        public static Pokemon CreatePokemon(int dexNumber, int level)
        {
            return Gen1PokemonFactory.Create(GetSpecies(dexNumber), level);
        }

        public static Move CreateMove(string moveName)
        {
            return Gen1MoveFactory.Create(GetMove(moveName));
        }

        public static IReadOnlyList<Gen1MoveData> GetAvailableMoves(string speciesName, int level)
        {
            if (level is < 1 or > 100)
                throw new ArgumentOutOfRangeException(nameof(level), "Level must be between 1 and 100.");

            Gen1SpeciesData species = GetSpecies(speciesName);
            var available = new List<Gen1MoveData>();
            var moveNames = new HashSet<string>(StringComparer.Ordinal);

            void AddMove(string name)
            {
                Gen1MoveData move = GetMove(name);
                if (moveNames.Add(Normalize(move.Name)))
                    available.Add(move);
            }

            foreach (string move in species.InitialMoves)
                AddMove(move);
            foreach (Gen1LevelUpMove move in species.LevelUpMoves)
            {
                if (move.Level <= level)
                    AddMove(move.Move);
            }
            foreach (string move in species.TmHmMoves)
                AddMove(move);

            return available.AsReadOnly();
        }

        private static CatalogData LoadCatalog()
        {
            Assembly assembly = typeof(Gen1Catalog).Assembly;
            using Stream stream = assembly.GetManifestResourceStream("PokemonGen1.gen1-red-blue.json")
                ?? throw new InvalidOperationException("The embedded Generation I catalog resource is missing.");

            return JsonSerializer.Deserialize<CatalogData>(stream, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? throw new InvalidOperationException("The Generation I catalog resource is invalid.");
        }

        private static string Normalize(string value)
        {
            return new string(value.Where(char.IsLetterOrDigit).Select(char.ToUpperInvariant).ToArray());
        }

        private sealed class CatalogData
        {
            public List<Gen1SpeciesData> Species { get; init; } = new();
            public List<Gen1MoveData> Moves { get; init; } = new();
        }
    }

    public sealed class Gen1SpeciesData
    {
        public int DexNumber { get; init; }
        public string Name { get; init; } = string.Empty;
        public string[] Types { get; init; } = Array.Empty<string>();
        public Gen1BaseStats BaseStats { get; init; } = new();
        public string[] InitialMoves { get; init; } = Array.Empty<string>();
        public Gen1LevelUpMove[] LevelUpMoves { get; init; } = Array.Empty<Gen1LevelUpMove>();
        public string[] TmHmMoves { get; init; } = Array.Empty<string>();
    }

    public sealed class Gen1BaseStats
    {
        public int Hp { get; init; }
        public int Attack { get; init; }
        public int Defense { get; init; }
        public int Speed { get; init; }
        public int Special { get; init; }
    }

    public sealed class Gen1LevelUpMove
    {
        public int Level { get; init; }
        public string Move { get; init; } = string.Empty;
    }

    public sealed class Gen1MoveData
    {
        public string Name { get; init; } = string.Empty;
        public int Power { get; init; }
        public string Type { get; init; } = string.Empty;
        public int Accuracy { get; init; }
        public int Pp { get; init; }
        public string Effect { get; init; } = string.Empty;
    }
}
