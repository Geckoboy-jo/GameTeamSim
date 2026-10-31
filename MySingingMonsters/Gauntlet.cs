using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MySingingMonsters
{
    internal class Gauntlet
    {
        private readonly record struct TeamCombination(int First, int Second, int Third, int Count);

        public Team PlayerTeam;
       
        public Element contains;
        public int maxMonsters;
        public int bedContains;
        public int maxBeds;
        public int requiredNumElements;
        public int Iterations { get; set; } = 100000;
        public int PlayerLevelCap { get; set; } = 20;
        public int OpponentLevelCap { get; set; } = 20;
        public bool natOnly;
        public bool ethOnly;
        private Monster? mustContain;
        public HashSet<string>? allowedElements;
        public Wrapper wrapper;
        public Gauntlet(Team player, Wrapper game)
        {
            PlayerTeam = player;
            contains = new Element("None");
            maxMonsters = 3;
            bedContains = 0;
            maxBeds = 20;
            requiredNumElements = 0;
            natOnly = false;
            ethOnly = false;
            wrapper = game;
        }

        public Monster? getMustContain(){return mustContain;}
        public void setMustContain(Monster? monster){mustContain = monster;}
        public string runGauntlet()
        {
            int wins = 0;
            int losses = 0;
            var opponentsThatWon = new List<Monster>();

            if (Iterations < 1)
            {
                throw new InvalidOperationException("A gauntlet must run at least one fight.");
            }

            if (maxMonsters < 1 || maxBeds < 1)
            {
                throw new InvalidOperationException("A gauntlet needs room for at least one opponent monster.");
            }

            if (mustContain is not null &&
                !PlayerTeam.Monsters.Any(monster => monster.GetType() == mustContain.GetType()))
            {
                throw new InvalidOperationException($"Your team must contain a {mustContain.GetType().Name} for this gauntlet.");
            }

            for (int i = 0; i < Iterations; i++)
            {
                wrapper.Player = CreateFreshPlayerTeam();
                List<Monster> enemyMonsters = CreateOpponentTeam();
                wrapper.Opononent = new Team(enemyMonsters);

                if (wrapper.game())
                {
                    wins++;
                }
                else
                {
                    losses++;
                    opponentsThatWon.AddRange(enemyMonsters.Where(monster => monster.isAlive));
                }
            }

            var top3Opponents = opponentsThatWon
                .GroupBy(monster => monster.GetType())
                .OrderByDescending(group => group.Count())
                .Take(3)
                .Select(group => group.Key);

            return $"You won {wins} times and lost {losses} times. The most common monsters you lost to were: {string.Join(", ", top3Opponents)}";
        }

        private Team CreateFreshPlayerTeam()
        {
            List<Monster> monsters = PlayerTeam.Monsters
                .Select(monster => (Monster)Activator.CreateInstance(
                    monster.GetType(), Math.Min(monster.level, PlayerLevelCap))!)
                .ToList();
            return new Team(monsters);
        }

        private List<Monster> CreateOpponentTeam()
        {
            var monsters = new List<Monster>();
            int bedsUsed = 0;

            if (mustContain is not null)
            {
                Monster requiredMonster = (Monster)Activator.CreateInstance(mustContain.GetType(), OpponentLevelCap)!;
                int requiredBeds = CalculateBeds(requiredMonster);
                if (requiredBeds > maxBeds)
                {
                    throw new InvalidOperationException(
                        $"The must-contain monster needs {requiredBeds} beds, which exceeds the {maxBeds} bed limit.");
                }

                monsters.Add(requiredMonster);
                bedsUsed += requiredBeds;
            }

            while (monsters.Count < maxMonsters && bedsUsed < maxBeds)
            {
                bool addedMonster = false;
                for (int attempt = 0; attempt < 100; attempt++)
                {
                    Monster monster = wrapper.getRandomMonster(
                        contains, natOnly, ethOnly, requiredNumElements, allowedElements, OpponentLevelCap);
                    int monsterBeds = CalculateBeds(monster);
                    if (bedsUsed + monsterBeds <= maxBeds)
                    {
                        monsters.Add(monster);
                        bedsUsed += monsterBeds;
                        addedMonster = true;
                        break;
                    }
                }

                if (!addedMonster)
                {
                    throw new InvalidOperationException("Failed to create a valid opponent team within the bed constraints.");
                }
            }

            if (monsters.Count == 0)
            {
                throw new InvalidOperationException("The selected gauntlet rules do not allow any opponent monsters.");
            }

            return monsters;
        }

        public int calculateBeds()
        {
            return PlayerTeam.Monsters.Sum(CalculateBeds);
        }

        public (List<List<Type>> Teams, int WavesCleared, long TeamsEvaluated) CalculateBestTeam(
            int teamMaxBeds,
            int maxTeamMonsters,
            bool allowDuplicates,
            IProgress<string>? progress = null)
        {
            const int maximumWaves = 200000;
            const int maximumLosses = 10;

            if (teamMaxBeds < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(teamMaxBeds), "Team bed capacity must be at least one.");
            }

            if (maxTeamMonsters < 1 || maxTeamMonsters > 3)
            {
                throw new ArgumentOutOfRangeException(nameof(maxTeamMonsters), "Team size must be between one and three monsters.");
            }

            Type[] monsterTypes = typeof(Monster).Assembly.GetTypes()
                .Where(type => type.IsClass && !type.IsAbstract &&
                    typeof(Monster).IsAssignableFrom(type) &&
                    type.GetConstructor(new[] { typeof(int) }) is not null)
                .ToArray();

            var candidates = monsterTypes
                .Select(type =>
                {
                    var monster = (Monster)Activator.CreateInstance(type, PlayerLevelCap)!;
                    return (Type: type, Monster: monster, Beds: CalculateBeds(monster), Species: GetBaseSpeciesName(type));
                })
                .Where(candidate => candidate.Beds <= teamMaxBeds && IsAllowedForTeam(candidate.Monster))
                .ToArray();

            if (candidates.Length == 0)
            {
                throw new InvalidOperationException("No monsters satisfy the selected team restrictions and bed limit.");
            }

            Type? mustContainType = mustContain?.GetType();
            if (mustContainType is not null && !candidates.Any(candidate => candidate.Type == mustContainType))
            {
                throw new InvalidOperationException("The must-contain monster does not satisfy the selected team restrictions and bed limit.");
            }

            List<Type> selectedTypes = new();
            List<int> selectedCandidateIndices = new();
            var selectedSpecies = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var evaluatedCombinations = new HashSet<TeamCombination>();
            var bestTeams = new List<List<Type>>();
            int bestWaves = -1;
            long teamsEvaluated = 0;

            TeamCombination CreateCombinationKey()
            {
                int first = selectedCandidateIndices[0];
                int second = selectedCandidateIndices.Count > 1 ? selectedCandidateIndices[1] : 0;
                int third = selectedCandidateIndices.Count > 2 ? selectedCandidateIndices[2] : 0;

                if (second < first)
                {
                    (first, second) = (second, first);
                }

                if (third < second)
                {
                    (second, third) = (third, second);
                }

                if (second < first)
                {
                    (first, second) = (second, first);
                }

                return new TeamCombination(first, second, third, selectedCandidateIndices.Count);
            }

            void SearchCombinations(int startIndex, int bedsUsed)
            {
                if (selectedTypes.Count > 0 &&
                    (mustContainType is null || selectedTypes.Contains(mustContainType)) &&
                    evaluatedCombinations.Add(CreateCombinationKey()))
                {
                    int waves = EvaluateTeam(selectedTypes, maximumWaves, maximumLosses);
                    teamsEvaluated++;
                    if (waves > bestWaves)
                    {
                        bestWaves = waves;
                        bestTeams.Clear();
                    }

                    if (waves == bestWaves)
                    {
                        bestTeams.Add(selectedTypes.ToList());
                    }

                    if (teamsEvaluated % 100 == 0)
                    {
                        progress?.Report($"Evaluated {teamsEvaluated:N0} teams; best result: {bestWaves:N0} waves.");
                    }
                }

                if (selectedTypes.Count == maxTeamMonsters)
                {
                    return;
                }

                for (int index = startIndex; index < candidates.Length; index++)
                {
                    var candidate = candidates[index];
                    if (!allowDuplicates && selectedSpecies.Contains(candidate.Species))
                    {
                        continue;
                    }

                    int nextBeds = bedsUsed + candidate.Beds;
                    if (nextBeds > teamMaxBeds)
                    {
                        continue;
                    }

                    selectedTypes.Add(candidate.Type);
                    selectedCandidateIndices.Add(index);
                    bool addedSpecies = selectedSpecies.Add(candidate.Species);
                    SearchCombinations(allowDuplicates ? index : index + 1, nextBeds);
                    selectedTypes.RemoveAt(selectedTypes.Count - 1);
                    selectedCandidateIndices.RemoveAt(selectedCandidateIndices.Count - 1);
                    if (addedSpecies)
                    {
                        selectedSpecies.Remove(candidate.Species);
                    }
                }
            }

            SearchCombinations(0, 0);
            if (bestTeams.Count == 0)
            {
                throw new InvalidOperationException("No eligible teams could be evaluated.");
            }

            return (bestTeams, bestWaves, teamsEvaluated);
        }

        private static string GetBaseSpeciesName(Type monsterType)
        {
            string[] baseSpeciesNames =
            {
                "Arackulele", "Bellowfish", "Blabbit", "Boodoo", "Bowgart", "Clamble", "Congle",
                "Cybop", "Dandidoo", "Deedge", "Dragong", "Drumpler", "Entbrat", "FungPray",
                "Furcorn", "Fwog", "Ghazt", "Grumpyre", "Hoola", "Humbug", "Jeeode", "Jellbilly",
                "Kazilleon", "Mammot", "Maw", "Nebulob", "Noggin", "Oaktopus", "Pango", "PomPom",
                "PotBelly", "Pummel", "Punkleton", "Quarrister", "Quibble", "Reedling", "Reebro",
                "Riff", "Scups", "Shellbeat", "Schmoochle", "Shrubb", "Sox", "Spunge", "Thumpies",
                "ToeJammer", "TRox", "Tweedle", "Whisp", "Yool"
            };

            return baseSpeciesNames
                .Where(name => monsterType.Name.StartsWith(name, StringComparison.Ordinal))
                .OrderByDescending(name => name.Length)
                .FirstOrDefault() ?? monsterType.Name;
        }

        private bool IsAllowedForTeam(Monster monster)
        {
            bool matchesElement = string.Equals(contains.name, "None", StringComparison.OrdinalIgnoreCase) ||
                monster.elems.Any(element => string.Equals(element.name, contains.name, StringComparison.OrdinalIgnoreCase));
            bool matchesCategory = (!natOnly || monster.elems.All(element => !element.isEtherial)) &&
                (!ethOnly || monster.elems.All(element => element.isEtherial));
            bool matchesAllowedElements = allowedElements is null || allowedElements.All(allowed =>
                monster.elems.Any(element => string.Equals(element.name, allowed, StringComparison.OrdinalIgnoreCase)));
            return matchesElement && matchesCategory && matchesAllowedElements;
        }

        private int EvaluateTeam(IReadOnlyList<Type> monsterTypes, int maximumWaves, int maximumLosses)
        {
            int wins = 0;
            int losses = 0;

            for (int wave = 0; wave < maximumWaves && losses <= maximumLosses; wave++)
            {
                wrapper.Player = new Team(monsterTypes
                    .Select(type => (Monster)Activator.CreateInstance(type, PlayerLevelCap)!)
                    .ToList());
                wrapper.Opononent = new Team(CreateOpponentTeam());
                if (wrapper.game())
                {
                    wins++;
                }
                else
                {
                    losses++;
                }
            }

            return wins;
        }

        private static int CalculateBeds(Monster monster)
        {
            int beds = monster.elems.Count;
            if (monster.elems.Any(element => string.Equals(element.name, "Seasonal", StringComparison.OrdinalIgnoreCase)))
            {
                beds++;
            }

            beds += monster.elems.Count(element => element.isEtherial) * 4;
            return beds;
        }
    }
}
