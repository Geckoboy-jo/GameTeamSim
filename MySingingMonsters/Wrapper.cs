using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq; 
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySingingMonsters
{
    internal class Wrapper
    {
        private sealed record MonsterOption(Type Type, string[] Elements, bool IsNatural, bool IsEthereal);
        private readonly record struct MonsterFilterKey(
            string ContainsElement,
            bool NaturalOnly,
            bool EtherealOnly,
            int RequiredElementCount,
            string AllowedElements);

        private static readonly MonsterOption[] MonsterOptions = typeof(Monster).Assembly.GetTypes()
            .Where(type => type.IsClass && !type.IsAbstract &&
                typeof(Monster).IsAssignableFrom(type) &&
                type.GetConstructor(new[] { typeof(int) }) is not null)
            .Select(type =>
            {
                var monster = (Monster)Activator.CreateInstance(type, 20)!;
                return new MonsterOption(
                    type,
                    monster.elems.Select(element => element.name).ToArray(),
                    monster.elems.All(element => !element.isEtherial),
                    monster.elems.All(element => element.isEtherial));
            })
            .ToArray();
        private static readonly ConcurrentDictionary<MonsterFilterKey, MonsterOption[]> MonsterOptionsByFilter = new();

        public Team Player;
        public Team Opononent;
        public Wrapper()
        {
            Player = new Team(new List<Monster> { new Spunge(17), new Thumpies(17) });  
            Opononent = new Team(new List<Monster> { new Mammot(20), new PotBelly(20), new Thumpies(18) });
            
        }


        public Wrapper(List<Monster> playerMonsters, List<Monster> opponentMonsters)
        {
            Player = new Team(playerMonsters);
            Opononent = new Team(opponentMonsters);
        }

        public bool game()
        {
            foreach (Monster monster in Player.Monsters)
            {
                monster.HP = monster.baseHp;
            }
            foreach (Monster monster in Opononent.Monsters)
            {
                monster.HP = monster.baseHp;
            }
            while (Player.lost == false && Opononent.lost == false)
            {
                turn(Player, Opononent);
                if (Opononent.lost == true) break;
                turn(Opononent, Player);
            }
            return Player.lost ? false : true;
        }
        public void turn(Team O, Team D)
        {
            float maxDamage = 0;
            Monster? bestMonster = null;
            foreach (Monster monster in O.Monsters)
            {   
                if(monster.isAlive == false) continue;
                foreach (Attack attack in monster.attacks)
                {
                    float damage = calculateDamage(monster, attack, D.Active);
                    if(damage > maxDamage)
                    {
                        maxDamage = damage;
                        bestMonster = monster;
                    }
                }
            }
            if (bestMonster is null)
            {
                O.lost = true;
                return;
            }
            O.Active = bestMonster;
            D.Active.takeDamage(maxDamage);
            if (D.Active.isAlive == false) 
            {
                foreach (Monster monster in D.Monsters)
                {
                    if(monster.isAlive == true)
                    {
                        D.Active = monster;
                        return;
                    }
                }
                D.lost = true;
            } 
        }
        public float calculateDamage(Monster O, Attack A, Monster D)
        {
            float multiplier = 1;
            foreach (Element element in D.elems)
            {
                if (A.type.name == element.weakTo)
                {
                    if (D.elems.Count == 1) multiplier = multiplier * 2;
                    else if (D.elems.Count == 2) multiplier = multiplier * 1.5f;
                    else if (D.elems.Count == 3) multiplier = multiplier * 1.33f;
                    else if (D.elems.Count == 4) multiplier = multiplier * 1.25f;
                }
                if(A.type.weakTo == element.name)
                {
                    if (D.elems.Count == 1) multiplier = multiplier * 0.5f;
                    else if (D.elems.Count == 2) multiplier = multiplier * 0.66f;
                    else if (D.elems.Count == 3) multiplier = multiplier * 0.75f;
                    else if (D.elems.Count == 4) multiplier = multiplier * 0.8f;
                }
                A.timesUsed++;
                
            }
            float damage =  multiplier * O.Attack * A.basePower;
            if(A.type.isEtherial == true)
            {
                O.heal(calculateHealing(A, damage));
            }
            return damage;
        }
        public float calculateHealing(Attack A, float damage)
        {
            if(A.timesUsed == 1)
            {
                return damage * 0.75f; // Example: 10% of the damage dealt as healing
            }
            else if(A.timesUsed == 2)
            {
                return damage * 0.6f; // Example: 5% of the damage dealt as healing
            }
            else if(A.timesUsed == 3)
            {
                return damage * 0.45f; // Example: 5% of the damage dealt as healing
            }
            else if(A.timesUsed == 4)
            {
                return damage * 0.3f; // Example: 5% of the damage dealt as healing
            }
            else if(A.timesUsed == 5)
                return damage * 0.15f; // No healing for subsequent uses
            else 
            {
                return 0; // No healing for subsequent uses
            }
        }
        public Monster getRandomMonster(int level)
        {
            return getRandomMonster(level, new Element("None"), false, false, 0);
        }

        public Monster getRandomMonster(
            Element contains,
            bool natOnly,
            bool ethOnly,
            int requiredElementCount = 0,
            IReadOnlyCollection<string>? allowedElements = null,
            int? level = null)
        {
            return getRandomMonster(level ?? Player.Active.level, contains, natOnly, ethOnly, requiredElementCount, allowedElements);
        }

        private static Monster getRandomMonster(
            int level,
            Element contains,
            bool natOnly,
            bool ethOnly,
            int requiredElementCount,
            IReadOnlyCollection<string>? allowedElements = null)
        {
            ArgumentNullException.ThrowIfNull(contains);

            string normalizedAllowedElements = allowedElements is null
                ? string.Empty
                : string.Join("\u001f", allowedElements
                    .Select(element => element.ToUpperInvariant())
                    .OrderBy(element => element, StringComparer.Ordinal));
            var filterKey = new MonsterFilterKey(
                contains.name.ToUpperInvariant(),
                natOnly,
                ethOnly,
                requiredElementCount,
                normalizedAllowedElements);
            MonsterOption[] candidates = MonsterOptionsByFilter.GetOrAdd(filterKey, _ =>
            {
                MonsterOption[] filtered = MonsterOptions
                    .Where(option =>
                        (!natOnly || option.IsNatural) &&
                        (!ethOnly || option.IsEthereal) &&
                        (requiredElementCount == 0 || option.Elements.Length == requiredElementCount) &&
                        (allowedElements is null || allowedElements.All(allowed =>
                            option.Elements.Contains(allowed, StringComparer.OrdinalIgnoreCase))))
                    .ToArray();

                if (!string.Equals(contains.name, "None", StringComparison.OrdinalIgnoreCase))
                {
                    MonsterOption[] matchingElement = filtered
                        .Where(option => option.Elements.Contains(contains.name, StringComparer.OrdinalIgnoreCase))
                        .ToArray();
                    if (matchingElement.Length > 0)
                    {
                        filtered = matchingElement;
                    }
                }

                return filtered;
            });

            if (candidates.Length == 0)
            {
                throw new InvalidOperationException("No monsters match the requested category and element-count filters.");
            }

            MonsterOption selected = candidates[Random.Shared.Next(candidates.Length)];
            return (Monster)Activator.CreateInstance(selected.Type, level)!;
        }
    }
}
