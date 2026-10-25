namespace PokemonGen1
{
    public class Gen1Pokemon : Pokemon
    {
        public Gen1SpeciesData Species { get; }

        public Gen1Pokemon(string speciesName, int level)
            : this(Gen1Catalog.GetSpecies(speciesName), level)
        {
        }

        internal Gen1Pokemon(Gen1SpeciesData species, int level)
        {
            Species = species;
            Initialize(species, level);
        }

        private void Initialize(Gen1SpeciesData species, int level)
        {
            if (level is < 1 or > 100)
                throw new ArgumentOutOfRangeException(nameof(level), "Level must be between 1 and 100.");

            setName(species.Name);
            setLevel(level);
            setTypes(species.Types.Select(type => new Type(type)).ToList());
            setBaseHp(species.BaseStats.Hp);
            setBaseAttack(species.BaseStats.Attack);
            setBaseDefense(species.BaseStats.Defense);
            setBaseSpeed(species.BaseStats.Speed);
            setBaseSpecial(species.BaseStats.Special);
            setMoves(Gen1Catalog.GetAvailableMoves(species.Name, level)
                .Select(move => Gen1Catalog.CreateMove(move.Name))
                .ToList());
            setStats();
            setCurrentHp(getMaxHp());
        }
    }
}
